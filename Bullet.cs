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
        bool hit = false;
        public void Shoost(Canvas c, bool facingLeft, double gunBarrelX, double gunBarrelY)
        {
            if (facingLeft == false)
            {
                gunBarrelX += 35;
            }
            if (facingLeft == true)
            {
                gunBarrelX -= 5;
            }

            Rectangle bullet = new Rectangle();
            bullet.Width = 5;
            bullet.Height = 5;
            bullet.Fill = Brushes.Green;

            if (Keyboard.IsKeyDown(Key.Enter))
            {
                c.Children.Add(bullet);
                Canvas.SetLeft(bullet, gunBarrelX);
                Canvas.SetBottom(bullet, gunBarrelY + 15);
            }
        }
    }
}
