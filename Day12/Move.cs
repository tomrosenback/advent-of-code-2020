using System;

namespace Day12
{
    public class Move
    {
        public Move()
        {

        }

        public Move(string input)
        {
            /*
            
            Action N means to move north by the given value.
            Action S means to move south by the given value.
            Action E means to move east by the given value.
            Action W means to move west by the given value.
            Action L means to turn left the given number of degrees.
            Action R means to turn right the given number of degrees.
            Action F means to move forward by the given value in the direction the ship is currently facing.

             */

            Type = input.Substring(0, 1);
            Amount = Convert.ToInt32(input.Substring(1));
        }

        public string Type { get; set; }
        public int Amount { get; set; }
    }
}
