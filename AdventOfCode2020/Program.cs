using System.Collections;
using System.Reflection;
using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main()
        {
            int dayNb = 0;
            foreach(var outputs in GetOutputs())
            {
                dayNb++;
                Console.WriteLine($"Day {dayNb} - {outputs.Item1}\n" +
                    $"Output 1 : {outputs.Item2}    " +
                    $"Output 2 : {outputs.Item3}\n");
            }
        }

        public static IEnumerable<Tuple<string, string,string>> GetOutputs()
        {
            var assembly = Assembly.Load("Days");
            var types = assembly.GetTypes();

            var methodName1 = "OutputFirst";
            var methodName2 = "OutputSecond";

            foreach (var type in types)
            {
                if (type.Name == "Helpers") yield break;
                var method1 = type.GetMethod(methodName1);
                var method2 = type.GetMethod(methodName2);

                var output1 = method1.Invoke(null, null);
                var output2 = method2.Invoke(null, null);
                yield return new Tuple<string, string, string>(type.Name, (string)output1, (string)output2);
            }
        }
    }
}
