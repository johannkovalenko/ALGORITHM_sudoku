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
            for (int i=1;i<=9;i++)
                for (int j=1;j<=9;j++)
                    if (fields[i,j].potential.Count == 1)
                    {
                        fields[i,j].number = fields[i,j].potential[0];
                        fields[i,j].potential.Clear();
                        return true;
                    }

            return false;
        }
    }
}