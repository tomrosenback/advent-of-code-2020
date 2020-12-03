using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day3
{
    public class Application
    {
        public IEnumerable<string> ReadFile(string file)
        {
            return File.ReadLines(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + "\\" + file);
        }

        public IEnumerable<string> GetPatterns(string file)
        {
            var patterns = from l in ReadFile(file)
                           where l.Trim() != string.Empty
                           select l;

            return patterns;
        }

        public IEnumerable<Slope> GetSlopes(string file)
        {
            var slopes = from l in ReadFile(file)
                         where l.Trim() != string.Empty
                         select new Slope(l);

            return slopes;
        }

        public List<long> FindCollisions(IEnumerable<string> patterns, Slope slope)
        {
            string tree = "#";
            var hits = (from p in patterns select (long)0).ToList();

            for (int y = 0, x = 0; y < patterns.Count(); y += slope.Y, x += slope.X)
            {
                var p = patterns.ElementAt(y);
                                
                if (p.Substring(x % p.Length, 1) == tree)
                {
                    hits[y]++;
                }
            }

            return hits;
        }

        public long GetMultipliedCollisions(IEnumerable<string> patterns, IEnumerable<Slope> slopes)
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
