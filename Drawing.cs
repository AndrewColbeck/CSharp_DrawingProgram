// Title:          Task 3.1P - Drawing
// Author:         Andrew Colbeck © 2018, all rights reserved.
// Version:        1.0
// Description:    This Class creates a Drawing which allowins the user to add,
//                 remove and select Shapes within the class.
// Date modified:  26/03/2018
// To Fix:         Complete!

using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame 
{
    public class Drawing 
    {
        // LOCAL VARIABLES:
        private readonly List<Shape> _shapes;
        private Color _background;
        
        // CONSTRUCTORS:
        // Default Constructor
        public Drawing() : this (Color.White) 
        {
        }
        
        public Drawing (Color background) 
        {
            _shapes = new List<Shape> ();
            Background = background;
        }

        // PROPERTIES:
        public Color Background 
        {
            get { return _background; }
            set { _background = value; }
        }
    
        public int ShapeCount 
        {
            get { return _shapes.Count; }
        }
        
        public List<Shape> SelectedShapes 
        {
            get 
            {
                List<Shape> result = new List<Shape> ();
                foreach (Shape shape in _shapes) 
                {
                    if (shape.Selected) 
                    {
                        result.Add (shape);
                    }
                }
                return result;
            }
        }

        // METHODS:
        // Add a Shape to the Drawing's List of Shapes:
        public void AddShape (Shape shape) 
        {
            _shapes.Add(shape);
        }
        
        // Collaborative Callthrough to each Shape's own Draw method:
        public void Draw() 
        {
            SwinGame.ClearScreen(Background);

            foreach (Shape shape in _shapes) 
            {
                shape.Draw ();
            }
        }
        
        // Select all Shapes at mouses position:
        public void SelectShapesAt(Point2D pt) 
        {
            foreach (Shape shape in _shapes) 
            {
                // if IsAt method returns true, shape's selected is updated:
                shape.Selected = shape.IsAt(pt);
            }
        }
        
        // Delete all selected Shapes:
        public void DeleteSelectedShapes()
        {
            foreach (Shape shape in SelectedShapes)
            {
                _shapes.Remove (shape);
            } 
        }
    }
}