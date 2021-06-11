using System.IO;
using System.Collections.Generic;

namespace InputData
{
    public class Sudoku
    {
        public void ReadOut(Field[,] fields, ref int globalcnt)
        {
            string[] rawLines = File.ReadAllLines("./sudoku.txt");

            for (int i=0; i<rawLines.Length; i++)
                for(int j=0; j<rawLines[i].Length; j++) 
                    if (rawLines[i][j] != '.')
                    {
                        fields[i+1, j+1].number = rawLines[i][j] - '0';
                        globalcnt++;
                    }
                    else
                        fields[i+1, j+1].potential = new List<int>(new int[]{1,2,3,4,5,6,7,8,9});
        }
    }
}