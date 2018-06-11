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
        public void drawPlatform(Canvas c, Point location, double width)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = width;
            rectangle.Height = 20;
            rectangle.Fill = Brushes.Red;
            Canvas.SetTop(rectangle, location.Y);
            Canvas.SetLeft(rectangle, location.X);
            c.Children.Add(rectangle);
        }

        public void drawMap1(Canvas c)
        {
            Point locFloor = new Point(0, c.Height - 20);
            Point locPlatform = new Point(100, 500);
            drawPlatform(c, locFloor, c.Width);
            drawPlatform(c, locPlatform, 100);
        }
    }


}