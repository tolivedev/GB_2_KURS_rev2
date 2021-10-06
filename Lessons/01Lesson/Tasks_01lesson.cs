using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._01Lesson
{
    class Tasks_01lesson
    {

        public Tasks_01lesson()

        {
            Console.SetWindowSize(159, 30);
            try
            {
                do
                {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(@"
                1. Напишите на C# функцию согласно блок-схеме
                2. Посчитайте сложность функции
                3. Реализуйте функцию вычисления числа Фибоначчи");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\nВыберите вариант задания");
                    char switcher = Console.ReadLine().ToCharArray()[0];

                    switch (switcher)
                    {
                        case '1': { new task01(); break; }
                        case '2': { new task02(); break; }
                        case '3': { new task03(); break; }


                        default:
                            {
                                Console.WriteLine("Введён неверный символ. Ввыберите один из '1,2,3' ");
                                break;
                            }
                    }
                }
                while (true);
            }
            catch (Exception arg)
            {
                Console.WriteLine("Упс, Возникло следующее: {0}", arg.Message);
            }


            ConsoleKeyInfo cki;
            do
            {
                cki = Console.ReadKey();
                if (cki.KeyChar == '\r')
                {
                    Environment.Exit(0);
                }
                Console.WriteLine("Для выхода нажимет клавишу ENTER");
            } while (cki.KeyChar != '\r');

        }
        //new task01();
        //new task03();


    }
}

