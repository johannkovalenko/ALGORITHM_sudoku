using System.Collections.Generic;

namespace Strategies
{
    public class Strategy2
    {
        public void Run(Field[,] fields, List<int[]>[] fieldsperblock, List<int[]> IntListArr)
        {
            for (int i=19;i<=27;i++)
                for (int j=1;j<=9;j++)
                {
                    IntListArr.Clear();
                    
                    SubTask0(fields, fieldsperblock, IntListArr, i, j);
                    
                    if (IntListArr.Count != 2)
                        continue;

                    SubTask1(IntListArr, fields, j);
                    SubTask2(IntListArr, fields, j);
                }
        }

        private void SubTask0(Field[,] fields, List<int[]>[] fieldsperblock, List<int[]> IntListArr, int i, int j)
        {
            foreach (int[] kk in fieldsperblock[i])
                if (fields[kk[0],kk[1]].potential.Contains(j))
                    IntListArr.Add(new int[] {kk[0],kk[1]});

        }

        private void SubTask1(List<int[]> IntListArr, Field[,] fields, int j)
        {
            if (IntListArr[0][0] != IntListArr[1][0])
                return;

            for (int l = 1; l<=9; l++)
                if (l != IntListArr[0][1] && l != IntListArr[1][1])
                {
                    var IntList = new List<int>(fields[IntListArr[0][0] ,l].potential);
                    IntList.Remove(j);
                    fields[IntListArr[0][0] ,l].potential = IntList;   
                }
        }

        private void SubTask2(List<int[]> IntListArr, Field[,] fields, int j)
        {
            if (IntListArr[0][1] != IntListArr[1][1])
                return;

            for (int l = 1; l<=9; l++)
                if (l != IntListArr[0][0] && l != IntListArr[1][0])
                {
                    var IntList = new List<int>(fields[l, IntListArr[0][1]].potential);
                    IntList.Remove(j);
                    fields[l,IntListArr[0][1]].potential = IntList;
                }                   
        }

    }
}