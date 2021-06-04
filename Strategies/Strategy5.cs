using System.Collections.Generic;
using System;

namespace Strategies
{
    public class Strategy5
    {
        public bool Run(object[,] blockforfield, int[,] sudokufield, object[,] potential, object[] potentialblock, object[,] furtherinfluencingblocks, ref int globalcnt)
        {
            List<string> BorderingBlock = new List<string>();
            bool DontDoIt;
            
            for (int i=1;i<=9;i++)
            {
                for (int j=1;j<=9;j++)
                {
                    int k = i - (i-1) % 3;
                    int l = j - (j-1) % 3;

                    foreach (int a in potential[i,j] as List<int>)
                    {
                        DontDoIt = false;
                        BorderingBlock.Clear();
    
                        for (int m=k;m<=k+2;m++)
                        {
                            for (int n=l;n<=l+2;n++)
                            {
                                if (!(m == i && n == j))
                                {
                                    BorderingBlock.Add(String.Format("{0}{1}",m, n));
                                }
                            }
                        }
                        
                        foreach (int b in furtherinfluencingblocks[i,j] as List<int>)
                        {
                            if (!(potentialblock[b] as List<int>).Contains(a))
                            {
                                for (int c = 0; c < BorderingBlock.Count; c++)
                                {
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
                            }
                        }
                        foreach (string c in BorderingBlock)
                        {
                            if (c != default(string))
                            {
                                int x = int.Parse(c.Substring(0,1));
                                int y = int.Parse(c.Substring(1,1)); 
                                if (sudokufield[x,y] == default(int))
                                {
                                    DontDoIt = true;
                                }
                            }
                        }
                        if (!DontDoIt)
                        {
                            sudokufield[i,j] = a;
                            //Console.WriteLine("Case two  {0},{1}", i, j);
                            potential[i,j] = new List<int>(new int[]{});
                            globalcnt++;
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}