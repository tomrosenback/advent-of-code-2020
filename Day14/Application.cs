using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14
{
    public class Application
    {
        public static ulong DecodeData(string file)
        {
            string mask = string.Empty;
            Dictionary<int, ulong> memory = new Dictionary<int, ulong>();

            foreach (var row in HelperMethods.ReadFile(file))
            {
                int address = 0;
                char[] val = null;

                if (row.StartsWith("mask = "))
                {
                    mask = row.Replace("mask = ", "");
                }
                else if (row.StartsWith("mem["))
                {
                    var tmp = row.Replace("mem[", "");
                    address = Convert.ToInt32(tmp.Substring(0, tmp.IndexOf("]")));
                    val = Convert.ToString(Convert.ToInt32(tmp.Substring(tmp.IndexOf("= ") + 2)), 2).PadLeft(mask.Length, '0').ToCharArray();
                }

                if (val != null && val.Length == mask.Length)
                {
                    foreach (var maskBit in mask.Select((b, idx) => new { Index = idx, Val = b }).Where(b => b.Val != 'X'))
                    {
                        val[maskBit.Index] = maskBit.Val;
                    }

                    if (address >= 0)
                    {
                        if (memory.ContainsKey(address))
                        {
                            memory[address] = Convert.ToUInt64(new string(val), 2);
                        }
                        else
                        {
                            memory.Add(address, Convert.ToUInt64(new string(val), 2));
                        }
                    }
                }
            }

            return memory.Select(m => m.Value).Aggregate((a, b) => a + b);
        }

        public static ulong DecodeAddress(string file)
        {
            string mask = string.Empty;
            Dictionary<ulong, ulong> memory = new Dictionary<ulong, ulong>();

            foreach (var row in HelperMethods.ReadFile(file))
            {
                char[] address = null;
                ulong val = 0;

                if (row.StartsWith("mask = "))
                {
                    mask = row.Replace("mask = ", "");
                }
                else if (row.StartsWith("mem["))
                {
                    var tmpMem = row.Replace("mem[", "");
                    address = Convert.ToString(Convert.ToInt32(tmpMem.Substring(0, tmpMem.IndexOf("]"))), 2).PadLeft(mask.Length, '0').ToCharArray();
                    val = Convert.ToUInt64(tmpMem.Substring(tmpMem.IndexOf("= ") + 2));

                    foreach (var maskBit in mask.Select((b, idx) => new { Index = idx, Val = b }))
                    {
                        if (maskBit.Val == '1' || maskBit.Val == 'X')
                        {
                            address[maskBit.Index] = maskBit.Val;
                        }
                    }

                    for (int i = 0; i < Math.Pow(2, mask.Where(m => m == 'X').Count()); i++)
                    {
                        var tmpAddress = address.ToArray();
                        var bitmask = Convert.ToString(i, 2).PadLeft(mask.Where(m => m == 'X').Count(), '0').ToCharArray();

                        foreach (var x in tmpAddress.Select((b, idx) => new { Index = idx, Val = b }).Where(b => b.Val == 'X').Select((x, i) => new { CounterIndex = i, FloatingIndex = x.Index }))
                        {
                            tmpAddress[x.FloatingIndex] = bitmask[x.CounterIndex];
                        }

                        ulong memoryAddress = Convert.ToUInt64(new string(tmpAddress), 2);

                        if (memory.ContainsKey(memoryAddress))
                        {
                            memory[memoryAddress] = val;
                        }
                        else
                        {
                            memory.Add(memoryAddress, val);
                        }

                    }
                }
            }

            return memory.Select(m => m.Value).Aggregate((a, b) => a + b);
        }
    }
}
