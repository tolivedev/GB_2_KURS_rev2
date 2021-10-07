using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    class task02
    {

        public task02()
        {

            Console.WriteLine(@"
        public int BinarySearch(int[] arr, int searchVal)
        {
            int left = 0; // O(1)
            int right = arr.Length - 1; // O(2)
            while (left <= right)   // O(log n)
            {
                int mid = (left + right) / 2;  // O(1)
                if (searchVal == arr[mid])
                {
                    return mid; // O(1)
                }
                else if (searchVal < arr[mid])
                {
                    right = mid - 1; // O(1)
                }
                else
                {
                    left = mid + 1; // O(1)
                }
            }
            return -1;
        }");

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("\nsummary = 1 + 2 + log n + 1 + 1 + 1 + 1 = O( log n )");

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        //summary = 1 + 2 + log n + 1 + 1 + 1 + 1 = O( log n )
    }
}
