using System;
using System.Linq;

namespace Days
{
    public static class TobogganTrajectory
    {
        public static byte[][] InitMap(string[] smpl, int x, int y)
            => InitMap(smpl, CountRepeation((x, y), (smpl[0].Length, smpl.Length)));

        public static byte[][] InitMap(string[] smpl, int repeating)
            => StringArrayToByteArray(smpl)
            .Select(line => Enumerable.Repeat(line, repeating).SelectMany(x => x).ToArray())
            .ToArray();

        public static int CountRepeation((int x, int y) step, (int x, int y) sample)
        {
            var totalLengh = (((sample.y / step.y) * step.x) + 1);
            return (int)Math.Ceiling((decimal)totalLengh / (decimal)sample.x);
        }

        public static int CountTrees(int x, int y, byte[][] map)
        {
            (int x, int y) point = (0, 0);
            int trees = 0;
            while (point.y < map.Length - 1)
            {
                point.x += x;
                point.y += y;
                if (map[point.y][point.x] == byte.MaxValue)
                    trees++;
            }
            return trees;
        }

        public static int CountTrees((int, int) step, byte[][] map)
            => CountTrees(step.Item1, step.Item2, map);

        public static int GetLongestRepeatition((int x, int y)[] steps, (int x, int y) sample)
            => steps.Max(s => CountRepeation((s.x, s.y), (sample.x, sample.y)));

        public static byte[][] StringArrayToByteArray(string[] smpl)
            => smpl.Select(y => y.Select(x => (x == '#') ? byte.MaxValue : byte.MinValue)
                                 .ToArray())
                   .ToArray();

        public static string OutputFirst()
        {
            var sample = Helpers.ReadFile("Inputs\\03.txt");
            var map = InitMap(sample, 3, 1);
            return CountTrees(3, 1, map).ToString();
        }

        public static string OutputSecond()
        {
            var sample = Helpers.ReadFile("Inputs\\03.txt");
            var slopes = new (int, int)[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) };
            var maxRepeat = GetLongestRepeatition(slopes, (sample[0].Length, sample.Length));

            var map = InitMap(sample, maxRepeat);

            long multipliedTrees = 1;
            foreach (var slope in slopes)
                multipliedTrees *= CountTrees(slope, map);

            return multipliedTrees.ToString();
        }
    }
}