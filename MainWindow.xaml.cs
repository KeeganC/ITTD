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
        Background.Maps maps;
        int counterTimer = 0;
        int bulletCounterTimer = 0;
        int hitPlayer = 0;
        int playerLives = 3;
        int player2Lives = 3;
        double playerMomentum = 0;
        double playerMoving = 0;
        double playerMovementX = 0;
        double playerMomentumUp = 0;
        double playerMovingUp = 0;
        double playerMovementY = 0;
        Point lastPos = new Point();
        bool canShoot = false;
        bool facingLeft = true;
        int bulletCounterTimer2 = 0;
        double player2Momentum = 0;
        double player2Moving = 0;
        double player2MovementX = 0;
        double player2MomentumUp = 0;
        double player2MovingUp = 0;
        double player2MovementY = 0;
        Point lastPos2 = new Point();
        bool canShoot2 = false;
        bool facingLeft2 = false;
        List<Bullet> bullets = new List<Bullet>();



        Point P1Start;
        Point P2Start;
        Player Player = new Player();
        Player Player2 = new Player();


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

        }

        public void setupGame()
        {
            //draw map
            Background map = new Background();
            map.drawMap1(canvas);
            maps = ITTD.Background.Maps.Map1;
            gameState = GameState.GameOn;

            //place character
            P1Start.X = 0;
            P1Start.Y = 0;
            P2Start.X = 0;
            P2Start.Y = 0;
            Player.createPlayer(canvas, P1Start, 1);
            Player2.createPlayer(canvas, P2Start, 2);

            //reset players
            playerLives = 3;
            player2Lives = 3;
            playerMovementX = 1;
            playerMovementY = 0;
            playerMoving = 1;
            playerMomentum = 0;
            playerMomentumUp = 0;
            playerMovingUp = 0;
            player2MovementX = 770;
            player2MovementY = 0;
            player2Moving = 770;
            player2Momentum = 0;
            player2MomentumUp = 0;
            player2MovingUp = 0;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            counterTimer++;

            if (gameState == GameState.SplashScreen)
            {
                if (Keyboard.IsKeyDown(Key.Y))
                {
                    setupGame();
                }
                if (Keyboard.IsKeyDown(Key.N))
                {
                    MessageBox.Show("Oh, okay :(");
                    Environment.Exit(0);
                }
            }

            if (gameState == GameState.GameOn)
            {


                lastPos.X = playerMovementX;
                lastPos.Y = playerMovementY;

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

                    //gravity
                    if (playerMovementY > 1)
                    {
                        //max fall speed
                        if (playerMomentumUp >= -7)
                        {
                            playerMomentumUp--;
                        }
                    }
                    else if (playerMomentumUp <= 0)
                    {
                        playerMomentumUp = 0;
                    }
                }

                if (maps == ITTD.Background.Maps.Map1)
                {
                    playerMomentum = Player.addMomentum(playerMomentum, 1);
                    playerMomentumUp = Player.addMomentumUp(playerMomentumUp, 1);

                    playerMoving += playerMomentum;
                    if (playerMovementX <= 0) //wall cycle to oposite wall
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
                    solidPlatform(0, 800, 600, 700);
                    solidPlatform(canvas.Width / 2 - 50, canvas.Width / 2 + 50, 20, 90);
                    passThroughPlatform(200, 300, 100, 110);
                    passThroughPlatform(500, 600, 100, 110);
                    solidPlatform(0, 100, 150, 170);
                    solidPlatform(canvas.Width - 100, canvas.Width, 150, 170);
                    solidPlatform(150, 650, 220, 240);
                    passThroughPlatform(150, 300, 310, 321);
                    solidPlatform(300, 500, 300, 320);
                    passThroughPlatform(500, 650, 310, 321);
                    passThroughPlatform(300, 500, 380, 390);
                    solidPlatform(0, 200, 450, 470);
                    solidPlatform(canvas.Width - 200, canvas.Width, 450, 470);


                    Player.update(canvas, playerMovementX, playerMovementY);
                }

                //check which way player is facing
                facingLeft = Player.facingLeft;

                //shoot a bullet
                if (canShoot == true)
                {
                    if (Keyboard.IsKeyDown(Key.Space))
                    {
                        bullets.Add(new Bullet(canvas, facingLeft, playerMovementX, playerMovementY));
                        canShoot = false;
                    }
                }

                //set delay in shots
                if (canShoot == false)
                {
                    bulletCounterTimer++;
                    if (bulletCounterTimer == 20)
                    {
                        canShoot = true;
                        bulletCounterTimer = 0;
                    }
                }






                //Player 2




                lastPos2.X = player2MovementX;
                lastPos2.Y = player2MovementY;

                //slow down player when not moving
                if (counterTimer % 2 == 0)
                {
                    if (player2Momentum < 0)
                    {
                        player2Momentum++;
                    }
                    if (player2Momentum > 0)
                    {
                        player2Momentum--;
                    }

                    //gravity
                    if (player2MovementY > 1)
                    {
                        //max fall speed
                        if (player2MomentumUp >= -7)
                        {
                            player2MomentumUp--;
                        }
                    }
                    else if (player2MomentumUp <= 0)
                    {
                        player2MomentumUp = 0;
                    }
                }

                if (maps == ITTD.Background.Maps.Map1)
                {
                    player2Momentum = Player2.addMomentum(player2Momentum, 2);
                    player2MomentumUp = Player2.addMomentumUp(player2MomentumUp, 2);

                    player2Moving += player2Momentum;
                    if (player2MovementX < 0) //wall cycle to oposite wall
                    {
                        player2Moving = 770;
                    }
                    if (player2Moving > 770)
                    {
                        player2Moving = 0;
                    }

                    //adjusts player's location based on momentum
                    player2Moving += player2Momentum;
                    player2MovementX = P2Start.X + player2Moving;

                    player2MovingUp += player2MomentumUp;
                    player2MovementY = P2Start.Y + player2MovingUp;
                    if (player2MovementY < 20) //floor collision
                    {
                        player2MovementY = 20;
                        player2MomentumUp = 1;
                    }

                    solidPlatform(0, 800, 600, 700);
                    solidPlatform(canvas.Width / 2 - 50, canvas.Width / 2 + 50, 20, 90);
                    passThroughPlatform(200, 300, 100, 110);
                    passThroughPlatform(500, 600, 100, 110);
                    solidPlatform(0, 100, 150, 170);
                    solidPlatform(canvas.Width - 100, canvas.Width, 150, 170);
                    solidPlatform(150, 650, 220, 240);
                    passThroughPlatform(150, 300, 310, 321);
                    solidPlatform(300, 500, 300, 320);
                    passThroughPlatform(500, 650, 310, 321);
                    passThroughPlatform(300, 500, 380, 390);
                    solidPlatform(0, 200, 450, 470);
                    solidPlatform(canvas.Width - 200, canvas.Width, 450, 470);


                    Player2.update(canvas, player2MovementX, player2MovementY);
                    Console.WriteLine(player2MovementX.ToString());
                }

                //check which way player is facing
                facingLeft2 = Player2.facingLeft;

                //shoot a bullet
                if (canShoot2 == true)
                {
                    if (Keyboard.IsKeyDown(Key.Enter))
                    {
                        bullets.Add(new Bullet(canvas, facingLeft2, player2MovementX, player2MovementY));
                        canShoot2 = false;
                    }
                }

                //set delay in shots
                if (canShoot2 == false)
                {
                    bulletCounterTimer2++;
                    if (bulletCounterTimer2 == 20)
                    {
                        canShoot2 = true;
                        bulletCounterTimer2 = 0;
                    }
                }

                //update bullet location
                foreach (Bullet b in bullets)
                {
                    b.update();
                     b.removeBullets(-100, 0, canvas.Height, 0);
                    b.removeBullets(800, 900, canvas.Height, 0);
                    b.removeBullets(canvas.Width / 2 - 50, canvas.Width / 2 + 50, 20, 90);
                    b.removeBullets(0, 100, 150, 170);
                    b.removeBullets(canvas.Width - 100, canvas.Width, 150, 170);
                    b.removeBullets(150, 650, 220, 240);
                    b.removeBullets(300, 500, 300, 320);
                    b.removeBullets(0, 200, 450, 470);
                    b.removeBullets(canvas.Width - 200, canvas.Width, 450, 470);
                    
                    hitPlayer = b.hitPlayerCheck(playerMovementX, playerMovementY, player2MovementX, player2MovementY);
                }

                //Scoring 
                if (hitPlayer == 1)
                {
                    playerLives -= 1;
                }
                if (hitPlayer == 2)
                {
                    player2Lives -= 1;
                }

                if (playerLives == 0 || player2Lives == 0)
                {
                    gameState = GameState.GameOver;
                }
            }
            if (gameState == GameState.GameOver)
            {
                if(Keyboard.IsKeyDown(Key.Enter) || Keyboard.IsKeyDown(Key.Space))
                {
                    canvas.Children.Clear();
                    gameState = GameState.SplashScreen;
                }
            }
        }

        private void passThroughPlatform(double platformLeftSide, double platformRightSide, double platformBottom, double platformTop)
        {
            //p1
            if (playerMovementX >= platformLeftSide - 30 &&
                playerMovementX <= platformRightSide &&
                playerMovementY > platformBottom &&
                playerMovementY <= platformTop - 1 &&
                lastPos.Y >= platformTop - 1) //platform player can't move through (top)
            {
                if (playerMomentumUp <= 0)
                {
                    playerMovementY = platformTop - 1;
                    playerMomentumUp = 0;
                    playerMovingUp = platformTop - 1;
                }
            }

            //p2
            if (player2MovementX >= platformLeftSide - 30 &&
                player2MovementX <= platformRightSide &&
                player2MovementY > platformBottom &&
                player2MovementY <= platformTop - 1 &&
                lastPos2.Y >= platformTop - 1) //platform player can't move through (top)
            {
                if (player2MomentumUp <= 0)
                {
                    player2MovementY = platformTop - 1;
                    player2MomentumUp = 0;
                    player2MovingUp = platformTop - 1;
                }
            }
        }
        private void solidPlatform(double platformLeftSide, double platformRightSide, double platformBottom, double platformTop)
        {
            //p1
            if (playerMovementX >= platformLeftSide - 30 &&
                playerMovementX <= platformRightSide &&
                playerMovementY > platformBottom &&
                playerMovementY < platformTop &&
                lastPos.Y >= platformTop) //platform player can't move through (top)
            {
                if (playerMomentumUp <= 0)
                {
                    playerMovementY = platformTop;
                    playerMomentumUp = 0;
                    playerMovingUp = platformTop;
                }
            }
            if (playerMovementX >= platformLeftSide - 30 &&
                playerMovementX <= platformRightSide &&
                playerMovementY > platformBottom - 35 &&
                playerMovementY < platformTop &&
                lastPos.Y + 35 <= platformBottom) //platform player can't move through (bottom)
            {
                if (playerMomentumUp > 0)
                {
                    playerMovementY = platformBottom - 35;
                    playerMomentumUp = 0;
                    playerMovingUp = platformBottom - 35;
                }
            }
            if (playerMovementX >= platformLeftSide - 30 &&
                playerMovementX <= platformRightSide - 10 &&
                playerMovementY >= platformBottom &&
                playerMovementY < platformTop &&
                lastPos.Y + 35 > platformBottom &&
                lastPos.X + 30 > platformLeftSide) //platform player can't move through (left)
            {
                if (playerMomentum > 0)
                {
                    playerMovementX = platformLeftSide - 30 + playerMomentum;
                    playerMoving = platformLeftSide - 30 + playerMomentum;
                    playerMomentum = 0;
                }
            }
            if (playerMovementX >= platformLeftSide - 30 &&
                playerMovementX <= platformRightSide - 10 &&
                playerMovementY >= platformBottom - 35 &&
                playerMovementY < platformTop - 35 &&
                lastPos.Y > platformBottom &&
                lastPos.X + 30 > platformLeftSide) //platform player can't move through (left) (additional)
            {
                if (playerMomentum > 0)
                {
                    playerMovementX = platformLeftSide - 30 + playerMomentum;
                    playerMoving = platformLeftSide - 30 + playerMomentum;
                    playerMomentum = 0;
                }
            }
            if (playerMovementX >= platformLeftSide + 10 &&
                playerMovementX <= platformRightSide &&
                playerMovementY >= platformBottom &&
                playerMovementY < platformTop &&
                lastPos.Y + 35 > platformBottom &&
                lastPos.X > platformLeftSide) //platform player can't move through (right)
            {
                if (playerMomentum < 0)
                {
                    playerMovementX = platformRightSide + playerMomentum;
                    playerMoving = platformRightSide + playerMomentum;
                    playerMomentum = 0;
                }
            }


            //p2
            if (player2MovementX >= platformLeftSide - 30 &&
                player2MovementX <= platformRightSide &&
                player2MovementY > platformBottom &&
                player2MovementY < platformTop &&
                lastPos2.Y >= platformTop) //platform player can't move through (top)
            {
                if (player2MomentumUp <= 0)
                {
                    player2MovementY = platformTop;
                    player2MomentumUp = 0;
                    player2MovingUp = platformTop;
                }
            }
            if (player2MovementX >= platformLeftSide - 30 &&
                player2MovementX <= platformRightSide &&
                player2MovementY > platformBottom - 35 &&
                player2MovementY < platformTop &&
                lastPos2.Y + 35 <= platformBottom) //platform player can't move through (bottom)
            {
                if (player2MomentumUp > 0)
                {
                    player2MovementY = platformBottom - 35;
                    player2MomentumUp = 0;
                    player2MovingUp = platformBottom - 35;
                }
            }
            if (player2MovementX >= platformLeftSide - 30 &&
                player2MovementX <= platformRightSide - 10 &&
                player2MovementY >= platformBottom &&
                player2MovementY < platformTop &&
                lastPos2.Y + 35 > platformBottom &&
                lastPos2.X + 30 > platformLeftSide) //platform player can't move through (left)
            {
                if (player2Momentum > 0)
                {
                    player2MovementX = platformLeftSide - 30 + player2Momentum;
                    player2Moving = platformLeftSide - 30 + player2Momentum;
                    player2Momentum = 0;
                }
            }
            if (player2MovementX >= platformLeftSide - 30 &&
                player2MovementX <= platformRightSide - 10 &&
                player2MovementY >= platformBottom - 35 &&
                player2MovementY < platformTop - 35 &&
                lastPos2.Y > platformBottom &&
                lastPos2.X + 30 > platformLeftSide) //platform player can't move through (left) (additional)
            {
                if (player2Momentum > 0)
                {
                    player2MovementX = platformLeftSide - 30 + player2Momentum;
                    player2Moving = platformLeftSide - 30 + player2Momentum;
                    player2Momentum = 0;
                }
            }
            if (player2MovementX >= platformLeftSide + 10 &&
                player2MovementX <= platformRightSide &&
                player2MovementY >= platformBottom &&
                player2MovementY < platformTop &&
                lastPos2.Y + 35 > platformBottom &&
                lastPos2.X > platformLeftSide) //platform player can't move through (right)
            {
                if (player2Momentum < 0)
                {
                    player2MovementX = platformRightSide + player2Momentum;
                    player2Moving = platformRightSide + player2Momentum;
                    player2Momentum = 0;
                }
            }
        }
    }
}
