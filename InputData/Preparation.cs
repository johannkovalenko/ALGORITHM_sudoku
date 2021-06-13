using System.IO;
using System.Collections.Generic;

namespace InputData
{
    public class Sudoku
    {
        public Field[,] Preparation(ref int globalcnt)
        {
            var board      = new Field[10, 10];
            string[] rawLines = File.ReadAllLines("./sudoku.txt");

            for (int i=0; i<rawLines.Length; i++)
                for(int j=0; j<rawLines[i].Length; j++) 
                {
                    int number = rawLines[i][j] == '.' ? 0 : rawLines[i][j] - '0';
                    
                    board[i+1, j+1] = new Field(i+1, j+1, number);
                    
                    if (rawLines[i][j] != '.')
                        globalcnt++;

                }

            return board;
        }
    }
}