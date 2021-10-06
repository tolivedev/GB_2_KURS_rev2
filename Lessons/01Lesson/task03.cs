using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._01Lesson
{
    public class TestCase
    {
        public int X { get; set; }
        public int Expected { get; set; }
        public Exception ExpectedException { get; set; }
    }


    class task03
    {
        public task03()
        {
            Start();
        }
        
        delegate int dFib();
        Stopwatch timer = new Stopwatch();
        int FibonachiRec(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else if (n < 0) { throw new ArgumentException(); }
            else
            {
                return FibonachiRec(n - 1) + FibonachiRec(n - 2);
            }
        }

        int Fibon(int end)
        {
            int a = 0;
            int b = 1;
            int tmp;

            for (int i = 0; i < end; i++)
            {
                tmp = a;
                a = b;
                b += tmp;
            }

            if (a < 0)
            {
                throw new Exception();
            }
            return a;
        }
        void TestFib(Func<int, int> dF, TestCase testCase)
        {
            try
            {
                var actual = dF(testCase.X);

                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception)
            {
                if (testCase.ExpectedException != null)
                {
                    //TODO add type exception tests;
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }


        public void Start()
        {
            var testCase1 = new TestCase()
            {
                X = 45,
                Expected = 1134903170,
                ExpectedException = null
            };

            var Fi = new Func<int, int>(Fibon);

            timer.Start();
            TestFib(Fi, testCase1);
            timer.Stop();
            Console.WriteLine($"\nФибоначчи цикл за: {timer.Elapsed.Milliseconds} мс");
            timer.Reset();

            Fi = new Func<int, int>(FibonachiRec);

            timer.Start();
            TestFib(Fi, testCase1);
            timer.Stop();
            Console.WriteLine($"\nФибоначчи рекурсия за: {timer.Elapsed.Milliseconds} мс");
            timer.Reset();

            Console.ReadKey();
        }
    }
}
