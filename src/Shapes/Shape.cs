// Title:           Shape.cs
// Author:          Andrew Colbeck © 2018, all rights reserved.
// Version:         1.0
// Description:     This Class creates a 100x100 pixel square using SwinGame SDK.
// Date modified:   26/03/2018
// To Fix:          Complete!

using System;
using System.Collections.Generic;
using System.IO;
using SwinGameSDK;

namespace MyGame 
{
    public abstract class Shape 
    {
        // SHAPE DICTIONARY:
        private static Dictionary<string, Type> _ShapeClassRegistry = new Dictionary<string, Type> ();
        
            // Add a Shape
        public static void RegisterShape(string name, Type t)
        {
            _ShapeClassRegistry [name] = t;
        }
        
            // Create Shape from key
        public static Shape CreateShape(string name)
        {
            try 
            {
                return (Shape)Activator.CreateInstance (_ShapeClassRegistry [name]);
            }
            catch( Exception e ) 
            {
                
                Console.Error.WriteLine ("Error creating Shape from {0}", e.Message);
                return null;
            }
        }
        
            // Return key of a shape
        public static string GetKey(Type t)
        {
            foreach (string s in _ShapeClassRegistry.Keys)
            {
                if (t.Equals(_ShapeClassRegistry[s]))
                {
                    return s;
                }
            }
            return null;
        }
        
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
            writer.WriteLine (GetKey(GetType ()));
            writer.WriteLine (Color.ToArgb ());
            writer.WriteLine (X);
            writer.WriteLine (Y);
        }
        
        // LoadFrom loads Shape
        public virtual void LoadFrom(StreamReader reader)
        {
            Color = Color.FromArgb (reader.ReadInteger ());
            X = reader.ReadInteger ();
            Y = reader.ReadInteger ();
        }
    }
}