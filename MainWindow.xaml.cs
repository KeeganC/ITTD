/*Keegan Chan and Ethan Shipston
 * 6 6 2018
 * ITTD
 * A multiplayer side shooter game*/
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

namespace ITTD
{
    enum GameState { SplashScreen, GameOn, GameOver }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Global variables
        GameState gameState;
        int counterTimer = 0;
        double playerMomentum = 0;
        double playerMoving = 0;
        double playerMovementX = 0;

        Point P1Start;
        Player Player = new Player();


        System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
        MediaPlayer musicPlayer = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            //splash screen
            //canvas.Background = new ImageBrush(new BitmapImage(new Uri("TroonSplash.png", UriKind.Relative)));

            //start music
            //musicPlayer.Open(new Uri("TRON Legacy R3CONF1GUR3D - 06 - C.L.U. (Paul Oakenfold Remix) Daft Punk.mp3", UriKind.Relative));
            //musicPlayer.Play();

            //starts the game timer thingy
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);//fps
            gameTimer.Start();
            gameState = GameState.SplashScreen;

            //place character
            P1Start.X = 0;
            P1Start.Y = 10;
            Player.createPlayer(canvas, P1Start, 1);

        }

        private void setupGame()
        {
            Background map = new Background();
            map.drawMap1(canvas);
            gameState = GameState.GameOn;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            counterTimer++;

            if (gameState == GameState.SplashScreen)
            {
                setupGame();
            }
            if (gameState == GameState.GameOn)
            {

            }
            if (gameState == GameState.GameOver)
            {

            }

            if (counterTimer % 2 == 0)
            {
                if (playerMomentum < 0)
                {
                    playerMomentum++;
                }
                if (playerMomentum > 0)
                {
                    playerMomentum--;
                }
            }

            playerMoving += playerMomentum;
            if (playerMovementX < 0)
            {
                playerMoving = 770;
            }
            if (playerMoving > 770)
            {
                playerMoving = 0;
            }
            playerMovementX = P1Start.X + playerMoving;
            Player.update(playerMovementX);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //apply force in a certain direction
            if (e.Key == Key.Left)
            {
                playerMomentum--;
            }
            if (e.Key == Key.Right)
            {
                playerMomentum++;
            }

        }
    }
}
