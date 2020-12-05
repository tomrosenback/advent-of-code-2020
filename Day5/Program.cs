using System;
using System.Linq;

namespace Day5
{
    public class Program
    {
        static void Main()
        {
            var tickets = Application.GetTickets("day5-input.txt");

            var highestId = tickets.Select(t => t.SeatId).Max(t => t);
            Console.WriteLine("Seat with highest id: {0}", highestId);

            var seat = Application.FindMySeat(tickets);
            Console.WriteLine("My seat id: {0}", seat);
        }
    }
}
