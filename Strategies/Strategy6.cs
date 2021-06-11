using System.Collections.Generic;
using System;

namespace Strategies
{
    public class Strategy6
    {
        private Field[,] fields;
        private Block block;
        private List<Coordinates>[][] threeBlockCollections;

        public Strategy6(Field[,] fields, Block block)
        {
            this.fields = fields;
            this.block = block;
            this.threeBlockCollections = new List<Coordinates>[][] {block.square.fields, block.horizontal.fields, block.vertical.fields};
        }

        public bool Run()
        {           
            var howoften = new Dictionary<int,int>();

            for (int i=1;i<=9;i++)
                for (int j=1;j<=9;j++)
                {
                    Field field = fields[i,j];
                    howoften.Clear();
                    foreach (int blocknumber in new int[]{field.blocknumber.square, field.blocknumber.horizontal, field.blocknumber.vertical}) 
                        if (Task0(field, blocknumber, howoften))
                            return true;
                }

            return false;
        }

        private bool Task0(Field field, int blockno, Dictionary<int,int> howoften)
        {
            foreach (var three in threeBlockCollections)
                foreach (Coordinates koors in three[blockno])
                    foreach (int number in fields[koors.x, koors.y].potential)
                        if (howoften.ContainsKey(number))
                            howoften[number]++;
                        else
                            howoften.Add(number, 1);
                        
            foreach (int ky in howoften.Keys)
                if (howoften[ky] == 1 && field.potential.Contains(ky))
                {
                    field.number = ky;
                    field.potential.Clear();
                    return true;
                }

            return false;
        }
    }
}