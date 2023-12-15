using System;
using System.IO;

public class AdminLogger : ILog<AdminLogger>
{
    private readonly string _source;

    public AdminLogger(string source)
    {
        _source = source;
    }

    public async void Log(LogMsg msg)
    {
        string logMessage = $"{DateTime.Now} - Source: {msg.Source} - {msg.Operation} - {msg.ExecutedBy} - {msg.Msg ?? ""}";

        Console.WriteLine(logMessage);

        using (StreamWriter writer = new StreamWriter(_source, true))
        {
            writer.WriteLine(logMessage);
        }
    }
}

public interface ILog<T>
{
    void Log(LogMsg msg);
}

public struct LogMsg 
{
    public string Operation { get; set; }
    public string ExecutedBy { get; set; }
    public string Source { get; set; }
    public string? Msg { get; set; }
}
