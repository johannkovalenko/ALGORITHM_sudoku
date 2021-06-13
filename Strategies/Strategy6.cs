using System.Collections.Generic;
using System;

namespace Strategies
{
    public class Strategy6
    {
        private Field[,] board;
        private Block block;
        private Coordinates[][][] threeBlockCollections;

        public Strategy6(Field[,] board, Block block)
        {
            this.board = board;
            this.block = block;
            this.threeBlockCollections = new Coordinates[][][] {block.square.fields, block.horizontal.fields, block.vertical.fields};
        }

        public bool Run()
        {           
            var howoften = new Dictionary<int,int>();

            foreach (Field field in board)
                if (field != null)
                {
                    howoften.Clear();
                    foreach (int fieldBlock in new int[]{field.square.number, field.horizontal.number, field.vertical.number}) 
                        if (Task0(field, fieldBlock, howoften))
                            return true;
                }

            return false;
        }

        private bool Task0(Field field, int blockno, Dictionary<int,int> howoften)
        {
            foreach (var three in threeBlockCollections)
                foreach (Coordinates koors in three[blockno])
                    if (koors != null)
                        foreach (int number in board[koors.x, koors.y].potential)
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