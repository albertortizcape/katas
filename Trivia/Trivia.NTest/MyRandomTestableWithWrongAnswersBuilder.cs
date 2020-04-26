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
        private int _successValue;

        public MyRandomTestableWithWrongAnswersBuilder WithDiceValue(int diceValue)
        {
            _diceValue = diceValue;
            return this;
        }

        public MyRandomTestableWithWrongAnswersBuilder WithSuccessValue(int successValue)
        {
            _successValue = successValue;
            return this;
        }

        public MyRandomTestableWithWrongAnswers Build()
        {
            return new MyRandomTestableWithWrongAnswers(_diceValue, _successValue);
        }
    }
}
