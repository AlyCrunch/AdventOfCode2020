using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Days
{
    public static class EncodingError
    {
        public static long GetFirstXMASNotValid(long[] arr, int offset)
        {
            for (int i = offset; i < arr.Length; i++)
            {
                var pair = FindPair(arr.Skip(i - offset).Take(offset).ToArray(), arr[i]);
                if (pair == null)
                    return arr[i];
            }

            return 0;
        }

        private static Tuple<long, long> FindPair(long[] arr, long sum)
        {
            var copy = arr.ToList();

            for (int i = 0; i < arr.Length - 2; i++)
            {
                copy.RemoveAt(0);
                for (int j = 0; j < copy.Count; j++)
                {
                    if (arr[i] + copy[j] == sum)
                        return new Tuple<long, long>(arr[i], copy[j]);
                }
            }

            return null;
        }

        public static long EncryptionWeakness(long[] arr, long sum)
        {
            var index = Array.IndexOf(arr, sum);
            long returnValue = 0;

            Parallel.For(0, index, (i, state) =>
            {
                List<long> temp = new List<long>();

                foreach (long val in arr.Skip(i))
                {
                    if (val >= sum) break;

                    temp.Add(val);

                    var tempSum = temp.Sum();

                    if (tempSum > sum) break;

                    if (tempSum == sum)
                    {
                        returnValue = temp.Min() + temp.Max();
                        state.Stop();
                    };
                }
            });

            if (returnValue != 0) return returnValue;

            throw new Exception("Value not found");
        }

        public static string OutputFirst()
            => GetFirstXMASNotValid(Helpers.ReadFileAs<long>("Inputs\\09.txt"), 25).ToString();
        public static string OutputSecond()
            => EncryptionWeakness(Helpers.ReadFileAs<long>("Inputs\\09.txt"), 20874512).ToString();
    }
}
