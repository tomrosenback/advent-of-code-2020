using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Day3
{
    public class Slope
    {
        public Slope()
        {

        }

        public Slope(string input)
        {
            var regex = new Regex(@"Right (?<x>[\d]+), down (?<y>[\d]+)\, test: (?<test>[\d]+)");
            var match = regex.Match(input);

            if (match.Groups.Count == 4)
            {
                X = GetGroupValue(match.Groups, "x");
                Y = GetGroupValue(match.Groups, "y");
                Test = GetGroupValue(match.Groups, "test");
            }
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Test { get; set; }


        private int GetGroupValue(GroupCollection grpCollection, string key)
        {
            int res = 0;

            if (grpCollection.TryGetValue(key, out Group grp))
            {
                res = Convert.ToInt32(grp.Value);
            }

            return res;
        }

    }
}
