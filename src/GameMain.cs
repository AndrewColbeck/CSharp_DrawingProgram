// Title:          Task 3.1P - ShapeDrawing
// Author:         Andrew Colbeck © 2018, all rights reserved.
// Version:        1.0
// Description:    Drawing Program that allows users to select, delete, and 
//                 change the colour of rectangles and background using Swingame.
// Date modified:  26/03/2018
// To Fix:         Complete!

// Controls:       Spacebar:          Change background to a random colour
//                 Left Click:        Draw a Rectangle
//                 Right Click:       Select a Shape
//                 Backspace Button:  Delete selected Shapes
 
using System;
using SwinGameSDK;

namespace MyGame 
{
    public class GameMain 
    {
        public static void Main() 
        {
            // LOCAL VARIABLES:
            Drawing drawing = new Drawing();

            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();
            
            // GAME LOOP:
            while(SwinGame.WindowCloseRequested() == false) 
            {
                // Fetch the next batch of UI interaction:
                SwinGame.ProcessEvents();
                
                // Clear the screen and draw the framerate:
                SwinGame.ClearScreen(Color.White);

                // Change Background to random color if Spacebar Key is pressed:
                if (SwinGame.KeyTyped(KeyCode.SpaceKey)) 
                {
                    drawing.Background = SwinGame.RandomRGBColor (255);
                }
                
                // Create a new Shape at Mouse's position when LMB is clicked:
                if (SwinGame.MouseClicked(MouseButton.LeftButton)) 
                {
                    Shape myShape = new Shape();
                    myShape.X = SwinGame.MouseX();
                    myShape.Y = SwinGame.MouseY();
                    drawing.AddShape (myShape);                    
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
                
                // Draw Assets on screen
                SwinGame.DrawFramerate(0, 0);
                
                // Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}