namespace Hebverb.Services;

public interface ILoggerManager 
{
    void LogError(string message);
    void LogWarning(string message);
    void LogInfo(string message);
}
