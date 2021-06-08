using System.Collections.Generic;

namespace Strategies
{
    public class Strategy3
    {
        public void Run(Field[,] fields, List<int[]>[] fieldsperblock, List<int[]> IntListArr)
        {
            for (int i=1;i<=9;i++)
                for (int j=1; j<=7; j+=3)
                {
                    SubProcedureHorizontal(ref i, ref j, fields, fieldsperblock, IntListArr);
                    SubProcedureVertical(ref i, ref j, fields, fieldsperblock, IntListArr);
                }
        }

        private void SubProcedureHorizontal(ref int i, ref int j, Field[,] fields, List<int[]>[] fieldsperblock, List<int[]> IntListArr)
        {
            IntListArr.Clear();

            Horizontal0(ref i, ref j, fields, IntListArr);

            if (!(IntListArr.Count == 2 && IntListArr[0][0] == IntListArr[1][0] && IntListArr[0][1] == IntListArr[1][1]))
                return;

            Horizontal1(ref i, ref j, IntListArr, fieldsperblock, fields);
            Horizontal2(ref i, ref j, fields, IntListArr);
        }


        private void SubProcedureVertical(ref int i, ref int j, Field[,] fields, List<int[]>[] fieldsperblock, List<int[]> IntListArr)
        {
            IntListArr.Clear();

            Vertical0(ref i, ref j, fields, IntListArr);

            if (!(IntListArr.Count == 2 && IntListArr[0][0] == IntListArr[1][0] && IntListArr[0][1] == IntListArr[1][1]))
                return;
            
            Vertical1(ref i, ref j, IntListArr, fieldsperblock, fields);
            Vertical2(ref i, ref j, fields, IntListArr);
        }

        private void Horizontal0(ref int i, ref int j, Field[,] fields, List<int[]> IntListArr)
        {
            for (int m=j;m<=j+2;m++)
            {
                var IntList = fields[i,m].potential;
                
                if(IntList.Count == 2)
                    IntListArr.Add(new int[]{IntList[0], IntList[1]});
            }
        }

        private void Horizontal1(ref int i, ref int j, List<int[]> IntListArr, List<int[]>[] fieldsperblock, Field[,] fields)
        {
            int[] blockarr = fields[i,j].block;
            
            foreach (int[] n in fieldsperblock[blockarr[2]])
                if (n[0] != i)
                {
                    var IntList2 = new List<int>(fields[n[0],n[1]].potential);
                    IntList2.Remove(IntListArr[0][0]);
                    IntList2.Remove(IntListArr[0][1]);
                    fields[n[0],n[1]].potential = IntList2;   
                }

        }

        private void Horizontal2(ref int i, ref int j, Field[,] fields, List<int[]> IntListArr)
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

        private void Vertical0(ref int i, ref int j, Field[,] fields, List<int[]> IntListArr)
        {
            for (int m=j;m<=j+2;m++)
            {
                var IntList = fields[m,i].potential;
                if(IntList.Count == 2)
                    IntListArr.Add(new int[]{IntList[0], IntList[1]});
            }
        }

        private void Vertical1(ref int i, ref int j, List<int[]> IntListArr, List<int[]>[] fieldsperblock, Field[,] fields)
        {
            int[] blockarr = fields[j,i].block;
            
            foreach (int[] n in fieldsperblock[blockarr[2]])
                if (n[1] != i)
                {
                    var IntList2 = new List<int>(fields[n[0],n[1]].potential);
                    IntList2.Remove(IntListArr[0][0]);
                    IntList2.Remove(IntListArr[0][1]);
                    fields[n[0],n[1]].potential = IntList2;   
                }
        }

        private void Vertical2(ref int i, ref int j, Field[,] fields, List<int[]> IntListArr)
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