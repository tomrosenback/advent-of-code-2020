using Day11;
using System.Linq;
using Xunit;

namespace XUnitTests
{
    public class Day11UnitTests
    {
        [Fact]
        public void GetPositionConfiguration()
        {
            var app = new Application("day11-test.txt");
            Assert.Equal(10, app.Rows.Count);

            var position = app.Rows.First().First();

            Assert.True(position.IsSeat);
            Assert.False(position.Occupied);
            
            position = app.Rows.Last().Last();
            Assert.True(position.IsSeat);
            Assert.False(position.Occupied);
        }

        [Fact]
        public void GetOccupiedByNearestAdjacentOnly()
        {
            var app = new Application("day11-test.txt");
            Assert.Equal(0, app.NumberOfSeatsOccupied);
            app.FillSeatsByNearestAdjacent();
            Assert.Equal(37, app.NumberOfSeatsOccupied);
        }

        [Fact]
        public void GetOccupiedByAnyAdjacent()
        {
            var app = new Application("day11-test.txt");
            Assert.Equal(0, app.NumberOfSeatsOccupied);
            app.FillSeatsByAnyAdjacent();
            Assert.Equal(26, app.NumberOfSeatsOccupied);
        }
    }
}
