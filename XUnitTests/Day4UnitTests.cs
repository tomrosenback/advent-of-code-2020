using Day4;
using Helpers;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTests
{
    public class Day4UnitTests
    {
        [Fact]
        public void GetPassportsPart1()
        {
            var app = new Application();
            var passports = app.GetPassportsPart1("day4-test.txt");

            Assert.Equal(4, passports.Count());

            Assert.True(passports.ElementAt(0).IsValid);
            Assert.False(passports.ElementAt(1).IsValid);
            Assert.True(passports.ElementAt(2).IsValid);
            Assert.False(passports.ElementAt(3).IsValid);
        }

        [Fact]
        public void GetPassportsPart2Valid()
        {
            var app = new Application();
            var passports = app.GetPassportsPart2("day4-test-part2-valid.txt");

            Assert.Equal(4, passports.Count());

            Assert.Equal(4, passports.Where(p => p.IsValid).Count());
        }

        [Fact]
        public void GetPassportsPart2Invalid()
        {
            var app = new Application();
            var passports = app.GetPassportsPart2("day4-test-part2-invalid.txt");

            Assert.Equal(4, passports.Count());

            Assert.Equal(4, passports.Where(p => !p.IsValid).Count());
        }

        [Fact]
        public void GetPassportRows()
        {
            IEnumerable<string> lines = HelperMethods.ReadFile("day4-test.txt");
            Assert.Equal(13, lines.Count());
        }

    }
}
