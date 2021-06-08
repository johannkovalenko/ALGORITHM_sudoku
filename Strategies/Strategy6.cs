using System.Collections.Generic;
using System;

namespace Strategies
{
    public class Strategy6
    {
        public bool Run(Field[,] fields, List<int[]>[] fieldsperblock)
        {
            int value;
            
            for (int i=1;i<=9;i++)
                for (int j=1;j<=9;j++)
                {
                    var howoften = new Dictionary<int,int>();
                    foreach (int blockno in fields[i,j].block)
                    {
                        foreach (int[] koors in fieldsperblock[blockno])
                            foreach (int number in fields[koors[0],koors[1]].potential)
                                if (howoften.TryGetValue(number, out value))
                                    howoften[number] = value + 1;
                                else
                                    howoften.Add(number,1);

                        foreach (int ky in howoften.Keys)
                            if (howoften[ky] == 1 && fields[i,j].potential.Contains(ky))
                            {
                                fields[i,j].number = ky;
                                fields[i,j].potential.Clear();
                                return true;
                            }
                    } 
                }

            return false;
        }
    }
}