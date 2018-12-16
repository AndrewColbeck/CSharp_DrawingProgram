// Title:           Shape.cs
// Author:          Andrew Colbeck © 2018, all rights reserved.
// Version:         1.0
// Description:     This Class creates a 100x100 pixel square using SwinGame SDK.
// Date modified:   26/03/2018
// To Fix:          Complete!

using System;
using System.IO;
using SwinGameSDK;

namespace MyGame 
{
    public abstract class Shape 
    {
        // LOCAL VARIABLES:
        private Color _color;
        private float _x, _y;
        private bool _selected;
        
        // CONSTRUCTORS:
        // Default Constructor:
        protected Shape() : this (Color.Yellow)
        {
        }
        
        protected Shape(Color color) 
        {
            _color = color;
            _x = 0;
            _y = 0;
        }
        
        // PROPERTIES:
        public Color Color { get => _color; set => _color = value; }
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public bool Selected { get => _selected; set => _selected = value; }

        // METHODS:
        // Abstract Draw method is overridden depending on 'kind of' Shape:
        public abstract void Draw ();

        // Abstract method returns true if Pint2D parameter is within a 
        // 'kind of' Shape, Shape boundaries are determined by kind:
        public abstract Boolean IsAt (Point2D pt);

        // Abstract method draws a 2 pixel black line around a Shape to 
        // signify the Shape is selected, the outline is determined by 'kind':
        public abstract void DrawOutline ();
        
        // SaveTo Method will save Shape details to file:
        public virtual void SaveTo(StreamWriter writer) 
        {
            writer.WriteLine (Color.ToArgb ());
            writer.WriteLine (X);
            writer.WriteLine (Y);
        }
        
        public virtual void LoadFrom(StreamReader reader)
        {
            Color = Color.FromArgb (reader.ReadInteger ());
            X = reader.ReadInteger ();
            Y = reader.ReadInteger ();
        }
    }
}