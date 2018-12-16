// Title:          Drawing.cs
// Author:         Andrew Colbeck © 2018, all rights reserved.
// Version:        1.0
// Description:    This Class creates a Drawing which allowins the user to add,
//                 remove and select Shapes within the class.
// Date modified:  26/03/2018
// To Fix:         Complete!

using System.Collections.Generic;
using System.IO;
using SwinGameSDK;

namespace MyGame 
{
    public class Drawing 
    {
        // LOCAL VARIABLES:
        private readonly List<Shape> _shapes;
        private Color _background;
        
        // CONSTRUCTORS:
        // Default Constructor:
        public Drawing() : this (Color.White) 
        {
        }
        
        public Drawing (Color background) 
        {
            _shapes = new List<Shape> ();
            _background = background;
        }

        // PROPERTIES:
        public Color Background { get => _background; set => _background = value; }
        public int ShapeCount { get => _shapes.Count; } // READ-ONLY
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
        public virtual void Draw() 
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
        
        // Save Method:
        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            try
            {
                // Output the Background as an Integer:
                writer.WriteLine (Background.ToArgb ());
                writer.WriteLine (ShapeCount);
                
                // SaveTo Method saves Shape parameters to writer:
                foreach(Shape s in _shapes)
                {
                    s.SaveTo (writer); // s.Color, s.X, s.Y
                }
            }
            finally
            {
                writer.Close ();
            }
            
        }
        
        // Load file
        public void Load(string filename)
        {
            StreamReader reader = new StreamReader (filename);
            try 
            {
                Background = Color.FromArgb (reader.ReadInteger ());
                int count = reader.ReadInteger ();
                string kind;
                Shape s;

                for (int i = 0; i < count; i++) 
                {
                    kind = reader.ReadLine ();
                    switch (kind) 
                    {
                        case "Rectangle":
                            s = new Rectangle ();
                            break;
                        case "Circle":
                            s = new Circle ();
                            break; 
                        case "Line":
                            s = new Line ();
                            break;
                        default:
                            throw new InvalidDataException ("Unknown shape kind: " + kind);
                    }
                    s.LoadFrom (reader);
                    AddShape (s);
                }
            }
            finally 
            {
                reader.Close ();
            }
        }
    }
}