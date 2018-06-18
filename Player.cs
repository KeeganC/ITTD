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
        public bool facingLeft = true;
        int counterTimer = 0;

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

        public void update(Canvas c, double playerMovementX, double playerMovementY)
        {
            //update the location of the player
            Canvas.SetLeft(rctPlayer, playerMovementX);
            Canvas.SetBottom(rctPlayer, playerMovementY);
        }

        public double addMomentum(double playerMomentum, int playerNum)
        {
            int speedcap = 7;
            //apply force in a certain direction
            if (playerNum == 1)
            {
                if (Keyboard.IsKeyDown(Key.A))
                {
                    facingLeft = true;
                    playerMomentum -= 1;
                    if (playerMomentum < -speedcap)//speedcap left
                    {
                        playerMomentum = -speedcap;
                    }
                }
                if (Keyboard.IsKeyDown(Key.D))
                {
                    facingLeft = false;
                    playerMomentum += 1;
                    if (playerMomentum > speedcap)//speedcap right
                    {
                        playerMomentum = speedcap;
                    }
                }
            }
            if (playerNum == 2)
            {
                if (Keyboard.IsKeyDown(Key.Left))
                {
                    facingLeft = true;
                    playerMomentum -= 1;
                    if (playerMomentum < -speedcap)//speedcap left
                    {
                        playerMomentum = -speedcap;
                    }
                }
                if (Keyboard.IsKeyDown(Key.Right))
                {
                    facingLeft = false;
                    playerMomentum += 1;
                    if (playerMomentum > speedcap)//speedcap right
                    {
                        playerMomentum = speedcap;
                    }
                }
            }
            return playerMomentum;
        }

        public double addMomentumUp(double playerMomentumUp, int playerNum)
        {
            if (playerNum == 1)
            {
                counterTimer++;

                //apply force upwards
                if (Keyboard.IsKeyDown(Key.W))
                {
                    if (canJump == true)
                    {
                        playerMomentumUp += 10;
                        canJump = false;
                        counterTimer = 0;
                    }
                }
                if (counterTimer >= 19 && Keyboard.IsKeyUp(Key.W))
                {
                    canJump = true;
                }
            }
            if (playerNum == 2)
            {
                counterTimer++;

                //apply force upwards
                if (Keyboard.IsKeyDown(Key.Up))
                {
                    if (canJump == true)
                    {
                        playerMomentumUp += 10;
                        canJump = false;
                        counterTimer = 0;
                    }
                }
                if (counterTimer >= 19 && Keyboard.IsKeyUp(Key.Up))
                {
                    canJump = true;
                }
            }
            return playerMomentumUp;
        }
    }
}
