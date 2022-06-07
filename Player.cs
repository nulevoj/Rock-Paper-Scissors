using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Rock_Paper_Scissors
{
    class Player
    {
        public string name;
        public string choice;
        //public int place;

        public TextBox textBox = new TextBox
        {
            BorderBrush = Brushes.Blue,
            Width = 125,
            Height = 25,
            Margin = new Thickness(5),
            TextAlignment = TextAlignment.Right,
            VerticalContentAlignment = VerticalAlignment.Center,
            FontSize = 18,
        };

        public void choose()
        {
            int rand = new Random().Next(RockPaperScissors.hierarchy.Count);
            choice = RockPaperScissors.hierarchy.ElementAt(rand).Key;
        }


    }
}


