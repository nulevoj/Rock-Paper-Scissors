using System;
using System.Collections.Generic;

namespace Rock_Paper_Scissors
{
    class RockPaperScissors
    {
        int roundNumber = 0;

        List<Player> players;
        List<Player> remainingPlayers;
        List<List<Player>> teams = new List<List<Player>>();

        public static readonly Dictionary<string, string> hierarchy = new Dictionary<string, string>()
        {
            {"Rock", "Scissors"},
            {"Paper", "Rock"},
            {"Scissors", "Paper"},
        };

        public RockPaperScissors(List<Player> finalPlayers)
        {
            players = finalPlayers;
        }

        public void start()
        {
            remainingPlayers = players;

            do
            {
                splitIntoTeams();
                do
                {
                    round();
                } while (teamsCheck());
                countRemainingPlayers();
            } while (remainingPlayers.Count > 1);
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

            if (teams.Count == 0)
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
            roundNumber++;

            foreach (List<Player> item in teams)
            {
                if (item.Count > 1)
                {
                    chooseTools();
                    fight(item);
                }

                MainWindow.draw(item, roundNumber);
            }
        }
        
        private void chooseTools()
        {
            foreach (List<Player> team in teams)
            {
                foreach (Player player in team)
                {
                    player.choose();
                }
            }
        }

        private void fight(List<Player> team)
        {
            chooseTools();





        }

        private bool teamsCheck()
        {
            foreach (List<Player> item in teams)
            {
                if(item.Count > 1)
                {
                    return true;
                }
            }
            return false;
        }
        
        private void countRemainingPlayers()
        {
            remainingPlayers = new List<Player>();

            foreach (List<Player> item in teams)
            {
                foreach (Player player in item)
                {
                    remainingPlayers.Add(player);
                }
            }
        }


        


}
}


// TODO:

// delegate ?

// add Readme

// restrict ctrl + V in amountTextBox
// fix generatePlayers() in amount_TextChanged() : playersPanel - Null exception