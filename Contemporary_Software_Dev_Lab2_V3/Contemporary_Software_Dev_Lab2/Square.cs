using System;


namespace Contemporary_Software_Dev_Lab2
{
    // Square class inherits from Shape class with the additional attribute "Side"
    // Side contains the lenght of the objects side, to be able to calculate Area.
    public class Square : Shape
    {

        double Side { get; set; }
         
        public Square(int xCoordinate, int yCoordinate, int length, int points) : base(xCoordinate, yCoordinate, length, points)
        {
            this.Side = this.Length / 4;
        }


        // GetArea() calculate the Area of the Square by returning Side * Side
        public override double GetArea()
        {
            return Math.Pow(this.Side, 2);
        }


        // IsInside() checks if a Point p is inside this. Square by mapping out the edges of the Square
        // The xCoordinate and yCoordinate gives us the center of the square, the Side gives us the length.
        // Therefore we get the distance from the center to the edge by calculating Side / 2,
        // adding or subtracting it from the center value gives us the min and max values.
        // This allows us to check if the Point p coordinates is inside or outside the edges of the square.
        public override bool IsInside(Point p)
        {
            double a = this.XCoordinate - Side / 2;
            double b = this.XCoordinate + Side / 2;
            double c = this.YCoordinate - Side / 2;
            double d = this.YCoordinate + Side / 2;

            return ((p.XPoint > a && p.XPoint < b) && (p.YPoint > c && p.YPoint < d));
        }


        // GetTypePoint() return the shape-specific score
        public override int GetTypePoint()
        {
            return 1;
        }
    }
}
