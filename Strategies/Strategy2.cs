using System.Collections.Generic;

namespace Strategies
{
    public class Strategy2
    {
        private Field[,] board;
        private Block block;

        public Strategy2 (Field[,] board, Block block)
        {
            this.board = board;
            this.block = block;
        }

        public void Run()
        {
            for (int squareBlockNumber=0; squareBlockNumber<9; squareBlockNumber++)
                for (int number=0; number<9; number++)
                {
                    var twoFields = new List<Coordinates>();
                    
                    if (ThereAreOnlyTwoFieldsInSquareBlockWithCurrentNumber(twoFields, squareBlockNumber, number))
                    {
                        if (TwoFieldsAreInSameLine(twoFields))
                            RemoveNumberFromPotentialInRemainingSevenFieldsInTheSameRow(twoFields, number);

                        if (TwoFieldsAreInSameColumn(twoFields))
                            RemovePotentialForAllOtherFieldsInColumn(twoFields, number);
                    }
                }
        }

        private bool ThereAreOnlyTwoFieldsInSquareBlockWithCurrentNumber(List<Coordinates> twoFields, int squareBlockNumber, int number)
        {
            foreach (Coordinates field in block.square.fields[squareBlockNumber])
                if (board[field.x, field.y].potential.Contains(number))
                    twoFields.Add(new Coordinates(field.x, field.y));

            return twoFields.Count == 2;
        }

        private bool TwoFieldsAreInSameLine(List<Coordinates> twoFields)
        {
            return twoFields[0].x == twoFields[1].x;
        }

        private void RemoveNumberFromPotentialInRemainingSevenFieldsInTheSameRow(List<Coordinates> twoFields, int number)
        {
            foreach (Coordinates fieldInSameRow in block.horizontal.fields[twoFields[0].x])
                if (!fieldInSameRow.Equals(twoFields[0]))
                    if (!fieldInSameRow.Equals(twoFields[1]))
                        board[fieldInSameRow.x, fieldInSameRow.y].potential.Remove(number); 
        }

        private bool TwoFieldsAreInSameColumn(List<Coordinates> twoFields)
        {
            return twoFields[0].y == twoFields[1].y;
        }

        private void RemovePotentialForAllOtherFieldsInColumn(List<Coordinates> twoFields, int number)
        {
            foreach (Coordinates fieldInSameColumn in block.vertical.fields[twoFields[0].y])
                if (!fieldInSameColumn.Equals(twoFields[0]))
                    if (!fieldInSameColumn.Equals(twoFields[1]))
                        board[fieldInSameColumn.x, fieldInSameColumn.y].potential.Remove(number);              
        }

    }
}