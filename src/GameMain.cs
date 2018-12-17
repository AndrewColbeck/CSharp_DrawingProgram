// Title:          GameMain.cs
// Author:         Andrew Colbeck © 2018, all rights reserved.
// Version:        1.0
// Description:    Drawing Program that allows users to select/delete/change
//                 the colour of rectangles and background using Swingame.
// Date modified:  26/03/2018
// To Fix:         Complete!

// ** CONTROLS **     
// Spacebar:           Change background to a random colour
// Left Click:         Draw a Rectangle
// Right Click:        Select a Shape
// Backspace Button:   Delete selected Shapes
// R, C, and L Button: Toggle between Rectangle, Circle, or Line
// S                   Save Game
// O                   Open Game

using System;
using SwinGameSDK;
using System.Reflection;

namespace MyGame 
{
    public class GameMain 
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }
        
        public static void Main() 
        {
            // REGISTER SHAPES:
            Shape.RegisterShape ("Rectangle", typeof (Rectangle));
            Shape.RegisterShape ("Circle", typeof (Circle));
            Shape.RegisterShape ("Line", typeof (Line));
            
            // LOCAL VARIABLES:
            Drawing drawing = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Circle;
            
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();
            
            
            // GAME LOOP:
            while (SwinGame.WindowCloseRequested() == false) 
            {

                // Fetch the next batch of UI interaction:
                SwinGame.ProcessEvents();
                
                // Clear the screen and draw the framerate:
                SwinGame.ClearScreen(Color.White);

                
                // HANDLE INPUT:
                
                // Background Color:
                if (SwinGame.KeyTyped(KeyCode.SpaceKey)) 
                {
                    drawing.Background = SwinGame.RandomRGBColor (255);
                }
                 
                 // Rectangle:
                if (SwinGame.KeyTyped (KeyCode.RKey)) 
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                // Circle:
                if (SwinGame.KeyTyped (KeyCode.CKey)) 
                {
                    kindToAdd = ShapeKind.Circle;
                }
                
                // Line:
                if (SwinGame.KeyTyped (KeyCode.LKey)) 
                {
                    kindToAdd = ShapeKind.Line;
                }

                // Draw:
                if (SwinGame.MouseClicked(MouseButton.LeftButton)) 
                {
                    // New Shape is created (by default as a Rectangle)
                    Shape newShape = new Rectangle();
                    
                    // Switch statement reads from ShapeKind enum, and draws
                    // currently selected Shape Type:
                    switch (kindToAdd)
                    {
                        case ShapeKind.Circle:
                            Circle newCircle = new Circle ();
                            newShape = newCircle;
                        break;
                        case ShapeKind.Rectangle:
                            Rectangle newRect = new Rectangle ();
                            newShape = newRect;
                        break;
                        case ShapeKind.Line:
                            Line newLine = new Line ();
                            newShape = newLine;
                        break;
                    }
                    
                    // Apply Mouse Pointer position to Shape's x & y:
                    newShape.X = SwinGame.MouseX ();
                    newShape.Y = SwinGame.MouseY ();
                    drawing.AddShape (newShape);
                }
                
                // Select Shapes at Mouse Position when RMB is clicked:
                if (SwinGame.MouseClicked(MouseButton.RightButton)) 
                {
                    drawing.SelectShapesAt (SwinGame.MousePosition());                   
                }
                
                // Delete Selected Shapes when Backspace key is typed:
                if (SwinGame.KeyTyped(KeyCode.BackspaceKey))
                {
                    drawing.DeleteSelectedShapes ();
                }
                
                // Save all Shapes when S key is typed:
                if (SwinGame.KeyTyped(KeyCode.SKey))
                {
                    try 
                    {
                        drawing.Save ("Users/andru/Desktop/TestDrawing.txt");
                    }
                    catch( Exception e )
                    {
                        Console.Error.WriteLine ("Error saving to file: {0}", e.Message);
                    }
                    
                }
                
                // Open from Text File when O key is typed:
                if (SwinGame.KeyTyped(KeyCode.OKey))
                {
                    try 
                    {
                        drawing.Load("//Users/andru/Desktop/TestDrawing.txt"); 
                    } 
                    catch( Exception e ) 
                    {
                        Console.Error.WriteLine ("Error loading file: {0}", e.Message);
                    }
                }
                
                // Draw Assets in drawing Object:               
                drawing.Draw ();
                
                // Draw Assets on screen:
                SwinGame.DrawFramerate(0, 0);
                
                // Draw onto the screen:
                SwinGame.RefreshScreen(60);
            }
        }
    }
}