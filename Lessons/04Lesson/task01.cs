using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._04Lesson
{
    class task01
    {
        public task01()
        {
            SIZE = 10_000;
        }

        public task01(int size)
        {
            this.SIZE = size;
            //arrStr = new string[SIZE];
        }
        private string[] arrStr = null;// = new string[SIZE];
        readonly int SIZE;
        readonly HashSet<string> hs = new();


        public void InitSequences()
        {
            arrStr = new string[SIZE];
            string tmp;
            for (int i = 0; i < SIZE; i++)
            {
                tmp = Guid.NewGuid().ToString();
                arrStr[i] = tmp;
                hs.Add(tmp);

            }
            Thread.Sleep(500);
        }
    }
}
