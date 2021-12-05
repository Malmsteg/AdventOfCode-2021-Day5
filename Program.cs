using System.IO;
using System.Collections.Generic;
using System;

namespace AdventOfCode_2021_Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string file = Path.Combine(currentDirectory, @"..\..\..\test.txt");
            string path = Path.GetFullPath(file);
            string[] text = File.ReadAllText(path).Split("\n");
            const int LENGTH = 1000;

            string currentLine = text[0];   // split current line into 4 coordinates, 
                                            //  x1,x2,y1,y2 ONLY horizontal or vertical







        }
    }
}
