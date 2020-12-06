using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day6;
using Xunit;

namespace XUnitTests
{
    public class Day6UnitTests
    {
        [Fact]
        public void GetGroupAnswers()
        {
            var groups = Application.GetAnswers("day6-test.txt");
            Assert.Equal(5, groups.Count());
        }

        [Fact]
        public void GetAnswerCountOfAnyone()
        {
            var answers = Application.GetSumOfAnyoneAnswer("day6-test.txt");
            Assert.Equal(11, answers);
        }

        [Fact]
        public void GetAnswerCountOfEveryone()
        {
            var answers = Application.GetSumOfEveryoneAnswer("day6-test.txt");
            Assert.Equal(6, answers);
        }

    }
}
