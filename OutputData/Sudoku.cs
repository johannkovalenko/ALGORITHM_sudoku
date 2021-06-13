using System;
using System.Text;
using System.IO;

namespace OutputData
{
    public class Sudoku
    {
        public void Print(Field[,] board)
        {
            for (int i = 1; i <=9; i++)
            {
                for(int j=1;j<=9;j++)
                {
                    if (board[i,j].number == 0)
                        Console.Write("  ");
                    else
                        Console.Write("{0} ", board[i,j].number);
                }

                Console.Write("\n");
            }

            Console.WriteLine();
        }

        public void SaveInTxt(Field[,] board, string fileName)
        {
            var sb = new StringBuilder();

            for (int i = 1; i <=9; i++)
            {
                for(int j=1;j<=9;j++)
                {
                    if (board[i,j].number == 0)
                        sb.Append("  ");
                    else
                        sb.Append(board[i,j].number + " ");
                }
                sb.Append("\r\n");
            }

            sb.Append("\r\n-----------------\r\n");
        
            File.AppendAllText(fileName, sb.ToString());
        }
    }
}