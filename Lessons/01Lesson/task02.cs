using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._01Lesson
{
    class task02
    {
        public task02()
        {
            StrangeSum(1, 2, 3, 4);
        }
        // fix. del static
        public int StrangeSum(params int[] inputArray)
        {
            int sum = 0; // O(1)
            for (int i = 0; i < inputArray.Length; i++) // O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) //O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) //O(N)
                    {
                        int y = 0; // O(1)

                        if (j != 0)
                        {
                            y = k / j; // O(1)
                        }

                        sum += inputArray[i] + i + k + j + y; // O(1)
                    }
                }
            }
            Console.WriteLine("\nsummary - 5 + N ^ 3 = 5 + N ^ 3 = N ^ 3");

            return sum; //O(1)

            // summary - 5+ N^3 = 5+ N^3 = N^3
        }
    }
}
