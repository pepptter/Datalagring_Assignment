using System.Diagnostics;
using System.Reflection;
using LibraryApp.Business.Interfaces;

namespace LibraryApp.Business.Utils;

public class Logger(string filePath) : ILogger
{
    private readonly string _filePath = filePath;

    public void Log(string message)
    {
        try
        {
            var logMessage = $"{DateTime.Now} :: {message}";
            Debug.WriteLine($"{logMessage}");
            using var sw = new StreamWriter(_filePath, true);
            sw.WriteLine(logMessage);

        }
        catch
        {
            Debug.WriteLine($"{DateTime.Now} :: Logger.log() :: {LogTypes.Error} :: {message}");
        }
    }
    public void Log(string message, LogTypes logType = LogTypes.Error)
    {
        try
        {
            var logMessage = $"{DateTime.Now} :: {logType} :: {message}";
            Debug.WriteLine($"{logMessage}");
            using var sw = new StreamWriter(_filePath, true);
            sw.WriteLine(logMessage);

        }
        catch
        {
            Debug.WriteLine($"{DateTime.Now} :: Logger.log() :: {LogTypes.Error} :: {message}");
        }
    }
    public void Log(string message, string methodName = "", LogTypes logType = LogTypes.Error)
    {
        try
        {
            var logMessage = $"{DateTime.Now} :: {methodName} :: {logType} :: {message}";
            Debug.WriteLine($"{logMessage}");
            using var sw = new StreamWriter(_filePath, true);
            sw.WriteLine(logMessage);

        }
        catch
        {
            Debug.WriteLine($"{DateTime.Now} :: Logger.log() :: {LogTypes.Error} :: {message}");
        }
    }
}
