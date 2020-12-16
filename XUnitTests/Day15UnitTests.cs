using Day15;
using System.Linq;
using Xunit;

namespace XUnitTests
{
    public class Day15UnitTests
    {
        [Theory]
        [InlineData(new int[] { 0, 3, 6 }, 436, 175594)]
        [InlineData(new int[] { 1, 3, 2 }, 1, 2578)]
        [InlineData(new int[] { 2, 1, 3 }, 10, 3544142)]
        [InlineData(new int[] { 1, 2, 3 }, 27, 261214)]
        [InlineData(new int[] { 2, 3, 1 }, 78, 6895259)]
        [InlineData(new int[] { 3, 2, 1 }, 438, 18)]
        [InlineData(new int[] { 3, 1, 2 }, 1836, 362)]
        public void PlayGame(int[] data, int expectedResult, int expectedResult2)
        {
            var app = new Application();
            int result = app.PlayGame(data.ToList());
            Assert.Equal(expectedResult, result);
            int result2 = app.PlayGame(data.ToList(), 30000000);
            Assert.Equal(expectedResult2, result2);
        }
    }
}
