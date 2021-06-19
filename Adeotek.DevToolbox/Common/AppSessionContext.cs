using System;
using System.Collections.Generic;
using System.Linq;
using Adeotek.DevToolbox.Models.Events;
using Adeotek.DevToolbox.Models;
using Adeotek.DevToolbox.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Adeotek.DevToolbox.Common
{
    public class AppSessionContext
    {
        private bool _sessionEndedHandled;
        private bool _sessionStartedHandled;
        private AppConfiguration _appConfiguration;
        private readonly IConfiguration _configuration;
        private readonly EventsAggregator _eventsAggregator;
        private readonly TasksManager _tasksManager;
        private readonly ILogger<AppSessionContext> _logger;

        public AppSessionContext(
            IConfiguration configuration,
            EventsAggregator eventsAggregator,
            TasksManager tasksManager,
            ILogger<AppSessionContext> logger)
        {
            _configuration = configuration;
            _eventsAggregator = eventsAggregator ?? throw new ArgumentNullException(nameof(eventsAggregator));
            _logger = logger;
            _eventsAggregator.OnRunAction += OnRunActionHandle;
            _eventsAggregator.OnWindowsSessionSwitch += OnWindowsSessionSwitchHandle;
            _tasksManager = tasksManager;
            AppPath = AppDomain.CurrentDomain.BaseDirectory;
            _logger.LogInformation("Load app context...");
            LoadAppConfiguration();
        }

        public string AppPath { get; }
        public bool DebugMode => _appConfiguration?.Debug ?? false;
        public bool RunDefaultScenarioOnStartup => _appConfiguration?.RunDefaultScenarioOnStartup ?? false;
        public bool AutoOpenMonitor => _appConfiguration?.AutoOpenMonitor ?? false;
        public Guid DefaultScenario => _appConfiguration?.DefaultScenario ?? Guid.Empty;
        public IEnumerable<Scenario> Scenarios => _appConfiguration?.Scenarios ?? new List<Scenario>();
        public IEnumerable<AppTask> Tasks => _appConfiguration?.Tasks ?? new List<AppTask>();
        
        public void ExecuteTask(Guid taskGuid)
        {
            AppTask task = null;
            try
            {
                task = Tasks.FirstOrDefault(t => t.Guid == taskGuid && taskGuid != Guid.Empty);
                if (task is not {IsActive: true})
                {
                    _logger.LogWarning("AppSessionContext.ExecuteTask invalid or inactive task");
                    return;
                }
                
                _tasksManager.ExecuteTask(task);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "AppSessionContext.ExecuteTask [{Task}] exception: {Message}", task?.Name ?? taskGuid.ToString(), e.Message);
            }
        }
        
        public void ExecuteScenario(Guid scenarioGuid, bool stopOnFailure = false)
        {
            Scenario scenario = null;
            try
            {
                scenario = Scenarios.FirstOrDefault(s => s.Guid == scenarioGuid && scenarioGuid != Guid.Empty);
                if (scenario is not {IsActive: true} || scenario.Tasks.Count == 0)
                {
                    _logger.LogWarning("AppSessionContext.ExecuteTask invalid or inactive scenario");
                    return;
                }
                
                var tasks = (from t in Tasks
                    join s in scenario.Tasks on t.Guid equals s
                    where t.IsActive
                    select t).ToList();
                
                if (!tasks.Any())
                {
                    _logger.LogWarning("AppSessionContext.ExecuteScenario: no active tasks in scenario {Scenario}", scenario.Name);
                    return;
                }
                
                _tasksManager.ExecuteTasks(tasks, stopOnFailure);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "AppSessionContext.ExecuteScenario [{Scenario}] exception: {Message}", scenario?.Name ?? scenarioGuid.ToString(), e.Message);
            }
        }
        
        public void ExecuteDefaultScenario(bool stopOnFailure = false)
        {
            if (DefaultScenario == Guid.Empty)
            {
                _logger.LogWarning("AppSessionContext.ExecuteDefaultScenario no default scenario is defined");
                return;
            }

            Scenario scenario = null; 
            try
            {
                scenario = Scenarios.FirstOrDefault(s => s.IsActive && s.Guid == DefaultScenario);
                if (scenario is not {IsActive: true} || scenario.Tasks.Count == 0)
                {
                    _logger.LogWarning("AppSessionContext.ExecuteDefaultScenario no default scenario found");
                    return;
                }
                
                var tasks = (from t in Tasks
                    join s in scenario.Tasks on t.Guid equals s
                    where t.IsActive
                    select t).ToList();
                
                if (!tasks.Any())
                {
                    _logger.LogWarning("AppSessionContext.ExecuteDefaultScenario: no active tasks in scenario {Scenario}", scenario.Name);
                    return;
                }
                
                _tasksManager.ExecuteTasks(tasks, stopOnFailure);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "AppSessionContext.ExecuteDefaultScenario [{Scenario}] exception: {Message}", scenario?.Name ?? DefaultScenario.ToString(), e.Message);
            }
        }
        
        public void ExecuteAllTasks(bool stopOnFailure = false)
        {
            try
            {
                var tasks = Tasks.Where(t => t.IsActive).ToList();
                
                if (!tasks.Any())
                {
                    _logger.LogWarning("AppSessionContext.ExecuteAllTasks: no active tasks found");
                    return;
                }
                
                _tasksManager.ExecuteTasks(tasks, stopOnFailure);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "AppSessionContext.ExecuteAllTasks exception: {Message}", e.Message);
            }
        }

        public void LoadAppConfiguration(AppConfiguration newAppConfiguration = null)
        {
            if (newAppConfiguration != null)
            {
                _appConfiguration = newAppConfiguration;
            }
            else
            {
                _appConfiguration = _configuration.GetSection("Application").Get<AppConfiguration>();
                if (_appConfiguration == null)
                {
                    throw new Exception("Invalid or missing [Application] configuration section!");
                }
            }
        }

        private void OnRunActionHandle(RunActionEventArgs e)
        {
            switch (e.Type)
            {
                case RunActionTypes.Scenario:
                    if (e.Default)
                    {
                        ExecuteDefaultScenario();
                    }
                    else
                    {
                        ExecuteScenario(e.TargetGuid);
                    }
                    break;
                case RunActionTypes.Task:
                    if (e.All)
                    {
                        ExecuteAllTasks();
                    }
                    else
                    {
                        ExecuteTask(e.TargetGuid);
                    }
                    break;
                default:
                    _logger.LogWarning("AppSessionContext.OnRunActionHandle invalid RunActionEventArgs type");
                    break;
            }
        }

        private void OnWindowsSessionSwitchHandle(WindowsSessionSwitchEventArgs e)
        {
            _logger.LogDebug("WindowsSessionSwitchHandle triggered (reason: {Reason}, multi-instance: {IsMultiInstance})", e.Reason.ToString(), e.IsMultiInstance.ToString());
            switch (e.Reason)
            {
                case WindowsSessionSwitchReasons.ConsoleDisconnect:
                    _sessionStartedHandled = false;
                    if (_sessionEndedHandled)
                    {
                        _sessionEndedHandled = false;
                        return;
                    }
                    try
                    {
                        _sessionEndedHandled = true;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex,"WindowsSessionSwitchHandle exception (reason: {Reason}, multi-instance: {IsMultiInstance})", e.Reason.ToString(), e.IsMultiInstance.ToString());
                    }
                    break;
                case WindowsSessionSwitchReasons.ConsoleConnect:
                    _sessionEndedHandled = false;
                    if (_sessionStartedHandled)
                    {
                        _sessionStartedHandled = false;
                        return;
                    }
                    try
                    {
                        LoadAppConfiguration();
                        _sessionStartedHandled = true;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex,"WindowsSessionSwitchHandle exception (reason: {Reason}, multi-instance: {IsMultiInstance})", e.Reason.ToString(), e.IsMultiInstance.ToString());
                    }
                    break;
                case WindowsSessionSwitchReasons.SessionLock:
                    _sessionStartedHandled = false;
                    if (_sessionEndedHandled)
                    {
                        _sessionEndedHandled = false;
                        return;
                    }
                    try
                    {
                        _sessionEndedHandled = true;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex,"WindowsSessionSwitchHandle exception (reason: {Reason}, multi-instance: {IsMultiInstance})", e.Reason.ToString(), e.IsMultiInstance.ToString());
                    }
                    break;
                case WindowsSessionSwitchReasons.SessionUnlock:
                    _sessionEndedHandled = false;
                    if (_sessionStartedHandled)
                    {
                        _sessionStartedHandled = false;
                        return;
                    }
                    try
                    {
                        LoadAppConfiguration();
                        _sessionStartedHandled = true;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex,"WindowsSessionSwitchHandle exception (reason: {Reason}, multi-instance: {IsMultiInstance})", e.Reason.ToString(), e.IsMultiInstance.ToString());
                    }
                    break;
            }
        }
        
        public void DoTest()
        {
            try
            {
                throw new NotImplementedException();
                
                ExecuteTask(Guid.Parse("539db734-89d0-440a-a4b2-adb471c8c004"));

                // _windowsActionsExecutor.ExecuteCommand("wsl.exe", $"-d {task.Name} hostname -I");
                // _windowsActionsExecutor.ExecuteCommand("cmd", $"/C dir {Environment.GetEnvironmentVariable("windir")}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error {Message}", e.Message);
            }
        }
    }
}