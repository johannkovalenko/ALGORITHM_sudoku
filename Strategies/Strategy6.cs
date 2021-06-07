using System.Collections.Generic;
using System;

namespace Strategies
{
    public class Strategy6
    {
        public bool Run(int[,][] blockforfield, int[,] sudokufield, List<int>[,] potential, List<int[]>[] fieldsperblock, ref int globalcnt)
        {
            int value;
            
            for (int i=1;i<=9;i++)
                for (int j=1;j<=9;j++)
                {
                    var howoften = new Dictionary<int,int>();
                    foreach (int blockno in blockforfield[i,j])
                    {
                        foreach (int[] koors in fieldsperblock[blockno])
                            foreach (int number in potential[koors[0],koors[1]])
                                if (howoften.TryGetValue(number, out value))
                                    howoften[number] = value + 1;
                                else
                                    howoften.Add(number,1);
                        
                        var IntList = potential[i,j];
                        foreach (int ky in howoften.Keys)
                            if (howoften[ky] == 1 && IntList.Contains(ky))
                            {
                                sudokufield[i,j] = ky;
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