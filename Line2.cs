// Title:           LineClass.cs
// Author:          Andrew Colbeck © 2018, all rights reserved.
// Version:         1.0
// Description:     Program designed for submission in OOP Portfolio. 
// Last modified:   28/03/2018
// To Fix:          Complete!

using System.IO;
using SwinGameSDK;

namespace MyGame
{
    public class Line : Shape
    {
        // CONSTRUCTORS:
        public Line () : this (Color.Green, 0, 0)
        {
        
        }
        
        public Line (Color clr, float x, float y) : base(clr)
        {
            X = x;
            Y = y;
        }
        
        // METHODS:
        // Override, allows the Object to override the existing method in
        // Draw, as the original method is declared as abstract:
        public override void Draw ()
        {
            if (Selected) DrawOutline ();

            SwinGame.DrawLine(Color, X, Y, (X + 50), (Y + 50));
        }

        // Draw an Outline around the Line (two small circles at start and end):
        public override void DrawOutline ()
        {
            SwinGame.FillCircle (Color.Black, X, Y, 2);
            SwinGame.FillCircle (Color.Black, (X + 50), (Y + 50), 2);
        }

        // A method to return a boolean if LMB is clicked within the line:
        public override bool IsAt (Point2D pt)
        {
            return SwinGame.PointOnLine(pt, X, Y, (X + 50), (Y + 50));
        }
        
        // SaveTo OVERRIDDEN Method for Line:
        public override void SaveTo (StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo (writer);
            writer.WriteLine (X + 50);
            writer.WriteLine (Y + 50);
        }
        
        // LoadFrom OVERRRIDEN Method for Rectangle:
        public override void LoadFrom (StreamReader reader)
        {
            base.LoadFrom (reader);
            X = reader.ReadInteger ();
            Y = reader.ReadInteger ();
        }
    }
}
