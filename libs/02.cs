using System;
using System.Collections.Generic;
using System.Linq;
using static Days.Helpers;

namespace Days
{
    public static class PasswordPhilosophy
    {
        public static string[] SplitEntry(string entry)
        => entry.Split(new char[] { ' ', '-', ':' }, StringSplitOptions.RemoveEmptyEntries);

        public static bool FirstParser(int min, int max, char p, string s)
            => s.Count(c => c == p) >= min && s.Count(c => c == p) <= max;
        public static bool FirstParser(PasswordEntry pwd)
            => FirstParser(pwd.Min, pwd.Max, pwd.Policy, pwd.Password);

        public static bool SecondParser(int pos1, int pos2, char p, string s)
            => s[pos1 - 1] == p ^ s[pos2 - 1] == p;
        public static bool SecondParser(PasswordEntry pwd)
            => SecondParser(pwd.Min, pwd.Max, pwd.Policy, pwd.Password);

        public static int ValidPasswordsInArray(Func<PasswordEntry, bool> Parser, IEnumerable<string[]> passwords)
        {
            int validPasswords = 0;
            foreach (var pwd in passwords)
                if (Parser(PasswordEntry.StringArrToEntry(pwd)))
                    validPasswords++;

            return validPasswords;
        }

        public static string OutputFirst()
        {
            var sample = ReadFile("Inputs\\02.txt");
            var entries = sample.Select(s => SplitEntry(s));

            return ValidPasswordsInArray(FirstParser, entries).ToString();
        }

        public static string OutputSecond()
        {
            var sample = ReadFile("Inputs\\02.txt");
            var entries = sample.Select(s => SplitEntry(s));

            return ValidPasswordsInArray(SecondParser, entries).ToString();
        }
    }

}
