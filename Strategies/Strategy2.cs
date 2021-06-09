using System.Collections.Generic;

namespace Strategies
{
    public class Strategy2
    {
        private Field[,] fields;
        private List<Coordinates>[] fieldsperblock;

        public Strategy2(Field[,] fields, List<Coordinates>[] fieldsperblock)
        {
            this.fields = fields;
            this.fieldsperblock = fieldsperblock;
        }

        public void Run()
        {
            for (int i=19;i<=27;i++)
                for (int j=1;j<=9;j++)
                {
                    var IntListArr = SubTask0(ref i, ref j);
                    
                    if (IntListArr.Count != 2)
                        continue;

                    SubTask1(IntListArr, ref j);
                    SubTask2(IntListArr, ref j);
                }
        }

        private List<int[]> SubTask0(ref int i, ref int j)
        {
            var IntListArr = new List<int[]>();

            foreach (Coordinates kk in fieldsperblock[i])
                if (fields[kk.x, kk.y].potential.Contains(j))
                    IntListArr.Add(new int[] {kk.x, kk.y});

            return IntListArr;
        }

        private void SubTask1(List<int[]> IntListArr, ref int j)
        {
            if (IntListArr[0][0] == IntListArr[1][0])
                for (int l = 1; l<=9; l++)
                    if (l != IntListArr[0][1] && l != IntListArr[1][1])
                        fields[IntListArr[0][0] ,l].potential.Remove(j); 
        }

        private void SubTask2(List<int[]> IntListArr, ref int j)
        {
            if (IntListArr[0][1] == IntListArr[1][1])
                for (int l = 1; l<=9; l++)
                    if (l != IntListArr[0][0] && l != IntListArr[1][0])
                        fields[l, IntListArr[0][1]].potential.Remove(j);                 
        }

    }
}