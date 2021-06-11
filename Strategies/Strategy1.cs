using System;
using System.Collections.Generic;

namespace Strategies
{
    public class Strategy1
    {   
        private Field[,] fields;
        private Block block;
        private OneFourSevenMap oneFourSevenMap;

        public Strategy1(Field[,] fields, Block block, OneFourSevenMap oneFourSevenMap)
        {
            this.fields = fields;
            this.block = block;
            this.oneFourSevenMap = oneFourSevenMap;
        }

        public void Run()
        {
            for (int row=1; row<=9; row++)
                for (int col=1; col<=9; col++)
                {
                    if (fields[row, col].number == 0)
                        continue;

                    UnknownActivity_RemovePotential(ref row, ref col, fields[row, col]);
                    RemovePotentialForAllFieldsInBlock(oneFourSevenMap[row * 10 + col], fields[row, col]);
                    RemovePotentialForAllFieldsInRowAndCol(ref row, ref col, fields[row, col]);
                }
        }

        private void UnknownActivity_RemovePotential(ref int row, ref int col, Field currentField)
        {
            block.square.potential[fields[row,col].blocknumber.square].Remove(currentField.number);
            block.horizontal.potential[fields[row,col].blocknumber.horizontal].Remove(currentField.number);
            block.vertical.potential[fields[row,col].blocknumber.vertical].Remove(currentField.number);
        }

        private void RemovePotentialForAllFieldsInBlock(Coordinates block, Field currentField)
        {
            for (int i = block.x; i <= block.x+2; i++)
                for (int j = block.y; j <= block.y+2; j++)
                    fields[i,j].potential.Remove(currentField.number);
        }

        private void RemovePotentialForAllFieldsInRowAndCol(ref int row, ref int col, Field currentField)
        {
            for (int i=1; i<=9; i++)
            {            
                fields[row,i].potential.Remove(currentField.number);
                fields[i, col].potential.Remove(currentField.number); 
            }
        }
    }
}