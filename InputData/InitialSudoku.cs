using System.IO;
using System.Collections.Generic;

namespace InputData
{
    public class Sudoku
    {
        public void ReadOut(Field[,] fields, ref int globalcnt)
        {
            using (StreamReader sr = File.OpenText("./sudoku.txt"))
            {
                int cnt = 0;
                
                while (cnt < 9)
                {
                    string line = sr.ReadLine();
                    cnt++;
                    for (int a=0;a<9;a++)
                        if (line.Substring(a,1) != ".")
                        {
                            fields[cnt,a+1].number = int.Parse(line.Substring(a,1));
                            globalcnt++;
                        }
                    }
            }
        }
    }
}