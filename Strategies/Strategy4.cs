using System.Collections.Generic;

namespace Strategies
{
    public class Strategy4
    {
        private Field[,] fields;

        public Strategy4(Field[,] fields)
        {
            this.fields = fields;
        }

        public bool Run()
        {
            foreach(Field field in fields)
                if (field != null)
                    if (field.potential.Count == 1)
                    {
                        field.number = field.potential[0];
                        field.potential.Clear();
                        return true;
                    }

            return false;
        }
    }
}