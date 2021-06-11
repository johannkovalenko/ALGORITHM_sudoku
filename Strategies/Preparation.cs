using System.Collections.Generic;
using System;

namespace Strategies
{
    public class Preparation
    {
        public void Run(Field[,] fields, Block block)
        {
            for (int i = 1; i <=9; i++)
                for(int j=1; j<=9; j++)                     
                    if (fields[i,j].number == 0)
                        fields[i,j].potential = new List<int>(new int[]{1,2,3,4,5,6,7,8,9});
        }
    }
}
