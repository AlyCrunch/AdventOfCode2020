using System;
using System.Collections.Generic;
using System.Text;

namespace Days.Objects
{
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
