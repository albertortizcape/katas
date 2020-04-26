using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.NTest
{
    public class MyRandomTestableWithWrongAnswersBuilder
    {
        private int _diceValue;

        public MyRandomTestableWithWrongAnswersBuilder WithDiceValue(int diceValue)
        {
            _diceValue = diceValue;
            return this;
        }

        public MyRandomTestableWithWrongAnswers Build()
        {
            return new MyRandomTestableWithWrongAnswers(_diceValue);
        }
    }
}
