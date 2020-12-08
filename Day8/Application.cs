using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day8
{
    public class Application
    {
        public Application()
        {

        }

        public Application(string file)
        {
            Operations = HelperMethods.GetRows(file, x => new Operation(x)).ToArray();
        }

        public Operation[] Operations { get; private set; }

        public Execution FixBrokenExecution()
        {
            Execution execution = new Execution();

            var possibleErrors = Operations
                .Select((item, index) => new { Index = index, Item = item })
                .Where(o => o.Item.Instruction == "jmp" || o.Item.Instruction == "nop")
                .Select(i => i.Index);

            foreach (var errorIndex in possibleErrors)
            {
                Operation[] operations = Operations.Select(o => (Operation)o.Clone()).ToArray();
                operations[errorIndex].Instruction = operations[errorIndex].Instruction == "jmp" ? "nop" : "jmp";
                execution = ExecuteOperations(operations);

                if (execution.Completed)
                {
                    break;
                }
            }

            return execution;
        }

        public Execution ExecuteOperations(Operation[] operations)
        {
            var execution = new Execution();
            int step;

            for (int i = 0; i < operations.Length; i += step)
            {
                step = 1;
                operations[i].Executions++;

                if (operations[i].Executions > 1)
                {
                    break;
                }

                switch (operations[i].Instruction)
                {
                    case "acc":
                        execution.Accumulator += operations[i].Value;
                        break;
                    case "jmp":
                        if (operations[i].Value != 0)
                        {
                            step = operations[i].Value;
                        }
                        break;
                    default:
                        break;
                }

                
            }

            execution.Completed = operations.Max(o => o.Executions) == 1;
            return execution;
        }
    }
}
