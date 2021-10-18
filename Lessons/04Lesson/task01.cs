using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._04Lesson
{
    class task01
    {

        public task01() : this(size: 10_000, desVal: string.Empty)
        {
            //SIZE = 10_000;
   
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size">Размер наборов</param>
        /// <param name="desVal">Искомое значение</param>
        public task01(int size, string desVal)
        {
            this.SIZE = size;
            this.desiredValue = desVal;

            InitSequences();
            Performance();

        }
        private string[] arrStr = null;
        readonly int SIZE;
        readonly HashSet<string> hs = new();
        Stopwatch sw = new();
        string desiredValue = default;

        public void InitSequences()
        {
            arrStr = new string[SIZE];
            string tmp;
            for (int i = 0; i < SIZE; i++)
            {
                tmp = Guid.NewGuid().ToString();
                arrStr[i] = tmp;
                hs.Add(tmp);

                if (i == 4999)
                {
                    desiredValue = arrStr[i];
                }

            }
            Thread.Sleep(500);
        }


        private void Performance()
        {

            sw.Start();
            //int i = 0;
            //while (arrStr[i] != desiredValue)
            //{
            //    i++;
            //}

            for (int i = 0; i < SIZE; i++)
            {
                if (arrStr[i] != desiredValue && SIZE - 1 == i)
                {
                    Console.WriteLine("Искомый элемент не найден в массиве");
                    break;
                }
                else if(arrStr[i] == desiredValue)
                {
                    Console.WriteLine($"Элемент {desiredValue}  найден в Массиве");
                    break;
                }
                
            }
            sw.Stop();
            Console.WriteLine("Затрачено на поиск в массиве {0}", sw.Elapsed.ToString("mm\\:ss\\.fffffff"));
            sw.Reset();

            sw.Start();
            if (hs.Contains(desiredValue))
            {
                Console.WriteLine($"Элемент {desiredValue}  найден в HashSet");
            }
            else
            {
                Console.WriteLine("Нет совпадения по искомому значению");
            }
            sw.Stop();
            Console.WriteLine("Затрачено на поиск в HashSet {0}", sw.Elapsed.ToString("mm\\:ss\\.fffffff"));
            sw.Reset();


        }
    }
}
