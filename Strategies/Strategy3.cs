using System.Collections.Generic;

namespace Strategies
{
    public class Strategy3
    {
        private Field[,] board;
        private Block block;

        public Strategy3(Field[,] board, Block block)
        {
            this.board = board;
            this.block = block;
        }

        public void Run()
        {
            for (int i=1;i<=9;i++)
                for (int j=1; j<=7; j+=3)
                {
                    SubProcedureHorizontal(ref i, ref j);
                    SubProcedureVertical(ref i, ref j);
                }
        }

        private void SubProcedureHorizontal(ref int i, ref int j)
        {
            var IntListArr = new List<Coordinates>();

            Horizontal0(ref i, ref j, IntListArr);

            if (!(IntListArr.Count == 2 && IntListArr[0].x == IntListArr[1].x && IntListArr[0].y == IntListArr[1].y))
                return;

            Horizontal1(ref i, ref j, IntListArr);
            Horizontal2(ref i, ref j, IntListArr);
        }


        private void SubProcedureVertical(ref int i, ref int j)
        {
            var IntListArr = new List<Coordinates>();

            Vertical0(ref i, ref j, IntListArr);

            if (!(IntListArr.Count == 2 && IntListArr[0].x == IntListArr[1].x && IntListArr[0].y == IntListArr[1].y))
                return;
            
            Vertical1(ref i, ref j, IntListArr);
            Vertical2(ref i, ref j, IntListArr);
        }

        private void Horizontal0(ref int i, ref int j, List<Coordinates> IntListArr)
        {
            for (int y=j; y<=j+2; y++)               
                if (board[i,y].potential.Count == 2)
                    IntListArr.Add(new Coordinates(board[i,y].potential[0], board[i,y].potential[1]));
        }

        private void Horizontal1(ref int i, ref int j, List<Coordinates> IntListArr)
        {
            foreach (Coordinates coordinates in block.square.fields[board[i,j].square.number])
                if (coordinates.x != i)
                {
                    board[coordinates.x, coordinates.y].potential.Remove(IntListArr[0].x);
                    board[coordinates.x, coordinates.y].potential.Remove(IntListArr[0].y); 
                }
        }

        private void Horizontal2(ref int i, ref int j, List<Coordinates> IntListArr)
        {
            for (int y=1; y<=9; y++)
                if (y!=j && y!=j+1 && y!= j+2)
                {
                    board[i,y].potential.Remove(IntListArr[0].x);
                    board[i,y].potential.Remove(IntListArr[0].y);   
                }
        }

        private void Vertical0(ref int i, ref int j, List<Coordinates> IntListArr)
        {
            for (int m=j;m<=j+2;m++)
                if(board[m,i].potential.Count == 2)
                    IntListArr.Add(new Coordinates(board[m,i].potential[0], board[m,i].potential[1]));
        }

        private void Vertical1(ref int i, ref int j, List<Coordinates> IntListArr)
        {           
            foreach (Coordinates n in block.square.fields[board[j,i].square.number])
                if (n.y != i)
                {
                    board[n.x, n.y].potential.Remove(IntListArr[0].x);
                    board[n.x, n.y].potential.Remove(IntListArr[0].y); 
                }
        }

        private void Vertical2(ref int i, ref int j, List<Coordinates> IntListArr)
        {
            for (int l = 1; l <=9; l++)
                if (l != j && l != j+1 && l!= j+2)
                {
                    board[l,i].potential.Remove(IntListArr[0].x);
                    board[l,i].potential.Remove(IntListArr[0].y);
                }
        }
    }
}