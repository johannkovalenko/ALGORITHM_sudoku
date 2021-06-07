using System.Collections.Generic;

namespace Strategies
{
    public class Strategy3
    {
        public void Run(int[,][] blockforfield, int[,] sudokufield, List<int>[,] potential, List<int[]>[] fieldsperblock, List<int[]> IntListArr)
        {
            for (int i=1;i<=9;i++)
                foreach (int j in new int[]{1,4,7})
                {
                    SubProcedureHorizontal(i, j, blockforfield, sudokufield, potential, fieldsperblock, IntListArr);
                    SubProcedureVertical(i, j, blockforfield, sudokufield, potential, fieldsperblock, IntListArr);
                }
        }

        private void SubProcedureHorizontal(int i, int j, int[,][] blockforfield, int[,] sudokufield, List<int>[,] potential, List<int[]>[] fieldsperblock, List<int[]> IntListArr)
        {
            IntListArr.Clear();

            Horizontal0(i, j, potential, IntListArr);

            if (!(IntListArr.Count == 2 && IntListArr[0][0] == IntListArr[1][0] && IntListArr[0][1] == IntListArr[1][1]))
                return;

            Horizontal1(i, j, blockforfield, IntListArr, fieldsperblock, potential);
            Horizontal2(i, j, potential, IntListArr);
        }


        private void SubProcedureVertical(int i, int j, int[,][] blockforfield, int[,] sudokufield, List<int>[,] potential, List<int[]>[] fieldsperblock, List<int[]> IntListArr)
        {
            IntListArr.Clear();

            Vertical0(i, j, potential, IntListArr);

            if (!(IntListArr.Count == 2 && IntListArr[0][0] == IntListArr[1][0] && IntListArr[0][1] == IntListArr[1][1]))
                return;
            

            Vertical1(i, j, blockforfield, IntListArr, fieldsperblock, potential);
            Vertical2(i, j, potential, IntListArr);
        }

        private void Horizontal0(int i, int j, List<int>[,] potential, List<int[]> IntListArr)
        {
            for (int m=j;m<=j+2;m++)
            {
                var IntList = potential[i,m];
                
                if(IntList.Count == 2)
                    IntListArr.Add(new int[]{IntList[0], IntList[1]});
            }
        }

        private void Horizontal1(int i, int j, int[,][] blockforfield, List<int[]> IntListArr, List<int[]>[] fieldsperblock, List<int>[,] potential)
        {
            int[] blockarr = blockforfield[i,j];
            
            foreach (int[] n in fieldsperblock[blockarr[2]])
                if (n[0] != i)
                {
                    var IntList2 = new List<int>(potential[n[0],n[1]]);
                    IntList2.Remove(IntListArr[0][0]);
                    IntList2.Remove(IntListArr[0][1]);
                    potential[n[0],n[1]] = IntList2;   
                }

        }

        private void Horizontal2(int i, int j, List<int>[,] potential, List<int[]> IntListArr)
        {
            for (int l=1; l<=9; l++)
                if (l!=j && l!=j+1 && l!= j+2)
                {
                    var IntList2 = new List<int>(potential[i,l]);
                    IntList2.Remove(IntListArr[0][0]);
                    IntList2.Remove(IntListArr[0][1]);
                    potential[i,l] = IntList2;   
                }
        }

        private void Vertical0(int i, int j, List<int>[,] potential, List<int[]> IntListArr)
        {
            for (int m=j;m<=j+2;m++)
            {
                var IntList = potential[m,i];
                if(IntList.Count == 2)
                    IntListArr.Add(new int[]{IntList[0], IntList[1]});
            }
        }

        private void Vertical1(int i, int j, int[,][] blockforfield, List<int[]> IntListArr, List<int[]>[] fieldsperblock, List<int>[,] potential)
        {
            int[] blockarr = blockforfield[j,i];
            
            foreach (int[] n in fieldsperblock[blockarr[2]])
                if (n[1] != i)
                {
                    var IntList2 = new List<int>(potential[n[0],n[1]]);
                    IntList2.Remove(IntListArr[0][0]);
                    IntList2.Remove(IntListArr[0][1]);
                    potential[n[0],n[1]] = IntList2;   
                }
        }

        private void Vertical2(int i, int j, List<int>[,] potential, List<int[]> IntListArr)
        {
            for (int l = 1; l <=9; l++)
                if (l != j && l != j+1 && l!= j+2)
                {
                    var IntList2 = new List<int>(potential[l,i]);
                    IntList2.Remove(IntListArr[0][0]);
                    IntList2.Remove(IntListArr[0][1]);
                    potential[l,i] = IntList2;   
                }
        }
    }
}