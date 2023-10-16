using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AsyncThreadApp.SitesAsync
{
    public static class SitesWorker
    {
        public static async Task<string> DownloadWebsiteAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }

        public static async Task WriteToFileAsync(string fileName, string content)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                await writer.WriteAsync(content);
            }
        }

        public static async Task<string[]> ReadFileAsync(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string content = await reader.ReadToEndAsync();
                return content.Split('\n');
            }
        }

        private static string StripHtmlTags(string input)
        {
            return Regex.Replace(input, "<.*?>", string.Empty);
        }

        public static Dictionary<string, int> GetWordFrequencies(string[] lines)
        {
            Dictionary<string, int> frequencies = new Dictionary<string, int>();

            foreach (var line in lines)
            {
                string content = StripHtmlTags(line);
                string[] words = content.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    if (frequencies.ContainsKey(word))
                        frequencies[word]++;
                    else
                        frequencies[word] = 1;
                }
            }

            return frequencies;
        }

        public static HashSet<string> GetUniqueWords(string[] lines)
        {
            HashSet<string> uniqueWords = new HashSet<string>();

            foreach (var line in lines)
            {
                string content = StripHtmlTags(line);
                string[] words = content.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    uniqueWords.Add(word);
                }
            }

            return uniqueWords;
        }

        public static Dictionary<string, int> CombineWordFrequencies(Dictionary<string, int> freq1, Dictionary<string, int> freq2)
        {
            Dictionary<string, int> combined = new Dictionary<string, int>(freq1);

            foreach (var kvp in freq2)
            {
                if (combined.ContainsKey(kvp.Key))
                    combined[kvp.Key] += kvp.Value;
                else
                    combined[kvp.Key] = kvp.Value;
            }

            return combined;
        }

        public static void PrintWordFrequencies(Dictionary<string, int> frequencies)
        {
            foreach (var kvp in frequencies)
            {
                Console.WriteLine($"{kvp.Key} ({kvp.Value})");
            }
        }
    }
}
