using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Rock_Paper_Scissors
{
    class RockPaperScissors
    {
        int roundNumber = 0;

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
                } while (teams.Count() > 0);
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
            roundNumber++;
            
            foreach (List<Player> item in teams)
            {
                if (item.Count > 1)
                {
                    fight(item);
                }

                MainWindow.draw(item, roundNumber);

                if (item.Count == 1)
                {
                    teams.Remove(item); // ??? !!!
                }
            }
        }

        private void fight(List<Player> team)
        {
            foreach(Player item in team)
            {
                int rand = new Random().Next(hierarchy.Count);
                item.choice = hierarchy.ElementAt(rand).Key;
            }

            


            
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
