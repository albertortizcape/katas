using System;

namespace Trivia
{
    public class GameRunner
    {
        private static bool _notAWinner;

        public static void Main(string[] args)
        {
            MyRandom rand = new MyRandom();
            var aGame = new Game();

            ExecuteTriviaGame(rand, aGame);
        }

        public static void ExecuteTriviaGame(MyRandom rand, Game aGame)
        {
            aGame.Add("Chet");
            aGame.Add("Pat");
            aGame.Add("Sue");

            do
            {
                aGame.Roll(rand.RollDice());

                if (rand.Match() == 7)
                {
                    _notAWinner = aGame.WrongAnswer();
                }
                else
                {
                    _notAWinner = aGame.WasCorrectlyAnswered();
                }
            } while (_notAWinner);
        }
    }

    public class MyRandom
    {
        private Random _rand = new Random();

        public virtual int RollDice()
        {
            return _rand.Next(5) + 1;
        }

        public virtual int Match()
        {
            return _rand.Next(9);
        }
    }
}