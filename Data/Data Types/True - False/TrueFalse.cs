using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedStudyBuddy
{
    [Serializable]
    public class TrueFalse : IData
    {
        public int CurrentIndex;
        public List<Question> Questions;
        public int TotalSeconds;

        [field: NonSerialized]
        private Random rnd;

        public TrueFalse() {}

        public TrueFalse(List<Question> Questions)
        {
            this.Questions = Questions;
            rnd = new Random();
        }



        public QuestionResults GetResults()
        {
            return new QuestionResults(Questions, TotalSeconds);
        }

        public TrueFalse GetMistakes()
        {
            var mistakes = new List<Question>();

            foreach (var question in Questions)
            {
                if (!question.IsCorrectAnswer.HasValue || question.IsCorrectAnswer.Value)
                    continue;

                mistakes.Add(question);
            }

            return new TrueFalse(mistakes);
        }



        DataType IData.GetType() { return DataType.TrueFalse; }

        public void Shuffle()
        {
            var rnd_num = 0;
            Question temp = null;

            for (var i = 0; i < Questions.Count; i++)
            {
                rnd_num = rnd.Next(i, Questions.Count);

                temp = Questions[i];
                Questions[i] = Questions[rnd_num];
                Questions[rnd_num] = temp;
            }
        }
    }
}
