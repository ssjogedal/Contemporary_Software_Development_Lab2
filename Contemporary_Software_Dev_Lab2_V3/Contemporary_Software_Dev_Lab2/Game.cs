using System;
using System.Collections.Generic;

namespace Contemporary_Software_Dev_Lab2
{

    // The Game class contains the user generated point and a List of shapes.
    // We have a ShapeListGenerator() method that takes the string input from the CSV file
    // and generate Shape-object which are passed into a list.
    // A Hit and a Miss method that returns a list of shapes tht are either hit or missed by the Point.
    // A PointScore() method that calculate and returns the Point score.
    // A ScoreAnnouncer() method that just prints the PointScore() result
    
    public class Game
    {

        public Point Point;
        public List<Shape> InputList;

        // We call ShapeListGenerator() on the input string to "convert" it to a list of Shapes
        // and announces the score of the game. 
        public Game(string point, string inputList)
        {
            this.Point = PointGenerator(point);
            this.InputList = ShapeListGenerator(inputList);

            this.PointScore();
            
        }


        // Converts the string-coordinates to integers and returns a new Point object.
        public Point PointGenerator(string point)
        {
            string[] pointArr = point.Split(",");
            
            int x;
            int y;
           
            try
            {
                x = Int32.Parse(pointArr[0]);
            }
            catch (FormatException)
            {
                Console.WriteLine($"{pointArr[0]} could not be passed in as an X-coordinate, the default value (0) has been passed in its stead.");
                x = 0;
            }
            try
            {
                y = Int32.Parse(pointArr[1]);
            }
            catch (FormatException)
            {
                Console.WriteLine($"{pointArr[1]} could not be passed in as a Y-coordinate, the default value (0) has been passed in its stead.");
                y = 0;
            }

            return new Point(x, y);
        }

        // The ShapeListGenerator() extracts the values of the inputList,
        // Since the CSV file we recieve our inputList from doesn't guarantee the order of the collumns,
        // we create a string[] of headers to use as a referene to make sure we get the correct values on the right place.
        // We split the input list first by ";" to get each object at a separet index, for each index we then split by ","
        // to extract the specific values. For each value we then check what the corresponding header is for that place and store it
        // in the appropriate variable after being converted from string to int.
        // When all values from the index is extracted we check the shape value to to see what shape the object should have and pass in the variables
        // containing our extracted values. 
        public List<Shape> ShapeListGenerator(string inputList)
        {
            
            string[] splitRow = inputList.Split(";");

            List<Shape> Shapes = new List<Shape>();

            string[] header = splitRow[0].Split(",");

            // Starting at i = 1 to skip the header och Length - 1 to skip empty column at the end
            for (int i = 1; i < splitRow.Length - 1; i++) 
            {
                string[] splitCol = splitRow[i].Split(",");

                string shape = "";
                int x = 0;
                int y = 0;
                int length = 0;
                int points = 0;

                for (int j = 0; j < splitCol.Length; j++)
                {
                    string trimmedHeader = header[j].Trim();
                    string trimmedValue = splitCol[j].Trim();

                    if (trimmedHeader == "SHAPE")
                    {
                        shape = trimmedValue;
                    }
                    else if (trimmedHeader == "X")
                    {
                        try
                        {
                            x = Int32.Parse(trimmedValue);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"{trimmedValue} could not be passed in as an X-coordinate, the default value (0) has been passed in its stead.");
                            x = 0;
                        }
                    }
                    else if (trimmedHeader == "Y")
                    {
                        try
                        {
                            y = Int32.Parse(trimmedValue);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"{trimmedValue} could not be passed in as a Y-coordinate, the default value (0) has been passed in its stead.");
                            y = 0;
                        }
                    }
                    else if (trimmedHeader == "LENGTH")
                    {
                        try
                        {
                            length = Int32.Parse(trimmedValue);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"{trimmedValue} could not be passed in as Length, the default value (0) has been passed in its stead.");
                            length = 0;
                        }
                    }
                    else if (trimmedHeader == "POINTS")
                    {
                        try
                        {
                            points = Int32.Parse(trimmedValue);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"{trimmedValue} could not be passed in as Points, the default value (0) has been passed in its stead.");
                            points = 0;
                        }
                    }

                }

                if (shape == "CIRCLE")
                {
                    Shapes.Add(new Circle(x, y, length, points));
                }
                else if (shape == "SQUARE")
                {
                    Shapes.Add(new Square(x, y, length, points));
                }
                else
                {
                    throw new ArgumentException("Shape not supported");
                }

            }

            return Shapes;
        }


        // Itterates thorugh the InputList applying the IsInside method to each object
        // Return a list with object that has been hit by the point
        public List<Shape> Hit()
        {
            List<Shape> hitList = new List<Shape>();

            foreach (Shape s in this.InputList)
            {
                if (s.IsInside(this.Point))
                {
                    hitList.Add(s);
                }
            }

            return hitList;

        }


        // Itterates thorugh the InputList applying the IsInside method to each object
        // Return a list with object that has been missed by the point
        public List<Shape> Miss()
        {
            List<Shape> missList = new List<Shape>();

            foreach (Shape s in this.InputList)
            {
                if (!s.IsInside(this.Point))
                {
                    missList.Add(s);
                }
            }

            return missList;
        }


        // Itterates thorugh the hitList and missList calculating the total hit/miss score
        // Calculates and return the final point score.
        public void PointScore()
        {
            List<Shape> hitList = this.Hit();
            List<Shape> missList = this.Miss();

            double hitScore = 0;
            double missScore = 0;
            int pointScore;

            foreach (Shape s in hitList)
            {
               hitScore += (s.GetTypePoint() * s.Points) / s.GetArea();
            }

            foreach (Shape s in missList)
            {
                missScore += (s.GetTypePoint() * s.Points) / s.GetArea();
            }

            pointScore = Convert.ToInt32(hitScore - 0.25 * missScore);

            Console.WriteLine($"You scored {pointScore} point!");
        }
    }
}
