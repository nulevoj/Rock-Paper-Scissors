using System;
using System.Collections.Generic;

namespace Rock_Paper_Scissors
{
    class RockPaperScissors
    {
        int roundNumber;

        List<Player> players;
        List<Player> remainingPlayers;
        List<List<Player>> teams = new List<List<Player>>();

        Dictionary<string, string> hierarchy = new Dictionary<string, string>()
        {
            {"Rock", "Scissors"},
            {"Paper", "Rock"},
            {"Scissors", "Paper"},
        };

        public RockPaperScissors(List<Player> finalPlayers)
        {
            players = finalPlayers;
            roundNumber = 0;
        }

        public void start()
        {
            // what is better: recursion or while ???

            remainingPlayers = players;

            //do
            //{
                roundNumber++;
                splitIntoTeams();
                round();
            //} while (remainingPlayers.Count > 0);
            
        }

        private void splitIntoTeams()
        {
            int rand;
            List<Player> team;

            for (int i = 2; i < remainingPlayers.Count; i += 3)
            {
                team = new List<Player>();

                for (; i < 3; i++)
                {
                    rand = new Random().Next(remainingPlayers.Count);
                    team.Add(remainingPlayers[rand]);
                    remainingPlayers.RemoveAt(rand);
                }
                teams.Add(team);
            }

            if(teams.Count == 0)
            {
                team = new List<Player>();
                teams.Add(team);
            }
            foreach (Player s in remainingPlayers)
            {
                teams[new Random().Next(teams.Count)].Add(s);
            }
        }

        private void round()
        {
            //bool boolean;

            //foreach(List<Player> item in teams)
            //{
            //    if(item.Count == 1)
            //    {

            //    }
            //}


        }

        private void fight()
        {

        }
        
        // TODO: make class Player


    }
}
