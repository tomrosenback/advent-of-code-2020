using Helpers;
using System.Collections.Generic;

namespace Day4
{
    public class Application
    {
        public IEnumerable<PassportPart1> GetPassportsPart1(string file)
        {
            IEnumerable<PassportPart1> passports = HelperMethods.GetRows(file, x =>
            {
                return new PassportPart1(x);
            },
            (res, current) =>
            {
                if (res.Count > 0)
                {
                    if (current != "")
                    {
                        res[^1] += " " + current;
                    }
                    else
                    {
                        res.Add(" ");
                    }
                }
                else
                {
                    res.Add(current);
                }

                return res;
            });

            return passports;
        }

        public IEnumerable<PassportPart2> GetPassportsPart2(string file)
        {
            IEnumerable<PassportPart2> passports = HelperMethods.GetRows(file, x =>
            {
                return new PassportPart2(x);
            },
            (res, current) =>
            {
                if (res.Count > 0)
                {
                    if (current != "")
                    {
                        res[^1] += " " + current;
                    }
                    else
                    {
                        res.Add(" ");
                    }
                }
                else
                {
                    res.Add(current);
                }

                return res;
            });

            return passports;
        }
    }
}
