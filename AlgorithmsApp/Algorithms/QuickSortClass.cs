using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsApp.Algorithms
{
    public static class QuickSortClass
    {
        public static void QuickSort<T>(T[] list) where T : IComparable<T>
        {
            QuickSortInternal(list, 0, list.Length - 1);
        }

        private static void QuickSortInternal<T>(T[] list, int left, int right) where T : IComparable<T>
        {
            if (left >= right)
            {
                return;
            }

            int partition = PartitionInternal(list, left, right);

            QuickSortInternal(list, left, partition - 1);
            QuickSortInternal(list, partition + 1, right);
        }

        private static int PartitionInternal<T>(T[] list, int left, int right) where T : IComparable<T>
        {
            T partition = list[right];

            // stack items smaller than partition from left to right
            int swapIndex = left;
            for (int i = left; i < right; i++)
            {
                T item = list[i];
                if (item.CompareTo(partition) <= 0)
                {
                    list[i] = list[swapIndex];
                    list[swapIndex] = item;

                    swapIndex++;
                }
            }

            // put the partition after all the smaller items
            list[right] = list[swapIndex];
            list[swapIndex] = partition;

            return right;
        }
    }
}
