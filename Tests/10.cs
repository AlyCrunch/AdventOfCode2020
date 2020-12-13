using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class AdapterArray
    {
        public readonly int[] example = new int[]
        {
            16,
            10,
            15,
            5,
            1,
            11,
            7,
            19,
            6,
            12,
            4
        };
        public readonly int[] largerExample = new int[]
        {
            28,
            33,
            18,
            42,
            31,
            14,
            46,
            20,
            48,
            47,
            24,
            23,
            49,
            45,
            19,
            38,
            39,
            11,
            1,
            32,
            25,
            35,
            8,
            17,
            7,
            9,
            4,
            2,
            34,
            10,
            3
        };

        [Fact]
        public void FirstStarExample()
        {
            int solution = Days.AdapterArray.GetJoltDifferences(example);
            Assert.Equal(35, solution);

            int solutionLarger = Days.AdapterArray.GetJoltDifferences(largerExample);
            Assert.Equal(220, solutionLarger);
        }
        [Fact]
        public void FirstStarSolution()
        {
            int solution = Days.AdapterArray.GetJoltDifferences(Days.Helpers.ReadFileAsInteger("Inputs\\10.txt"));
            Assert.Equal(2775, solution);
        }

        [Fact]
        public void SecondStarExample()
        {
            var solution = Days.AdapterArray.CountArrangements(example);
            Assert.Equal(8, solution);

            var solutionLarger = Days.AdapterArray.CountArrangements(largerExample);
            Assert.Equal(19208, solutionLarger);
        }
        [Fact]
        public void SecondStarSolution()
        {
            var input = Days.Helpers.ReadFileAsInteger("Inputs\\10.txt");
            var solution = Days.AdapterArray.CountArrangements(input);
            Assert.Equal(518344341716992, solution);
        }
    }
}
