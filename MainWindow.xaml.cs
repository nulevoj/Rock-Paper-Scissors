using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rock_Paper_Scissors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int amount;
        TextBox playerTextBox;
        TextBox[] arrayOfPlayers = new TextBox[0];
        public MainWindow()
        {
            InitializeComponent();
            generatePlayers();
        }

        private void amount_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void amount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");

            if (regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }

        private void amount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (amountTextBox.Text == "" || int.Parse(amountTextBox.Text) < 2)
            {
                amountTextBox.Text = "2";
            }
            //generatePlayers();
        }

        private void amountButton_Click(object sender, RoutedEventArgs e)
        {
            players.Children.Clear();
            generatePlayers();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            amountButton_Click(sender, e);

            List<string> names = new List<string>();
            for (int i = 0; i < amount; i++)
            {
                names.Add(arrayOfPlayers[i].Text);
            }

            RockPaperScissors RPS = new RockPaperScissors(names);
            RPS.start();
        }


        private void generatePlayers()
        {
            amount = int.Parse(amountTextBox.Text);          
            if(amount > arrayOfPlayers.Length)
            {
                for (int i = arrayOfPlayers.Length; i < amount; i++)
                {
                    playerTextBox = new TextBox
                    {
                        BorderBrush = Brushes.Blue,
                        Width = 125,
                        Height = 25,
                        Margin = new Thickness(5),
                        TextAlignment = TextAlignment.Right,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        FontSize = 18,
                    };
                    playerTextBox.Name = "player" + i;
                    playerTextBox.Text = "Player" + (i + 1);

                    //playerTextBox.TextChanged += player_TextChanged;
                    arrayOfPlayers = arrayOfPlayers.Append(playerTextBox).ToArray();
                }
            }
            for (int i = 0; i < amount; i++)
            {
                players.Children.Add(arrayOfPlayers[i]);
            }
        }
        
    }
}

// TODO:
// restrict ctrl + V
// fix generatePlayers() in amount_TextChanged()