using System;
using System.Collections.Generic;

namespace Strategies
{
    public class Strategy1
    {   
        private Field[,] board;
        private Block block;

        public Strategy1(Field[,] board, Block block)
        {
            this.board = board;
            this.block = block;
        }

        public void Run()
        {
            foreach (Field field in board)
                if (field != null && field.number != 0)
                {
                    RemoveNumberOfCurrentField_FromThePotentialList_OfAllThreeBlocks_TheNumberIsIn(field);
                    RemoveNumberOfCurrentField_FromThePotentialList_InAllFields_ThatAreInTheSameThreeBlocks_TheNumberIsIn(field);
                }
        }

        private void RemoveNumberOfCurrentField_FromThePotentialList_OfAllThreeBlocks_TheNumberIsIn(Field field)
        {
            block.square.potential[field.square.number].Remove(field.number);
            block.horizontal.potential[field.horizontal.number].Remove(field.number);
            block.vertical.potential[field.vertical.number].Remove(field.number);
        }

        private void RemoveNumberOfCurrentField_FromThePotentialList_InAllFields_ThatAreInTheSameThreeBlocks_TheNumberIsIn(Field field)
        {
            foreach (Coordinates coor in block.square.fields[field.square.number])
                if (coor != null)
                    board[coor.x, coor.y].potential.Remove(field.number);

            foreach (Coordinates coor in block.horizontal.fields[field.horizontal.number])
                if (coor != null)
                    board[coor.x, coor.y].potential.Remove(field.number);

            foreach (Coordinates coor in block.vertical.fields[field.vertical.number])
                if (coor != null)
                    board[coor.x, coor.y].potential.Remove(field.number);
        }
    }
}