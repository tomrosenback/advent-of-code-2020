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
        }

        [Theory]
        [InlineData(0, 44, 5, 357)]
        [InlineData(1, 70, 7, 567)]
        [InlineData(2, 14, 7, 119)]
        [InlineData(3, 102, 4, 820)]
        public void TestTicketSeats(int index, int expectedRow, int expectedColumn, int expectedSeatId)
        {
            var ticket = Application.GetTickets("day5-test.txt").ElementAt(index);
            Assert.Equal(expectedRow, ticket.Row);
            Assert.Equal(expectedColumn, ticket.Column);
            Assert.Equal(expectedSeatId, ticket.SeatId);
        }
    }
}
