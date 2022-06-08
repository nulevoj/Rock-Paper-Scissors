using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Rock_Paper_Scissors
{
    class Painter
    {
        int roundNumber = 0;
        int teamNumber;





        StackPanel currentRound;
        StackPanel currentTeam;
        StackPanel currentFight;



        public void drawRound()
        {
            teamNumber = 0;
            roundNumber++;
            Border border = new Border()
            {
                BorderBrush = Brushes.White,
                BorderThickness = new Thickness(5),
            };
            DockPanel dockPanel = new DockPanel();
            Label label = new Label()
            {
                Content = "Round " + roundNumber,
                HorizontalAlignment = HorizontalAlignment.Center,
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
            MainWindow.mainWindow.battleground.Children.Add(border);
        }

        public void drawTeam()
        {
            teamNumber++;

            Border border = new Border()
            {
                BorderBrush = Brushes.Gray,
                BorderThickness = new Thickness(5),
            };
            DockPanel dockPanel = new DockPanel();
            Label label = new Label()
            {
                Content = "Team" + teamNumber,
                HorizontalAlignment = HorizontalAlignment.Center,
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

        public void drawFight(List<Player> team)
        {

            currentFight = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            currentTeam.Children.Add(currentFight);

            foreach (Player player in team)
            {
                drawFighter(player);
            }
        }

        private void drawFighter(Player player)
        {
            Border border = new Border()
            {
                BorderBrush = Brushes.Blue,
                BorderThickness = new Thickness(5),
            };

            DockPanel dockPanel = new DockPanel();
            Label label = new Label()
            {
                Content = player.name,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 16,
                // color
            };
            DockPanel.SetDock(label, Dock.Top);

            Image image = new Image();
            image.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/" + player.choice +".png"));
            image.Height = image.Width = 50;
            





            dockPanel.Children.Add(label);
            dockPanel.Children.Add(image);


            border.Child = dockPanel;

            currentFight.Children.Add(border);


        }

        

        public void drawWinner(List<Player> team)
        {
            drawFight(team);
        }

    }
}

// TODO:

// refactoring class Painter

// add Readme

// restrict ctrl + V in amountTextBox
// fix generatePlayers() in amount_TextChanged() : playersPanel - Null exception