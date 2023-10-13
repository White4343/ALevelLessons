using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncThreadApp.SitesAsync
{
    public class SitesRunner
    {
        public static async Task Runner()
        {
            Task<string> downloadSite1Task = SitesWorker.DownloadWebsiteAsync("https://www.helloworld.org/");
            Task<string> downloadSite2Task = SitesWorker.DownloadWebsiteAsync("http://www.toad.com/");

            string content1 = await downloadSite1Task;
            string content2 = await downloadSite2Task;

            await SitesWorker.WriteToFileAsync("site1.html", content1);
            await SitesWorker.WriteToFileAsync("site2.html", content2);

            Console.WriteLine("Downloaded and saved files.");

            string[] lines1 = await SitesWorker.ReadFileAsync("site1.html");
            string[] lines2 = await SitesWorker.ReadFileAsync("site2.html");

            Dictionary<string, int> freq1 = SitesWorker.GetWordFrequencies(lines1);
            Dictionary<string, int> freq2 = SitesWorker.GetWordFrequencies(lines2);

            Dictionary<string, int> combinedFreq = SitesWorker.CombineWordFrequencies(freq1, freq2);

            Console.WriteLine("1 File:");
            SitesWorker.PrintWordFrequencies(freq1);

            Console.WriteLine("\n2 File:");
            SitesWorker.PrintWordFrequencies(freq2);

            Console.WriteLine("\nCombined:");
            SitesWorker.PrintWordFrequencies(combinedFreq);
        }
    }
}
