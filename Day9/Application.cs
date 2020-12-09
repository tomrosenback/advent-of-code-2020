using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public class Application
    {
        public Application(string file, int preamble)
        {
            Data = HelperMethods.GetRows(file, x => Convert.ToUInt64(x)).ToArray();
            Preamble = preamble;
        }

        public ulong[] Data { get; private set; }
        public int Preamble { get; private set; }

        public ulong FindCorruptData()
        {
            ulong corruptData = 0;

            for (int i = Preamble; i < Data.Length; i++)
            {
                var xmas = Data.Skip(i - Preamble)
                    .Take(Preamble)
                    .OrderByDescending(d => d)
                    .Where(d => d < Data[i])
                    .ToArray();

                var valid = false;

                foreach (var x1 in xmas)
                {
                    foreach (var x2 in xmas.Where(x2 => x2 != x1))
                    {
                        if (x1 + x2 == Data[i])
                        {
                            valid = true;
                            break;
                        }
                    }

                    if (valid)
                    {
                        break;
                    }
                }

                if (!valid)
                {
                    corruptData = Data[i];
                    break;
                }
            }

            return corruptData;
        }

        public ulong FindEncryptionWeakness(ulong expectedSum)
        {
            var min = ulong.MaxValue;
            var max = ulong.MinValue;

            for (int i = 0; i < Data.Length; i++)
            {
                min = Data[i];
                
                ulong sum = Data[i];

                for (int j = i + 1; j < Data.Length && sum <= expectedSum; j++)
                {
                    sum += Data[j];

                    if (Data[j] < min)
                    {
                        min = Data[j];
                    }

                    if (Data[j] > max)
                    {
                        max = Data[j];
                    }

                    if (sum == expectedSum)
                    {
                        break;
                    }

                }

                if (sum == expectedSum)
                {
                    break;
                }
            }

            return min + max;
        }
    }
}
