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
using System.Windows.Shapes;
using System.Windows.Threading; /// alle using voegde visual studio automatisch toe, het is nodig om de codes te laten functioneren en visual geeft het ook aan als een code niet kan functioneren zonder een bepaalde using.

namespace RacegameWPF
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private ImageBrush Player1Brush = new ImageBrush(); /// plaatje voor player 1
        private bool moveUp = false, moveDown = false, moveLeft = false, moveRight = false; /// Voor het navigeren in de game
        private DispatcherTimer gameTimer = new DispatcherTimer();

        private void GameCanvas_KeyDown(object sender, KeyEventArgs e) /// Als er op de toets gedrukt wordt beweeg naar:
        {
            if (e.Key == Key.A)
                moveLeft = true;
            if (e.Key == Key.D)
                moveRight = true;
            if (e.Key == Key.W)
                moveUp = true;
            if (e.Key == Key.S)
                moveDown = true;
        }

        private void GameCanvas_KeyUp(object sender, KeyEventArgs e) /// als de toets losgelaten is stop met bewegen 
        {
            if (e.Key == Key.A)
                moveLeft = false;
            if (e.Key == Key.D)
                moveRight = false;
            if (e.Key == Key.W)
                moveUp = false;
            if (e.Key == Key.S)
                moveDown = false;
        }



        /// er gebeurt iets na een tijd, ook als een speler nergens op klikt. Daarom is er dus een DispatcherTimer nodig
        const int SPEED = 10; /// snelheid die de auto's hebben in game

        public GameWindow(string spelerNaam) /// code die aangeeft dat het spel een spelersnaam verwacht
        {
            InitializeComponent();

            Player1Brush.ImageSource = new BitmapImage(new Uri("Pack://application:,,,/Images/Auto1Rechts.jpg")); ///zorgt ervoor dat de groenerechthoek in de code verandert naar de auto1, dus de auto is zichtbaar tijdens gamen
            Player1.Fill = Player1Brush;

            gameTimer.Interval = TimeSpan.FromMilliseconds(5); /// zie het als frames per second
            gameTimer.Tick += GameEngine; ///GameEngine
            gameTimer.Start(); /// Timer moet wel starten natuurlijk, anders staat alles stil
            GameCanvas.Focus(); /// Volgens mij stelt dit de Canvas vast, weet nog niet zeker wat het precies doet maar is wel nodig voor movement
        }

        private void GameEngine(object sender, EventArgs e)
        {
            if (moveRight)
            {
                Canvas.SetLeft(Player1, Canvas.GetLeft(Player1) + SPEED); /// Verplaatst speler + SPEED punten vanaf de linkerkant gezien. 
            }
            if (moveLeft)
            {
                Canvas.SetLeft(Player1, Canvas.GetLeft(Player1) - SPEED); /// Verplaatst speler - SPEED punten vanaf de linkerkant gezien. 
            }
        }

    }
}
