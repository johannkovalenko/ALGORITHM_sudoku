using System.Collections.Generic;
using System;

namespace Strategies
{
    public class Strategy7
    {
        private Field[,] board;
        private Block block;
        private Coordinates[][][] threeBlockCollections;

        public Strategy7(Field[,] board, Block block)
        {
            this.board = board;
            this.block = block;

            threeBlockCollections = new Coordinates[][][] {block.square.fields, block.horizontal.fields, block.vertical.fields};
        }

        public bool Run()
        {
            for (int i=1;i<=9;i++)
                for (int o=1;o<=9;o++)
                    if (GetCount(ref i, ref o) == 1)
                        foreach (var three in threeBlockCollections)
                            if (Task0(ref o, three[i]))
                                return true;

            return false;
        }

        private int GetCount(ref int i, ref int o)
        {
            int cnt = 0;

            foreach (var three in threeBlockCollections)
                foreach (Coordinates j in three[i])
                    if (j != null)
                        foreach (int m in board[j.x, j.y].potential)
                            if (o == m)
                                cnt++;
       
            return cnt;
        }

        private bool Task0(ref int o, Coordinates[] coordinates)
        {
            foreach (Coordinates j in coordinates)
                if (board[j.x, j.y].potential.Contains(o))
                {
                    board[j.x, j.y].number = o;
                    board[j.x, j.y].potential.Clear();
                    return true;
                }

            return false;
        }
    }
}