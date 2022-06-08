﻿using System;
using System.Collections.Generic;
using System.Windows;

namespace Rock_Paper_Scissors
{
    class RockPaperScissors
    {
        int roundNumber = 0;

        int rockAmount;
        int paperAmount;
        int scissorsAmount;

        bool fightIsEnd = false;
        

        List<Player> players;
        List<Player> remainingPlayers;
        List<List<Player>> teams;

        public static List<string> tools = new List<string>
            {
                "Rock",
                "Paper",
                "Scissors",
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
            MessageBox.Show("Winner: " + remainingPlayers[0].name + " - " + remainingPlayers[0].choice);
        }

        private void splitIntoTeams()
        {
            int rand;
            List<Player> team;

            teams = new List<List<Player>>();
            for (int i = 2; i < remainingPlayers.Count;)
            {
                team = new List<Player>();

                for (int j = 0; j < 3; j++)
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
            foreach (Player player in remainingPlayers)
            {
                teams[new Random().Next(teams.Count)].Add(player);
            }
        }

        private void round()
        {
            roundNumber++;

            foreach (List<Player> team in teams)
            {
                if (team.Count > 1)
                {
                    fightIsEnd = false;
                    do
                    {
                        chooseTools(team);
                        if (drawCheck(team)) { continue; }
                        fight(team);
                        MainWindow.draw(team, roundNumber);
                    } while (!fightIsEnd);
                }
            }
        }

        private void chooseTools(List<Player> team)
        {
            foreach (Player player in team)
            {
                player.choose();
            }

            if (true)
            {
                string s = "";
                foreach (Player player in team)
                {
                    s += player.name + " - " + player.choice + "\n";
                }
                MessageBox.Show(s);
            }

        }

        private bool drawCheck(List<Player> team)
        {
            bool isDraw = false;

            rockAmount = 0;
            paperAmount = 0;
            scissorsAmount = 0;

            foreach (Player player in team)
            {
                switch (player.choice)
                {
                    case "Rock":
                        rockAmount++;
                        break;
                    case "Paper":
                        paperAmount++;
                        break;
                    case "Scissors":
                        scissorsAmount++;
                        break;
                }
            }
            if (rockAmount >= 1 && paperAmount >= 1 && scissorsAmount >= 1)
            {
                isDraw = true;
            }

            if (rockAmount == 0 && paperAmount == 0
                || paperAmount == 0 && scissorsAmount == 0
                || scissorsAmount == 0 && rockAmount == 0)
            {
                isDraw = true;
            }

            return isDraw;
        }

        private void fight(List<Player> team)
        {
            fightIsEnd = true;

            string winnerTool;
            string loserTool = "";

            if (rockAmount == 0)
            {
                winnerTool = "Scissors";
                loserTool = "Paper";
            }

            else if (paperAmount == 0)
            {
                winnerTool = "Rock";
                loserTool = "Scissors";
            }

            else if (scissorsAmount == 0)
            {
                winnerTool = "Paper";
                loserTool = "Rock";
            }

            for (int i = team.Count-1; i >= 0; i--)
            {
                if (team[i].choice == loserTool)
                {
                    team.RemoveAt(i);
                }
            }
        }

        private bool teamsCheck()
        {
            foreach (List<Player> team in teams)
            {
                if (team.Count > 1)
                {
                    return true;
                }
            }
            return false;
        }

        private void countRemainingPlayers()
        {
            remainingPlayers = new List<Player>();

            foreach (List<Player> team in teams)
            {
                foreach (Player player in team)
                {
                    remainingPlayers.Add(player);
                }
            }
        }


    }
}
