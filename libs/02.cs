using System;
using System.Collections.Generic;
using System.Linq;

namespace Days
{
    public static class PasswordPhilosophy
    {
        public static string[] SplitEntry(string entry)
        => entry.Split(new char[] { ' ', '-', ':' }, StringSplitOptions.RemoveEmptyEntries);

        public static bool FirstParser(int min, int max, char p, string s)
            => s.Count(c => c == p) >= min && s.Count(c => c == p) <= max;
        public static bool FirstParser(Objects.PasswordEntry pwd)
            => FirstParser(pwd.Min, pwd.Max, pwd.Policy, pwd.Password);

        public static bool SecondParser(int pos1, int pos2, char p, string s)
            => s[pos1 - 1] == p ^ s[pos2 - 1] == p;
        public static bool SecondParser(Objects.PasswordEntry pwd)
            => SecondParser(pwd.Min, pwd.Max, pwd.Policy, pwd.Password);

        public static int ValidPasswordsInArray(Func<Objects.PasswordEntry, bool> Parser, IEnumerable<string[]> passwords)
            => passwords.Count(pwd => Parser(Objects.PasswordEntry.StringArrToEntry(pwd)));

        public static string OutputFirst()
        {
            var sample = Helpers.ReadFile("Inputs\\02.txt");
            var entries = sample.Select(s => SplitEntry(s));

            return ValidPasswordsInArray(FirstParser, entries).ToString();
        }

        public static string OutputSecond()
        {
            var sample = Helpers.ReadFile("Inputs\\02.txt");
            var entries = sample.Select(s => SplitEntry(s));

            return ValidPasswordsInArray(SecondParser, entries).ToString();
        }
    }
}