using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoggerApp
{
    public struct Result
    {
        private readonly DateTime _dateOfLog = DateTime.Now;
        private string _logType;
        private string _message;

        public Result(string logType, string message)
        {
            _logType = logType;
            _message = message;
        }

        public override string ToString()
        {
            return $"{_dateOfLog}; {_logType}; {_message}";
        }
    }


    public sealed class Logger
    {
        private static readonly Logger _instance = new Logger();
        private List<Result> _logs = new List<Result>();

        public static Logger Instance => _instance;

        static Logger() {}

        private Logger() {}

        public void AddLogData(string logType, string message)
        {
            _logs.Add(new Result(logType, message));
        }

        public void PrintLoggedData()
        {
            foreach (var log in _logs)
            {
                Console.WriteLine(log.ToString());
            }
        }

        public void LogsToTxt()
        {
            File.WriteAllText("log.txt", string.Join(Environment.NewLine, _logs));
        }

        public void LogsToJson()
        {
            var filename = "log.txt";
            var lines = File.ReadAllLines(filename);

            var model = lines.Select(p => new
            {
                Date = p.Split(";")[0],
                Type = p.Split(";")[1],
                Message = p.Split(";")[2],
            });
            var json = JsonSerializer.Serialize(model);
            File.WriteAllText("jsonLog.json", json);
        }
    }
}
