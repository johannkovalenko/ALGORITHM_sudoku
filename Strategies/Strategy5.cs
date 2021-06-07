using System.Collections.Generic;
using System;

namespace Strategies
{
    public class Strategy5
    {
        public bool Run(int[,] sudokufield, List<int>[,] potential, List<List<int>> potentialblock, List<int>[,] furtherinfluencingblocks, ref int globalcnt)
        {
            List<string> BorderingBlock = new List<string>();
            
            for (int i=1;i<=9;i++)
                for (int j=1;j<=9;j++)
                {
                    int k = i - (i-1) % 3;
                    int l = j - (j-1) % 3;

                    foreach (int a in potential[i,j])
                    {
                        BorderingBlock.Clear();
    
                        Task1(i, j, k, l, BorderingBlock);
                        Task2(i, j, a, potentialblock, furtherinfluencingblocks, BorderingBlock);

                        if (!Task3(BorderingBlock, sudokufield))
                        {
                            sudokufield[i,j] = a;
                            potential[i,j] = new List<int>(new int[]{});
                            globalcnt++;
                            return true;
                        }
                    }
                }

            return false;
        }

        private void Task1(int i, int j, int k, int l, List<string> BorderingBlock)
        {
            for (int m=k;m<=k+2;m++) 
                for (int n=l;n<=l+2;n++)
                    if (!(m == i && n == j))
                        BorderingBlock.Add(String.Format("{0}{1}",m, n));
        }

        private void Task2(int i, int j, int a, List<List<int>> potentialblock, List<int>[,] furtherinfluencingblocks, List<string> BorderingBlock)
        {
            foreach (int b in furtherinfluencingblocks[i,j])
                if (!potentialblock[b].Contains(a))
                    for (int c = 0; c < BorderingBlock.Count; c++)
                        if (BorderingBlock[c] != default(string))
                        {
                            if (b <= 9)
                            {
                                if (BorderingBlock[c].Substring(0,1) == String.Format("{0}", b))
                                    BorderingBlock[c] = default(string);
                            }
                            else
                            {
                                if (BorderingBlock[c].Substring(1,1) == String.Format("{0}", b-9))
                                    BorderingBlock[c] = default(string);
                            }
                        }
        }

        private bool Task3(List<string> BorderingBlock, int[,] sudokufield)
        {
            foreach (string c in BorderingBlock)
                if (c != default(string))
                {
                    int x = int.Parse(c.Substring(0,1));
                    int y = int.Parse(c.Substring(1,1)); 
                    if (sudokufield[x,y] == default(int))
                        return true;
                }

            return false;
        }
    }
}