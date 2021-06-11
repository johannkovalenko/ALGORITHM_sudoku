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
            for (int i=1;i<=9;i++)
                for (int o=1;o<=9;o++)
                    if (GetCount(ref i, ref o) == 1)
                    {
                        if (Task0(ref o, block.horizontal.fields[i]))
                            return true;

                        if (Task0(ref o, block.vertical.fields[i]))
                            return true;

                        if (Task0(ref o, block.square.fields[i]))
                            return true; 
                    }
            return false;
        }

        private int GetCount(ref int i, ref int o)
        {
            int cnt = 0;
            foreach (Coordinates j in block.horizontal.fields[i])
                foreach (int m in fields[j.x, j.y].potential)
                    if (o == m)
                        cnt++;

            foreach (Coordinates j in block.vertical.fields[i])
                foreach (int m in fields[j.x, j.y].potential)
                    if (o == m)
                        cnt++;

            foreach (Coordinates j in block.square.fields[i])
                foreach (int m in fields[j.x, j.y].potential)
                    if (o == m)
                        cnt++;            

            return cnt;
        }

        private bool Task0(ref int o, List<Coordinates> coordinates)
        {
            foreach (Coordinates j in coordinates)
                if (fields[j.x, j.y].potential.Contains(o))
                {
                    fields[j.x, j.y].number = o;
                    fields[j.x, j.y].potential.Clear();
                    return true;
                }

            return false;
        }
    }
}