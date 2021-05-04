using System;

namespace Contemporary_Software_Dev_Lab2
{
    // Abstract Shape class acting as Base class for specific shapes.
    // All shapes contain the values passed in from the CSV file and,
    // three methods: GetArea() which returns the area of a shape.
    // IsInside() which will returns true if a Point object is inside the shape object and false if it's outside or "on" the shape.
    // GetTypePoint() which return a shape specific point (1 for Square and 2 for Circle)

    public abstract class Shape
    {

        public int XCoordinate { get; set; } // X-coordinate of the shape
        public int YCoordinate { get; set; }  // Y-coordinate of the shape
        public int Length { get; set; }  // Circumference of the shape
        public int Points { get; set; }  // Instance points of the shape


        public Shape(int xCoordinate, int yCoordinate, int length, int points)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            this.Length = length;
            this.Points = points;
        }

        public abstract double GetArea();

        public abstract bool IsInside(Point p);

        public abstract int GetTypePoint();
    }
}
