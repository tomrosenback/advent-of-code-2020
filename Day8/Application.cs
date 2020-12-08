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
            NumOfOperations = Operations.Length;
        }

        public Operation[] Operations { get; private set; }
        public int NumOfOperations { get; private set; }

        public Execution FixBrokenExecution()
        {
            Execution execution = Operations
                .Select((item, index) => new { Index = index, Item = item })
                .Where(o => o.Item.Instruction == "jmp" || o.Item.Instruction == "nop")
                .Select(i => ExecuteOperations(i.Index)).FirstOrDefault(e => e.Completed);

            return execution;
        }

        public Execution ExecuteOperations(int swapIndex = -1)
        {
            var execution = new Execution();
            int step;
            int[] operationExecution = new int[NumOfOperations];
            bool completed = true;

            for (int i = 0; i < NumOfOperations; i += step)
            {
                step = 1;
                var currentOperation = Operations[i];
                operationExecution[i]++;

                if (operationExecution[i] > 1)
                {
                    completed = false;
                    break;
                }

                string instruction = currentOperation.Instruction;

                if (i == swapIndex)
                {
                    instruction = instruction == "jmp" ? "nop" : "jmp";
                }

                switch (instruction)
                {
                    case "acc":
                        execution.Accumulator += currentOperation.Value;
                        break;
                    case "jmp":
                        if (currentOperation.Value != 0)
                        {
                            step = currentOperation.Value;
                        }
                        break;
                    default:
                        break;
                }


            }

            execution.Completed = completed; //  operationExecution.Max(o => o) == 1;
            return execution;
        }
    }
}
