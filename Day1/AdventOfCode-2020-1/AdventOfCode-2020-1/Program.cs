using System;
using System.IO;
using System.Linq;

namespace AdventOfCode_2020_1
{
    class Program
    {
        private const string inputFile = "input.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of code 2020 day 1!");

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var report = File.ReadAllText(AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.LastIndexOf(AppDomain.CurrentDomain.FriendlyName)) + inputFile)?.Split("\r\n").Select(x => Convert.ToInt32(x));
            watch.Stop();
            Console.WriteLine("Read input took " + watch.ElapsedMilliseconds + "ms");

            watch.Restart();
            var result = (from x in report
                          from y in report
                          where y != x && x + y == 2020
                          select new { x, y, m = x * y }).First();

            watch.Stop();

            Console.WriteLine("Part 1 calculation took: " + watch.ElapsedMilliseconds + "ms");
            Console.WriteLine(result);

            watch.Restart();
            var result2 = (from x in report
                          from y in report
                          from z in report
                          where x != y && y != z && z != x && x + y + z == 2020
                          select new { x, y, z, m = x * y * z }).First();

            watch.Stop();

            Console.WriteLine("Part 2 calculation took: " + watch.ElapsedMilliseconds + "ms");
            Console.WriteLine(result2);
        }
    }
}
