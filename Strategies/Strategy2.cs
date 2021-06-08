using System.Collections.Generic;

namespace Strategies
{
    public class Strategy2
    {
        public void Run(Field[,] fields, List<int[]>[] fieldsperblock)
        {
            for (int i=19;i<=27;i++)
                for (int j=1;j<=9;j++)
                {
                    var IntListArr = SubTask0(fields, fieldsperblock, ref i, ref j);
                    
                    if (IntListArr.Count != 2)
                        continue;

                    SubTask1(IntListArr, fields, ref j);
                    SubTask2(IntListArr, fields, ref j);
                }
        }

        private List<int[]> SubTask0(Field[,] fields, List<int[]>[] fieldsperblock, ref int i, ref int j)
        {
            var IntListArr = new List<int[]>();

            foreach (int[] kk in fieldsperblock[i])
                if (fields[kk[0],kk[1]].potential.Contains(j))
                    IntListArr.Add(new int[] {kk[0],kk[1]});

            return IntListArr;
        }

        private void SubTask1(List<int[]> IntListArr, Field[,] fields, ref int j)
        {
            if (IntListArr[0][0] == IntListArr[1][0])
                for (int l = 1; l<=9; l++)
                    if (l != IntListArr[0][1] && l != IntListArr[1][1])
                        fields[IntListArr[0][0] ,l].potential.Remove(j); 
        }

        private void SubTask2(List<int[]> IntListArr, Field[,] fields, ref int j)
        {
            if (IntListArr[0][1] == IntListArr[1][1])
                for (int l = 1; l<=9; l++)
                    if (l != IntListArr[0][0] && l != IntListArr[1][0])
                        fields[l, IntListArr[0][1]].potential.Remove(j);                 
        }

    }
}