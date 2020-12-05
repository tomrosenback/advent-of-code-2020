using Xunit;
using Day5;
using System.Linq;
using System.Collections.Generic;

namespace XUnitTests
{
    public class Day5UnitTests
    {
        [Fact]
        public void GetTickets()
        {
            var tickets = Application.GetTickets("day5-input.txt");
            Assert.Equal(975, tickets.Count());
        }

        [Fact]
        public void TestTickets()
        {
            var tickets = Application.GetTickets("day5-test.txt");
            Assert.Equal(4, tickets.Count());

            Assert.Equal("BBFFBBFRLL", tickets.Last().TicketId);

            var seats = new List<Seat>()
            {
                new Seat() { Row = 44, Column = 5, SeatIdValidation = 357 },
                new Seat() { Row = 70, Column = 7, SeatIdValidation = 567 },
                new Seat() { Row = 14, Column = 7, SeatIdValidation = 119 },
                new Seat() { Row = 102, Column = 4, SeatIdValidation = 820 },
            };

            Assert.Equal(seats.Count, tickets.Count());

            for (int i = 0; i < tickets.Count(); i++)
            {
                var ticketSeat = tickets.ElementAt(i).GetSeat();
                var seat = seats.ElementAt(i);

                Assert.Equal(expected: seat.Row, ticketSeat.Row);
                Assert.Equal(expected: seat.Column, ticketSeat.Column);
                Assert.Equal(expected: seat.SeatIdValidation, ticketSeat.SeatId);
            }
        }
    }
}
