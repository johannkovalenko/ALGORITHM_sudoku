using System.Collections.Generic;
using System;

namespace Strategies
{
    public class Strategy5
    {
        private class Coordinates
        {
            public int x;
            public int y;

            public Coordinates(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public bool Run(Field[,] fields, List<List<int>> potentialblock)
        {
            var BorderingBlock = new List<Coordinates>();
            
            for (int i=1;i<=9;i++)
                for (int j=1;j<=9;j++)
                {
                    int k = i - (i-1) % 3;
                    int l = j - (j-1) % 3;

                    foreach (int a in fields[i,j].potential)
                    {
                        BorderingBlock.Clear();
    
                        Task1(ref i, ref j, k, l, BorderingBlock);
                        Task2(ref i, ref j, a, potentialblock, BorderingBlock, fields);

                        if (!Task3(BorderingBlock, fields))
                        {
                            fields[i,j].number = a;
                            fields[i,j].potential.Clear();
                            return true;
                        }
                    }
                }

            return false;
        }

        private void Task1(ref int i, ref int j, int k, int l, List<Coordinates> BorderingBlock)
        {
            for (int m=k;m<=k+2;m++) 
                for (int n=l;n<=l+2;n++)
                    if (!(m == i && n == j))
                        BorderingBlock.Add(new Coordinates(m,n));
        }

        private void Task2(ref int i, ref int j, int a, List<List<int>> potentialblock, List<Coordinates> BorderingBlock, Field[,] fields)
        {
            foreach (int b in fields[i,j].furtherinfluencingblocks)
                if (!potentialblock[b].Contains(a))
                    for (int c = 0; c < BorderingBlock.Count; c++)
                        if (BorderingBlock[c] != null)
                        {
                            if (b <= 9 && BorderingBlock[c].x == b)
                                BorderingBlock[c] = null;
                            else if (BorderingBlock[c].y == b-9)
                                BorderingBlock[c] = null;

                        }
        }

        private bool Task3(List<Coordinates> BorderingBlock, Field[,] fields)
        {
            foreach (Coordinates c in BorderingBlock)
                if (c != null && fields[c.x, c.y].number == 0)
                    return true;
                    
            return false;
        }
    }
}