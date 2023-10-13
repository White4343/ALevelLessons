using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncThreadApp
{
    public class ThreadsFibRunner
    {
        static ConcurrentDictionary<int, int> FibonacciResults = new ConcurrentDictionary<int, int>();
        static ConcurrentDictionary<int, int> FactorialResults = new ConcurrentDictionary<int, int>();

        public static void Runner()
        {
            Thread inputThread = new Thread(InputNumbers);
            Thread fibonacciThread = new Thread(CalculateFibonacci);
            Thread factorialThread = new Thread(CalculateFactorial);

            inputThread.Start();
            fibonacciThread.Start();
            factorialThread.Start();

            inputThread.Join();
            fibonacciThread.Join();
            factorialThread.Join();

            Console.WriteLine("Results:");
            foreach (var key in FibonacciResults.Keys)
            {
                Console.WriteLine($"Input: {key}, Fibonacci: {FibonacciResults[key]}, Factorial: {FactorialResults[key]}");
            }
        }


        static void InputNumbers()
        {
            Console.WriteLine("Enter numbers (separated by spaces):");
            string[] inputNumbers = Console.ReadLine().Split(' ');

            foreach (string inputNumber in inputNumbers)
            {
                int num = int.Parse(inputNumber);

                FibonacciResults.TryAdd(num, CalculateFibonacci(num));
                FactorialResults.TryAdd(num, CalculateFactorial(num));

                Thread.Sleep(100); // Simulating user input delay
            }
        }

        static void CalculateFibonacci()
        {
            foreach (var key in FibonacciResults.Keys)
            {
                FibonacciResults[key] = CalculateFibonacci(key);
            }
        }

        static int CalculateFibonacci(int n)
        {
            if (n <= 1)
                return n;

            int result;
            if (FibonacciResults.TryGetValue(n - 1, out result))
            {
                return FibonacciResults[n - 1] + FibonacciResults.GetOrAdd(n - 2, CalculateFibonacci);
            }

            return CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
        }

        static void CalculateFactorial()
        {
            foreach (var key in FactorialResults.Keys)
            {
                FactorialResults[key] = CalculateFactorial(key);
            }
        }

        static int CalculateFactorial(int n)
        {
            if (n == 0)
                return 1;

            int result;
            if (FactorialResults.TryGetValue(n - 1, out result))
            {
                return n * FactorialResults[n - 1];
            }

            return n * CalculateFactorial(n - 1);
        }
    }
}
