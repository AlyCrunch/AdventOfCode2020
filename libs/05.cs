using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Days
{
    public static class BinaryBoarding
    {
        public static (int row, int column, int seatID) Partitioning(string str)
        {
            string strRow = str[..7];
            string strColumn = str[7..];
            var row = DichotomicSearch(strRow, 'F', 'B', 0, 127);
            var column = DichotomicSearch(strColumn, 'L', 'R', 0, 7);

            return (row, column, row * 8 + column);
        }

        private static int DichotomicSearch(string str, char min, char max, int valmin, int valmax)
        {
            foreach (char c in str)
            {
                int diff = (valmax + 1 - valmin + 1) / 2;
                if (c == min)
                    valmax -= diff;
                if (c == max)
                    valmin += diff;
            }

            if (valmin == valmax)
                return valmin;
            else
                throw new Exception("Dichotomy search exited without finishing");
        }
        public static int GetMissingSeat(int[] arr) 
            => arr.TakeWhile((x, i) => (x - arr[0]) + 1 == ++i).LastOrDefault() + 1;

        public static string OutputFirst()
        {
            return Helpers.ReadFile("Inputs\\05.txt")
                            .Select(s => Partitioning(s))
                            .Max(x => x.seatID)
                            .ToString();
        }
        public static string OutputSecond()
        {
            var sample = Helpers.ReadFile("Inputs\\05.txt");
            var sortedSeats = sample.Select(s => Partitioning(s).seatID).OrderBy(s => s);
            return GetMissingSeat(sortedSeats.ToArray()).ToString();
        }
    }
}
