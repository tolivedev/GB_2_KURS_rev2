using System;
//using Lessons._01Lesson;
//using Lessons._02Lesson;
//using BenchmarkDotNet.Attributes;
//using BenchmarkDotNet.Running;
//using Lessons._03Lesson;
//using Lessons._04Lesson;
using Lessons._05Lesson;

namespace Lessons
{
    /// <summary>
    ///  
    /// SIZE = 100
    ///  
    /// BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1266 (21H1/May2021Update)
    ///    Intel Core i7-5820K CPU 3.30GHz(Broadwell), 1 CPU, 12 logical and 6 physical cores
    ///   .NET SDK= 5.0.401

    ///     [Host]     : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT[AttachedDebugger]
    ///  DefaultJob : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT


    ///|                                Method |      Mean |    Error |   StdDev |
    ///|-------------------------------------- |----------:|---------:|---------:|
    ///|               'Класс с данными float' | 132.46 ns | 2.496 ns | 2.335 ns |
    ///|           'Структура с данными float' | 150.49 ns | 2.948 ns | 3.276 ns |
    ///|          'Структура с данными double' | 100.94 ns | 1.617 ns | 1.512 ns |
    ///| 'Структура с данными float без корня' |  95.99 ns | 1.761 ns | 1.647 ns |
    ///
    /// 
    /// 1. Третий по скорости, обращение по ссылкам идет сравнительно медленней первых двух лидеров со структурными типами.
    /// 2. Четвертый по скорости, казалось бы структура и нет прербразования к double ввиду использования класса MathF
    /// 3. Второй по скорости, 
    /// 4. Первый по скорости. Корень не высчитывается.
    /// 
    /// 
    /// !!! SIZE = 100_000
    /// 
    /// BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1266 (21H1/May2021Update)
    ///    Intel Core i5-10210U CPU 1.60GHz, 1 CPU, 8 logical and 4 physical cores
    ///    .NET SDK= 5.0.201

    ///      [Host]     : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT[AttachedDebugger]
    ///  DefaultJob : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT


    ///|                                Method |      Mean |    Error |   StdDev |    Median |
    ///|-------------------------------------- |----------:|---------:|---------:|----------:|
    ///|               'Класс с данными float' | 140.83 us | 2.780 us | 2.731 us | 140.74 us |
    ///|           'Структура с данными float' | 181.87 us | 2.032 us | 1.900 us | 181.58 us |
    ///|          'Структура с данными double' | 110.28 us | 2.191 us | 5.121 us | 107.81 us |
    ///| 'Структура с данными float без корня' |  72.79 us | 0.947 us | 0.930 us |  72.88 us |
    /// * Hints *
    ///    Outliers
    ///      BehaviorClass.'Структура с данными double': Default          -> 13 outliers were removed (132.63 us..225.18 us)
    ///  BehaviorClass.'Структура с данными float без корня': Default -> 5 outliers were removed(85.20 us..105.49 us)

    /// * Legends *
    ///    Mean   : Arithmetic mean of all measurements
    ///  Error  : Half of 99.9% confidence interval
    ///  StdDev : Standard deviation of all measurements
    ///  Median : Value separating the higher half of all measurements(50th percentile)
    ///  1 us   : 1 Microsecond(0.000001 sec)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //new Tasks_01lesson();

            //new Lesson02();   // les02

            //BenchmarkRunner.Run<BehaviorClass>(); //  les03

            new _04Lesson.Lesson04(); // le04

            //new task01(); 
        }
    }
}
