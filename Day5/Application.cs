using Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Day5
{
    public class Application
    {
        public static IEnumerable<Ticket> GetTickets(string file)
        {
            IEnumerable<Ticket> tickets = HelperMethods.GetRows(file, ticketId =>
            {
                return new Ticket(ticketId.Substring(0, 10));
            });

            return tickets;
        }

        public static int FindMySeat(IEnumerable<Ticket> tickets)
        {
            tickets = tickets.OrderByDescending(t => t.SeatId);
            int seat = 0;

            for (int i = 1; i < tickets.Count(); i++)
            {
                var prevSeat = tickets.ElementAt(i-1).SeatId;
                var currSeat = tickets.ElementAt(i).SeatId;

                if (prevSeat - currSeat > 1 && prevSeat - currSeat <= 2)
                {
                    seat = currSeat + 1;
                }          
            }

            return seat;
        }
    }
}
