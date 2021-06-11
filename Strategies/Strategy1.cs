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
            foreach (Field field in fields)
                if (field != null)
                {
                    if (field.number == 0)
                        continue;

                    UnknownActivity_RemovePotential(field);
                    RemovePotentialForAllFieldsInBlock(oneFourSevenMap[field.x * 10 + field.y], field);
                    RemovePotentialForAllFieldsInRowAndCol(field);
                }
        }

        private void UnknownActivity_RemovePotential(Field field)
        {
            block.square.potential[field.blocknumber.square].Remove(field.number);
            block.horizontal.potential[field.blocknumber.horizontal].Remove(field.number);
            block.vertical.potential[field.blocknumber.vertical].Remove(field.number);
        }

        private void RemovePotentialForAllFieldsInBlock(Coordinates block, Field field)
        {
            for (int i = block.x; i <= block.x+2; i++)
                for (int j = block.y; j <= block.y+2; j++)
                    fields[i,j].potential.Remove(field.number);
        }

        private void RemovePotentialForAllFieldsInRowAndCol(Field field)
        {
            for (int i=1; i<=9; i++)
            {            
                fields[field.x,i].potential.Remove(field.number);
                fields[i, field.y].potential.Remove(field.number); 
            }
        }
    }
}