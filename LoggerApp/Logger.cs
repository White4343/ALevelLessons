using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApp
{
    public sealed class Logger
    {
        private static readonly Logger instance = new Logger();
        private List<object> _logs = new List<object>();

        public static Logger Instance => instance;

        static Logger() {}

        private Logger() {}

        public void AddLogData(string logType, string message)
        {
            _logs.Add($"{DateTime.Now}: {logType}: {message}");
        }


        public void PrintLoggedData()
        {
            foreach (var log in _logs)
            {
                Console.WriteLine(log);
            }
        }
    }
}
