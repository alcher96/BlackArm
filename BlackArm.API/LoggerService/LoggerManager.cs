using BlackArm.Application.Contracts;
using NLog;
using ILogger = NLog.ILogger;

namespace BlackArm.Application.LoggerService;

public class LoggerManager : ILoggerManager
{
    private static ILogger _logger = LogManager.GetCurrentClassLogger();
    public LoggerManager()
    {
        
    }
    
    public void LogInfo(string message)
    {
        _logger.Info(message);
    }

    public void LogWarning(string message)
    {
        _logger.Warn(message);
    }

    public void LogError(string message)
    {
        _logger.Error(message);
    }

    public void LogDebug(string message)
    {
        _logger.Debug(message);
    }
}