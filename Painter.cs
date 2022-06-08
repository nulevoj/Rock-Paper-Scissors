using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Rock_Paper_Scissors
{
    class Painter
    {
        List<Border> rounds = new List<Border>();
        List<Border> teams;


        StackPanel currentRound;
        StackPanel currentTeam;




        public void drawRound()
        {
            teams = new List<Border>();

            Border border = new Border()
            {
                BorderBrush = Brushes.White,
                BorderThickness = new Thickness(5),
            };
            DockPanel dockPanel = new DockPanel();
            Label label = new Label()
            {
                Content = "Round " + (rounds.Count + 1),
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                FontSize = 20,
                // color
            };
            DockPanel.SetDock(label, Dock.Top);

            currentRound = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            
            dockPanel.Children.Add(label);
            dockPanel.Children.Add(currentRound);

            border.Child = dockPanel;
            rounds.Add(border);
            MainWindow.mainWindow.battleground.Children.Add(border);
        }

        public void drawTeam()
        {
            Border border = new Border()
            {
                BorderBrush = Brushes.Gray,
                BorderThickness = new Thickness(5),
            };
            DockPanel dockPanel = new DockPanel();
            Label label = new Label()
            {
                Content = "Team" + teams.Count + 1,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch,
                FontSize = 18,
                // color
            };
            DockPanel.SetDock(label, Dock.Top);

            currentTeam = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            dockPanel.Children.Add(label);
            dockPanel.Children.Add(currentTeam);
            border.Child = dockPanel;

            currentRound.Children.Add(border);

        }

        public void drawFight()
        {

        }

        public void drawWinner()
        {

        }

        private void drawPlayer()
        {
            Border border = new Border();
            // border
        }


    }
}

// TODO:

// refactoring class Painter

// add Readme

// restrict ctrl + V in amountTextBox
// fix generatePlayers() in amount_TextChanged() : playersPanel - Null exception