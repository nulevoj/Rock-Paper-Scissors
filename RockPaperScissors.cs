using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Rock_Paper_Scissors
{
    class RockPaperScissors
    {
        Dictionary<string, string> hierarchy = new Dictionary<string, string>()
        {
            {"Rock", "Scissors"},
            {"Paper", "Rock"},
            {"Scissors", "Paper"},
        };

        List<string> players;

        public RockPaperScissors(List<string> names)
        {
            players = names;
        }

        public void start()
        {

        }
        



    }
}
