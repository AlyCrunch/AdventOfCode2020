using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Days
{
    public static class HandheldHalting
    {
        public static (string op, int arg)[] FormatString(string[] input)
            => input.Select(str =>
            {
                var splitted = str.Split(' ');
                return (splitted[0], int.Parse(splitted[1]));
            }).ToArray();

        public static int GetAccumulator(string[] list)
            => FollowInstructions(FormatString(list)).Item2;

        public static int GetAccumulatorUncorrupted(string[] list)
        {
            var inst = FormatString(list);
            var acc = 0;

            for (int i = 0; i < inst.Length - 1; i++)
            {
                if (inst[i].op.Equals("acc")) continue;

                var ret = FollowInstructions(((string op, int arg)[])inst.Clone(), i);
                if (ret.Item1)
                {
                    acc = ret.Item2;
                    break;
                }
            }

            return acc;
        }

        private static Tuple<bool, int> FollowInstructions((string op, int arg)[] inst, int change = -1)
        {
            if (change != -1)
                inst[change].op = inst[change].op.Equals("jmp") ? "nop" : "jmp";

            HashSet<int> history = new HashSet<int>();
            int acc = 0, index = 0;

            do
            {
                history.Add(index);
                switch (inst[index].op)
                {
                    case "nop":
                        index++;
                        break;
                    case "acc":
                        acc += inst[index].arg;
                        index++;
                        break;
                    case "jmp":
                        index += inst[index].arg;
                        break;
                }
            } while (!history.Contains(index) && index < inst.Length);

            return new Tuple<bool, int>(index >= inst.Length, acc);
        }

        public static string OutputFirst()
            => GetAccumulator(Helpers.ReadFile("inputs\\08.txt")).ToString();
        public static string OutputSecond()
            => GetAccumulatorUncorrupted(Helpers.ReadFile("inputs\\08.txt")).ToString();
    }
}