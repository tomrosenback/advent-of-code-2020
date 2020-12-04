using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
{
    public enum PasswordPolicy
    {
        NEW,
        OLD
    }

    public class Application
    {
        public IEnumerable<PasswordCheck> GetPasswords(string file)
        {
            var lines = File.ReadLines(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + "\\" + file);

            var passwords = from l in lines
                            where l.Trim() != string.Empty
                            select new PasswordCheck(l);

            return passwords;

        }

        public int ValidatePasswords(IEnumerable<PasswordCheck> passwords, PasswordPolicy policy)
        {
            int validPasswords;

            if (policy == PasswordPolicy.OLD)
            {
                validPasswords = OldPolicyValidation(passwords);
            }
            else
            {
                validPasswords = NewPolicyValidation(passwords);
            }

            return validPasswords;
        }

        private int OldPolicyValidation(IEnumerable<PasswordCheck> passwords)
        {
            var validPasswords = 0;

            foreach (var p in passwords)
            {
                var occurence = p.Password.Count(l => l == char.Parse(p.RequiredLetter));

                if (occurence >= p.LowerLimit && occurence <= p.UpperLimit)
                {
                    validPasswords++;
                }
            }

            return validPasswords;
        }

        private int NewPolicyValidation(IEnumerable<PasswordCheck> passwords)
        {
            var validPasswords = 0;

            foreach (var p in passwords)
            {
                var p1 = p.Password.Substring(p.LowerLimit - 1, 1);
                var p2 = p.Password.Substring(p.UpperLimit - 1, 1);

                if (p1 != p2 && (p1 == p.RequiredLetter || p2 == p.RequiredLetter))
                {
                    validPasswords++;
                }
            }

            return validPasswords;
        }
    }
}
