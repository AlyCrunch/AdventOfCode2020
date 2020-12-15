using System;
using System.Collections.Generic;
using System.Linq;

namespace Days
{
    public static class RambunctiousRecitation
    {
        public static int GetMemoryGameResultAt(string inputstr, int turn)
        {
            Dictionary<int, int> mem = new Dictionary<int, int>();
            int index = 0;
            foreach (string str in inputstr.Split(","))
            {
                mem.Add(index, int.Parse(str));
                index++;
            }

            for (int i = mem.Count; i < turn; i++)
            {
                var lastSpoken = mem[i - 1];
                var lastMatches = mem.Take(i)
                    .Where(t => t.Value == lastSpoken)
                    .Reverse()
                    .Take(2);
                if (lastMatches.Count() < 2)
                    mem[i] = 0;
                else
                {
                    mem[i] = (i - 1) - lastMatches.Last().Key;
                }
            }

            return mem[turn - 1];
        }

        public static int GetMemoryOptimized(string inputstr, int turn)
        {
            var input = inputstr.Split(",")
                                .Select(int.Parse)
                                .ToArray();
            var mem = new int[turn];
            Array.Fill(mem, -1);

            for (int i = 1; i < input.Length + 1; i++)
                mem[input[i - 1]] = i;

            var value = 0;
            for (int i = input.Length + 1; i < turn; i++)
            {
                var lastSpoken = mem[value];
                mem[value] = i;
                value = lastSpoken != -1 ? i - lastSpoken : 0;
            }
            return value;
        }

        #region Printing methods
        public static string OutputFirst()
            => GetMemoryOptimized("1,2,16,19,18,0", 2020).ToString();
        public static string OutputSecond()
            => GetMemoryOptimized("1,2,16,19,18,0", 30000000).ToString();
        #endregion
    }
}