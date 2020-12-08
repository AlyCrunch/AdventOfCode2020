using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class HandheldHalting
    {
        public static readonly string[] example = new string[]
        {
            "nop +0",
            "acc +1",
            "jmp +4",
            "acc +3",
            "jmp -3",
            "acc -99",
            "acc +1",
            "jmp -4",
            "acc +6"
        };

        [Fact]
        public void TestFormat()
        {
            var ops = Days.HandheldHalting.FormatString(example);
            Assert.Equal("nop", ops[0].op);
            Assert.Equal(0, ops[0].arg);
            Assert.Equal("acc", ops[5].op);
            Assert.Equal(-99, ops[5].arg);
        }

        [Fact]
        public void FirstStarExample()
        {
            int acc = Days.HandheldHalting.GetAccumulator(example);
            Assert.Equal(5, acc);
        }
        [Fact]
        public void FirstStarSolution()
        {
            int acc = Days.HandheldHalting.GetAccumulator(Days.Helpers.ReadFile("inputs\\08.txt"));
            Assert.Equal(1744, acc);
        }
        [Fact]
        public void SecondStarExample()
        {
            int acc = Days.HandheldHalting.GetAccumulatorUncorrupted(example);
            Assert.Equal(8, acc);
        }

        [Fact]
        public void SecondStarSolution()
        {
            int acc = Days.HandheldHalting.GetAccumulatorUncorrupted(Days.Helpers.ReadFile("inputs\\08.txt"));
            Assert.Equal(1174, acc);
        }
    }
}
