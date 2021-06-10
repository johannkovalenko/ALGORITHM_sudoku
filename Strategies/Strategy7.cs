using System.Collections.Generic;
using System;

namespace Strategies
{
    public class Strategy7
    {
        private Field[,] fields;
        private Block block;

        public Strategy7(Field[,] fields, Block block)
        {
            this.fields = fields;
            this.block = block;
        }

        public bool Run()
        {
            for (int i=1;i<=27;i++)
                for (int o=1;o<=9;o++)
                    if (GetCount(ref i, ref o) == 1)
                        foreach (Coordinates j in block.fields[i])
                            if (fields[j.x, j.y].potential.Contains(o))
                            {
                                fields[j.x, j.y].number = o;
                                fields[j.x, j.y].potential.Clear();
                                return true;
                            }

            return false;
        }

        private int GetCount(ref int i, ref int o)
        {
            int cnt = 0;
            foreach (Coordinates j in block.fields[i])
                foreach (int m in fields[j.x, j.y].potential)
                    if (o == m)
                        cnt++;

            return cnt;
        }
    }
}