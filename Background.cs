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
    class Background
    {
        public void drawWalls(Canvas c)
        {
            Rectangle leftWall = new Rectangle();
            leftWall.Height = c.Height;
            leftWall.Width = 10;
            leftWall.Fill = Brushes.Red;
            c.Children.Add(leftWall);

            Rectangle floor = new Rectangle();
            floor.Width = c.Width;
            floor.Height = 10;
            floor.Fill = Brushes.Red;
            Canvas.SetBottom(floor, 0);
            c.Children.Add(floor);

            Rectangle rightWall = new Rectangle();
            rightWall.Height = c.Height;
            rightWall.Width = 10;
            rightWall.Fill = Brushes.Red;
            Canvas.SetRight(rightWall, 0);
            c.Children.Add(rightWall);

            Rectangle roof = new Rectangle();
            roof.Height = 10;
            roof.Width = c.Width;
            roof.Fill = Brushes.Red;
            c.Children.Add(roof);
        }
    }
}
