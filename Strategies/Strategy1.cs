using System.Collections.Generic;

namespace Strategies
{
    public class Strategy1
    {
        public void Run(int[,][] blockforfield, int[,] sudokufield, List<int>[,] potential, List<int>[] potentialblock)
        {
            for (int i = 1; i <=9; i++)
            {
                for(int j=1;j<=9;j++)
                {
                    if (sudokufield[i,j] != default(int))
                    {     
                        int k = i - (i-1) % 3;
                        int l = j - (j-1) % 3;

                        foreach (int a in blockforfield[i,j])
                        {
                            var IntList = new List<int>(potentialblock[a]);
                            IntList.Remove(sudokufield[i,j]);
                            potentialblock[a] = IntList;
                        }

                        for (int m = k; m <= k+2; m++)
                        {
                            for (int n = l; n <= l+2; n++)
                            {
                                var IntList = new List<int>(potential[m,n]);
                                IntList.Remove(sudokufield[i,j]);
                                potential[m,n] = IntList;                           
                            }
                        }
                        
                        for (k = 1; k <=9; k++)
                        {
                            var IntList = new List<int>(potential[i,k]);
                            IntList.Remove(sudokufield[i,j]);
                            potential[i,k] = IntList;
                            IntList = new List<int>(potential[k,j]);
                            IntList.Remove(sudokufield[i,j]);
                            potential[k,j] = IntList;                      
                        }
                    }
                }
            }
        }
    }
}