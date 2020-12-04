using Helpers;
using Day3;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTests
{
    public class CommonUnitTests
    {
        [Fact]
        public void ReadFile()
        {
            var rows = HelperMethods.ReadFile("day2-test.txt");
            Assert.Equal(3, rows.Count());
        }

        [Fact]
        public void GetPatternRows()
        {
            IEnumerable<Pattern> patterns = HelperMethods.GetRows("day3-test.txt", x =>
            {
                return new Pattern(x);
            });

            Assert.Equal(11, patterns.Count());
            Assert.Equal(".#..#...#.#", patterns.Last().Row);
        }




    }
}
