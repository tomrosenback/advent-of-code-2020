using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day4
{
    public class Program
    {
        static void Main()
        {
            var app = new Application();

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var part1 = app.GetPassportsPart1("day4-input.txt");
            var validPasswords = part1.Count(p => p.IsValid);

            //foreach (var passport in passports.Where(p => !p.IsValid).Select(p => p))
            //{
            //    foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(passport))
            //    {
            //        string name = descriptor.Name;
            //        object value = descriptor.GetValue(passport);
            //        Console.Write("{0}\t{1}\t", name, value);
            //    }

            //    Console.WriteLine("\n");
            //}

            watch.Stop();
            Console.WriteLine("Part 1 traversed in {0}ms, number of passwords = {1} of which {2} is valid", watch.ElapsedMilliseconds, part1.Count(), validPasswords);

            var part2 = app.GetPassportsPart2("day4-input.txt");
            validPasswords = part2.Count(p => p.IsValid);

            foreach (var passport in part2.Where(p => p.IsValid).Select(p => p))
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(passport))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(passport);
                    Console.Write("{0}\t{1}\t", name, value);
                }

                Console.WriteLine("");
            }

            watch.Stop();


            Console.WriteLine("Part 2 traversed in {0}ms, number of passwords = {1} of which {2} is valid", watch.ElapsedMilliseconds, part2.Count(), validPasswords);


        }



    }
}
