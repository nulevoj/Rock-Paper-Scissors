using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Rock_Paper_Scissors
{
    class Player
    {
        public string name;
        public int place;
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




    }
}


