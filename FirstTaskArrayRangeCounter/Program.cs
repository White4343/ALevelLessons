namespace FirstTaskArrayRangeCounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random randomNumberInArray = new Random();

            int[] array = Enumerable.Repeat(0, 255).Select(i => randomNumberInArray.Next(-255, 255)).ToArray();

            Array.Sort(array);

            Console.WriteLine($"Newly created array:");
            Console.WriteLine("[{0}]", string.Join(", ", array));
            
            byte j = 0;

            foreach (var i in array.Where(i => i >= -100 & i <= 100))
            {
                j++;
            }

            Console.WriteLine($"Count of element that in a range between [-100; 100]: {j}");
        }
    }
}