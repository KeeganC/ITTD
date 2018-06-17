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
        public void drawPlatform(Canvas c, Point location, double width, Brush colour, double height)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = width;
            rectangle.Height = height;
            rectangle.Fill = colour;
            Canvas.SetBottom(rectangle, location.Y);
            Canvas.SetLeft(rectangle, location.X);
            c.Children.Add(rectangle);
        }
        public void drawMap1(Canvas c)
        {
            Point locFloor = new Point(0, 0);
            drawPlatform(c, locFloor, c.Width, Brushes.DarkGreen, 20);

            Point locPlatform = new Point();
            locPlatform.Y = 20;
            locPlatform.X = c.Width / 2 - 50;
            drawPlatform(c, locPlatform, 100, Brushes.Black, 70);

            locPlatform.X = 100;
            locPlatform.Y = 100;
            drawPlatform(c, locPlatform, 100, Brushes.Blue, 10);

            

            locPlatform.X = 600;
            drawPlatform(c, locPlatform, 100, Brushes.Blue, 10);

            locPlatform.X = 250;
            locPlatform.Y = 170;
            drawPlatform(c, locPlatform, 300, Brushes.Black, 20);

            locPlatform.X = 300;
            locPlatform.Y = 230;
            drawPlatform(c, locPlatform, 200, Brushes.Blue, 10);
        }
    }
    

}
