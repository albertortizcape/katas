using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia
{
    public class AmplifiedGame : Game
    {
        public string GameStatus()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ 'players': [");
            for(int i = 0; i < _players.Count; i++)
            {
                sb.AppendLine();
                sb.Append("{");

                // Player
                sb.Append("'player': '" + _players[i] + "',");

                // Penalty
                sb.Append("'pnalty': '" + _inPenaltyBox[i] + "',");

                // Places
                sb.Append("'place': '" + _places[i] + "',");

                // Purses
                sb.Append("'purses': '" + _purses[i] + "'");

                sb.Append("},");
            }
            sb.AppendLine("]}");

            return sb.ToString();
        }
    }
}
