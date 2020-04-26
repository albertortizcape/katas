using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.NTest
{
    public class MyRandomTestable : MyRandom
    {
        private int DICERESULT;
        private int SUCCESS;

        public MyRandomTestable(int diceValue, int successValue)
        {
            DICERESULT = diceValue;
            SUCCESS = successValue;
        }

        public override int RollDice()
        {
            return DICERESULT;
        }

        public override int Match()
        {
            return SUCCESS;
        }
    }

    public class MyRandomTestableWithWrongAnswers : MyRandom
    {
        private int DICERESULT;
        private int SUCCESS;
        private int NumSuccess = 0;

        public MyRandomTestableWithWrongAnswers(int diceValue, int successValue)
        {
            DICERESULT = diceValue;
            SUCCESS = successValue;
        }

        public override int RollDice()
        {
            return DICERESULT;
        }

        public override int Match()
        {
            NumSuccess++;
            return NumSuccess % 3 == 0? 7 : SUCCESS;
        }
    }
}
