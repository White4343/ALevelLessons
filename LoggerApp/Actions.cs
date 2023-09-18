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
            try
            {
                throw new Exception("I broke logic");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _log.AddLogData("Error", e.Message);
            }
        }

        public static void WarningAdd()
        {
            try
            {
                throw new Exception("Skipped logic in method");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _log.AddLogData("Warning", e.Message);
            }
        }
    }
}
