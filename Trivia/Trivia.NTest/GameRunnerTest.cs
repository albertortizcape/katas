using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using FluentAssertions.Execution;
using Xunit;

namespace Trivia.NTest
{
    [UseReporter(typeof(DiffReporter))]
    public class game_runner_should
    {
        [Fact]
        public void get_same_file_with_all_values_6()
        {
            // This comes from @catirado glidedrose solution
            // First execution: You need to copy the result to:
            // game_runner_should.same_file_with_always_result_6.approved.txt
            StringBuilder sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            var diceValue_6 = 6;
            var successValue_6 = 6;
            MyRandomTestable randomResults = new MyRandomTestable(diceValue_6, successValue_6);
            Game aGame = new Game();
            GameRunner.ExecuteTriviaGame(randomResults, aGame);

            string actualExecution = sb.ToString();
            Approvals.Verify(actualExecution);
        }

        [Fact]
        public void get_same_results_with_same_entries()
        {
            var diceValues = new List<int>() {6};
            var successValues = new List<int>() {6};

            CombinationApprovals.VerifyAllCombinations(
                ExecuteTriviaGame,
                diceValues,
                successValues);
        }

        private object ExecuteTriviaGame(int diceValue, int successValue)
        {
            MyRandomTestable randomResult = new MyRandomTestable(diceValue, successValue);
            AmplifiedGame aGame = new AmplifiedGame();

            GameRunner.ExecuteTriviaGame(randomResult, aGame);

            return aGame.GameStatus();
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
