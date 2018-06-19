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
    class Bullet
    {
        double bulletX;
        double bulletY;
        public Rectangle bullet;
        bool movingLeft = true;
        int hitPlayer = 0;
        int hitDelay = 0;
        Canvas canvas;

        public Bullet(Canvas c, bool facingLeft, double gunBarrelX, double gunBarrelY)
        {
            canvas = c;

            //create bullet
            bullet = new Rectangle();
            bullet.Width = 5;
            bullet.Height = 5;
            bullet.Fill = Brushes.Red;

            //check which side of player to spawn the bullet on
            if (facingLeft == false)
            {
                bulletX = gunBarrelX + 35;
            }
            if (facingLeft == true)
            {
                bulletX = gunBarrelX - 5;
            }
            bulletY = gunBarrelY + 15;
            canvas.Children.Add(bullet);
            Canvas.SetLeft(bullet, bulletX);
            Canvas.SetBottom(bullet, bulletY);

            movingLeft = facingLeft;
        }

        //move bullet
        public void update()
        {
            if (movingLeft == true)
            {
                bulletX -= 20;
            }
            else
            {
                bulletX += 20;
            }
            Canvas.SetLeft(bullet, bulletX);
        }

        //remove bullet when it hits something
        public void removeBullets()
        {
            if (bulletX > 800 || bulletX < 0)
            {
                canvas.Children.Remove(bullet);
            }
        }

        //Check player Collision
        public int hitPlayerCheck(double hitboxX, double hitboxY, double hitbox2X, double hitbox2Y)
        {
            hitPlayer = 0;
            hitDelay++;

            if (hitDelay >= 10)
            {
                if (bulletX > hitboxX && bulletX < hitboxX + 30 && bulletY > hitboxY && bulletY < hitboxY + 35)
                {
                    MessageBox.Show("Game Over man, Game Over\r\nP2 wins");
                    hitPlayer = 1;
                    hitDelay = 0;
                }
                if (bulletX > hitbox2X && bulletX < hitbox2X + 30 && bulletY > hitbox2Y && bulletY < hitbox2Y + 35)
                {
                    MessageBox.Show("Game Over man, Game Over\r\nP1 wins");
                    hitPlayer = 2;
                    hitDelay = 0;
                }
            }
            return hitPlayer;
        }
    }
}
