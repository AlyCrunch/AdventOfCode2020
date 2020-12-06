using System;
using System.Collections.Generic;
using System.Text;
using Days;
using System.Linq;
using Xunit;

namespace Tests
{
    public class CustomCustoms
    {
        public static readonly string[] example = new string[]
        {
            "abc",
            "",
            "a",
            "b",
            "c",
            "",
            "ab",
            "ac",
            "",
            "a",
            "a",
            "a",
            "a",
            "",
            "b"
        };

        [Fact]
        public void FirstStarExample()
        {
            var sum = Days.CustomCustoms.CountAnyoneAnsweredYes(example);
            Assert.Equal(11, sum);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var sum = Days.CustomCustoms.CountAnyoneAnsweredYes(Helpers.ReadFile("Inputs\\06.txt"));
            Assert.Equal(6504, sum);
        }

        [Fact]
        public void SecondStarExample()
        {
            var sum = Days.CustomCustoms.CountEveryoneAnsweredYes(example);
            Assert.Equal(6, sum);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var sum = Days.CustomCustoms.CountEveryoneAnsweredYes(Helpers.ReadFile("Inputs\\06.txt"));
            Assert.Equal(3351, sum);
        }
    }
}
