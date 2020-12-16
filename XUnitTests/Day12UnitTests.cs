using Day12;
using Xunit;

namespace XUnitTests
{
    public class Day12UnitTests
    {
        [Fact]
        public void MoveShip()
        {
            var pos = Application.MoveShip("day12-test.txt", false);
            Assert.Equal(25, pos);
        }

        [Fact]
        public void MoveShipByWayPoint()
        {
            var pos = Application.MoveShip("day12-test.txt", true);
            Assert.Equal(286, pos);
        }
    }
}
