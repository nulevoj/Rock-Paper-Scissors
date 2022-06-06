using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Rock_Paper_Scissors
{
    class Player
    {
        public int place;
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




    }
}


