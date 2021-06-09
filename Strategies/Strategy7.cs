using System.Collections.Generic;
using System;

namespace Strategies
{
    public class Strategy7
    {
        private Field[,] fields;
        private List<int[]>[] fieldsperblock;

        public Strategy7(Field[,] fields, List<int[]>[] fieldsperblock)
        {
            this.fields = fields;
            this.fieldsperblock = fieldsperblock;
        }

        public bool Run()
        {
            for (int i=1;i<=27;i++)
                for (int o=1;o<=9;o++)
                {  
                    int cnt = 0;
                    foreach (int[] j in fieldsperblock[i])
                        foreach (int m in fields[j[0],j[1]].potential)
                            if (o == m)
                                cnt++;

                    if (cnt!=1)
                        continue;

                    foreach (int[] j in fieldsperblock[i])
                        if (fields[j[0],j[1]].potential.Contains(o))
                        {
                            fields[j[0],j[1]].number = o;
                            fields[j[0],j[1]].potential.Clear();
                            return true;
                        }
                }

            return false;
        }
    }
}