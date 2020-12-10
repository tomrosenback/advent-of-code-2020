using System;
using System.Diagnostics;

namespace Day10
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Advent of code 2020 - day 10");

            var timer = new Stopwatch();
            var app = new Application("day10-input.txt");

            timer.Start();
            var multiplier = app.FitAdapters();
            timer.Stop();
            Console.WriteLine("Part1: adapter multiplier: {0}, found in {1}ms", multiplier, timer.Elapsed.TotalMilliseconds);

            timer.Restart();
            var combinations = app.GetPossibleAdapterConfigurations();
            timer.Stop();
            Console.WriteLine("Part1: adapter combinations: {0}, found in {1}ms", combinations, timer.Elapsed.TotalMilliseconds);
        }
    }
}
