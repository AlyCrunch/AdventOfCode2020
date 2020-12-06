using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Days
{
    public static class CustomCustoms
    {
        public static List<List<HashSet<char>>> FormatGroup(string[] strs)
        {
            return strs.Aggregate(new List<List<HashSet<char>>> { new List<HashSet<char>>() },
                                   (list, value) =>
                                   {
                                       if (value == "") list.Add(new List<HashSet<char>>());
                                       else list.Last().Add(new HashSet<char>(value));
                                       return list;
                                   });

        }

        public static int CountAnyoneAnsweredYes(string[] strs)
        {
            return FormatGroup(strs).Select((list) =>
            {
                return list.Aggregate((acc, answers) =>
                {
                    acc.UnionWith(answers);
                    return acc;
                });
            }).Sum(x => x.Count);
        }

        public static int CountEveryoneAnsweredYes(string[] strs)
        {
            return FormatGroup(strs).Select((list) =>
            {
                return list.Aggregate((acc, answers) =>
                {
                    acc.IntersectWith(answers);
                    return acc;
                });
            }).Sum(x => x.Count);
        }

        public static string OutputFirst()
            => CountAnyoneAnsweredYes(Helpers.ReadFile("Inputs\\06.txt")).ToString();
        public static string OutputSecond()
            => CountEveryoneAnsweredYes(Helpers.ReadFile("Inputs\\06.txt")).ToString();
    }
}