using System;
using System.Collections.Generic;
using System.Text;

namespace Day8
{
    public class Operation : ICloneable<Operation>
    {
        public Operation()
        {

        }

        public Operation(string operation)
        {
            var tmp = operation.Split(" ");
            Instruction = tmp[0];
            Value = Convert.ToInt32(tmp[1]);
        }

        public string Instruction { get; set; }
        public int Value { get; set; }
        public int Executions { get; set; }

        public Operation Clone()
        {
            return new Operation()
            {
                Instruction = Instruction,
                Value = Value
            };
        }
    }
    public interface ICloneable<T>
    {
        T Clone();
    }
}
