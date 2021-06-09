using System;
using System.Collections.Generic;

namespace Strategies
{
    public class Strategy1
    {   
        private Field[,] fields;
        private List<List<int>> potentialblock;

        public Strategy1(Field[,] fields, List<List<int>> potentialblock)
        {
            this.fields = fields;
            this.potentialblock = potentialblock;
        }

        public void Run()
        {
            for (int row=1; row<=9; row++)
                for (int col=1; col<=9; col++)
                {
                    if (fields[row, col].number == 0)
                        continue;

                    UnknownActivity_RemovePotential(ref row, ref col, fields[row, col]);
                    RemovePotentialForAllFieldsInBlock(ref row, ref col, fields[row, col]);
                    RemovePotentialForAllFieldsInRow(ref row, fields[row, col]);
                    RemovePotentialForAllFieldsInCol(ref col, fields[row, col]);
                }
        }

        private void UnknownActivity_RemovePotential(ref int row, ref int col, Field currentField)
        {
            foreach (int a in fields[row,col].block)
            {
                var IntList = new List<int>(potentialblock[a]);
                IntList.Remove(currentField.number);
                potentialblock[a] = IntList;
            }
        }

        private void RemovePotentialForAllFieldsInBlock(ref int row, ref int col, Field currentField)
        {
            int rowBlock = row - (row - 1) % 3;
            int colBlock = col - (col - 1) % 3;

            for (int i = rowBlock; i <= rowBlock+2; i++)
                for (int j = colBlock; j <= colBlock+2; j++)
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