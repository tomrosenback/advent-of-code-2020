using Day13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTests
{
    public class Day13UnitTests
    {
        [Fact]
        public void FindFirstDepartingBus()
        {
            var firstDeparture = Application.GetFirstDepartingBus("day13-test.txt");
            Assert.Equal((ulong)295, firstDeparture);
        }

        [Theory]
        [InlineData("17,x,13,19", 3417)]
        [InlineData("67,7,59,61", 754018)]
        [InlineData("67,x,7,59,61", 779210)]
        [InlineData("67,7,x,59,61", 1261476)]
        [InlineData("1789,37,47,1889", 1202161486)]
        public void FindTime(string input, ulong expectedDeparture)
        {
            Assert.Equal(expectedDeparture, Application.GetFirstDepartingBusPart2(input));
        }

    }
}
