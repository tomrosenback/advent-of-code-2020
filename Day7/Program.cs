using System;
using System.Linq;

namespace Day7
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Advent of code 2020 - day 7");
            string myBagColor = "shiny gold";

            var app = new Application("day7-input.txt");
            var parents = app.GetParentBags(myBagColor);
            Console.WriteLine("'{0}' fits in {1} bags", myBagColor, parents.Count());

            var bagContent = app.GetBagContent(myBagColor);
            Console.WriteLine("'{0}' encloses {1} bags", myBagColor, bagContent);
        }
    }
}
