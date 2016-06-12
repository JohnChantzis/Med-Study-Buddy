using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedStudyBuddy
{
    public class Question
    {
        public int Number;
        public string Text;
        public bool Solution;
        public bool? IsCorrectAnswer;

        public Question() {}

        public Question(int Number, string Text, bool Solution)
        {
            this.Number = Number;
            this.Text = Text;
            this.Solution = Solution;
        }

        public void Answer(bool answer)
        {
            IsCorrectAnswer = answer == Solution;
        }
    }
}
