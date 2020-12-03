using System;
using System.Linq;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of code - day 3");

            var app = new Application();
            var patterns = app.GetPatterns("input.txt");

            var watch = System.Diagnostics.Stopwatch.StartNew();

            var collisions = app.FindCollisions(patterns, new Slope() { X = 3, Y = 1 });
            var count = collisions.Select(c => c).Sum();

            watch.Stop();

            Console.WriteLine("Part 1 traversed in {0}ms, number of hits = {1}", watch.ElapsedMilliseconds, count);

            var slopes = app.GetSlopes("slopes.txt");

            watch.Restart();

            var mult = app.GetMultipliedCollisions(patterns, slopes);

            Console.WriteLine("Part 2 traversed in {0}ms, multiplied hits = {1}", watch.ElapsedMilliseconds, mult);
        }
    }
}
