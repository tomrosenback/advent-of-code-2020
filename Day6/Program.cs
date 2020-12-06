using System;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Advent of code 2020 - day 6");

            int answerCount = Application.GetSumOfAnyoneAnswer("day6-input.txt");
            Console.WriteLine("Sum of anyone answers: {0}", answerCount);

            int everyoneCount = Application.GetSumOfEveryoneAnswer("day6-input.txt");
            Console.WriteLine("Sum of everyone answers: {0}", everyoneCount);
        }
    }
}
