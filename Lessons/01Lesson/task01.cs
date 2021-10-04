using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._01Lesson
{
    class task01
    {
        public task01()
        {
            Console.WriteLine("Enter number\n");
            TestFunc(int.Parse(Console.ReadLine()));
        }

        public void TestFunc(int n)
        {
            int d = 0;
            //int i = 2;

            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    d++;
                }
            }

            if (d == 0)
            {
                Console.WriteLine("\n it's simple number");
            }
            else
            {
                Console.WriteLine("\n not simple number");
            }
            Console.ReadKey();
        }
    }
}
