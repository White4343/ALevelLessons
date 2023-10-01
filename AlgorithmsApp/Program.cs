using AlgorithmsApp.Algorithms;

namespace AlgorithmsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Recursion.Fibonacci(20));
            Console.WriteLine(Recursion.Factorial(20));

            var numbers = new int[] { 5, 4, 5, 7, 6, 9, 4, 1, 1, 3, 4, 50, 41 };
            QuickSortClass.QuickSort(numbers);
            Console.WriteLine(string.Join($", ", numbers));
            Console.WriteLine(BinarySearchClass.BinarySearch(numbers,0));
        }
    }
}