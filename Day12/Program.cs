using System;
using System.Diagnostics;

namespace Day12
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Advent of code 2020 - day 12");

            var timer = new Stopwatch();
            timer.Start();

            var pos = Application.MoveShip("day12-input.txt", false);

            timer.Stop();
            Console.WriteLine("Part1: Ship position : {0}, found in {1}ms", pos, timer.Elapsed.TotalMilliseconds);

            timer.Restart();

            var pos2 = Application.MoveShip("day12-input.txt", true);

            timer.Stop();
            Console.WriteLine("Part2: Ship position: {0}, found in {1}ms", pos2, timer.Elapsed.TotalMilliseconds);

        }
    }
}
