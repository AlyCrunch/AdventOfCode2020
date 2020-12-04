using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Days.Objects
{
    public class Passport
    {
        public int? BirthYear { get; set; } = null;
        public int? IssueYear { get; set; } = null;
        public int? ExpirationYear { get; set; } = null;
        public (int size, string unit)? Height { get; set; } = null;
        public string HairColor { get; set; } = null;
        public string EyeColor { get; set; } = null;
        public string PassportID { get; set; } = null;
        public string CountryID { get; set; } = null;

        private readonly Regex hcRegex = new Regex(@"^#(?:[0-9a-fA-F]{3}){1,2}$");
        private readonly Regex pidRegex = new Regex(@"^\d{9}$");
        private readonly string[] eyeColors = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

        public bool AllRequiredField()
        {
            if (BirthYear == null) return false;
            if (IssueYear == null) return false;
            if (ExpirationYear == null) return false;
            if (Height == null) return false;
            if (HairColor == null) return false;
            if (EyeColor == null) return false;
            if (PassportID == null) return false;

            return true;
        }
        public bool IsValid()
        {
            if (!AllRequiredField()) return false;
            if (BirthYear.HasValue && !ValidBirthYear(BirthYear.Value)) return false;
            if (IssueYear.HasValue && !ValidIssueYear(IssueYear.Value)) return false;
            if (ExpirationYear.HasValue && !ValidExpirationYear(ExpirationYear.Value)) return false;
            if (Height.HasValue && !ValidHeight(Height.Value)) return false;
            if (!ValidHairColor(HairColor)) return false;
            if (!ValidEyeColor(EyeColor)) return false;
            if (!ValidPassportID(PassportID)) return false;
            return true;
        }

        public static Passport GetPassport(IEnumerable<string> passport)
        {
            var pass = new Passport();
            foreach(var field in passport)
            {
                var kv = field.Split(':');
                if (kv.Length < 2) continue;

                switch (kv[0])
                {
                    case "byr": pass.BirthYear = int.Parse(kv[1]); break;
                    case "iyr": pass.IssueYear = int.Parse(kv[1]); break;
                    case "eyr": pass.ExpirationYear = int.Parse(kv[1]); break;
                    case "hgt": pass.Height = GetHeightFromString(kv[1]); break;
                    case "hcl": pass.HairColor = kv[1]; break;
                    case "ecl": pass.EyeColor = kv[1]; break;
                    case "pid": pass.PassportID = kv[1]; break;
                    case "cid": pass.CountryID = kv[1]; break;
                    default:
                        break;
                }
            }

            return pass;
        }

        private static (int,string)? GetHeightFromString(string height)
        {
            if (height.Length <= 3) return (int.Parse(height), null);
            var size = int.Parse(string.Concat(height.Where(c => char.IsDigit(c))));

            if (height.Contains("in")) return (size, "in");
            if (height.Contains("cm")) return (size, "cm");

            return null;
        }

        public bool ValidBirthYear(int by)
            => by >= 1920 && by <= 2002;
        public bool ValidIssueYear(int iy)
            => iy >= 2010 && iy <= 2020;
        public bool ValidExpirationYear(int ey)
            => ey >= 2020 && ey <= 2030;
        public bool ValidHeight((int size, string unit) h)
            => (h.unit == "in" && h.size >= 59 && h.size <= 76)
            || (h.unit == "cm" && h.size >= 150 && h.size <= 193);
        public bool ValidHairColor(string hc)
            => hcRegex.IsMatch(hc);
        public bool ValidEyeColor(string ec)
            => eyeColors.Contains(ec);
        public bool ValidPassportID(string pid)
            => pidRegex.IsMatch(pid);
    }
}
