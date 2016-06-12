using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedStudyBuddy
{
    public class Cards : IData
    {
        public List<string> Front;
        public List<string> Back;

        private Random rnd;

        public Cards(List<string> Cards)
        {
            this.Front = Cards;

            rnd = new Random();
        }

        public Cards(List<string> CardsFront, List<string> CardsBack)
        {
            this.Front = CardsFront;
            this.Back = CardsBack;
            rnd = new Random();
        }



        DataType IData.GetType() { return DataType.Cards; }

        public void Shuffle()
        {
            var rnd_num = 0;
            var temp = "";


            for (var i = 0; i < Front.Count; i++)
            {
                rnd_num = rnd.Next(i, Front.Count);

                temp = Front[i];
                Front[i] = Front[rnd_num];
                Front[rnd_num] = temp;

                if (HaveBackSide())
                {
                    temp = Back[i];
                    Back[i] = Back[rnd_num];
                    Back[rnd_num] = temp;
                }
            }
        }

        public bool HaveBackSide() { return Back != null; }
    }
}
