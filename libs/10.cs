using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Days
{
    public static class AdapterArray
    {
        public static int GetJoltDifferences(int[] jolts)
        {
            int one = 0, three = 1;
            int currJolts = 0, jolt = 0;

            var joltsList = jolts.OrderBy(x => x).ToList();

            do
            {
                jolt = joltsList.Where(x => 1 <= (x - currJolts) && (x - currJolts) <= 3).FirstOrDefault();
                joltsList.Remove(jolt);
                if (jolt - currJolts == 3) three++;
                if (jolt - currJolts == 1) one++;
                currJolts = jolt;
            }
            while (jolt != 0);

            return three * one;
        }

        public static int CountArrangements(List<int> jolts, int index = 0)
        {
            if (index == 0)
                jolts.Insert(0, 0);

            do
            {
                var p = jolts.Skip(index + 1).Take(3)
                    .Where(x => 1 <= (x - jolts[index]) && (x - jolts[index]) <= 3).ToList();

                if (p.Count() == 0 && index == jolts.Count - 1)
                    break;

                index = jolts.IndexOf(p.First());

                if (p.Count() == 1) continue;

                return p.Select(x => CountArrangements(jolts, jolts.IndexOf(x)))
                    .Sum();
            }
            while (index < jolts.Count);

            return 1;
        }

        public static long CountArrangements(int[] jolts)
        {
            var list = jolts.OrderBy(x => x).ToList();
            list.Insert(0, 0);
            list.Add(list.Last() + 3);

            List<List<int>> diffs = new List<List<int>>() { new List<int>() };
            for (int i = 1; i < list.Count; i++)
            {
                var diff = list[i] - list[i - 1];
                switch (diff)
                {
                    case 1:
                        diffs.Last().Add(diff);
                        break;
                    case 2:
                        diffs.Last().Add(diff);
                        break;
                    case 3:
                        diffs.Add(new List<int>());
                        break;
                }
            }

            return diffs.Aggregate((long)1, (acc, values) => acc * Simplify(values));
        }

        private static long Simplify(List<int> part)
        {
            if (part.Count <= 1) return 1;
            if (part[0] + part[1] > 3) return 1;

            var sum = part[0] + part[1];

            var left = part.Skip(1).ToList();
            var right = part.Skip(1).ToList();
            right[0] = sum;

            return new List<List<int>> { left, right }.Sum(x => Simplify(x));
        }

        public static string OutputFirst()
            => GetJoltDifferences(Helpers.ReadFileAsInteger("Inputs\\10.txt")).ToString();
        public static string OutputSecond()
            => CountArrangements(Helpers.ReadFileAsInteger("Inputs\\10.txt")).ToString();
    }
}