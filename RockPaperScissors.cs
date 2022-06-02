using System;
using System.Collections.Generic;
using System.Text;

namespace Rock_Paper_Scissors
{
    class RockPaperScissors
    {
        Dictionary<string, string> hierarchy = new Dictionary<string, string>();
        List<string> players = new List<string>();

        RockPaperScissors()
        {
            hierarchy.Add("Rock", "Scissors");
            hierarchy.Add("Paper", "Rock");
            hierarchy.Add("Scissors", "Paper");
        }

        

    }
}
