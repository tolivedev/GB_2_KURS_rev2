using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._08Lesson
{
    public class BucketSort
    {
        public void SortAuto(int[] A)
        {
            Console.WriteLine("Need for sorting, Search max and min");
            if (A == null || A.Length < 2) return; //Блок проверок на необходимость сортировки и поиск максимального и минимального значения
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
            max++;

            int n = (max - min) / 10;
            List<int>[] buckets = new List<int>[n]; //инициализируем массив с корзинами (списками)
            for (int i = 0; i < n; i++)
            {
                buckets[i] = new List<int>();
            }

            for (int i = 0; i < A.Length; i++)      //заполняем корзины
            {
                int num = Math.Abs((n * (A[i] - min) / (max - min)));
                buckets[num].Add(A[i]);
            }

            for (int i = 0; i < n; i++)              //сортируем корзины
            {
                buckets[i].Sort();
            }
            int position = 0;
            for (int i = 0; i < n; i++)            //объединяем наши корзины в массиве для сортировки
            {
                buckets[i].CopyTo(A, position);
                position += buckets[i].Count;
            }
            return;
        }

        private void BubbleSort(List<int> A)
        {
            for (int i = 0; i < A.Count - 1; i++)        //пузырьковая сортировка
            {
                int n = 0;
                for (int j = 0; j < A.Count - 1; j++)
                {
                    if (A[j] > A[j + 1])
                    {
                        int temp = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = temp;
                        n = 1;
                    }
                }
                if (n == 0)
                    break;
            }
        }
        public void Sort(int[] A)
        {
            if (A == null || A.Length < 2) return; //Блок проверок на необходимость сортировки и поиск максимального и минимального значения
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
            max++;

            int n = (max - min) / 10;
            List<int>[] buckets = new List<int>[n]; //инициализируем массив с корзинами
            for (int i = 0; i < n; i++)
            {
                buckets[i] = new List<int>();
            }

            for (int i = 0; i < A.Length; i++)      //заполняем корзины
            {
                int num = Math.Abs((n * (A[i] - min) / (max - min)));
                buckets[num].Add(A[i]);
            }

            for (int i = 0; i < n; i++)              //сортируем корзины
            {
                BubbleSort(buckets[i]);
            }
            int position = 0;
            for (int i = 0; i < n; i++)            //объединяем наши корзины в массиве для сортировки
            {
                buckets[i].CopyTo(A, position);
                position += buckets[i].Count;
            }
            return;
        }
    }
}
