using System.Collections.Generic;
using System;

namespace Strategies
{
    public class Strategy7
    {
        public bool Run(int[,] sudokufield, List<int>[,] potential, List<int[]>[] fieldsperblock, ref int globalcnt)
        {
            for (int i=1;i<=27;i++)
                for (int o=1;o<=9;o++)
                {  
                    int cnt = 0;
                    foreach (int[] j in fieldsperblock[i])
                    {
                        var IntList = potential[j[0],j[1]];
                        foreach (int m in IntList)
                            if (o == m)
                                cnt++;
                    }
                    if (cnt!=1)
                        continue;

                    foreach (int[] j in fieldsperblock[i])
                        if (potential[j[0],j[1]].Contains(o))
                        {
                            sudokufield[j[0],j[1]] = o;
                            potential[j[0],j[1]] = new List<int>(new int[]{});
                            globalcnt++;
                            return true;
                        }
                }

            return false;
        }
    }
}