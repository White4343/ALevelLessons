using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLINQApp
{
    internal class LINQ
    {
        public static void Run()
        {
            Random randNum = new Random();

            List<string> stringList = new List<string>();

            for (int i = 0; i < 15; i++)
            {
                stringList.Add(RandomString(randNum.Next(1, 15)));
            }

            Console.WriteLine($"Init list of strings:");
            PrintResult(stringList);

            // Linq
            int[] test = Enumerable
                .Repeat(0, 15)
                .Select(i => randNum.Next(-200, 200))
                .ToArray();

            Array.Sort(test);

            var averageArrayValue = test.Average();

            string randomString = RandomString(25);
            string myStringOutput = ArrayToStringLine(test);

            Console.WriteLine($"Init array: {myStringOutput}");
            Console.WriteLine($"Init string: {randomString}");
            Console.WriteLine("\nWrite a LINQ query to find the numbers in a given array which are divisible by 2 and 3");

            var bufferArray = test.Where(p => p % 2 == 0 && p % 3 == 0);

            PrintResult(bufferArray);

            Console.WriteLine("\nWrite a LINQ query to find the sum of all the numbers in a given array");

            Console.WriteLine($"Result: {test.Sum()}");

            Console.WriteLine("\nWrite a LINQ query to find the average of all the numbers in a given array");

            Console.WriteLine($"Result: {averageArrayValue}");

            Console.WriteLine("\nWrite a LINQ query to find the maximum number in a given array");

            Console.WriteLine($"Result: {test.Max()}");

            Console.WriteLine("\nWrite a LINQ query to find the minimum number in a given array");

            Console.WriteLine($"Result: {test.Min()}");

            Console.WriteLine("\nWrite a LINQ query to find the numbers greater than 10 in a given array and multiply each number by 10");

            bufferArray = test.Where(p => p > 10).Select(p => p * 10);

            PrintResult(bufferArray);

            Console.WriteLine("\nWrite a LINQ query to find the unique characters from a given string");

            var bufferStringArray = randomString.Distinct();

            PrintResult(bufferStringArray);

            Console.WriteLine("\nWrite a LINQ query to find the numbers and the frequency of each number in a given array");

            var frequencyBufferArray = test.GroupBy(t => t).
                Select(n => new
                {
                    Value = n.Key,
                    Frequency = n.Count()
                });

            PrintResult(frequencyBufferArray);

            Console.WriteLine("\nWrite a LINQ query to group the numbers in a given array into even and odd groups and then find the maximum number in each group");

            var oddEvenBufferArray = test.GroupBy(i => i % 2 == 0 ? "Even" : "Odd")
                .Select(t => new
                {
                    Type = t.Key,
                    Max = t.Max()
                });

            PrintResult(oddEvenBufferArray);

            Console.WriteLine("\nFind the elements of a list of integers that are greater than the average of the list");

            bufferArray = test.Where(i => i > averageArrayValue);

            PrintResult(bufferArray);

            Console.WriteLine("\nGroup the elements of a list of strings by the length of the string");

            var bufferStringList = stringList
                .GroupBy(i => i.Length)
                .OrderBy(t => t.Key);

            foreach (var t in bufferStringList)
            {
                Console.WriteLine($"Length {t.Key}:");
                foreach (var str in t)
                {
                    Console.WriteLine(str);
                }
            }

            Console.WriteLine("\nFind the elements of a list of strings that contain a given substring, group them by the length of the string and project them into a new list with the strings in a normalized format (first character upper-case every else lower-case)");

            string substringToFind = "S";
            Console.WriteLine($"\nString to find: {substringToFind}");

            var subStringListString = stringList
                .Where(s => s.Contains(substringToFind))
                .GroupBy(s => s.Length)
                .OrderBy(group => group.Key)
                .SelectMany(group => group.Select(s =>
                    char.ToUpper(s[0]) + s.Substring(1).ToLower()
                ));

            PrintResult(subStringListString);
        }

        public static void PrintResult<T>(IEnumerable<T> array)
        {
            Console.WriteLine(ArrayToStringLine(array));
        }

        public static string ArrayToStringLine<T>(IEnumerable<T> array)
        {
            return string.Join(", ", array.Select(p => p.ToString()).ToArray());
        }

        public static string RandomString(int length)
        {
            Random randNum = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[randNum.Next(s.Length)]).ToArray());
        }
    }
}