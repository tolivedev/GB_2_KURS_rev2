using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lessons._08Lesson
{
    public class task01
    {
        public task01()
        {
            Start();
        }

        BucketSort BS = new();
        ExternalBucket exBS = new();

        public delegate void Sort(int[] array);
        static void PrintArray<T>(T[] array)        //печать массива дл€ проверки корректности сортировок на малых массивах данных
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.ResetColor();
            Console.WriteLine();
        }


        public void Start()
        {
            List<string> buble = new();
            List<string> bucket_auto = new();
            List<string> bucket_buble = new();
            List<string> bucket_count = new();
            List<string> auto = new();

            int size = 100;
            int value = 100;
            Console.WriteLine();
            Console.WriteLine("size = " + size + "    value = " + value);
            TestAll(size, value, buble, bucket_count, bucket_auto, bucket_buble, auto);

            size = 100;
            value = 100_000;
            Console.WriteLine();
            Console.WriteLine("size = " + size + "    value = " + value);
            TestAll(size, value, buble, bucket_count, bucket_auto, bucket_buble, auto);

            size = 100_000;
            value = 100;
            Console.WriteLine();
            Console.WriteLine("size = " + size + "    value = " + value);
            TestAll(size, value, buble, bucket_count, bucket_auto, bucket_buble, auto);

            size = 100_000;
            value = 100_000;
            Console.WriteLine();
            Console.WriteLine("size = " + size + "    value = " + value);
            TestAll(size, value, buble, bucket_count, bucket_auto, bucket_buble, auto);

            size = 100_000_000;
            value = 1_000_000;
            Console.WriteLine();
            Console.WriteLine("size = " + size + "    value = " + value);
            TestAll(size, value, buble, bucket_count, bucket_auto, bucket_buble, auto);

            Console.WriteLine();
            Console.WriteLine("—корость нескольких разных сортировок на разных размерах массивов и разных диапазонах значений");
            Console.WriteLine();
            Console.WriteLine("________________________________________________________________________________________________________");
            Console.WriteLine("                       |               |               |               |               |               |");
            Console.WriteLine("     –азмер массива    |      100      |      100      |    100 000    |    100 000    |  100 000 000  |");
            Console.WriteLine("   ƒиапазон значений   |      100      |    100 000    |      100      |    100 000    |   1 000 000   |");
            Console.WriteLine("_______________________|_______________|_______________|_______________|_______________|_______________|");
            Console.Write($"ѕузырькова€ сортировка |  {buble[0]}   |  {buble[1]}   |  {buble[2]}   |  {buble[3]}   |               | ");
            Console.WriteLine();
            Console.WriteLine("_______________________|_______________|_______________|_______________|_______________|_______________|");
            Console.Write($"Ѕлочна€ с авто         |  {bucket_auto[0]}   |  {bucket_auto[1]}   |  {bucket_auto[2]}   |  {bucket_auto[3]}   |  {bucket_auto[4]}   |");
            Console.WriteLine();
            Console.WriteLine("_______________________|_______________|_______________|_______________|_______________|_______________|");
            Console.Write($"Ѕлочна€ с пузырьковой  |  {bucket_buble[0]}   |  {bucket_buble[1]}   |  {bucket_buble[2]}   |  {bucket_buble[3]}   |               |");
            Console.WriteLine();
            Console.WriteLine("_______________________|_______________|_______________|_______________|_______________|_______________|");
            Console.Write($"Ѕлочна€-подсчЄтом      |  {bucket_count[0]}   |  {bucket_count[1]}   |  {bucket_count[2]}   |  {bucket_count[3]}   |  {bucket_count[4]}   |");
            Console.WriteLine();
            Console.WriteLine("_______________________|_______________|_______________|_______________|_______________|_______________|");
            Console.Write($"јвтосортировка         |  {auto[0]}   |  {auto[1]}   |  {auto[2]}   |  {auto[3]}   |  {auto[4]}   |");
            Console.WriteLine();
            Console.WriteLine("_______________________|_______________|_______________|_______________|_______________|_______________|");
            Console.ReadKey();
            Console.ReadKey();
            Console.ReadKey();
        }
        void TestAll(int size, int value, List<string> buble, List<string> bucket_count, List<string> bucket_auto, List<string> bucket_buble, List<string> auto)
        {
            int[] mas = RandomArray(size, value);      //метод тестирующий на одном массиве несколько различных сортировок
            int[] mas1 = CopyArray(mas);
            int[] mas2 = CopyArray(mas);
            int[] mas3 = CopyArray(mas);
            int[] mas4 = CopyArray(mas);


            Sort sort = exBS.ExtSort;
            Test(bucket_count, sort, mas);
            if (size < 200_000)
            {
                sort = BS.Sort;
                Test(bucket_buble, sort, mas1);
            }
            sort = BS.SortAuto;
            Test(bucket_auto, sort, mas2);
            if (size < 200_000)
            {
                sort = BubleSort;
                Test(buble, sort, mas3);
            }

            Console.WriteLine("Auto Sort");         //пришлось вынести автосорт отдельно, т.к. нужно сначала преобразовать в List массив, что занимает много времени
            //var list = mas4.Cast<int>().ToList();
            var list = new List<int>(mas4);
            var watch = new Stopwatch();

            watch.Start();
            list.Sort();

            watch.Stop();
            
            string time = (watch.Elapsed).ToString().Substring(6);
            Console.WriteLine(watch.Elapsed);
            auto.Add(time);
        }

        void Test(List<string> timer, Sort sort, int[] array)    //тест и замер производительности конкретного алгоритма
        {

            var watch = new Stopwatch();

            watch.Start();
            sort(array);

            watch.Stop();

            string time = (watch.Elapsed).ToString().Substring(6);
            Console.WriteLine(time);
            timer.Add(time);
        }
        int[] RandomArray(int size, int maxvalue)
        {
            var rand = new Random();
            int[] mas = new int[size];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rand.Next(0, maxvalue);
            }
            return mas;
        }
        
        int[] CopyArray(int[] array)
        {
            int[] mas = new int[array.Length];
            array.CopyTo(mas, 0);
            return mas;
        }
        
        void BubleSort(int[] array)
        {
            Console.WriteLine("BUBLE");
            for (int i = 0; i < array.Length - 1; i++)
            {
                int n = 0;
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        n = 1;
                    }
                }
                if (n == 0)
                    break;
            }
        }
    }
}