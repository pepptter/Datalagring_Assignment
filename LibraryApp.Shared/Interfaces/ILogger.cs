using LibraryApp.Shared.Utils;

namespace LibraryApp.Shared.Interfaces
{
    public interface ILogger
    {
        void Log(string message);
        void Log(string message, LogTypes logType = LogTypes.Error);
        void Log(string message, string methodName = "", LogTypes logType = LogTypes.Error);
    }
}