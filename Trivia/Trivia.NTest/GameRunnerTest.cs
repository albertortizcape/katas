using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using FluentAssertions;
using Xunit;

namespace Trivia.NTest
{
    //[UseReporter(typeof(DiffReporter))]
    public class game_runner_should
    {
        private string OLDRESULT;

        public game_runner_should()
        {
            ReadFirstTestCaseSample();
        }

        private void ReadFirstTestCaseSample()
        {
            using (StreamReader sr = new StreamReader("./test/Redirect_01.txt"))
            {
                OLDRESULT = sr.ReadToEnd();
            }
        }

        //private static void RedirectConsoleOutput()
        //{
        //    FileStream ostrm;
        //    StreamWriter writer;
        //    TextWriter oldOut = Console.Out;
        //    try
        //    {
        //        ostrm = new FileStream("./Redirect.txt", FileMode.OpenOrCreate, FileAccess.Write);
        //        writer = new StreamWriter(ostrm);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Cannot open Redirect.txt for writing");
        //        Console.WriteLine(e.Message);
        //        return;
        //    }

        //    Console.SetOut(writer);

        //    writer.Close();
        //    ostrm.Close();
        //}

        //
        [Fact]
        public void TestMethod1()
        {
            //FileStream ostrm;
            StringWriter writer;
            TextWriter oldOut = Console.Out;
            StringBuilder sb = new StringBuilder();

            try
            {
                writer = new StringWriter(sb);

                //ostrm = new FileStream("./Redirect.txt", FileMode.OpenOrCreate, FileAccess.Write);
                //writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(writer);


            MyRandomTestable randomResults = new MyRandomTestable();
            GameRunner.ExecuteTriviaGame(randomResults);

            Console.SetOut(oldOut);
            writer.Close();
            //ostrm.Close();

            string actualExecution = sb.ToString();
            actualExecution.Should().BeEquivalentTo(OLDRESULT);

            //Approvals.Verify(actualExecution);
        }

        public class MyRandomTestable : MyRandom
        {
            private int DICERESULT = 6;
            private int SUCCESS = 6;

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
