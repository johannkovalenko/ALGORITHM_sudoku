using System.IO;

namespace InputData
{
    public class Sudoku
    {
        public void ReadOut(int[,] sudokufield, ref int globalcnt)
        {
            using (StreamReader sr = File.OpenText("./sudoku.txt"))
            {
                
                int cnt = 0;
                string line = default(string);

                while (cnt < 9)
                {
                    line = sr.ReadLine();
                    cnt++;
                    for (int a=0;a<9;a++)
                    {
                        if (line.Substring(a,1) != ".")
                        {
                            sudokufield[cnt,a+1] = int.Parse(line.Substring(a,1));
                            globalcnt++;
                        }
                    }
                }
            }
        }
    }
}