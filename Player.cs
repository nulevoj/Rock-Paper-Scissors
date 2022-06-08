using System;
using System.Collections.Generic;
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

        public List<Border> borders = new List<Border>();

            

        public void choose()
        {
            int rand = new Random().Next(RockPaperScissors.tools.Count);
            choice = RockPaperScissors.tools.ElementAt(rand);
        }


    }
}


