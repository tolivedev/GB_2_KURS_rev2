using System;

namespace Lessons._07Lesson
{
    public class task01
    {
        public task01()
        {
            start();
        }
        public void start()
        {
      
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\tПоиск количества путей в прямоугольнике");
                Console.ResetColor();
                Console.WriteLine();

                var place = InputPlacement();
                SumOfPaths(place.Item1, place.Item2);

                //Console.Clear();
            

            Console.ReadKey();

        }


        void SumOfPaths(int A, int B)
        {
            int[,] mas = new int[A, B];
            int i, j;
            for (i = 0; i < B; i++)
                mas[0, i] = 1;
            for (i = 1; i < A; i++)
            {
                mas[i, 0] = 1;
                for (j = 1; j < B; j++)
                    mas[i, j] = mas[i, j - 1] + mas[i - 1, j];
            }

            PrintPaths(mas);
        }
        void PrintPaths(int[,] mas)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"От левой верхней клетки до правой нижней есть {mas[mas.GetLength(0) - 1, mas.GetLength(1) - 1]} вариантов пути. ");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("Таблица количества путей до каждой клетки поля: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int i, j;
            Console.WriteLine();
            for (i = 0; i < mas.GetLength(0); i++)
            {
                for (j = 0; j < mas.GetLength(1); j++)
                {
                    if (mas[i, j] < 10)
                        Console.Write(mas[i, j] + "   ");
                    else if ((mas[i, j] < 100))
                        Console.Write(mas[i, j] + "  ");
                    else
                        Console.Write(mas[i, j] + " ");

                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ResetColor();
        }
        (int a, int b) InputPlacement()
        {
            int a, b;
            Console.WriteLine("Введите ширину поля");
            while (!Int32.TryParse(Console.ReadLine(), out b))
                Console.WriteLine("Ошибка ввода! Введите целочисленное значение ширины поля");
            Console.WriteLine("Введите высоту поля");
            while (!Int32.TryParse(Console.ReadLine(), out a))
                Console.WriteLine("Ошибка ввода! Введите целочисленное значение длины поля");
            return (a, b);
        }

        bool NextOrExit()
        {
            Console.Write("Нажмите ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter");
            Console.ResetColor();
            Console.Write(", чтобы продолжить или ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Esc");
            Console.ResetColor();
            Console.Write(", чтобы выйти");
            if (Console.ReadKey().Key == ConsoleKey.Escape)
                return true;
            return false;
        }
    }
}
