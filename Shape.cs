// Title:          Task 3.1P - Shape
// Author:         Andrew Colbeck © 2018, all rights reserved.
// Version:        1.0
// Description:    This Class creates a 100x100 pixel square using SwinGame SDK.
// Date modified:  26/03/2018
// To Fix:         Complete!
  
using System;
using SwinGameSDK;

namespace MyGame 
{
    public class Shape 
    {
        // LOCAL VARIABLES:
        private Color _color;
        private float _x, _y;
        private int _width, _height;
        private bool _selected;
        
        // CONSTRUCTOR:
        public Shape() 
        {
            _color = Color.Green;
            _x = 0;
            _y = 0;
            _width = 100;
            _height = 100;
        }
        
        // PROPERTIES:
        public Color Color 
        {
            get { return _color; }
            set { _color = value; }
        }

        public float X 
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y 
        {
            get { return _y; }
            set { _y = value; }
        }

        public int Width 
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height 
        {
            get { return _height; }
            set { _height = value; } 
        }

        public bool Selected 
        { 
            get { return _selected; }
            set { _selected = value; }
        }
            
        // METHODS:
        public void Draw() 
        {            
            if (_selected) 
            {
                DrawOutline ();
            }
            
            SwinGame.FillRectangle (_color, _x, _y, _width, _height);
        }
    
        // Return true if Pint2D paramter is within a Shape:
        public Boolean IsAt (Point2D pt) 
        {
            return SwinGame.PointInRect (pt, _x, _y, _width, _height);
        }
        
        // Draw a 2 pixel black line around a Shape to signify the Shape is selected:
        public void DrawOutline() 
        {
            SwinGame.FillRectangle (Color.Black, (_x - 2), (_y - 2), (_width + 4), (_height + 4));
        }
    }
}