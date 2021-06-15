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
                    var fields = new List<Coordinates>();
                    
                    if (ThereAreOnlyTwoFieldsInSquareBlockWithCurrentNumber(fields, squareBlockNumber, number))
                    {
                        if (TwoFieldsAreInSameLine(fields))
                            RemoveNumberFromPotentialInRemainingSevenFieldsInTheSameRow(fields, number);

                        if (TwoFieldsAreInSameColumn(fields))
                            RemovePotentialForAllOtherFieldsInColumn(fields, number);
                    }
                }
        }

        private bool ThereAreOnlyTwoFieldsInSquareBlockWithCurrentNumber(List<Coordinates> fields, int squareBlockNumber, int number)
        {
            foreach (Coordinates field in block.square.fields[squareBlockNumber])
                if (board[field.x, field.y].potential.Contains(number))
                    fields.Add(new Coordinates(field.x, field.y));

            return fields.Count == 2;
        }

        private bool TwoFieldsAreInSameLine(List<Coordinates> fields)
        {
            return fields[0].x == fields[1].x;
        }

        private void RemoveNumberFromPotentialInRemainingSevenFieldsInTheSameRow(List<Coordinates> fields, int number)
        { 
            for (int y=0; y<9; y++)
                if (y!= fields[0].y && y!= fields[1].y)
                    board[fields[0].x ,y].potential.Remove(number); 
        }

        private bool TwoFieldsAreInSameColumn(List<Coordinates> fields)
        {
            return fields[0].y == fields[1].y;
        }

        private void RemovePotentialForAllOtherFieldsInColumn(List<Coordinates> fields, int number)
        {
            for (int x=0; x<9; x++)
                if (x!= fields[0].x && x!= fields[1].x)
                    board[x, fields[0].y].potential.Remove(number);                 
        }

    }
}