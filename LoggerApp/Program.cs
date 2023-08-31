namespace LoggerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Starter.Run();
            Logger.Instance.PrintLoggedData();
            Logger.Instance.LogsToTxt();
        }
    }
}