using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class RambunctiousRecitation
    {
        public static readonly string example = "0,3,6";

        [Fact]
        public void FirstStarExample()
        {
            var val = Days.RambunctiousRecitation.GetMemoryOptimized(example, 2020);
            Assert.Equal(436, val);
        }
        [Fact]
        public void FirstStarSolution()
        {
            var val = Days.RambunctiousRecitation.GetMemoryOptimized("1,2,16,19,18,0", 2020);
            Assert.Equal(536, val);
        }
        [Fact]
        public void SecondStarExample()
        {
            var val = Days.RambunctiousRecitation.GetMemoryOptimized(example, 30000000);
            Assert.Equal(175594, val);
        }
        [Fact]
        public void SecondStarSolution()
        {
            var val = Days.RambunctiousRecitation.GetMemoryOptimized("1,2,16,19,18,0", 30000000);
            Assert.Equal(24065124, val);
        }
    }
}
