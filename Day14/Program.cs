using System;
using System.Diagnostics;

namespace Day14
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Advent of code 2020 - day 14");

            var timer = new Stopwatch();
            timer.Start();

            var sum = Application.DecodeData("day14-input.txt");

            timer.Stop();
            Console.WriteLine("Part1: DecodeData Sum: {0}, found in {1}ms", sum, timer.Elapsed.TotalMilliseconds);

            timer.Restart();
            sum = Application.DecodeAddress("day14-input.txt");

            timer.Stop();
            Console.WriteLine("Part2: DecodeAddress Sum: {0}, found in {1}ms", sum, timer.Elapsed.TotalMilliseconds);



        }
    }
}
