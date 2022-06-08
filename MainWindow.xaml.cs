using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Rock_Paper_Scissors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int amount;
        Player[] players = new Player[0];
        private static MainWindow mainWindow;

        public MainWindow()
        {
            InitializeComponent();
            initialization();
        }

        private void initialization()
        {
            MainWindow.mainWindow = this;

            amountTextBox.Text = "2";
            amountButton_Click(null, null);
        }

        private void amountTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void amountTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");

            if (regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }

        private void amountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (amountTextBox.Text == "" || int.Parse(amountTextBox.Text) < 2)
            {
                amountTextBox.Text = "2";
            }
            //generatePlayers();
        }

        private void amountButton_Click(object sender, RoutedEventArgs e)
        {
            amount = int.Parse(amountTextBox.Text);
            generatePlayers();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            amountButton_Click(sender, e);

            List<Player> finalPlayers = new List<Player>();

            for (int i = 0; i < amount; i++)
            {
                players[i].name = players[i].textBox.Text;
                finalPlayers.Add(players[i]);
            }

            RockPaperScissors RPS = new RockPaperScissors(finalPlayers);
            RPS.start();
        }

        private void generatePlayers()
        {
            playersPanel.Children.Clear();

            if (amount > players.Length)
            {
                Player player;
                for (int i = players.Length; i < amount; i++)
                {
                    player = new Player();
                    // !!!
                    players = players.Append(player).ToArray();

                    players[players.Length - 1].textBox.Name = "player" + i;
                    players[players.Length - 1].textBox.Text = "Player" + (i + 1);
                    //players[players.Length - 1].textBox.TextChanged += player_TextChanged;
                }
            }
            for (int i = 0; i < amount; i++)
            {
                playersPanel.Children.Add(players[i].textBox);
            }
        }

        internal static void draw(List<Player> team, int roundNumber)
        {

            // team contains 1-5 players. Overload???



        }



        
    }
}

// TODO:

// draw(*)

// add Readme

// restrict ctrl + V in amountTextBox
// fix generatePlayers() in amount_TextChanged() : playersPanel - Null exception
