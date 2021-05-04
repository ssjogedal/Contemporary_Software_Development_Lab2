using System;

namespace Contemporary_Software_Dev_Lab2
{
    class Program
    {

        static void Main(string[] args)
        {

            // Test-input from lab instructions:
            //"1,0" "SHAPE,X,Y,LENGTH,POINTS;CIRCLE,3,1,13,100;CIRCLE,1,-1,15,200;SQUARE,-1,0,20,300;SQUARE,-3,2,8,400;"

            // Test-input with untrimmed values
            //"1,0" "SHAPE,X,Y,LENGTH,POINTS;CIRCLE ,3,1,13 ,100;CIRCLE,1,-1, 15,200; SQUARE,-1,0,20,300;SQUARE,-3,2,8,400;"

            // Test-input with alternative col-order
            //"1,0" "POINTS,X,Y,LENGTH,SHAPE;100,3,1,13,CIRCLE;200,1,-1,15,CIRCLE;300,-1,0,20,SQUARE;400,-3,2,8,SQUARE;"

            // Test-input with alternative col-order and non-int coordinate:
            //"1,y" "POINTS,X,Y,LENGTH,SHAPE;100,3,1,13,CIRCLE;200,1,-1,15,CIRCLE;300,-1,0,20,SQUARE;400,-3,2,8,SQUARE;"

            Game newGame = new Game(args[0], args[1]);
            
        }
    }
}
