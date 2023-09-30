using DelegateLINQApp.Delegate;
using static System.Net.Mime.MediaTypeNames;

namespace DelegateLINQApp
{
    internal class Program
    {
        public static Random Random = new Random();

        static void Main(string[] args)
        {
            LINQ.Run();
            UserLINQ.Run();
            Starter.Run();
        }
    }
}