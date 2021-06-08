using System.Collections.Generic;

namespace Strategies
{
    public class Strategy4
    {
        public bool Run(Field[,] fields)
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