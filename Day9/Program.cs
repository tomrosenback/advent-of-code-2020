using System;
using System.Diagnostics;

namespace Day9
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Advent of code 2020 - day 9");

            var timer = new Stopwatch();
            var app = new Application("day9-input.txt", 25);
    
            timer.Start();
            var corruptData = app.FindCorruptData();
            timer.Stop();
            Console.WriteLine("Part1: Corrupt data: {0}, found in {1}ms", corruptData, timer.Elapsed.TotalMilliseconds);

            timer.Restart();
            var weakness = app.FindEncryptionWeakness(corruptData);
            Console.WriteLine("Part1: Weakness: {0}, found in {1}ms", weakness, timer.Elapsed.TotalMilliseconds);

        }
    }
}
