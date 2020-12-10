using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    public class Application
    {
        private readonly int _maxJoltDiff = 3;
        public Dictionary<int, ulong> Cache { get; set; }

        public Application()
        {
        }

        public Application(string file)
        {
            Adapters = HelperMethods.GetRows(file, x => Convert.ToInt32(x)).OrderBy(a => a);
            MaxAdapterRating = Adapters.Last();
            Cache = new Dictionary<int, ulong>();
        }

        private IEnumerable<int> Adapters { get; set; }
        public int MaxAdapterRating { get; private set; }

        public int FitAdapters()
        {
            var min = 0;
            var max = 0;
            var prevAdapter = 0;

            foreach (var adapter in Adapters)
            {
                switch (adapter - prevAdapter)
                {
                    case 1:
                        min++;
                        break;
                    case 3:
                        max++;
                        break;
                    default:
                        break;
                }

                prevAdapter = adapter;
            }

            return min * (max + 1);
        }

        public ulong GetPossibleAdapterConfigurations(int prevAdapter = 0)
        {
            ulong combinations = 0;
            var start = prevAdapter;

            if (start == 0)
            {
                Cache.Clear();
            }
            
            if(Cache.ContainsKey(prevAdapter))
            {
                Cache.TryGetValue(prevAdapter, out combinations);
                return combinations;
            }

            foreach (var adapter in Adapters.Where(a => a > prevAdapter && a - prevAdapter <= _maxJoltDiff))
            {
                var diff = adapter - start;

                if (adapter == MaxAdapterRating)
                {
                    // reached end
                    combinations++;
                }
                else if (diff <= _maxJoltDiff)
                {
                    combinations += GetPossibleAdapterConfigurations(adapter);
                }
            }

            Cache.Add(prevAdapter, combinations);
            return combinations;
        }

    }
}
