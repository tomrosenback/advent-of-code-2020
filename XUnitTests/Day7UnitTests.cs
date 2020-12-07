using System.Linq;
using Xunit;
using Day7;

namespace XUnitTests
{
    public class Day7UnitTests
    {
        [Fact]
        public void GetBags()
        {
            var app = new Application("day7-test.txt");
            Assert.Equal(9, app.Bags.Count());

            Assert.Equal(3, app.Bags.First().NestedBags.Sum(b => b.MaxAmount));
            Assert.Equal(11, app.Bags.ElementAt(app.Bags.Count() - 3).NestedBags.Sum(b => b.MaxAmount));
        }

        [Theory]
        [InlineData("shiny gold", 4)]
        public void GetParentBagCount(string childbagColor, int possibleParentCount)
        {
            var app = new Application("day7-test.txt");
            var parents = app.GetParentBags(childbagColor);
            Assert.Equal(possibleParentCount, parents.Count());
        }

        [Theory]
        [InlineData("day7-test.txt", "shiny gold", 32)]
        [InlineData("day7-test-part2.txt", "shiny gold", 126)]
        public void GetBagContent(string file, string childbagColor, int contentCount)
        {
            var app = new Application(file);
            var content = app.GetBagContent(childbagColor);
            Assert.Equal(contentCount, content);
        }

    }
}
