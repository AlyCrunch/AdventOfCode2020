using System;
using System.Collections.Generic;
using System.Linq;

namespace Days
{
    public static class HandyHaversacks
    {

        public static Dictionary<string, Dictionary<string, int>> FormatBags(string[] strs)
        {
            var bags = strs.Select(x => CleanBagsLine(x))
                .ToDictionary(str => str.Split(" contain ")[0],
                                str =>
                                {
                                    var splitted = str.Split(" contain ", StringSplitOptions.RemoveEmptyEntries);
                                    if (splitted.Length == 1)
                                        return new Dictionary<string, int>();
                                    else
                                        return GetSubbags(splitted[1]);
                                }
            );
            return bags;
        }

        public static List<string> FindBagInBags(string key, Dictionary<string, Dictionary<string, int>> bags)
        {
            var listOfBags = new HashSet<string>();
            var keys = new List<string>() { key };

            while (keys.Count > 0)
            {
                keys = bags.Where(x => x.Value.Any(b => keys.Contains(b.Key)))
                    .Select(x => x.Key).ToList();
                if (keys.Count > 0) listOfBags.UnionWith(keys);
            }

            return listOfBags.ToList();
        }

        public static int CountBagsInBag(string key, Dictionary<string, Dictionary<string, int>> bags)
        {
            if (bags[key].Values.Count == 0)
                return 0;
            else
                return bags[key].Sum(x => x.Value + (x.Value * CountBagsInBag(x.Key, bags)));
        }

        private static string CleanBagsLine(string str)
        => str.Replace("no other bags", "")
            .Replace("bags", "")
            .Replace("bag", "")
            .Replace("  ", " ")
            .Replace(".", "");

        private static Dictionary<string, int> GetSubbags(string str)
        {
            Dictionary<string, int> formattedBags = new Dictionary<string, int>();
            foreach (string bag in str.Split(" , "))
            {
                var splitted = bag.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                formattedBags.Add(string.Join(" ", splitted[1..]), int.Parse(splitted[0]));
            }

            return formattedBags;
        }

        public static string OutputFirst()
        {
            var bags = FormatBags(Helpers.ReadFile("Inputs\\07.txt"));
            return FindBagInBags("shiny gold", bags).Count.ToString();
        }
        public static string OutputSecond()
        {
            var bags = FormatBags(Helpers.ReadFile("Inputs\\07.txt"));
            return CountBagsInBag("shiny gold", bags).ToString();
        }
    }
}
