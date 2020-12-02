using System;
using Days;
using Xunit;

namespace Tests
{
    public class ReportRepair
    {
        private static readonly int[] example = new int[] { 1721, 979, 366, 299, 675, 1456 };

        [Fact]
        public void FirstStarExample()
        {
            Days.ReportRepair.Search2(example, out int first, out int second);

            var result = new int[] { first, second };
            Assert.Contains(1721, result);
            Assert.Contains(299, result);
            Assert.Equal(2020, first + second);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var sample = Helpers.ReadFileAsInteger("Inputs\\01.txt");
            Days.ReportRepair.Search2(sample, out int first, out int second);

            Assert.Equal(2020, first + second);
        }

        [Fact]
        public void SecondStarExample()
        {
            Days.ReportRepair.Search3
                (example, out int first, out int second, out int third);

            var result = new int[] { first, second, third };
            Assert.Contains(979, result);
            Assert.Contains(366, result);
            Assert.Contains(675, result);
        }
        [Fact]
        public void SecondStarSolution()
        {
            var sample = Helpers.ReadFileAsInteger("Inputs\\01.txt");
            Days.ReportRepair.Search3
                (sample, out int first, out int second, out int third);

            Assert.Equal(2020, first + second + third);
        }
    }
}
