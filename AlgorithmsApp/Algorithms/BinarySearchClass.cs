using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsApp.Algorithms
{
    public static class BinarySearchClass
    {
        public static int BinarySearch<T>(IEnumerable<T> list, T needle) where T : IComparable<T>
        {
            int left = 0;
            int right = list.Count() - 1;

            while (left <= right)
            {
                int median = (left + right) / 2;
                T item = list.ElementAt(median);

                var comparison = needle.CompareTo(item);
                if (comparison == 0)
                {
                    return median;
                }

                if (comparison < 0)
                {
                    right = median - 1;
                }
                else
                {
                    left = median + 1;
                }
            }

            return -1;
        }
    }
}
