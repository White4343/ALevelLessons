using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApp
{
    public class Starter
    {
        private static Random _random = new Random();

        public static void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                RandomLogSelector();
            }
        }

        private static void RandomLogSelector()
        {
            switch (_random.Next(1, 4))
            {
                case 1:
                    Actions.InfoAdd();
                    return;
                case 2:
                    Actions.ErrorAdd();
                    return;
                case 3:
                    Actions.WarningAdd();
                    return;
            }
        }
    }
}
