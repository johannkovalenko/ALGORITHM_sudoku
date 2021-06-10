using System.Collections.Generic;
using System;

namespace Strategies
{
    public class Strategy6
    {
        private Field[,] fields;
        private Block block;

        public Strategy6(Field[,] fields, Block block)
        {
            this.fields = fields;
            this.block = block;
        }

        public bool Run()
        {           
            var howoften = new Dictionary<int,int>();

            for (int i=1;i<=9;i++)
                for (int j=1;j<=9;j++)
                {
                    howoften.Clear();
                            
                    if (Task0(ref i, ref j, fields[i,j].blocknumber.square, howoften))
                        return true;

                    if (Task0(ref i, ref j, fields[i,j].blocknumber.horizontal, howoften))
                        return true;

                    if (Task0(ref i, ref j, fields[i,j].blocknumber.vertical, howoften))
                        return true;

                }

            return false;
        }

        private bool Task0(ref int i, ref int j, int blockno, Dictionary<int,int> howoften)
        {
            foreach (Coordinates koors in block.fields[blockno])
                foreach (int number in fields[koors.x, koors.y].potential)
                    if (howoften.ContainsKey(number))
                        howoften[number]++;
                    else
                        howoften.Add(number, 1);

            foreach (int ky in howoften.Keys)
                if (howoften[ky] == 1 && fields[i,j].potential.Contains(ky))
                {
                    fields[i,j].number = ky;
                    fields[i,j].potential.Clear();
                    return true;
                }

            return false;
        }
    }
}