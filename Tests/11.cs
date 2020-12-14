using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class SeatingSystem
    {
        public static readonly string[] example = new string[]
        {
            "L.LL.LL.LL",
            "LLLLLLL.LL",
            "L.L.L..L..",
            "LLLL.LL.LL",
            "L.LL.LL.LL",
            "L.LLLLL.LL",
            "..L.L.....",
            "LLLLLLLLLL",
            "L.LLLLLL.L",
            "L.LLLLL.LL"
        };

        public static readonly string[] example2 = new string[]
        {
            ".......#.",
            "...#.....",
            ".#.......",
            ".........",
            "..#L....#",
            "....#....",
            ".........",
            "#........",
            "...#....."
        };

        public static readonly string[] example3 = new string[]
        {
            ".............",
            ".L.L.#.#.#.#.",
            "............."
        };

        [Fact]
        public void FirstStarExample()
        {
            int seats = Days.SeatingSystem.GetSeatsOccupied(example);
            Assert.Equal(37, seats);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var input = Days.Helpers.ReadFile("Inputs\\11.txt");
            int seats = Days.SeatingSystem.GetSeatsOccupied(input);
            Assert.Equal(2338, seats);
        }
        [Fact]
        public void SecondStarExample()
        {
            int seats1 = Days.SeatingSystem.GetOccupiedAdjecentNewRule(3, 4, example2);
            Assert.Equal(8, seats1);

            int seats2 = Days.SeatingSystem.GetOccupiedAdjecentNewRule(1, 1, example3);
            Assert.Equal(0, seats2);

            int seats = Days.SeatingSystem.GetSeatsOccupiedNew(example);
            Assert.Equal(26, seats);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var input = Days.Helpers.ReadFile("Inputs\\11.txt");
            int seats = Days.SeatingSystem.GetSeatsOccupiedNew(input);
            Assert.Equal(2134, seats);
        }
    }
}