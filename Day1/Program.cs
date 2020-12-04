using System;
using System.IO;
using System.Linq;

namespace AdventOfCode_2020_1
{
    class Program
    {
        private const string inputFile = "day1-input.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of code 2020 day 1!");

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var report = File.ReadAllText(AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.LastIndexOf(AppDomain.CurrentDomain.FriendlyName)) + inputFile)?
                .Split("\r\n")
                .Select(x => Convert.ToInt32(x))
                .OrderBy(x => x);

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

            watch.Restart();
            var foundSolution = false;

            foreach (var x in report)
            {
                foreach (var y in report)
                {
                    var pair = x + y;

                    if (pair > 2020)
                    {
                        break;
                    }

                    foreach (var z in report)
                    {
                        var triple = pair + z;
                        if (triple > 2020)
                        {
                            break;
                        }
                        else if (triple == 2020)
                        {
                            watch.Stop();
                            Console.WriteLine("Part 2, alternative solution took: " + watch.ElapsedMilliseconds + "ms");
                            Console.WriteLine("{0} + {1} + {2} = 2020, multiplied = {3}", x, y, z, x * y * z);
                            foundSolution = true;
                            break;
                        }
                    }

                    if(foundSolution)
                    {
                        break;
                    }
                }

                if(foundSolution)
                {
                    break;
                }
            }
        }
    }
}
