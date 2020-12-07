using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class HandyHaversacks
    {
        public static readonly string[] example = new string[]
        {
            "light red bags contain 1 bright white bag, 2 muted yellow bags.",
            "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
            "bright white bags contain 1 shiny gold bag.",
            "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
            "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
            "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
            "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
            "faded blue bags contain no other bags.",
            "dotted black bags contain no other bags."
        };

        public static readonly string[] example2 = new string[]
        {
            "shiny gold bags contain 2 dark red bags.",
            "dark red bags contain 2 dark orange bags.",
            "dark orange bags contain 2 dark yellow bags.",
            "dark yellow bags contain 2 dark green bags.",
            "dark green bags contain 2 dark blue bags.",
            "dark blue bags contain 2 dark violet bags.",
            "dark violet bags contain no other bags."
        };

        [Fact]
        public void FirstStarExample()
        {
            var bags = Days.HandyHaversacks.FormatBags(example);
            var shinybags = Days.HandyHaversacks.FindBagInBags("shiny gold", bags);
            Assert.Equal(4, shinybags.Count);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var bags = Days.HandyHaversacks.FormatBags(Days.Helpers.ReadFile("Inputs\\07.txt"));
            var shinybags = Days.HandyHaversacks.FindBagInBags("shiny gold", bags);
            Assert.Equal(238, shinybags.Count);
        }

        [Fact]
        public void SecondStarExample()
        {
            var first = Days.HandyHaversacks.FormatBags(example);
            var nbFirst = Days.HandyHaversacks.CountBagsInBag("shiny gold", first);
            Assert.Equal(32, nbFirst);

            var bags = Days.HandyHaversacks.FormatBags(example2);
            var nb = Days.HandyHaversacks.CountBagsInBag("shiny gold", bags);
            Assert.Equal(126, nb);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var bags = Days.HandyHaversacks.FormatBags(Days.Helpers.ReadFile("Inputs\\07.txt"));
            var nb = Days.HandyHaversacks.CountBagsInBag("shiny gold", bags);
            Assert.Equal(82930, nb);

        }
    }
}
