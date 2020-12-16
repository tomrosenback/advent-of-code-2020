using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Day15
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Advent of code 2020 - day 15");

            var timer = new Stopwatch();
            timer.Start();

            var initialData = new List<int>() { 1, 0, 15, 2, 10, 13 };
            var app = new Application();

            var result = app.PlayGame(initialData);
            timer.Stop();
            Console.WriteLine("Part1: Playgame: {0}, found in {1}ms", result, timer.Elapsed.TotalMilliseconds);

            timer.Restart();
            var result2 = app.PlayGame(initialData, 30000000);
            timer.Stop();
            Console.WriteLine("Part2: Playgame: {0}, found in {1}ms", result2, timer.Elapsed.TotalMilliseconds);
        }

    }
}
