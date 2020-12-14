using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class DockingData
    {
        public static readonly string[] example = new string[]
        {
            "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
            "mem[8] = 11",
            "mem[7] = 101",
            "mem[8] = 0"
        };

        public static readonly string[] example2 = new string[]
        {
            "mask = 000000000000000000000000000000X1001X",
            "mem[42] = 100",
            "mask = 00000000000000000000000000000000X0XX",
            "mem[26] = 1"
        };

        [Fact]
        public void FirstStarExample()
        {
            var value = Days.DockingData.Decoder1(example);
            Assert.Equal((ulong)165, value);
        }
        [Fact]
        public void FirstStarSolution()
        {
            var value = Days.DockingData.Decoder1(Days.Helpers.ReadFile("Inputs\\14.txt"));
            Assert.Equal((ulong)5902420735773, value);
        }
        [Fact]
        public void SecondStarExample()
        {
            var value = Days.DockingData.Decoder2(example2);
            Assert.Equal(208, value);
        }
        [Fact]
        public void SecondStarSolution()
        {
            var value = Days.DockingData.Decoder2(Days.Helpers.ReadFile("Inputs\\14.txt"));
            Assert.Equal(3801988250775, value);
        }
    }
}
