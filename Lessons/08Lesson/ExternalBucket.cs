using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._08Lesson
{
    class ExternalBucket
    {
        public void ExtSort(int[] A)
        {
            Console.WriteLine("Counter");

            if (A == null || A.Length < 2) return;  //Блок проверок на необходимость сортировки и поиск максимального и минимального значения
            int min = A[0];
            int max = A[0];
            bool is_sorted = true;

            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] < min) min = A[i];
                if (A[i] > max) max = A[i];
                if (A[i] < A[i - 1]) is_sorted = false;
            }
            if (is_sorted) return;


            List<int>[] bucket = new List<int>[max - min + 1];  //инициализируем массив с корзинами (списками) для каждого из значений (по сути превращая её сортировку подсчётом)
            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            for (int i = 0; i < A.Length; i++)        //заполняем корзины (в каждой будут одинаковые значения)
            {
                bucket[A[i] - min].Add(A[i]);
            }
            int position = 0;
            for (int i = 0; i < bucket.Length; i++)       //объединяем наши корзины в массиве для сортировки
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        A[position] = bucket[i][j];
                        position++;
                    }
                }
            }
        }
    }
}
