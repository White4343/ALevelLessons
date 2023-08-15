namespace SecondTaskArrayCopy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random randomNumberInArray = new Random();

            int[] A = Enumerable.Repeat(0, 20).Select(i => randomNumberInArray.Next(-888, 2000)).ToArray();

            Array.Sort(A);

            Console.WriteLine($"Newly created array A:");
            Console.WriteLine("[{0}]", string.Join(", ", A));

            int[] B = new int[20];

            Array.Copy(A, 0, B, 0, A.Length);

            Console.WriteLine($"Newly copied array B from ARRAY B:");
            Console.WriteLine("[{0}]", string.Join(", ", B));

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] <= 888)
                {
                    A[i] = -4444;
                }
            }

            Console.WriteLine($"Array A after exclusion of number <= 888 where excluded now have number of -4444");
            Console.WriteLine("[{0}]", string.Join(", ", A));

            Console.WriteLine($"Array B (deep copy) again:");
            Console.WriteLine("[{0}]", string.Join(", ", B));
        }
    }
}