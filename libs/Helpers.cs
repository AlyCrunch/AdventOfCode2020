using System;
using System.Collections.Generic;
using System.IO;

namespace Days
{
    public static class Helpers
    {
        public static string[] ReadFile(string fileName)
            => File.ReadAllLines(fileName);
        public static int[] ArrToInt(string[] arr)
            => Array.ConvertAll(arr, s => int.Parse(s));
        public static int[] ReadFileAsInteger(string fileName)
            => Array.ConvertAll(File.ReadAllLines(fileName), s => int.Parse(s));

        public class PasswordEntry
        {
            public int Min { get; set; }
            public int Max { get; set; }
            public char Policy { get; set; }
            public string Password { get; set; }

            public PasswordEntry(int min, int max, char policy, string password)
            {
                Min = min;
                Max = max;
                Policy = policy;
                Password = password;
            }

            public static PasswordEntry StringArrToEntry(string[] pwd)
            {
                return new PasswordEntry(
                    int.Parse(pwd[0]),
                    int.Parse(pwd[1]),
                    pwd[2][0],
                    pwd[3]);
            }
        }
    }
}
