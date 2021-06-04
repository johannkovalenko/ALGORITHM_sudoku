using System.Collections.Generic;

namespace Strategies
{
    public class Strategy2
    {
        public void Run(int[,] sudokufield, List<int>[,] potential, List<int[]>[] fieldsperblock, List<int[]> IntListArr)
        {
            for (int i=19;i<=27;i++)
            {
                for (int j=1;j<=9;j++)
                {
                    IntListArr.Clear();
                    foreach (int[] kk in fieldsperblock[i])
                        if ((potential[kk[0],kk[1]]).Contains(j))
                            IntListArr.Add(new int[] {kk[0],kk[1]});

                    if (IntListArr.Count == 2)
                    {
                        if (IntListArr[0][0] == IntListArr[1][0])
                        {
                            for (int l = 1; l <=9; l++)
                            {
                                if (l != IntListArr[0][1] && l != IntListArr[1][1])
                                {
                                    var IntList = new List<int>(potential[IntListArr[0][0],l]);
                                    IntList.Remove(j);
                                    potential[IntListArr[0][0],l] = IntList;   
                                }
                            }
                        }
                        if (IntListArr[0][1] == IntListArr[1][1])
                        {
                            for (int l = 1; l <=9; l++)
                            {
                                if (l != IntListArr[0][0] && l != IntListArr[1][0])
                                {
                                    var IntList = new List<int>(potential[l,IntListArr[0][1]]);
                                    IntList.Remove(j);
                                    potential[l,IntListArr[0][1]] = IntList;
                                }                   
                            }
                        }
                    }
                }
            }
        }
    }
}