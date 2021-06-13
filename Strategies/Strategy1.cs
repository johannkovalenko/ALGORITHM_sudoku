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
            block.square.potential[field.square.number].Remove(field.number);
            block.horizontal.potential[field.horizontal.number].Remove(field.number);
            block.vertical.potential[field.vertical.number].Remove(field.number);
        }

        private void RemovePotentialForAllFieldsInBlock(Field field)
        {
            foreach (Coordinates coor in field.square.fields)
                if (coor != null)
                    fields[coor.x, coor.y].potential.Remove(field.number);
        }

        private void RemovePotentialForAllFieldsInRowAndCol(Field field)
        {
            foreach (Coordinates coor in field.horizontal.fields)
                if (coor != null)
                    fields[coor.x, coor.y].potential.Remove(field.number);

            foreach (Coordinates coor in field.vertical.fields)
                if (coor != null)
                    fields[coor.x, coor.y].potential.Remove(field.number);
        }
    }
}