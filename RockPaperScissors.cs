using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Rock_Paper_Scissors
{
    class RockPaperScissors
    {
        int roundN;

        Dictionary<string, string> hierarchy = new Dictionary<string, string>()
        {
            {"Rock", "Scissors"},
            {"Paper", "Rock"},
            {"Scissors", "Paper"},
        };

        List<string> players;
        List<string> remaining;
        List<List<string>> teams;

        public RockPaperScissors(List<string> names)
        {
            players = names;
            roundN = 0;
        }

        public void start()
        {
            // what is better: recursion or while ???

            remaining = players;

            do
            {
                roundN++;
                splitIntoTeams();
                round();
            } while (remaining.Count > 0);
            
        }

        private void splitIntoTeams()
        {
            int rand;
            List<string> team;

            for (int i = 2; i < remaining.Count; i += 3)
            {
                team = new List<string>();

                for (; i < 3; i++)
                {
                    rand = new Random().Next(remaining.Count);
                    team.Add(remaining[rand]);
                    remaining.RemoveAt(rand);
                }
            }

            foreach (string s in remaining)
            {
                teams[new Random().Next(teams.Count)].Add(s);
            }
        }

        private void round()
        {
            
        }
        
        // TODO: make class Player


    }
}
