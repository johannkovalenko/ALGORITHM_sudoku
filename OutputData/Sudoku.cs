using System;

namespace OutputData
{
    public class Sudoku
    {
        public void Print(Field[,] fields)
        {
            for (int i = 1; i <=9; i++)
            {
                for(int j=1;j<=9;j++)
                {
                    if (fields[i,j].number == 0)
                        Console.Write("  ");
                    else
                        Console.Write("{0} ", fields[i,j].number);
                }

                Console.Write("\n");
            }
        }
    }
}