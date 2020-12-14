using System;
using System.Collections.Generic;
using System.Linq;

namespace Days
{
    public static class DockingData
    {
        public static UInt64 Decoder1(string[] input)
        {
            string currMask = "";
            Dictionary<string, UInt64> memory = new Dictionary<string, UInt64>();
            foreach (var value in input)
            {
                var splitted = value.Split(" = ");
                if (splitted[0] == "mask")
                    currMask = splitted[1];
                else
                {
                    int first = 4;
                    int second = splitted[0].IndexOf(']');
                    var memIndex = splitted[0][first..second];
                    var binary = Convert.ToString(int.Parse(splitted[1]), 2).PadLeft(36, '0');
                    memory[memIndex] = Mask(currMask, binary);
                }

            }

            return memory.Aggregate(0UL, (a, c) => a + c.Value);
        }

        private static UInt64 Mask(string mask, string value)
        {
            var prout = new string(mask.Select((m, i) =>
            {
                return m switch
                {
                    '0' => '0',
                    '1' => '1',
                    'X' => value[i],
                    _ => value[i],
                };
            }).ToArray());

            return Convert.ToUInt64(prout.PadLeft(64, '0'), 2);
        }

        public static long Decoder2(string[] input)
        {
            string currMask = "";
            Dictionary<string, long> memory = new Dictionary<string, long>();
            foreach (var instruction in input)
            {
                var splitted = instruction.Split(" = ");
                if (splitted[0] == "mask")
                    currMask = splitted[1];
                else
                {
                    int first = 4;
                    int second = splitted[0].IndexOf(']');
                    var memIndex = Convert.ToString(int.Parse(splitted[0][first..second]), 2).PadLeft(36, '0');
                    var value = int.Parse(splitted[1]);
                    var newmask = CreateMask(currMask, memIndex);
                    foreach (var adress in AllMemoryAddresses(newmask))
                    {
                        memory[adress] = value;
                    }
                }
            }

            return memory.Sum(x => x.Value);
        }

        private static List<string> AllMemoryAddresses(string mask)
        {
            List<string> mems = new List<string>();
            var nb = mask.Count(x => x.Equals('X'));

            for (int i = 0; i < Math.Pow(2, nb); i++)
            {
                var val = new Queue<char>(Convert.ToString(i, 2).PadLeft(nb, '0').ToArray());
                mems.Add(new string(mask.Select(x => (x == 'X') ? val.Dequeue() : x).ToArray()));
            }
            return mems;
        }

        private static string CreateMask(string mask, string value)
        {
            return new string(mask.Select((m, i) =>
            {
                return m switch
                {
                    '0' => value[i],
                    '1' => '1',
                    'X' => 'X',
                    _ => value[i],
                };
            }).ToArray());
        }

        #region Printing methods
        public static string OutputFirst()
            => Decoder1(Helpers.ReadFile("Inputs\\14.txt")).ToString();
        public static string OutputSecond()
            => Decoder2(Helpers.ReadFile("Inputs\\14.txt")).ToString();
        #endregion
    }
}