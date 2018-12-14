// Title:          4-1P_ShapeDrawingV3 - GameMain.cs
// Author:         Andrew Colbeck © 2018, all rights reserved.
// Version:        1.0
// Description:    Drawing Program that allows users to select/delete/change
//                 the colour of rectangles and background using Swingame.
// Date modified:  26/03/2018
// To Fix:         Complete!

// --------------------------------
// ** REFLECTIONS ON ABSTRACTION**
// --------------------------------
/* As we approach a particular problem or begin to imagine how a set of tasks or 
 objects may interact to fullfil a desired outcome, we begin the process of 
 mentally abstracting representations of these things as they exist in reality.

 During this process and throughout continual development of our Programs, we 
 further refine these abstractions and begin to make decisions about how they 
 should be represented in code, what they should “know”, and what they should be 
 able to “do”.

 In this Program abstraction allows us to override the Draw(), DrawOutline(), 
 and Shape Class in a way that informs the compiler that the methods exist, 
 but that they will also morph to suit the ‘kind of’ Shape which has yet to be 
 created.

 This allows the compiler to prepare for the execution of these methods while 
 remaining agnostic to the actual resources and the way they will interact until 
 the methods are eventually called. */

using SwinGameSDK;

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
            // LOCAL VARIABLES:
            Drawing drawing = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Circle;
            
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();
            
            // GAME LOOP:
            while (SwinGame.WindowCloseRequested() == false) 
            {
                // ** CONTROLS **     
                // Spacebar:           Change background to a random colour
                // Left Click:         Draw a Rectangle
                // Right Click:        Select a Shape
                // Backspace Button:   Delete selected Shapes
                // R, C, and L Button: Toggle between Rectangle, Circle, or Line
                
                // Fetch the next batch of UI interaction:
                SwinGame.ProcessEvents();
                
                // Clear the screen and draw the framerate:
                SwinGame.ClearScreen(Color.White);

                // Change Background to random color if Spacebar Key is pressed:
                if (SwinGame.KeyTyped(KeyCode.SpaceKey)) 
                {
                    drawing.Background = SwinGame.RandomRGBColor (255);
                }
                
                // If R Key is pressed: Shape type changes to Rectangle:
                if (SwinGame.KeyTyped (KeyCode.RKey)) 
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                
                // If C Key is pressed: Shape type changes to Circle:
                if (SwinGame.KeyTyped (KeyCode.CKey)) 
                {
                    kindToAdd = ShapeKind.Circle;
                }
                
                // If L Key is pressed: Shape type changes to Line:
                if (SwinGame.KeyTyped (KeyCode.LKey)) 
                {
                    kindToAdd = ShapeKind.Line;
                }

                // Create a new Shape at Mouse's position when LMB is clicked:
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