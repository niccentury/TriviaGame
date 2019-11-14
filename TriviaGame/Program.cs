using System;
using System.Collections.Generic;

namespace TriviaGame
{
    class Program
    {
        static void Main()
        {
            Answers a = new Answers();
            Game g = new Game();
            
            a.TextFileToDictionary();
            g.GameFunc();
        }
    }
}
