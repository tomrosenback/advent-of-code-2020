using Day14;
using Xunit;

namespace XUnitTests
{
    public class Day14UnitTests
    {
        [Fact]
        public void DecodeData()
        {
            var sum = Application.DecodeData("day14-test.txt");
            Assert.Equal((ulong)165, sum);
        }

        [Fact]
        public void DecodeAddress()
        {
            var sum = Application.DecodeAddress("day14-test-2.txt");
            Assert.Equal((ulong)208, sum);
        }
    }
}
