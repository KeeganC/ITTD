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
        public void drawMap1(Canvas c)
        {
            Rectangle floor = new Rectangle();
            floor.Width = c.Width;
            floor.Height = 10;
            floor.Fill = Brushes.Red;
            Canvas.SetBottom(floor, 0);
            c.Children.Add(floor);
        }
    }
    

}
