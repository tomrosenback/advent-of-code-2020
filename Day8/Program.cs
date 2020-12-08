using System;

namespace Day8
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Advent of code 2020 - day 8");

            var app = new Application("day8-input.txt");
            var execution = app.ExecuteOperations(app.Operations);
            Console.WriteLine("Part1: Accumulator before infinite-loop: {0}", execution.Accumulator);

            execution = app.FixBrokenExecution();
            Console.WriteLine("Part2: Accumulator with fixed code: {0}", execution.Accumulator);
        }
    }
}
