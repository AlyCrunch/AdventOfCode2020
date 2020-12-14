using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class RainRisk
    {
        public static readonly string[] example = new string[]
        {
            "F10",
            "N3",
            "F7",
            "R90",
            "F11"
        };

        [Fact]
        public void FirstStarExample()
        {
            int distance = Days.RainRisk.GetManhattanDistance(example);
            Assert.Equal(25, distance);
        }
        [Fact]
        public void FirstStarSolution()
        {
            int distance = Days.RainRisk.GetManhattanDistance(Days.Helpers.ReadFile("Inputs\\12.txt"));
            Assert.Equal(1186, distance);
        }
        [Fact]
        public void SecondStarExample()
        {
            int distance = Days.RainRisk.GetManhattanDistanceNew(example);
            Assert.Equal(286, distance);
        }
        [Fact]
        public void SecondStarSolution()
        {
            int distance = Days.RainRisk.GetManhattanDistanceNew(Days.Helpers.ReadFile("Inputs\\12.txt"));
            Assert.Equal(47806, distance);
        }
    }
}