// Title:			ExtensionMethods.cs
// Author:			Andrew Colbeck © 2018, all rights reserved.
// Version:			1.0
// Description:		Program designed for submission in OOP Portfolio. 
// Last modified:	19/04/2018
// To Fix:         	Check Instructions
//
//
using System;
using System.IO;

namespace MyGame
{
    public static class ExtensionMethods
    {
    
        
        // METHODS:
        
        // The 'This' term denotes that ReadInteger is an 'extension method':
        public static int ReadInteger(this StreamReader reader)
        {
            return Convert.ToInt32 (reader.ReadLine ());
        }
    }
}
