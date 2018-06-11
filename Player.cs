using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ITTD
{
    class Player
    {
        Rectangle rctPlayer = new Rectangle();
        Canvas canvas;
        bool canJump = true;

        //create player
        public void createPlayer(Canvas c, Point location, int playerNum)
        {
            canvas = c;
            rctPlayer.Fill = Brushes.Red;
            rctPlayer.Height = 35;
            rctPlayer.Width = 30;

            canvas.Children.Add(rctPlayer);
            Canvas.SetLeft(rctPlayer, location.X);
            Canvas.SetBottom(rctPlayer, location.Y);
        }

        public void update(double playerMovementX, double playerMovementY)
        {
            Canvas.SetLeft(rctPlayer, playerMovementX);
            Canvas.SetBottom(rctPlayer, playerMovementY);
        }

        public double addMomentum(double playerMomentum)
        {
            //apply force in a certain direction
            if (Keyboard.IsKeyDown(Key.Left))
            {
                playerMomentum -= 1;
            }
            if (Keyboard.IsKeyDown(Key.Right))
            {
                playerMomentum += 1;
            }
            return playerMomentum;
        }

        public double addMomentumUp(double playerMomentumUp)
        {
            //apply force upwards
            if (Keyboard.IsKeyDown(Key.Up))
            {
                if (canJump == true)
                {
                    playerMomentumUp += 15;
                    canJump = false;
                }
            }
            if (Keyboard.IsKeyUp(Key.Up))
            {
                canJump = true;
            }
            return playerMomentumUp;
        }
    }
}
