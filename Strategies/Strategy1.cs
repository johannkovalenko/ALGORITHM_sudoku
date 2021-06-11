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
                    RemovePotentialForAllFieldsInRow(ref row, fields[row, col]);
                    RemovePotentialForAllFieldsInCol(ref col, fields[row, col]);
                }
        }

        private void UnknownActivity_RemovePotential(ref int row, ref int col, Field currentField)
        {
            var IntList = new List<int>(block.square.potential[fields[row,col].blocknumber.square]);
            IntList.Remove(currentField.number);
            block.square.potential[fields[row,col].blocknumber.square] = IntList;

            IntList = new List<int>(block.potential[fields[row,col].blocknumber.horizontal]);
            IntList.Remove(currentField.number);
            block.potential[fields[row,col].blocknumber.horizontal] = IntList;

            IntList = new List<int>(block.potential[fields[row,col].blocknumber.vertical]);
            IntList.Remove(currentField.number);
            block.potential[fields[row,col].blocknumber.vertical] = IntList;
        }

        private void RemovePotentialForAllFieldsInBlock(Coordinates block, Field currentField)
        {
            for (int i = block.x; i <= block.x+2; i++)
                for (int j = block.y; j <= block.y+2; j++)
                {
                    var IntList = new List<int>(fields[i,j].potential);
                    IntList.Remove(currentField.number);
                    fields[i,j].potential = IntList;                           
                }
        }

        private void RemovePotentialForAllFieldsInRow(ref int row, Field currentField)
        {
            for (int i=1; i<=9; i++)
            {               
                var IntList = new List<int>(fields[row,i].potential);
                IntList.Remove(currentField.number);
                fields[row,i].potential = IntList;
            }

        }

        private void RemovePotentialForAllFieldsInCol(ref int col, Field currentField)
        {
            for (int i=1; i<=9; i++)
            {                    
                var IntList = new List<int>(fields[i, col].potential);
                IntList.Remove(currentField.number);
                fields[i, col].potential = IntList;                      
            }
        }
    }
}