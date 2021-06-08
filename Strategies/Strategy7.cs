using System.Collections.Generic;
using System;

namespace Strategies
{
    public class Strategy7
    {
        public bool Run(Field[,] fields, List<int[]>[] fieldsperblock, ref int globalcnt)
        {
            for (int i=1;i<=27;i++)
                for (int o=1;o<=9;o++)
                {  
                    int cnt = 0;
                    foreach (int[] j in fieldsperblock[i])
                    {
                        var IntList = fields[j[0],j[1]].potential;
                        foreach (int m in IntList)
                            if (o == m)
                                cnt++;
                    }
                    if (cnt!=1)
                        continue;

                    foreach (int[] j in fieldsperblock[i])
                        if (fields[j[0],j[1]].potential.Contains(o))
                        {
                            fields[j[0],j[1]].number = o;
                            fields[j[0],j[1]].potential = new List<int>(new int[]{});
                            globalcnt++;
                            return true;
                        }
                }

            return false;
        }
    }
}