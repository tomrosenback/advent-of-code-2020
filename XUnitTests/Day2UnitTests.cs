using Day2;
using System.Linq;
using Xunit;

namespace XUnitTests
{
    public class Day2UnitTests
    {
        [Fact]
        public void ReadFile()
        {
            var pwds = new Application().GetPasswords("day2-test.txt");
            Assert.Equal(3, pwds.Count());

            var pwd = pwds.First();

            Assert.Equal(1, pwd.LowerLimit);
            Assert.Equal(3, pwd.UpperLimit);
            Assert.Equal("a", pwd.RequiredLetter);
            Assert.Equal("abcde", pwd.Password);
        }

        [Fact]
        public void OldPolicy()
        {
            var app = new Application();
            var pwds = new Application().GetPasswords("day2-test.txt");

            Assert.Equal(2, app.ValidatePasswords(pwds, PasswordPolicy.OLD));
        }

        [Fact]
        public void NewPolicy()
        {
            var app = new Application();
            var pwds = new Application().GetPasswords("day2-test.txt");

            Assert.Equal(1, app.ValidatePasswords(pwds, PasswordPolicy.NEW));
        }

    }
}
