using System;
using System.Collections.Generic;
using System.Linq;
using Days;
using Xunit;

namespace Tests
{
    public class BinaryBoarding
    {
        public static readonly string[] example = new string[]
        {
            "FBFBBFFRLR",
            "BFFFBBFRRR",
            "FFFBBBFRRR",
            "BBFFBBFRLL"
        };

        [Fact]
        public static void FirstStarExample()
        {
            var seats = example.Select(s => Days.BinaryBoarding.Partitioning(s)).ToArray();
            Assert.Equal((44, 5, 357), seats[0]);
            Assert.Equal((70, 7, 567), seats[1]);
            Assert.Equal((14, 7, 119), seats[2]);
            Assert.Equal((102, 4, 820), seats[3]);
        }

        [Fact]
        public static void FirstStarSolution()
        {
            var sample = Helpers.ReadFile("Inputs\\05.txt");

            Assert.Equal(938, sample.Select(s => Days.BinaryBoarding.Partitioning(s))
                                  .Max(x => x.seatID));
        }

        [Fact]
        public static void SecondStarSolution()
        {
            var sample = Helpers.ReadFile("Inputs\\05.txt");
            var sortedSeats = sample.Select(s => Days.BinaryBoarding.Partitioning(s).seatID).OrderBy(s => s);
            var mySeat = Days.BinaryBoarding.GetMissingSeat(sortedSeats.ToArray());
            Assert.Equal(696, mySeat);
        }
    }
}
