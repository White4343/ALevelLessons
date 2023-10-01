using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsApp.Algorithms
{
    public static class Recursion
    {
        public static int Fibonacci(int value)
        {
            if (value == 0 || value == 1) 
                return value;

            return Fibonacci(value - 1) + Fibonacci(value - 2);
        }


        public static int Factorial(int value)
        {
            if (value == 1) 
                return 1;

            return value * Factorial(value - 1);
        }
    }
}
