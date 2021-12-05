using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AdventOfCode_2021_Day5
{
    public static class Program
    {
        public static void Main()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string file = Path.Combine(currentDirectory, @"..\..\..\input.txt");
            string path = Path.GetFullPath(file);
            string[] text = File.ReadAllText(path).Split("\n");
            const int LENGTH = 1000;

            int[,] board = new int[LENGTH,LENGTH];
            int count = 0;

            for(int i = 0; i < text.Length;i++){
                string[] currentLine = text[i].Replace(" -> ", ",").Replace("\r", "").Split(",");   // split current line into 4 coordinates, 
                                                                                                //x1,x2,y1,y2 ONLY horizontal or vertical
                int x1 = Convert.ToInt32(currentLine[0]);
                int x2 = Convert.ToInt32(currentLine[2]);
                int y1 = Convert.ToInt32(currentLine[1]);
                int y2 = Convert.ToInt32(currentLine[3]);

                if(x1 != x2 && y1 != y2)
                {
                    int distance = Math.Abs(x1-x2) + 1;
                    if(x1 > x2)
                    {
                        if(y1 > y2)
                        {
                            for(int j = 0; j < distance; j++)
                            {
                                board[x2+j,y2+j]++;
                            }
                        }
                        else
                        {
                            for(int j = 0; j < distance; j++)
                            {
                                board[x2+j,y2-j]++;
                            }
                        }
                    }
                    else
                    {
                        if(y2 > y1)
                        {
                            for(int j = 0; j < distance; j++)
                            {
                                board[x1+j,y1+j]++;
                            }
                        }
                        else
                        {
                            for(int j = 0; j < distance; j++)
                            {
                                board[x1+j,y1-j]++;
                            }
                        }
                    }
                }
                else
                {
                    if(x1 > x2){
                        int distance = x1-x2 +1;
                        for(int j = 0; j < distance; j++){
                            board[x2+j,y1]++;
                        }
                    }
                    else if (x2 > x1){
                        int distance = x2-x1 +1;

                        for(int j = 0; j < distance; j++){
                            board[x1+j,y1]++;
                        }
                    }
                    else if (y1 > y2){
                        int distance = y1-y2 +1;

                        for(int j = 0; j < distance; j++){
                            board[x1,y2+j]++;
                        }
                    }
                    else if (y2 > y1){
                        int distance = y2-y1 +1;

                        for(int j = 0; j < distance; j++){
                            board[x1,y1+j]++;
                        }
                    }
                    // count = board.Cast<int>().Max();
                }
            }
            for(int i = 0; i < LENGTH; i++){
                for(int j = 0; j < LENGTH; j++){
                    if(board[i,j] > 1){
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
