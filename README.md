# Contemporary_Software_Development_Lab2

The software solution must meet the requirements outlined in the problem and requirements sections.
The summarizing lab report must not exceed 1,000 words and must be submitted in .pdf format. In the report you must demonstrate your ability to understand what your written classes do, how objects interact with other objects, and what role your classes serve in solving the problem at hand.


Problem:

Imagine that we are drawing a set of (potentially overlapping) squares and circles on a piece of (infinitely large) paper. Imagine then that we take a pen, close our eyes, and draw a dot at a random location on the paper.When we open our eyes again the point will be either be “inside” or “outside” of each shape.Let us refer to this as a hit or a miss, respectively.

Let p represent any point in this two-dimensional coordinate system (i.e.the paper). Let h(p) and m(p) be two functions that return the set of shapes that are hit and missed, respectively, by point p.The score of point p can then be computed as: the difference between the sum of the shape score of all hit shapes and a fourth of the sum of the shape score all missed shapes. 

The shape score function is defined as: shapeScore(s) = typePoints(s) ∗ instancePoints(s) (2) area(s)
where area(s) computes the area of shape s, typePoints returns 2 if s is a circle and 1 if it is a square, and instancePoints(s) returns a number specific to the s that’s been given as input to the program.

Input is given as two command line arguments. The first argument is a point in a two- dimensional coordinate system, while the second is a list of shapes along with their positions, sizes and scores.

The first argument is specified on the form (x, y) where the two letters should be replaced by integers. To make the program compute the score for the point (x = 1, y = 0), we would pass (1,0) as the first argument.

 The second argument, the shapes, arrives in CSV6 format where columns are delimited by comma (,) and rows by semi-colon (;). Note that the first row contains headers and that the order of columns might vary between inputs.

Note that since whitespace must be insignificant in all input and output to and from the program the above input example is equivalent to:
"SHAPE,X,Y,LENGTH,POINTS;CIRCLE,3,1,13,100;CIRCLE,1,-1,15,200;SQUARE,-1,0,20,300;SQUARE,-3,2,8,400;"

Your command line program should read the two command line arguments and respond with the point score for the point provided in the first argument, rounded to the nearest integer. When run with the two arguments provided in the example above, we should print 6.
