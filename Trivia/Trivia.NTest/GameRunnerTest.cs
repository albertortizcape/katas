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
            var random = Builder.Random
                .WithDiceValue(diceValue_6)
                .WithSuccessValue(successValue_6)
                .Build();

            Game aGame = new Game();
            GameRunner.ExecuteTriviaGame(random, aGame);

            string actualExecution = sb.ToString();
            Approvals.Verify(actualExecution);
        }

        [Fact]
        public void get_same_file_with_all_values_6_and_wrong_matchs_each_3_turns()
        {
            // This comes from @catirado glidedrose solution
            // First execution: You need to copy the result to:
            // game_runner_should.same_file_with_always_result_6.approved.txt
            StringBuilder sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            var diceValue_6 = 6;
            var successValue_6 = 6;
            var random = Builder.RandomWithWrong
                .WithDiceValue(diceValue_6)
                .WithSuccessValue(successValue_6)
                .Build();

            Game aGame = new Game();
            GameRunner.ExecuteTriviaGame(random, aGame);

            string actualExecution = sb.ToString();
            Approvals.Verify(actualExecution);
        }

        [Fact]
        public void get_same_results_with_same_entries()
        {
            var diceValues = new List<int>() { 6 };
            var successValues = new List<int>() { 6 };

            CombinationApprovals.VerifyAllCombinations(
                ExecuteTriviaGame,
                diceValues,
                successValues);
        }

        [Fact]
        public void get_same_results_with_same_entries_and_wrong_answers()
        {
            var diceValues = new List<int>() {6};
            var successValues = new List<int>() {6};

            CombinationApprovals.VerifyAllCombinations(
                ExecuteTriviaGameWithWrongAnswers,
                diceValues,
                successValues);
        }

        private object ExecuteTriviaGame(int diceValue, int successValue)
        {
            var randomResult = Builder.Random
                .WithDiceValue(diceValue)
                .WithSuccessValue(successValue)
                .Build();

            AmplifiedGame aGame = new AmplifiedGame();

            GameRunner.ExecuteTriviaGame(randomResult, aGame);

            return aGame.GameStatus();
        }

        private object ExecuteTriviaGameWithWrongAnswers(int diceValue, int successValue)
        {
            var randomWithWrong = Builder.RandomWithWrong
                .WithDiceValue(diceValue)
                .WithSuccessValue(successValue)
                .Build();

            AmplifiedGame aGame = new AmplifiedGame();

            GameRunner.ExecuteTriviaGame(randomWithWrong, aGame);

            return aGame.GameStatus();
        }
    }
}
