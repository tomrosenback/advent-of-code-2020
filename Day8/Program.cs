using System;
using System.Diagnostics;

namespace Day8
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Advent of code 2020 - day 8");

            var timer = new Stopwatch();
            
            var app = new Application("day8-input.txt");
            timer.Start();
            var execution = app.ExecuteOperations();
            timer.Stop();
            Console.WriteLine("Part1: Accumulator before infinite-loop: {0}, executed in {1}ms", execution.Accumulator, timer.Elapsed.TotalMilliseconds);

            timer.Restart();
            execution = app.FixBrokenExecution();
            timer.Stop();
            Console.WriteLine("Part2: Accumulator with fixed code: {0}, executed in {1}ms", execution.Accumulator, timer.Elapsed.TotalMilliseconds);
        }
    }
}
