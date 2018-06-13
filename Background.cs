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
        public enum Maps { Map1 }
        public void drawPlatform(Canvas c, Point location, double width, Brush colour)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = width;
            rectangle.Height = 20;
            rectangle.Fill = colour;
            Canvas.SetBottom(rectangle, location.Y);
            Canvas.SetLeft(rectangle, location.X);
            c.Children.Add(rectangle);
        }
        public void drawMap1(Canvas c)
        {
            Point locFloor = new Point(0, 0);
            drawPlatform(c, locFloor, c.Width, Brushes.Red);

            Point locPlatform = new Point(100, 100);
            drawPlatform(c, locPlatform, 100, Brushes.Blue);

            locPlatform.X = 600;
            drawPlatform(c, locPlatform, 100, Brushes.Blue);

            locPlatform.X = 250;
            locPlatform.Y = 170;
            drawPlatform(c, locPlatform, 300, Brushes.Black);
        }
    }
    

}

