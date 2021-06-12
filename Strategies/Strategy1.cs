using System;
using System.Collections.Generic;

namespace Strategies
{
    public class Strategy1
    {   
        private Field[,] fields;
        private Block block;

        public Strategy1(Field[,] fields, Block block)
        {
            this.fields = fields;
            this.block = block;
        }

        public void Run()
        {
            foreach (Field field in fields)
                if (field != null && field.number != 0)
                {
                    UnknownActivity_RemovePotential(field);
                    RemovePotentialForAllFieldsInBlock(field);
                    RemovePotentialForAllFieldsInRowAndCol(field);
                }
        }

        private void UnknownActivity_RemovePotential(Field field)
        {
            block.square.potential[field.blocknumber.square].Remove(field.number);
            block.horizontal.potential[field.blocknumber.horizontal].Remove(field.number);
            block.vertical.potential[field.blocknumber.vertical].Remove(field.number);
        }

        private void RemovePotentialForAllFieldsInBlock(Field field)
        {
            for (int i = field.blockCoordinates.x; i <= field.blockCoordinates.x+2; i++)
                for (int j = field.blockCoordinates.y; j <= field.blockCoordinates.y+2; j++)
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