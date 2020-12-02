using System.Threading.Tasks;

namespace Days
{
    public static class ReportRepair
    {
        public static void Search2(int[] arr, out int first, out int second)
        {
            var t_first = -1;
            var t_second = -1;
            Parallel.ForEach(arr, val1 =>
            {

                foreach (var val2 in arr)
                    if (val1 != val2 && (val1 + val2 == 2020))
                    {
                        t_first = val1;
                        t_second = val2;
                        break;
                    }
            });

            first = t_first;
            second = t_second;
        }

        public static void Search3(int[] arr, out int first, out int second, out int third)
        {
            var t_first = -1;
            var t_second = -1;
            var t_third = -1;

            Parallel.ForEach(arr, val1 =>
            {

                foreach (var val2 in arr)
                    foreach (var val3 in arr)
                        if (val1 + val2 + val3 == 2020)
                        {
                            t_first = val1;
                            t_second = val2;
                            t_third = val3;
                            break;
                        }
            });

            first = t_first;
            second = t_second;
            third = t_third;
        }

        public static string OutputFirst()
        {
            var sample = Helpers.ReadFileAsInteger("Inputs\\01.txt");
            Search2(sample, out int first, out int second);

            return (first * second).ToString();
        }

        public static string OutputSecond()
        {
            var sample = Helpers.ReadFileAsInteger("Inputs\\01.txt");
            Search3(sample, out int first, out int second, out int third);

            return (first * second * third).ToString();
        }
    }
}
