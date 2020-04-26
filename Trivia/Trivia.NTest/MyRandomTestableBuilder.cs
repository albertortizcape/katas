using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.NTest
{
    public class MyRandomTestableBuilder
    {
        private int _diceValue;
        private int _successValue;

        public MyRandomTestableBuilder WithDiceValue(int diceValue)
        {
            _diceValue = diceValue;
            return this;
        }

        public MyRandomTestableBuilder WithSuccessValue(int successValue)
        {
            _successValue = successValue;
            return this;
        }

        public MyRandomTestable Build()
        {
            return new MyRandomTestable(_diceValue, _successValue);
        }
    }
}
