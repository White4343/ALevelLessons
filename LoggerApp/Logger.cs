using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApp
{
    public sealed class Logger
    {
        private readonly DateTime _dateOfLog = DateTime.Now;
        private string _logType;
        private string _message;

        private static readonly Logger instance = new Logger();
        private List<object> _logs = new List<object>();

        public static Logger Instance
        {
            get => instance;
        }

        static Logger() {}

        private Logger() {}

        private Logger(DateTime dateOfLog, string logType, string message)
        {
            _dateOfLog = dateOfLog;
            _logType = logType;
            _message = message;
        }

        public void AddLogData(string logType, string message)
        {
            _logs.Add(new Logger(_dateOfLog, logType, message));
        }

        public override string ToString()
        {
            return $"{_dateOfLog}: {_logType}: {_message}";
        }

        public void PrintLoggedData()
        {
            foreach (var log in _logs)
            {
                Console.WriteLine(log.ToString());
            }
        }
    }
}
