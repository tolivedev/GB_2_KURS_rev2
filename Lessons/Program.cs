using System;
using Lessons._01Lesson;
using Lessons._02Lesson;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Lessons._03Lesson;

namespace Lessons
{
    /// <summary>
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
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //new Tasks_01lesson();

            //new Lesson02();

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

        }
    }
}
