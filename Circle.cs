// Title:			4-1P_ShapeDrawingV3 - Circle.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Program designed for submission in OOP Portfolio. 
// Last modified:	26/03/2018
// To Fix:         	Complete!

using SwinGameSDK;

namespace MyGame
{
    // Circle Class inherits all features of Shape:
    public class Circle : Shape
    {
        // LOCAL VARIABLES:
        private int _radius;
        
        // CONSTRUCTORS:
        public Circle (Color clr, int radius)
        {
        }
        
        // Default Constructor:
        public Circle () : this (Color.Blue, 50)
        {
            _radius = 50;
        }
        //PROPERTIES:
        public int Radius { get => _radius; set => _radius = value; }

		// METHODS:
        // Override, allows the Object to override the existing method in
        // Draw, as the original method is declared as abstract:
		public override void Draw ()
		{
            if (Selected) DrawOutline ();
            SwinGame.FillCircle (Color, X, Y, _radius);
		}

        // Draw an Outline around the Circle:
		public override void DrawOutline ()
		{
			SwinGame.FillCircle (Color.Black, X, Y, ( _radius + 2 ));
		}

        // A method to return a boolean if LMB is clicked within the circle:
        public override bool IsAt (Point2D pt)
        {
            return SwinGame.PointInCircle (pt, X, Y, Radius);
        }
        
	}
}
