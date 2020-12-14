using System;
using System.Collections.Generic;
using System.Linq;

namespace Days
{
    public static class ShuttleSearch
    {

        public static int GetWaitingMinute(string[] input)
        {
            var busses = Format(input);
            var bus = FindNextBus(busses.ts, busses.list);
            return (bus.ts - busses.ts) * bus.id;
        }

        private static (int ts, List<int> list) Format(string[] input)
        {
            var ts = int.Parse(input[0]);
            var list = input[1].Split(',')
                               .Where(x => x != "x")
                               .Select(x => int.Parse(x))
                               .ToList();
            return (ts, list);
        }

        private static (int ts, int id) FindNextBus(int timestamp, List<int> bus)
        {
            do
            {
                var currbus = bus.Where(x => (timestamp % x) == 0);
                if (currbus.Count() > 0) return (timestamp, currbus.First());
                timestamp++;
            }
            while (true);

            throw new Exception("No bus found");
        }

        public static long GetTimestampMatching(string input)
        {
            var formatted = FormatNew(input);
            return FindBusPattern(formatted);
        }

        public static long GetTimeStampingChinese(string input)
        {
            var formatted = FormatForChinese(input);
            return ChineseReminder(formatted.Item1, formatted.Item2);
        }

        private static Dictionary<int, int> FormatNew(string input)
        {
            Dictionary<int, int> busses = new Dictionary<int, int>();
            var ids = input.Split(',');

            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i] == "x") continue;
                busses.Add(int.Parse(ids[i]), i);
            }

            return busses;
        }
        private static (int[], int[]) FormatForChinese(string input)
        {
            var ids = new List<int>();
            var modulos = new List<int>();
            var splitted = input.Split(',');


            for (int i = 0; i < splitted.Length; i++)
            {
                if (splitted[i] == "x") continue;
                ids.Add(int.Parse(splitted[i]));
                modulos.Add(Mod((i * -1), ids.Last()));
            }

            return (ids.ToArray(), modulos.ToArray());
        }

        private static long FindBusPattern(Dictionary<int, int> busses)
        {
            long timestamp = 0;
            var step = busses.First().Key;
            do
            {
                var test = busses.All(x => ((timestamp + x.Value) % x.Key) == 0);
                if (test) return timestamp;
                timestamp += step;
            }
            while (true);

            throw new Exception("No bus found");
        }

        public static long ChineseReminder(int[] n, int[] a)
        {
            long prod = n.Aggregate((long)1, (i, j) => i * j);
            long p;
            long sm = 0;
            for (int i = 0; i < n.Length; i++)
            {
                p = prod / n[i];
                sm += a[i] * ModularMultiplicativeInverse(p, n[i]) * p;
            }
            return sm % prod;
        }

        private static long ModularMultiplicativeInverse(long a, long mod)
        {
            long b = a % mod;
            for (long x = 1; x < mod; x++)
            {
                if ((b * x) % mod == 1)
                {
                    return x;
                }
            }
            return 1;
        }

        private static int Mod(int x, int y)
            => (x % y + y) % y;

        #region Printing methods
        public static string OutputFirst()
            => GetWaitingMinute(Helpers.ReadFile("Inputs\\13.txt")).ToString();
        public static string OutputSecond()
            => GetTimeStampingChinese(Helpers.ReadFile("Inputs\\13.txt")[1]).ToString();
        #endregion
    }
}