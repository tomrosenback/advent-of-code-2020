using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Helpers
{
    public static class HelperMethods
    {
        public static IEnumerable<string> ReadFile(string file)
        {
            return File.ReadLines(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + "\\" + file);
        }

        public static IEnumerable<T> GetRows<T>(string file, Func<string, T> classConstructor, Func<List<string>, string, List<string>> aggregator = null) where T : new()
        {
            var rows = ReadFile(file);

            if(aggregator != null)
            {
                rows = rows.Aggregate(new List<string>(), aggregator);
            }

            var result = from l in rows
                         where l.Trim() != string.Empty
                         select classConstructor(l);

            return result;
        }

        public static T GetRegexGroupValue<T>(GroupCollection grpCollection, string key) where T : IConvertible
        {
            T res = default;

            if (grpCollection.TryGetValue(key, out Group grp))
            {
                try
                {
                    res = (T)Convert.ChangeType(grp.Value, typeof(T));
                }
                catch
                {
                    res = default;
                }
            }

            return res;
        }

        public static T GetRegexMatchValue<T>(MatchCollection matchCollection, string key) where T : IConvertible
        {
            T res = default;

            foreach (Match match in matchCollection)
            {
                if(match.Groups.TryGetValue(key, out Group grp) && grp.Success)
                {
                    try
                    {
                        res = (T)Convert.ChangeType(grp.Value, typeof(T));
                        break;
                    }
                    catch
                    {
                        res = default;
                    }
                }
            }

            return res;
        }
    }
}
