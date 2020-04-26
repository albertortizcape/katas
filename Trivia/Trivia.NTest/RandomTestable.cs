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
        private int NumSuccess = 0;

        public MyRandomTestableWithWrongAnswers(int diceValue)
        {
            DICERESULT = diceValue;
        }

        public override int RollDice()
        {
            return DICERESULT;
        }

        public override int Match()
        {
            NumSuccess++;
            return NumSuccess % 7 == 0 ? 7 : new Random().Next(6);
        }
    }

    public class MyRandomTestableWithIncrementalValues : MyRandom
    {
        private int DiceResult = 0;
        private int NumSuccess = 0;

        public override int RollDice()
        {
            return NextDiceResult();
        }

        public int NextDiceResult()
        {
            if (DiceResult >= 6)
            {
                DiceResult = 0;
            }

            DiceResult++;

            return DiceResult;
        }

        public override int Match()
        {
            NumSuccess++;
            return NumSuccess % 7 == 0 ? 7 : new Random().Next(6);
        }
    }
}
