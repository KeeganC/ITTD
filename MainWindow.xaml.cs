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

        System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            //splash screen
            //canvas.Background = new ImageBrush(new BitmapImage(new Uri("TroonSplash.png", UriKind.Relative)));

            //start music, by Keegan
            //musicPlayer.Open(new Uri("TRON Legacy R3CONF1GUR3D - 06 - C.L.U. (Paul Oakenfold Remix) Daft Punk.mp3", UriKind.Relative));
            //musicPlayer.Play();

            // starts the game timer thingy
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);//fps
            gameTimer.Start();

        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            counterTimer++;
            
        }
    }
}
