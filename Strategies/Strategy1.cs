using System;
using System.Collections.Generic;

namespace Strategies
{
    public class Strategy1
    {
        public void Run(int[,][] blockforfield, int[,] sudokufield, List<int>[,] potential, List<List<int>> potentialblock)
        {
            for (int row=1; row<=9; row++)
                for (int col=1; col<=9; col++)
                {
                    int numberInField = sudokufield[row, col];

                    if (numberInField == 0)
                        continue;


                    UnknownActivity_RemovePotential(row, col, blockforfield, potentialblock, numberInField);
                    RemovePotentialForAllFieldsInBlock(row, col, potential, numberInField);
                    RemovePotentialForAllFieldsInRow(row, potential, numberInField);
                    RemovePotentialForAllFieldsInCol(col, potential, numberInField);
                }
        }

        private void UnknownActivity_RemovePotential(int row, int col, int[,][] blockforfield, List<List<int>> potentialblock, int numberInField)
        {
            foreach (int a in blockforfield[row,col])
            {
                var IntList = new List<int>(potentialblock[a]);
                IntList.Remove(numberInField);
                potentialblock[a] = IntList;
            }
        }

        private void RemovePotentialForAllFieldsInBlock(int row, int col, List<int>[,] potential, int numberInField)
        {
            int rowBlock = row - (row - 1) % 3;
            int colBlock = col - (col - 1) % 3;

            for (int i = rowBlock; i <= rowBlock+2; i++)
                for (int j = colBlock; j <= colBlock+2; j++)
                {
                    var IntList = new List<int>(potential[i,j]);
                    IntList.Remove(numberInField);
                    potential[i,j] = IntList;                           
                }
        }

        private void RemovePotentialForAllFieldsInRow(int row, List<int>[,] potential, int numberInField)
        {
            for (int i=1; i<=9; i++)
            {               
                var IntList = new List<int>(potential[row,i]);
                IntList.Remove(numberInField);
                potential[row,i] = IntList;
            }

        }

        private void RemovePotentialForAllFieldsInCol(int col, List<int>[,] potential, int numberInField)
        {
            for (int i=1; i<=9; i++)
            {                    
                var IntList = new List<int>(potential[i,col]);
                IntList.Remove(numberInField);
                potential[i,col] = IntList;                      
            }
        }
    }
}