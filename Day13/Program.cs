using System;
using System.Diagnostics;

namespace Day13
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Advent of code 2020 - day 13");

            var timer = new Stopwatch();
            timer.Start();

            var departure = Application.GetFirstDepartingBus("day13-input.txt");

            timer.Stop();
            Console.WriteLine("Part1: First bus departure: {0}, found in {1}ms", departure, timer.Elapsed.TotalMilliseconds);
        }
    }
}
