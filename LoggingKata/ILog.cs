using System;
namespace LoggingKata
{
    public interface ILog
    {
        void LogFatal(string log, Exception exception = null);
        void LogError(string log, Exception exception = null);
        void LogWarning(string log);
        void LogInfo(string log);
        void LogInfoArray(string[] log);
        void LogITrackableInfo(ITrackable log);
        void LogDebug(string log);
    }
}
