using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day8;
using Xunit;

namespace XUnitTests
{
    public class Day8UnitTests
    {
        [Theory]
        [InlineData("day8-test.txt", 9, "acc", 6)]
        [InlineData("day8-input.txt", 633, "jmp", 1)]
        public void GetOperations(string file, int opCount, string instruction, int value)
        {
            var app = new Application(file);
            Assert.Equal(opCount, app.Operations.Length);

            var operation = app.Operations.Last();
            Assert.Equal(instruction, operation.Instruction);
            Assert.Equal(value, operation.Value);
        }

        [Fact]
        public void ExecuteOperations()
        {
            var app = new Application("day8-test.txt");
            var execution = app.ExecuteOperations();
            Assert.Equal(5, execution.Accumulator);
        }

        [Fact]
        public void FixOperations()
        {
            var app = new Application("day8-test.txt");
            var execution = app.FixBrokenExecution();

            Assert.True(execution.Completed);
            Assert.Equal(8, execution.Accumulator);
        }
    }
}
