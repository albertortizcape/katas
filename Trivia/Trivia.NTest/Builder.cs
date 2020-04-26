using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.NTest
{
    public class Builder
    {
        public static MyRandomTestableBuilder Random => new MyRandomTestableBuilder();
        public static MyRandomTestableWithWrongAnswersBuilder RandomWithWrong => new MyRandomTestableWithWrongAnswersBuilder();
    }
}
