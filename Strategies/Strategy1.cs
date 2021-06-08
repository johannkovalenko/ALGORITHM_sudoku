using System;
using System.Collections.Generic;

namespace Strategies
{
    public class Strategy1
    {            
        public void Run(int[,][] blockforfield, Field[,] fields, List<List<int>> potentialblock)
        {
            for (int row=1; row<=9; row++)
                for (int col=1; col<=9; col++)
                {
                    if (fields[row, col].number == 0)
                        continue;

                    UnknownActivity_RemovePotential(row, col, blockforfield, potentialblock, fields[row, col]);
                    RemovePotentialForAllFieldsInBlock(row, col, fields, fields[row, col]);
                    RemovePotentialForAllFieldsInRow(row, fields, fields[row, col]);
                    RemovePotentialForAllFieldsInCol(col, fields, fields[row, col]);
                }
        }

        private void UnknownActivity_RemovePotential(int row, int col, int[,][] blockforfield, List<List<int>> potentialblock, Field currentField)
        {
            foreach (int a in blockforfield[row,col])
            {
                var IntList = new List<int>(potentialblock[a]);
                IntList.Remove(currentField.number);
                potentialblock[a] = IntList;
            }
        }

        private void RemovePotentialForAllFieldsInBlock(int row, int col, Field[,] fields, Field currentField)
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

        private void RemovePotentialForAllFieldsInRow(int row, Field[,] fields, Field currentField)
        {
            for (int i=1; i<=9; i++)
            {               
                var IntList = new List<int>(fields[row,i].potential);
                IntList.Remove(currentField.number);
                fields[row,i].potential = IntList;
            }

        }

        private void RemovePotentialForAllFieldsInCol(int col, Field[,] fields, Field currentField)
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