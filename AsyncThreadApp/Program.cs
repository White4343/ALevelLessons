using System.Text;
using AsyncThreadApp.SitesAsync;

namespace AsyncThreadApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //ThreadsFibRunner.Runner();
            await SitesRunner.Runner();
        }
    }
}