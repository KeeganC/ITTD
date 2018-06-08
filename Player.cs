using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ITTD
{
    class Player
    {
        Rectangle rctPlayer = new Rectangle();
        Canvas canvas;
        
        //create player
        public void createPlayer(Canvas c, Point location, int playerNum)
        {
            canvas = c;
            rctPlayer.Fill = Brushes.Red;
            rctPlayer.Height = 35;
            rctPlayer.Width = 30;

            canvas.Children.Add(rctPlayer);
            Canvas.SetLeft(rctPlayer, location.X);
            Canvas.SetTop(rctPlayer, location.Y);
        }

        public void update(double playerMovementX)
        {
            Canvas.SetLeft(rctPlayer, playerMovementX);
        }
    }
}
