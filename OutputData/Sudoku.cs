using System;

namespace OutputData
{
    public class Sudoku
    {
        public void Print(int[,] sudokufield)
        {
            for (int i = 1; i <=9; i++)
            {
                for(int j=1;j<=9;j++)
                {
                    if (sudokufield[i,j] == 0)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write("{0} ", sudokufield[i,j]);
                    }
                    
                }
                Console.Write("\n");
            }
        }
    }
}