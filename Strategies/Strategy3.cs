using System.Collections.Generic;

namespace Strategies
{
    public class Strategy3
    {
        private Field[,] fields;
        private List<int[]>[] fieldsperblock;

        public Strategy3(Field[,] fields, List<int[]>[] fieldsperblock)
        {
            this.fields = fields;
            this.fieldsperblock = fieldsperblock;
        }

        public void Run()
        {
            for (int i=1;i<=9;i++)
                for (int j=1; j<=7; j+=3)
                {
                    SubProcedureHorizontal(ref i, ref j);
                    SubProcedureVertical(ref i, ref j);
                }
        }

        private void SubProcedureHorizontal(ref int i, ref int j)
        {
            var IntListArr = new List<int[]>();

            Horizontal0(ref i, ref j, IntListArr);

            if (!(IntListArr.Count == 2 && IntListArr[0][0] == IntListArr[1][0] && IntListArr[0][1] == IntListArr[1][1]))
                return;

            Horizontal1(ref i, ref j, IntListArr);
            Horizontal2(ref i, ref j, IntListArr);
        }


        private void SubProcedureVertical(ref int i, ref int j)
        {
            var IntListArr = new List<int[]>();

            Vertical0(ref i, ref j, IntListArr);

            if (!(IntListArr.Count == 2 && IntListArr[0][0] == IntListArr[1][0] && IntListArr[0][1] == IntListArr[1][1]))
                return;
            
            Vertical1(ref i, ref j, IntListArr);
            Vertical2(ref i, ref j, IntListArr);
        }

        private void Horizontal0(ref int i, ref int j, List<int[]> IntListArr)
        {
            for (int m=j;m<=j+2;m++)
            {
                var IntList = fields[i,m].potential;
                
                if(IntList.Count == 2)
                    IntListArr.Add(new int[]{IntList[0], IntList[1]});
            }
        }

        private void Horizontal1(ref int i, ref int j, List<int[]> IntListArr)
        {
            int[] blockarr = fields[i,j].block;
            
            foreach (int[] n in fieldsperblock[blockarr[2]])
                if (n[0] != i)
                {
                    fields[n[0],n[1]].potential.Remove(IntListArr[0][0]);
                    fields[n[0],n[1]].potential.Remove(IntListArr[0][1]); 
                }

        }

        private void Horizontal2(ref int i, ref int j, List<int[]> IntListArr)
        {
            for (int l=1; l<=9; l++)
                if (l!=j && l!=j+1 && l!= j+2)
                {
                    fields[i,l].potential.Remove(IntListArr[0][0]);
                    fields[i,l].potential.Remove(IntListArr[0][1]);   
                }
        }

        private void Vertical0(ref int i, ref int j, List<int[]> IntListArr)
        {
            for (int m=j;m<=j+2;m++)
            {
                var IntList = fields[m,i].potential;
                if(IntList.Count == 2)
                    IntListArr.Add(new int[]{IntList[0], IntList[1]});
            }
        }

        private void Vertical1(ref int i, ref int j, List<int[]> IntListArr)
        {
            int[] blockarr = fields[j,i].block;
            
            foreach (int[] n in fieldsperblock[blockarr[2]])
                if (n[1] != i)
                {
                    fields[n[0],n[1]].potential.Remove(IntListArr[0][0]);
                    fields[n[0],n[1]].potential.Remove(IntListArr[0][1]); 
                }
        }

        private void Vertical2(ref int i, ref int j, List<int[]> IntListArr)
        {
            for (int l = 1; l <=9; l++)
                if (l != j && l != j+1 && l!= j+2)
                {
                    fields[l,i].potential.Remove(IntListArr[0][0]);
                    fields[l,i].potential.Remove(IntListArr[0][1]);
                }
        }
    }
}