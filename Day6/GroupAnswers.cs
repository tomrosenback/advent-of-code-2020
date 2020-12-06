using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    public class GroupAnswers
    {
        public string Answers { get; set; }

        public IEnumerable<char> AllAnswers => Answers.Replace(" ", "");
        public IEnumerable<char> AnswersOfAnyone => AllAnswers.Distinct();

        public int AnswerOfEveryoneCount()
        {
            var persons = Answers.Trim().Split(" ").Length;
            var count = 0;

            foreach (var answer in AnswersOfAnyone)
            {
                if(AllAnswers.Where(a => a == answer).Count() == persons)
                {
                    count++;
                }
            }
            
            return count;
        }
    }
}