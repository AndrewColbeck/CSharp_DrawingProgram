// Title:           4-1P_ShapeDrawingV3 - Shape.cs
// Author:          Andrew Colbeck © 2018, all rights reserved.
// Version:         1.0
// Description:     This Class creates a 100x100 pixel square using SwinGame SDK.
// Date modified:   26/03/2018
// To Fix:          Complete!

using System;
using SwinGameSDK;

namespace MyGame 
{
    public abstract class Shape 
    {
        // LOCAL VARIABLES:
        private Color _color;
        private float _x, _y;
        private int _width, _height;
        private bool _selected;
        
        // CONSTRUCTORS:
        // Default Constructor:
        public Shape() : this (Color.Yellow)
        {
        }
        
        public Shape(Color color) 
        {
            _color = Color.Green;
            _x = 0;
            _y = 0;
            _width = 100;
            _height = 100;
        }
        
        // PROPERTIES:
        public Color Color { get => _color; set => _color = value; }
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
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
    }
}