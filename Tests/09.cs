using Xunit;

namespace Tests
{
    public class EncodingError
    {
        public static long[] example = new long[]
        {
            35,
            20,
            15,
            25,
            47,
            40,
            62,
            55,
            65,
            95,
            102,
            117,
            150,
            182,
            127,
            219,
            299,
            277,
            309,
            576
        };

        [Fact]
        public void FirstStarExample()
        {
            var val = Days.EncodingError.GetFirstXMASNotValid(example, 5);
            Assert.Equal(127, val);
        }
        [Fact]
        public void FirstStarSolution()
        {
            var input = Days.Helpers.ReadFileAs<long>("Inputs\\09.txt");
            var val = Days.EncodingError.GetFirstXMASNotValid(input, 25);
            Assert.Equal(20874512, val);
        }
        [Fact]
        public void SecondStarExample()
        {
            Assert.Equal(62, Days.EncodingError.EncryptionWeakness(example, 127));
        }
        [Fact]
        public void SecondStarSolution()
        {
            var input = Days.Helpers.ReadFileAs<long>("Inputs\\09.txt");
            Assert.Equal(3012420, Days.EncodingError.EncryptionWeakness(input, 20874512));
        }
    }
}
