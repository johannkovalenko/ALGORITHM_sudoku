using System.Collections.Generic;

namespace Strategies
{
    public class Strategy2
    {
        private Field[,] fields;
        private Block block;

        public Strategy2(Field[,] fields, Block block)
        {
            this.fields = fields;
            this.block = block;
        }

        public void Run()
        {
            for (int i=1;i<=9;i++)
                for (int j=1;j<=9;j++)
                {
                    var interimCoordinates = SubTask0(ref i, ref j);
                    
                    if (interimCoordinates.Count != 2)
                        continue;

                    SubTask1(interimCoordinates, ref j);
                    SubTask2(interimCoordinates, ref j);
                }
        }

        private List<Coordinates> SubTask0(ref int i, ref int j)
        {
            var interimCoordinates = new List<Coordinates>();

            foreach (Coordinates coor in block.square.fields[i])
                if (fields[coor.x, coor.y].potential.Contains(j))
                    interimCoordinates.Add(new Coordinates(coor.x, coor.y));

            return interimCoordinates;
        }

        private void SubTask1(List<Coordinates> interimCoordinates, ref int j)
        {
            if (interimCoordinates[0].x == interimCoordinates[1].x)
                for (int l = 1; l<=9; l++)
                    if (l != interimCoordinates[0].y && l != interimCoordinates[1].y)
                        fields[interimCoordinates[0].x ,l].potential.Remove(j); 
        }

        private void SubTask2(List<Coordinates> interimCoordinates, ref int j)
        {
            if (interimCoordinates[0].y == interimCoordinates[1].y)
                for (int l = 1; l<=9; l++)
                    if (l != interimCoordinates[0].x && l != interimCoordinates[1].x)
                        fields[l, interimCoordinates[0].y].potential.Remove(j);                 
        }

    }
}