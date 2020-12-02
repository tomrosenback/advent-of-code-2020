using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Day2
{
    public class PasswordCheck
    {
        public PasswordCheck(string passwordLine)
        {
            var regex = new Regex(@"(?<lower>[\d]+)-(?<upper>[\d]+) (?<required>[a-z]): (?<password>[a-z]+)");
            var match = regex.Match(passwordLine);

            if (match.Groups.Count == 5)
            {
                LowerLimit = Convert.ToInt32(GetGroupValue(match.Groups, "lower"));
                UpperLimit = Convert.ToInt32(GetGroupValue(match.Groups, "upper"));

                RequiredLetter = GetGroupValue(match.Groups, "required");
                Password = GetGroupValue(match.Groups, "password");
            }
        }

        public string RequiredLetter { get; set; }
        public string Password { get; set; }
        public int LowerLimit { get; set; }
        public int UpperLimit { get; set; }

        private string GetGroupValue(GroupCollection grpCollection, string key)
        {
            string res = string.Empty;

            if (grpCollection.TryGetValue(key, out Group grp))
            {
                res = grp.Value;
            }

            return res;
        }
    }
}
