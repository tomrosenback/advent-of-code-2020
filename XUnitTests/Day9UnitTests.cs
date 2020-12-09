using Xunit;
using Day9;

namespace XUnitTests
{
    public class Day9UnitTests
    {
        [Theory]
        [InlineData("day9-test.txt", 5, 127)]
        public void FindCorruptData(string file, int preamble, ulong expectedCorruptedData)
        {
            var app = new Application(file, preamble);
            ulong corruptData = app.FindCorruptData();
            Assert.Equal(expectedCorruptedData, corruptData);
        }

        [Theory]
        [InlineData("day9-test.txt", 5, 127, 62)]
        public void FindEncryptionWeakness(string file, int preamble, ulong corruptedData, ulong expectedWeakness)
        {
            var app = new Application(file, preamble);
            ulong weakness = app.FindEncryptionWeakness(corruptedData);
            Assert.Equal(expectedWeakness, weakness);
        }
    }
}
