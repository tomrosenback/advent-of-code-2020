using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day6
{
    public class Application
    {
        public static IEnumerable<GroupAnswers> GetAnswers(string file)
        {
            IEnumerable<GroupAnswers> answers = HelperMethods.GetRows(file, x =>
            {
                return new GroupAnswers()
                {
                    Answers = x
                };
            },
            (res, current) =>
            {
                if (res.Count > 0)
                {
                    if (current != "")
                    {
                        res[^1] += " " + current;
                    }
                    else
                    {
                        res.Add("");
                    }
                }
                else
                {
                    res.Add(current);
                }

                return res;
            });

            return answers;
        }

        public static int GetSumOfAnyoneAnswer(string file)
        {
            return GetAnswers(file).Select(a => a.AnswersOfAnyone.Count()).Sum();
        }

        public static int GetSumOfEveryoneAnswer(string file)
        {
            return GetAnswers(file).Select(a => a.AnswerOfEveryoneCount()).Sum();
        }
    }
}
