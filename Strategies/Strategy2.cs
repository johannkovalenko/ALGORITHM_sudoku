using System.Collections.Generic;

namespace Strategies
{
    public class Strategy2
    {
        private Field[,] board;
        private Block block;

        public Strategy2(Field[,] board, Block block)
        {
            this.board = board;
            this.block = block;
        }

        public void Run()
        {
            foreach (Field field in board)
                if (field != null)
                {
                    var interimCoordinates = SubTask0(field);
                    
                    if (interimCoordinates.Count != 2)
                        continue;

                    SubTask1(interimCoordinates, field);
                    SubTask2(interimCoordinates, field);
                }
        }

        private List<Coordinates> SubTask0(Field field)
        {
            var interimCoordinates = new List<Coordinates>();

            foreach (Coordinates coor in block.square.fields[field.x])
                if (board[coor.x, coor.y].potential.Contains(field.y))
                    interimCoordinates.Add(new Coordinates(coor.x, coor.y));

            return interimCoordinates;
        }

        private void SubTask1(List<Coordinates> interimCoordinates, Field field)
        {
            if (interimCoordinates[0].x == interimCoordinates[1].x)
                for (int l = 1; l<=9; l++)
                    if (l != interimCoordinates[0].y && l != interimCoordinates[1].y)
                        board[interimCoordinates[0].x ,l].potential.Remove(field.y); 
        }

        private void SubTask2(List<Coordinates> interimCoordinates, Field field)
        {
            if (interimCoordinates[0].y == interimCoordinates[1].y)
                for (int l = 1; l<=9; l++)
                    if (l != interimCoordinates[0].x && l != interimCoordinates[1].x)
                        board[l, interimCoordinates[0].y].potential.Remove(field.y);                 
        }

    }
}