using System;
using System.Linq;
using Helpers;
using System.Text.RegularExpressions;

namespace Day4
{
    public class PassportPart2
    {
        public PassportPart2()
        {

        }

        public PassportPart2(string row)
        {

            /*
            byr (Birth Year) - four digits; at least 1920 and at most 2002.
            iyr (Issue Year) - four digits; at least 2010 and at most 2020.
            eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
            hgt (Height) - a number followed by either cm or in:
            If cm, the number must be at least 150 and at most 193.
            If in, the number must be at least 59 and at most 76.
            hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
            ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
            pid (Passport ID) - a nine-digit number, including leading zeroes.
            cid (Country ID) - ignored, missing or not.         

            */

            Regex regex = new Regex(
                        @"byr:(?<birthyear>\d{4,})
                        |
                        ecl:(?<eyecolor>amb|blu|brn|gry|grn|hzl|oth) 
                        |
                        pid:(?<passportid>\d{9,}) 
                        |
                        eyr:(?<expirationyear>\d{4,})
                        |
                        hcl:(?<haircolor>\#[a-f0-9]{6,})
                        |
                        iyr:(?<issueyear>\d{4,})
                        |
                        cid:(?<countryid>.?[a-z0-9]+)
                        |
                        hgt:(?<height>\d+)(?<heightunit>cm|in)",
                        RegexOptions.IgnorePatternWhitespace);

            var matches = regex.Matches(row);

            BirthYear = HelperMethods.GetRegexMatchValue<int>(matches, "birthyear");
            IssueYear = HelperMethods.GetRegexMatchValue<int>(matches, "issueyear");
            ExpirationYear = HelperMethods.GetRegexMatchValue<int>(matches, "expirationyear");
            Height = HelperMethods.GetRegexMatchValue<int>(matches, "height");
            HeightUnit = HelperMethods.GetRegexMatchValue<string>(matches, "heightunit");
            HairColor = HelperMethods.GetRegexMatchValue<string>(matches, "haircolor");
            EyeColor = HelperMethods.GetRegexMatchValue<string>(matches, "eyecolor");
            PassportId = HelperMethods.GetRegexMatchValue<string>(matches, "passportid");
            CountryId = HelperMethods.GetRegexMatchValue<string>(matches, "countryid");


        }

        public int BirthYear { get; set; }
        public int IssueYear { get; set; }
        public int ExpirationYear { get; set; }
        public int Height { get; set; }
        public string HeightUnit { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportId { get; set; }

        // optional
        public string CountryId { get; set; }

        /*
            byr (Birth Year) - four digits; at least 1920 and at most 2002.
            iyr (Issue Year) - four digits; at least 2010 and at most 2020.
            eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
            hgt (Height) - a number followed by either cm or in:
            If cm, the number must be at least 150 and at most 193.
            If in, the number must be at least 59 and at most 76.
            hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
            ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
            pid (Passport ID) - a nine-digit number, including leading zeroes.
            cid (Country ID) - ignored, missing or not.         

            */

        public bool IsValid =>
            BirthYear >= 1920 && BirthYear <= 2002 &&
            IssueYear >= 2010 && IssueYear <= 2020 &&
            ExpirationYear >= 2020 && ExpirationYear <= 2030 &&
            ((HeightUnit == "cm" && Height >= 150 && Height <= 193) || (HeightUnit == "in" && Height >= 59 && Height <= 76)) &&
            !string.IsNullOrEmpty(HairColor) && HairColor.Length == 7 &&
            !string.IsNullOrEmpty(EyeColor) &&
            !string.IsNullOrEmpty(PassportId) && PassportId.Length == 9;
    }
}
