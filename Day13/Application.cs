using Helpers;
using System;
using System.Linq;

namespace Day13
{
    public class Application
    {
        public static ulong GetFirstDepartingBus(string file)
        {
            var data = HelperMethods.ReadFile(file);

            ulong myDeparture = Convert.ToUInt64(data.First());
            var firstDeparture = data.Last().Split(",")
                .Where(d => d != "x")
                .Select(d => Convert.ToUInt64(d))
                .OrderBy(d => d)
                .Select(d => new
                {
                    Id = d,
                    Time = (myDeparture / d) * d + d
                })
                .OrderBy(d => d.Time).First();

            return firstDeparture.Id * (firstDeparture.Time - myDeparture);
        }

        public static ulong CalculatePart2(string file)
        {
            return GetFirstDepartingBusPart2(HelperMethods.ReadFile(file).Last());
        }

        public static ulong GetFirstDepartingBusPart2(string input)
        {
            ulong firstDeparture = 0;

            var departures = input.Split(",")
                .Select((d, index) => new
                {
                    Id = d == "x" ? 0 : Convert.ToUInt64(d),
                    Offset = (ulong)index
                })
                .Where(d => d.Id > 0)
                .ToList();

            for (ulong i = 1; i < ulong.MaxValue; i++)
            {
                var tmp = departures.Select(d => d.Offset > 0 ? (i + d.Offset) / d.Offset * (i + d.Offset) + (i + d.Offset) : 0);

                if(i == 3417)
                {
                    break;
                }

                if (tmp.Distinct().Count() == 1)
                {
                    firstDeparture = tmp.First();
                    break;
                }
            }

            return firstDeparture;
        }
    }
}
