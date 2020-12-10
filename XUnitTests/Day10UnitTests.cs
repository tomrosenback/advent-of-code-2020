using Xunit;
using Day10;

namespace XUnitTests
{
    public class Day10UnitTests
    {

        [Theory]
        [InlineData("day10-test.txt", 35)]
        [InlineData("day10-test-2.txt", 220)]
        public void FitAdapters(string file, int expectedJoltMultiplier)
        {
            var app = new Application(file);
            var multiplier = app.FitAdapters();
            Assert.Equal(expectedJoltMultiplier, multiplier);
        }

        [Theory]
        [InlineData("day10-test.txt", 8)]
        [InlineData("day10-test-2.txt", 19208)]
        public void FindCombinations(string file, ulong expectedCombinations)
        {
            var app = new Application(file);
            var combinations = app.GetPossibleAdapterConfigurations();
            Assert.Equal(expectedCombinations, combinations);
        }
    }
}
