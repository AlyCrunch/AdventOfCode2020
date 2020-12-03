using System;
using System.Collections.Generic;
using System.Text;
using Days;
using Xunit;

namespace Tests
{
    public class TobogganTrajectory
    {
        public static readonly string[] example = new string[]
        {
            "..##.......",
            "#...#...#..",
            ".#....#..#.",
            "..#.#...#.#",
            ".#...##..#.",
            "..#.##.....",
            ".#.#.#....#",
            ".#........#",
            "#.##...#...",
            "#...##....#",
            ".#..#...#.#"
        };

        [Fact]
        public static void FirstStarExample()
        {
            var map = Days.TobogganTrajectory.InitMap(example, 3, 1);
            var trees = Days.TobogganTrajectory.CountTrees(3, 1, map);

            Assert.Equal(7, trees);
        }

        [Fact]
        public static void FirstStarSolution()
        {
            var sample = Helpers.ReadFile("Inputs\\03.txt");
            var map = Days.TobogganTrajectory.InitMap(sample, 3, 1);
            var trees = Days.TobogganTrajectory.CountTrees(3, 1, map);

            Assert.Equal(145, trees);
        }

        [Fact]
        public static void SecondStarExample()
        {
            var slopes = new (int, int)[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) };
            var maxRepeat = Days.TobogganTrajectory.GetLongestRepeatition(slopes, (example[0].Length, example.Length));

            var map = Days.TobogganTrajectory.InitMap(example, maxRepeat);

            int multipliedTrees = 1;
            foreach (var slope in slopes)
                multipliedTrees *= Days.TobogganTrajectory.CountTrees(slope, map);


            Assert.Equal(336, multipliedTrees);
        }
        [Fact]
        public static void SecondStarSolution()
        {
            var sample = Helpers.ReadFile("Inputs\\03.txt");
            var slopes = new (int, int)[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) };
            var maxRepeat = Days.TobogganTrajectory.GetLongestRepeatition(slopes, (sample[0].Length, sample.Length));

            var map = Days.TobogganTrajectory.InitMap(sample, maxRepeat);

            long multipliedTrees = 1;
            foreach (var slope in slopes)
                multipliedTrees *= Days.TobogganTrajectory.CountTrees(slope, map);


            Assert.Equal(3424528800, multipliedTrees);
        }

    }
}
