using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ITTD
{
    class Background
    {
        public enum Maps { Map1 }
        ImageBrush solidWallCube = new ImageBrush(new BitmapImage(new Uri("Platforms/solidWallCube.png", UriKind.Relative)));
        ImageBrush solidWallCentre = new ImageBrush(new BitmapImage(new Uri("Platforms/solidWallCentre.png", UriKind.Relative)));
        ImageBrush solidWallLeftSide = new ImageBrush(new BitmapImage(new Uri("Platforms/solidWallLeftSide.png", UriKind.Relative)));
        ImageBrush solidWallRightSide = new ImageBrush(new BitmapImage(new Uri("Platforms/solidWallRightSide.png", UriKind.Relative)));

        ImageBrush platformRightSide = new ImageBrush(new BitmapImage(new Uri("Platforms/platformRightSide.png", UriKind.Relative)));
        ImageBrush platformLeftSide = new ImageBrush(new BitmapImage(new Uri("Platforms/platformLeftSide.png", UriKind.Relative)));
        ImageBrush platformCentre = new ImageBrush(new BitmapImage(new Uri("Platforms/platformCentre.png", UriKind.Relative)));
        public void drawPlatform(Canvas c, Point location, double width, ImageBrush image, double height)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = width;
            rectangle.Height = height;
            rectangle.Fill = image;
            Canvas.SetBottom(rectangle, location.Y);
            Canvas.SetLeft(rectangle, location.X);
            c.Children.Add(rectangle);
        }
        public void drawMap1(Canvas c)
        {
            Point locFloor = new Point(0, 0);
            drawPlatform(c, locFloor, c.Width, solidWallCentre, 20); //floor
            drawPlatform(c, locFloor, 14, solidWallLeftSide, 20);
            locFloor.X = c.Width - 14;
            drawPlatform(c, locFloor, 14, solidWallRightSide, 20);

            Point locPlatform = new Point();
            locPlatform.Y = 20;
            locPlatform.X = c.Width / 2 - 50;
            drawPlatform(c, locPlatform, 100, solidWallCube, 70); //solidcube

            locPlatform.X = 200;
            locPlatform.Y = 100;
            drawPlatform(c, locPlatform, 100, platformCentre, 10);
            drawPlatform(c, locPlatform, 6, platformLeftSide, 10);
            locPlatform.X = 300 - 6;
            drawPlatform(c, locPlatform, 6, platformRightSide, 10); //platform


            locPlatform.X = 500;
            drawPlatform(c, locPlatform, 100, platformCentre, 10);
            drawPlatform(c, locPlatform, 6, platformLeftSide, 10);
            locPlatform.X = 600 - 6;
            drawPlatform(c, locPlatform, 6, platformRightSide, 10); //platform

            locPlatform.X = 150;
            locPlatform.Y = 220;
            drawPlatform(c, locPlatform, 500, solidWallCentre, 20);
            drawPlatform(c, locPlatform, 14, solidWallLeftSide, 20);
            locPlatform.X = 650 - 14;
            drawPlatform(c, locPlatform, 14, solidWallRightSide, 20); //solidplatform

            locPlatform.X = 0;
            locPlatform.Y = 150;
            drawPlatform(c, locPlatform, 100, solidWallCentre, 20);
            locPlatform.X = 100 - 14;
            drawPlatform(c, locPlatform, 14, solidWallRightSide, 20); //solidplatform

            locPlatform.X = c.Width - 100;
            drawPlatform(c, locPlatform, 100, solidWallCentre, 20);
            drawPlatform(c, locPlatform, 14, solidWallLeftSide, 20); //solidplatform
        }
    }


}
