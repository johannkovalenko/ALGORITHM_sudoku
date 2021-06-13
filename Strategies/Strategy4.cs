using System.Collections.Generic;

namespace Strategies
{
    public class Strategy4
    {
        private Field[,] board;

        public Strategy4(Field[,] board)
        {
            this.board = board;
        }

        public bool Run()
        {
            foreach(Field field in board)
                if (field.potential.Count ==1)
                {
                    field.number = field.potential[0];
                    field.potential.Clear();
                    return true;
                }

            return false;
        }
    }
}