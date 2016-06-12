using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedStudyBuddy
{
    public class QuestionResults
    {
        public List<Question> Questions;
        public TimeSpan TimeSpent;
        public int NumberOfCorrectAnswers;
        public int NumberOfMistakes;
        public int NumberOfAnsweredQuestions;
        public int NumberOfQuestions;
        public float PercentOfCorrectAnswers;
        public float PercentOfMistakes;
        public float PercentOfAnsweredQuestions;

        public QuestionResults(List<Question> Questions, int TotalSeconds)
        {
            this.Questions = Questions;
            this.TimeSpent = TimeSpan.FromSeconds(TotalSeconds);

            NumberOfQuestions = Questions.Count;

            foreach (var question in Questions)
            {
                if (!question.IsCorrectAnswer.HasValue)
                    continue;

                NumberOfAnsweredQuestions++;

                if (question.IsCorrectAnswer.Value)
                    NumberOfCorrectAnswers++;
                else
                    NumberOfMistakes++;
            }

            PercentOfCorrectAnswers = ((float)NumberOfCorrectAnswers / NumberOfAnsweredQuestions) * 100;
            PercentOfMistakes = ((float)NumberOfMistakes / NumberOfAnsweredQuestions) * 100;
            PercentOfAnsweredQuestions = ((float)NumberOfAnsweredQuestions / NumberOfQuestions) * 100;
        }
        
    }
}
