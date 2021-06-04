using System.Collections.Generic;

namespace Strategies
{
    public class Strategy4
    {
        public bool Run(object[,] blockforfield, int[,] sudokufield, object[,] potential, object[] potentialblock, ref int globalcnt)
        {
            for (int i=1;i<=9;i++)
            {
                for (int j=1;j<=9;j++)
                {
                    if ((potential[i,j] as List<int>).Count == 1)
                    {
                        sudokufield[i,j] = (potential[i,j] as List<int>)[0];
                        //Console.WriteLine("Case one {0},{1}", i, j);
                        potential[i,j] = new List<int>(new int[]{});
                        globalcnt++;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}