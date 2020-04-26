using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;

namespace Trivia.NTest
{
    [UseReporter(typeof(DiffReporter))]
    public class game_runner_should
    {
        [Fact]
        public void same_file_with_allways_result_6()
        {
            // This comes from @catirado glidedrose solution
            // First execution: You need to copy the result to:
            // game_runner_should.same_file_with_allways_result_6.approved.txt

            StringBuilder sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));
            //Console.SetIn(new StringReader("a\n"));

            var diceValue_6 = 6;
            var successValue_6 = 6;
            MyRandomTestable randomResults = new MyRandomTestable(diceValue_6, successValue_6);
            GameRunner.ExecuteTriviaGame(randomResults);

            string actualExecution = sb.ToString();
            Approvals.Verify(actualExecution);
        }

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
    }
}
