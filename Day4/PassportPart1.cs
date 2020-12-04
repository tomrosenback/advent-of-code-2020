using System.Linq;
using System.Text.RegularExpressions;
using Helpers;

namespace Day4
{
    public class PassportPart1
    {
        public PassportPart1()
        {

        }

        public PassportPart1(string row)
        {

            /*
            byr (Birth Year)
            iyr (Issue Year)
            eyr (Expiration Year)
            hgt (Height)
            hcl (Hair Color)
            ecl (Eye Color)
            pid (Passport ID)
            cid (Country ID)
            
            

            */
            
            Regex regex = new Regex(
                        @"byr:(?<birthyear>.?[a-z0-9]+)
                        |
                        ecl:(?<eyecolor>.?[a-z0-9]+)
                        |
                        pid:(?<passportid>.?[a-z0-9]+)
                        |
                        eyr:(?<expirationyear>.?[a-z0-9]+)
                        |
                        hcl:(?<haircolor>.?[a-z0-9]+)
                        |
                        iyr:(?<issueyear>.?[a-z0-9]+)
                        |
                        cid:(?<countryid>.?[a-z0-9]+)
                        |
                        hgt:(?<height>.?[a-z0-9]+)",
                        RegexOptions.IgnorePatternWhitespace);

            var matches = regex.Matches(row);

            BirthYear = HelperMethods.GetRegexMatchValue<string>(matches, "birthyear");
            IssueYear = HelperMethods.GetRegexMatchValue<string>(matches, "issueyear");
            ExpirationYear = HelperMethods.GetRegexMatchValue<string>(matches, "expirationyear");
            Height = HelperMethods.GetRegexMatchValue<string>(matches, "height");
            HairColor = HelperMethods.GetRegexMatchValue<string>(matches, "haircolor");
            EyeColor = HelperMethods.GetRegexMatchValue<string>(matches, "eyecolor");
            PassportId = HelperMethods.GetRegexMatchValue<string>(matches, "passportid");
            CountryId = HelperMethods.GetRegexMatchValue<string>(matches, "countryid");
        }

        public string BirthYear { get; set; }
        public string IssueYear { get; set; }
        public string ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportId { get; set; }

        // optional
        public string CountryId { get; set; }

        public bool IsValid =>
            !string.IsNullOrEmpty(BirthYear) &&
            !string.IsNullOrEmpty(IssueYear) &&
            !string.IsNullOrEmpty(ExpirationYear) &&
            !string.IsNullOrEmpty(Height) &&
            !string.IsNullOrEmpty(HairColor) &&
            !string.IsNullOrEmpty(EyeColor) &&
            !string.IsNullOrEmpty(PassportId);
    }
}
