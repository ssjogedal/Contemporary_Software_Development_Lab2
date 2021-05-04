using System;

namespace Contemporary_Software_Dev_Lab2
{
    // Circle class inherits from Shape class with the additional attribute "Radious", used to calculate Area.
    public class Circle : Shape
    {
        double Radious { get; set; }

        // Radious is calculated by dividing the circles circumference(Length) with 2*Pi 
        public Circle(int xCoordinate, int yCoordinate, int length, int points) : base(xCoordinate, yCoordinate, length, points)
        {
            this.Radious = this.Length / (2*Math.PI);
        }


        // GetArea() will return the area of the Circle by multiplying Pi with Radious^2
        public override double GetArea()
        {
            return Math.PI * (Math.Pow(this.Radious, 2));
        }


        // IsInside() will return true if Point p is inside the Circle. We calculate this by:
        // (Subtracting the Circles x value from the points x value)^2 and (Subtracting the Circles y value from the points y value)^2
        // Add these togheter and check if the value is less than the Circles Radius^2. 
        public override bool IsInside(Point p)
        {
            return ((Math.Pow((p.XPoint - this.XCoordinate), 2) + Math.Pow((p.YPoint - this.YCoordinate), 2)) < Math.Pow(this.Radious, 2));
        }


        // GetTypePoint() return the shape-specific score
        public override int GetTypePoint()
        {
            return 2;
        }
    }
}
