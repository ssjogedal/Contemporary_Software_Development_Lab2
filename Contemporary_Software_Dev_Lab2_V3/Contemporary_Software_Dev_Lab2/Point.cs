using System;

namespace Contemporary_Software_Dev_Lab2
{

    // Point Class for creating Point objects from the userinput-coordinates. 
    public class Point
    {
        public int XPoint { get; set; }
        public int YPoint { get; set; }

        public Point(int xPoint, int yPoint)
        {
                this.XPoint = xPoint;
                this.YPoint = yPoint;
        }
    }
}
