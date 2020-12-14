using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class ShuttleSearch
    {
        public static readonly string[] example = new string[]
        {
            "939",
            "7,13,x,x,59,x,31,19"
        };

        [Fact]
        public void FirstStarExample()
        {
            var sol = Days.ShuttleSearch.GetWaitingMinute(example);
            Assert.Equal(295, sol);
        }
        [Fact]
        public void FirstStarSolution()
        {
            var sol = Days.ShuttleSearch.GetWaitingMinute(Days.Helpers.ReadFile("Inputs\\13.txt"));
            Assert.Equal(2215, sol);
        }
        [Fact]
        public void SecondStarExample()
        {
            var sol = Days.ShuttleSearch.GetTimeStampingChinese(example[1]);
            Assert.Equal(1068781, sol);

            var sol2 = Days.ShuttleSearch.GetTimeStampingChinese("67,7,59,61");
            Assert.Equal(754018, sol2);

            var sol3 = Days.ShuttleSearch.GetTimeStampingChinese("67,x,7,59,61");
            Assert.Equal(779210, sol3);

            var sol4 = Days.ShuttleSearch.GetTimeStampingChinese("67,7,x,59,61");
            Assert.Equal(1261476, sol4);

            var sol5 = Days.ShuttleSearch.GetTimeStampingChinese("1789,37,47,1889");
            Assert.Equal(1202161486, sol5);
        }
        [Fact]
        public void SecondStarSolution()
        {
            var sol = Days.ShuttleSearch.GetTimeStampingChinese(Days.Helpers.ReadFile("Inputs\\13.txt")[1]);
            Assert.Equal(1058443396696792, sol);
        }
    }
}