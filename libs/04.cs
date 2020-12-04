using System.Linq;
using System.Collections.Generic;

namespace Days
{
    public static class PassportProcessing
    {
        public static IEnumerable<Objects.Passport> ParsePassports(string[] passports)
        {
            List<string> fields = new List<string>();
            List<Objects.Passport> pps = new List<Objects.Passport>();

            foreach(string line in passports)
            {
                if(line == string.Empty)
                {
                    pps.Add(Objects.Passport.GetPassport(fields));
                    fields = new List<string>();
                    continue;
                }
                fields.AddRange(line.Split(' '));
            }
            if(fields.Any())
                pps.Add(Objects.Passport.GetPassport(fields));

            return pps;
        }

        public static string OutputFirst()
        {
            var sample = Helpers.ReadFile("Inputs\\04.txt");
            var passports = ParsePassports(sample);
            return passports.Count(p => p.AllRequiredField()).ToString();
        }

        public static string OutputSecond()
        {
            var sample = Helpers.ReadFile("Inputs\\04.txt");
            var passports = ParsePassports(sample);
            return passports.Count(p => p.IsValid()).ToString();
        }
    }
}