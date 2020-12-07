using Helpers;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day7
{
    public class Bag
    {
        public Bag()
        {
            MaxAmount = 1;
            NestedBags = new List<Bag>();
        }

        public Bag(string bag)
        {
            // light red bags contain 1 bright white bag, 2 muted yellow bags.

            var tmp = bag.Split("bags contain");
            Color = tmp[0].Trim();
            MaxAmount = 1;
            NestedBags = new List<Bag>();

            Regex regex = new Regex(@"(?<nestedbag>(?<maxamount>\d+) (?<color>[a-z]+ [a-z]+) bag)");

            foreach (Match match in regex.Matches(tmp[1].Trim()))
            {
                NestedBags.Add(new Bag()
                {
                    Color = HelperMethods.GetRegexGroupValue<string>(match.Groups, "color"),
                    MaxAmount = HelperMethods.GetRegexGroupValue<int>(match.Groups, "maxamount")
                });
            }

        }

        public int MaxAmount { get; set; }
        public string Color { get; set; }
        public List<Bag> NestedBags { get; set; }
    }
}
