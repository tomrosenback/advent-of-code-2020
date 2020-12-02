using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day2
{
    class Program
    {
        private const string inputFile = "input.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of code 2020 day 2!");
            var validPasswords = 0;

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var passwords = File.ReadAllText(AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.LastIndexOf(AppDomain.CurrentDomain.FriendlyName)) + inputFile)?
                .Split("\n");

            watch.Stop();
            Console.WriteLine("Read input took " + watch.ElapsedMilliseconds + "ms");

            watch.Restart();

            foreach (var pp in passwords)
            {
                if (string.IsNullOrEmpty(pp.Trim()))
                {
                    continue;
                }

                var tmp = pp.Split(':');
                var policy = tmp[0]?.Split(' ');
                var requiredLetter = policy[1].Trim();
                var requiredOccurence = policy[0].Trim().Split('-').Select(o => Convert.ToInt32(o)).ToList();
                var pwd = tmp[1]?.Trim();
                var occurence = pwd.Count(l => l == char.Parse(requiredLetter));

                if (occurence >= requiredOccurence[0] && occurence <= requiredOccurence[1])
                {
                    validPasswords++;
                }
                else
                {
                    Console.WriteLine(pp);
                }
            }

            watch.Stop();
            Console.WriteLine("Part 1, valid passwords: {0}, validated in {1}ms", validPasswords, watch.ElapsedMilliseconds);

            watch.Restart();
            validPasswords = 0;

            foreach (var pp in passwords)
            {
                if (string.IsNullOrEmpty(pp.Trim()))
                {
                    continue;
                }

                var tmp = pp.Split(':');
                var policy = tmp[0]?.Split(' ');
                var requiredLetter = policy[1].Trim();
                var requiredPositions = policy[0].Trim().Split('-').Select(o => Convert.ToInt32(o) - 1).ToList();
                var pwd = tmp[1]?.Trim();
                var matches = (pwd.Substring(requiredPositions[0], 1) == requiredLetter ? 1 : 0) + (pwd.Substring(requiredPositions[1], 1) == requiredLetter ? 1 : 0);

                if (matches == 1)
                {
                    validPasswords++;
                }
                else
                {
                    Console.WriteLine(pp);
                }
            }

            watch.Stop();
            Console.WriteLine("Part 2, valid passwords: {0}, validated in {1}ms", validPasswords, watch.ElapsedMilliseconds);
        }

    }
}
