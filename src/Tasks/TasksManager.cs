using System;
using System.Collections.Generic;
using System.Linq;
using Adeotek.DevToolbox.Models;
using Microsoft.Extensions.Logging;

namespace Adeotek.DevToolbox.Tasks
{
    public class TasksManager
    {
        private readonly WindowsActionsExecutor _windowsActionsExecutor;
        private readonly ILogger<TasksManager> _logger;

        public TasksManager(WindowsActionsExecutor windowsActionsExecutor, ILogger<TasksManager> logger)
        {
            _windowsActionsExecutor = windowsActionsExecutor;
            _logger = logger;
        }

        public void ExecuteTasks(IEnumerable<AppTask> tasks, bool stopOnFailure = false)
        {
            if (tasks == null)
            {
                throw new ArgumentNullException(nameof(tasks));
            }

            var appTasks = tasks.ToList();
            if (appTasks.Count == 0)
            {
                return;
            }

            foreach (var task in appTasks)
            {
                try
                {
                    ExecuteTask(task);
                }
                catch (ApplicationAlreadyRunningException are)
                {
                    _logger.LogWarning(are, "Task {Name} [{Guid}] skipped: {Message}", task.Name, task.Guid.ToString(), are.Message);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Task {Name} [{Guid}] exception: {Message}", task.Name, task.Guid.ToString(), e.Message);
                    if (stopOnFailure)
                    {
                        throw;
                    }
                }
            }
        }

        public void ExecuteTask(AppTask task)
        {
            if (!(task?.IsActive ?? false))
            {
                return;
            }

            switch (task.TypeAsEnum)
            {
                case TaskTypes.StartApp:
                    _windowsActionsExecutor.LaunchApp(task);
                    break;
                case TaskTypes.StartWsl2:
                    _windowsActionsExecutor.StartWsl2(task);
                    break;
                case TaskTypes.ManageService:
                    _windowsActionsExecutor.ManageService(task);
                    break;
                case TaskTypes.Custom:
                    ExecuteCustomTask(task);
                    break;
                case TaskTypes.Undefined:
                    throw new Exception($"Invalid task type: {task.Type}");
            }
            
            _logger.LogInformation("Task {Name} [{Guid}] executed successfully", task.Name, task.Guid.ToString());
        }

        public void ExecuteCustomTask(AppTask task)
        {
            if (!(task?.IsActive ?? false))
            {
                return;
            }
            
            if (task.Arguments == null)
            {
                throw new ArgumentNullException("Task.Arguments");
            }

            var command = task.Arguments.ContainsKey("Command") ? task.Arguments["Command"] : null;
            var arguments = task.Arguments.ContainsKey("Arguments") && !string.IsNullOrEmpty(task.Arguments["Arguments"]) ? task.Arguments["Arguments"] : null;
            _windowsActionsExecutor.ExecuteCommand(command, arguments);
            _logger.LogInformation("Command {Command} with args {Arguments} executed", command, arguments);
        }
    }
}