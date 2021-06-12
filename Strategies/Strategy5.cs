using System.Collections.Generic;
using System;

namespace Strategies
{
    public class Strategy5
    {
        private Field[,] fields;
        private Block block;

        public Strategy5(Field[,] fields, Block block)
        {
            this.fields = fields;
            this.block = block;
        }

        public bool Run()
        {
            var BorderingBlock = new List<Coordinates>();
            
                foreach (Field field in fields)
                    if (field != null)
                        foreach (int potentialNumber in field.potential)
                        {
                            BorderingBlock.Clear();
        
                            Task1(field, BorderingBlock);
                            Task2(field, potentialNumber, BorderingBlock);

                            if (!Task3(BorderingBlock))
                            {
                                field.number = potentialNumber;
                                field.potential.Clear();
                                return true;
                            }
                        }

            return false;
        }

        private void Task1(Field field, List<Coordinates> BorderingBlock)
        {
            for (int m=field.blockCoordinates.x; m<=field.blockCoordinates.x+2; m++) 
                for (int n=field.blockCoordinates.y; n<=field.blockCoordinates.y+2; n++)
                    if (!(m == field.x && n == field.y))
                        BorderingBlock.Add(new Coordinates(m,n));
        }

        private void Task2(Field field, int potentialNumber, List<Coordinates> BorderingBlock)
        {
            foreach (int b in field.furtherinfluencingblocksHorizontal)
                if (!block.horizontal.potential[b].Contains(potentialNumber))
                    for (int c = 0; c < BorderingBlock.Count; c++)
                        if (BorderingBlock[c] != null)
                        {
                            if (b <= 9 && BorderingBlock[c].x == b)
                                BorderingBlock[c] = null;
                            else if (BorderingBlock[c].y == b-9)
                                BorderingBlock[c] = null;

                        }

            foreach (int b in field.furtherinfluencingblocksVertical)
                if (!block.vertical.potential[b].Contains(potentialNumber))
                    for (int c = 0; c < BorderingBlock.Count; c++)
                        if (BorderingBlock[c] != null)
                        {
                            if (b <= 9 && BorderingBlock[c].x == b)
                                BorderingBlock[c] = null;
                            else if (BorderingBlock[c].y == b-9)
                                BorderingBlock[c] = null;

                        }
        }

        private bool Task3(List<Coordinates> BorderingBlock)
        {
            foreach (Coordinates c in BorderingBlock)
                if (c != null && fields[c.x, c.y].number == 0)
                    return true;
                    
            return false;
        }
    }
}