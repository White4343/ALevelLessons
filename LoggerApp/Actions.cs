using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApp
{
    internal class Actions
    {
        private static Logger _log = Logger.Instance;

        public static void InfoAdd()
        {
            _log.AddLogData("Info", "Info message bruh");
        }

        public static void ErrorAdd()
        {
            _log.AddLogData("Error", "Error message bruh");
        }

        public static void WarningAdd()
        {
            _log.AddLogData("Warning", "Warning message bruh");
        }
    }
}
