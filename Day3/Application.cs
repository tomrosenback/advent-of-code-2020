using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;

namespace Day3
{
    public class Application
    {

        public IEnumerable<Pattern> GetPatterns(string file)
        {
            var patterns = HelperMethods.GetRows(file, x =>
            {
                return new Pattern(x);
            });

            return patterns;
        }

        public IEnumerable<Slope> GetSlopes(string file)
        {
            var slopes = from l in HelperMethods.ReadFile(file)
                         where l.Trim() != string.Empty
                         select new Slope(l);

            return slopes;
        }

        public List<long> FindCollisions(IEnumerable<Pattern> patterns, Slope slope)
        {
            string tree = "#";
            var hits = (from p in patterns select (long)0).ToList();

            for (int y = 0, x = 0; y < patterns.Count(); y += slope.Y, x += slope.X)
            {
                var p = patterns.ElementAt(y).Row;
                                
                if (p.Substring(x % p.Length, 1) == tree)
                {
                    hits[y]++;
                }
            }

            return hits;
        }

        public long GetMultipliedCollisions(IEnumerable<Pattern> patterns, IEnumerable<Slope> slopes)
        {
            long mult = 1;

            foreach (var slope in slopes)
            {
                var hits = FindCollisions(patterns, slope).Select(c => c).Sum();
                mult *= hits;
            }

            return mult;
        }
    }
}
