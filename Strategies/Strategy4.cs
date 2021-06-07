using System.Collections.Generic;

namespace Strategies
{
    public class Strategy4
    {
        public bool Run(int[,] sudokufield, List<int>[,] potential, ref int globalcnt)
        {
            for (int i=1;i<=9;i++)
                for (int j=1;j<=9;j++)
                    if (potential[i,j].Count == 1)
                    {
                        sudokufield[i,j] = potential[i,j][0];
                        //Console.WriteLine("Case one {0},{1}", i, j);
                        potential[i,j] = new List<int>(new int[]{});
                        globalcnt++;
                        return true;
                    }

            return false;
        }
    }
}