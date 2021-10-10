using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace RacegameWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) /// start-knop in menu
        {
            String IngevoerdeNaam = InputName.Text; /// haalt de ingevoerde naam uit de textbox van het menu
            GameWindow game = new GameWindow(IngevoerdeNaam); /// is nodig anders stuurt menu je niet door naar de game
            game.Visibility = Visibility.Visible; /// maakt gamewindow zichtbaar tijdens het gamen
            this.Visibility = Visibility.Hidden; /// maakt mainwindow onzichtbaar tijdens het gamen
        }

        

        private void Exit_Click(object sender, RoutedEventArgs e) /// exit-knop in menu
        {

        }
    }      
}