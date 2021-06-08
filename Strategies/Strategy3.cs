using System.Collections.Generic;

namespace Strategies
{
    public class Strategy3
    {
        public void Run(int[,][] blockforfield, Field[,] fields, List<int[]>[] fieldsperblock, List<int[]> IntListArr)
        {
            for (int i=1;i<=9;i++)
                foreach (int j in new int[]{1,4,7})
                {
                    SubProcedureHorizontal(i, j, blockforfield, fields, fieldsperblock, IntListArr);
                    SubProcedureVertical(i, j, blockforfield, fields, fieldsperblock, IntListArr);
                }
        }

        private void SubProcedureHorizontal(int i, int j, int[,][] blockforfield, Field[,] fields, List<int[]>[] fieldsperblock, List<int[]> IntListArr)
        {
            IntListArr.Clear();

            Horizontal0(i, j, fields, IntListArr);

            if (!(IntListArr.Count == 2 && IntListArr[0][0] == IntListArr[1][0] && IntListArr[0][1] == IntListArr[1][1]))
                return;

            Horizontal1(i, j, blockforfield, IntListArr, fieldsperblock, fields);
            Horizontal2(i, j, fields, IntListArr);
        }


        private void SubProcedureVertical(int i, int j, int[,][] blockforfield, Field[,] fields, List<int[]>[] fieldsperblock, List<int[]> IntListArr)
        {
            IntListArr.Clear();

            Vertical0(i, j, fields, IntListArr);

            if (!(IntListArr.Count == 2 && IntListArr[0][0] == IntListArr[1][0] && IntListArr[0][1] == IntListArr[1][1]))
                return;
            

            Vertical1(i, j, blockforfield, IntListArr, fieldsperblock, fields);
            Vertical2(i, j, fields, IntListArr);
        }

        private void Horizontal0(int i, int j, Field[,] fields, List<int[]> IntListArr)
        {
            for (int m=j;m<=j+2;m++)
            {
                var IntList = fields[i,m].potential;
                
                if(IntList.Count == 2)
                    IntListArr.Add(new int[]{IntList[0], IntList[1]});
            }
        }

        private void Horizontal1(int i, int j, int[,][] blockforfield, List<int[]> IntListArr, List<int[]>[] fieldsperblock, Field[,] fields)
        {
            int[] blockarr = blockforfield[i,j];
            
            foreach (int[] n in fieldsperblock[blockarr[2]])
                if (n[0] != i)
                {
                    var IntList2 = new List<int>(fields[n[0],n[1]].potential);
                    IntList2.Remove(IntListArr[0][0]);
                    IntList2.Remove(IntListArr[0][1]);
                    fields[n[0],n[1]].potential = IntList2;   
                }

        }

        private void Horizontal2(int i, int j, Field[,] fields, List<int[]> IntListArr)
        {
            for (int l=1; l<=9; l++)
                if (l!=j && l!=j+1 && l!= j+2)
                {
                    var IntList2 = new List<int>(fields[i,l].potential);
                    IntList2.Remove(IntListArr[0][0]);
                    IntList2.Remove(IntListArr[0][1]);
                    fields[i,l].potential = IntList2;   
                }
        }

        private void Vertical0(int i, int j, Field[,] fields, List<int[]> IntListArr)
        {
            for (int m=j;m<=j+2;m++)
            {
                var IntList = fields[m,i].potential;
                if(IntList.Count == 2)
                    IntListArr.Add(new int[]{IntList[0], IntList[1]});
            }
        }

        private void Vertical1(int i, int j, int[,][] blockforfield, List<int[]> IntListArr, List<int[]>[] fieldsperblock, Field[,] fields)
        {
            int[] blockarr = blockforfield[j,i];
            
            foreach (int[] n in fieldsperblock[blockarr[2]])
                if (n[1] != i)
                {
                    var IntList2 = new List<int>(fields[n[0],n[1]].potential);
                    IntList2.Remove(IntListArr[0][0]);
                    IntList2.Remove(IntListArr[0][1]);
                    fields[n[0],n[1]].potential = IntList2;   
                }
        }

        private void Vertical2(int i, int j, Field[,] fields, List<int[]> IntListArr)
        {
            for (int l = 1; l <=9; l++)
                if (l != j && l != j+1 && l!= j+2)
                {
                    var IntList2 = new List<int>(fields[l,i].potential);
                    IntList2.Remove(IntListArr[0][0]);
                    IntList2.Remove(IntListArr[0][1]);
                    fields[l,i].potential = IntList2;   
                }
        }
    }
}