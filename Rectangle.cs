// Title:			4-1P_ShapeDrawingV3 - Rectangle.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Rectangle Class for 4.1P Task
// Last modified:	26/03/2018
// To Fix:         	Complete!

using SwinGameSDK;

namespace MyGame
{
    // Rectangle Class inherits all features of Shape:
    public class Rectangle : Shape
    {
        // LOCAL VARIABLES:
        private int _width, _height;

        // CONSTRUCTORS:
        // Default Constructor:
        public Rectangle () : this (Color.Green, 0, 0, 100, 100)
        {
        }
        
        // By using the base keyword, it is possible to call the clr parameter
        // from within a derived class:
        public Rectangle (Color clr, float x, float y, int width, int height) : base(clr)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        
        // PROPERTIES:
        public new int Width { get => _width; set => _width = value; }
        public new int Height { get => _height; set => _height = value; }
    
        // METHODS:
        // Override, allows the Object to override the existing method in
        // Draw, as the original method is declared as abstract:
        public override void Draw ()
        {
            if (Selected) DrawOutline ();
            SwinGame.FillRectangle(Color, X, Y, Width, Height);
        }

        // Draw an Outline around the Rectangle:
		public override void DrawOutline ()
		{
			SwinGame.FillRectangle(Color.Black, (X - 2), (Y - 2), (Width + 4), (Height + 4));
		}

        // A method to return a boolean if LMB is clicked within the rectangle:
		public override bool IsAt (Point2D pt)
		{
			return SwinGame.PointInRect(pt, X, Y, Width, Height);
		}

	}
}
