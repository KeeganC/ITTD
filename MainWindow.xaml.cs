/*Keegan Chan
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
        double playerMomentumUp = 0;
        double playerMovingUp = 0;
        double playerMovementY = 0;


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
            P1Start.X = 10;
            P1Start.Y = 40;
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

                //slow down player when not moving
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

                    if (playerMovementY > 10)
                    {
                        playerMomentumUp--;
                    }
                    else if (playerMomentumUp <= 0)
                    {
                        playerMomentumUp = 0;
                    }
                }

                playerMomentum = Player.addMomentum(playerMomentum);
                playerMomentumUp = Player.addMomentumUp(playerMomentumUp);

                playerMoving += playerMomentum;
                if (playerMovementX < 0) //wall cycle to oposite wall
                {
                    playerMoving = 770;
                }
                if (playerMoving > 770)
                {
                    playerMoving = 0;
                }

                //adjusts player's location based on momentum
                playerMoving += playerMomentum;
                playerMovementX = P1Start.X + playerMoving;
                
                playerMovingUp += playerMomentumUp;
                playerMovementY = P1Start.Y + playerMovingUp;
                if (playerMovementY < 20) //floor collision
                {
                    playerMovementY = 20;
                    playerMomentumUp = 1;
                }
                Player.update(playerMovementX, playerMovementY);
            }

            if (gameState == GameState.GameOver)
            {

            }
        }

    }
}
