using System;
using System.Collections.Generic;
using Days;
using Xunit;
using System.Linq;

namespace Tests
{
    public class PasswordPhilosophy
    {
        private static readonly string[] example =
            {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc"
            };

        [Fact]
        public void ParserExample()
        {
            var pwdStr = Days.PasswordPhilosophy.SplitEntry(example[0]);
            var password = Helpers.PasswordEntry.StringArrToEntry(pwdStr);

            Assert.Equal(1, password.Min);
            Assert.Equal(3, password.Max);
            Assert.Equal('a', password.Policy);
            Assert.Equal("abcde", password.Password);
        }

        [Fact]
        public void FirstStarExample()
        {
            var entries = example.Select(s => Days.PasswordPhilosophy.SplitEntry(s));
            
            int validPwd = Days.PasswordPhilosophy.ValidPasswordsInArray
                (Days.PasswordPhilosophy.FirstParser, entries);

            Assert.Equal(2, validPwd);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var sample = Helpers.ReadFile("Inputs\\02.txt");
            var entries = sample.Select(s => Days.PasswordPhilosophy.SplitEntry(s));

            int validPwd = Days.PasswordPhilosophy.ValidPasswordsInArray
                (Days.PasswordPhilosophy.FirstParser, entries);
            Assert.Equal(515, validPwd);
        }

        [Fact]
        public void SecondStarExample()
        {
            var entries = example.Select(s => Days.PasswordPhilosophy.SplitEntry(s));

            int validPwd = Days.PasswordPhilosophy.ValidPasswordsInArray
                (Days.PasswordPhilosophy.SecondParser, entries);

            Assert.Equal(1, validPwd);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var sample = Helpers.ReadFile("Inputs\\02.txt");
            var entries = sample.Select(s => Days.PasswordPhilosophy.SplitEntry(s));

            int validPwd = Days.PasswordPhilosophy.ValidPasswordsInArray
                (Days.PasswordPhilosophy.SecondParser, entries);
            Assert.Equal(711, validPwd);
        }
    }
}
