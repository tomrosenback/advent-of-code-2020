using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Application();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var pwds = app.GetPasswords("input.txt");
            watch.Stop();
            Console.WriteLine("Read input took " + watch.ElapsedMilliseconds + "ms");

            watch.Restart();
            var res1 = app.ValidatePasswords(pwds, PasswordPolicy.OLD);
            watch.Stop();
            Console.WriteLine("Validated passwords in {0}ms, number of valid passwords = {1}", watch.ElapsedMilliseconds, res1);

            watch.Restart();
            var res2 = app.ValidatePasswords(pwds, PasswordPolicy.NEW);
            watch.Stop();
            Console.WriteLine("Validated passwords in {0}ms, number of valid passwords = {1}", watch.ElapsedMilliseconds, res2);
            
        }

    }
}
