using System;
using System.Diagnostics;

namespace Day11
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Advent of code 2020 - day 11");

            var timer = new Stopwatch();
            timer.Start();

            var app = new Application("day11-input.txt");
            
            timer.Stop();
            Console.WriteLine("Load seat configuration took {0}ms", timer.Elapsed.TotalMilliseconds);

            timer.Restart();
            app.FillSeatsByNearestAdjacent();
            timer.Stop();
            Console.WriteLine("Part1: Seat occupation stabilized with : {0} filled seats, found in {1}ms", app.NumberOfSeatsOccupied, timer.Elapsed.TotalMilliseconds);

            timer.Restart();
            app.FillSeatsByAnyAdjacent();
            timer.Stop();
            Console.WriteLine("Part2: Seat occupation stabilized with : {0} filled seats, found in {1}ms", app.NumberOfSeatsOccupied, timer.Elapsed.TotalMilliseconds);
        }
    }
}
