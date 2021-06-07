using System.Collections.Generic;
using System;

namespace Strategies
{
    public class Preparation
    {
        public void Run(int[,][] blockforfield, int[,] sudokufield, List<int>[,] potential, List<List<int>> potentialblock, List<int[]>[] fieldsperblock, List<int>[,] furtherinfluencingblocks)
        {
            var block19to27= new Dictionary<string,int>();

            Task1(fieldsperblock, block19to27);
            Task2(blockforfield, sudokufield, potential, potentialblock, fieldsperblock, furtherinfluencingblocks, block19to27);
        }

        private void Task1(List<int[]>[] fieldsperblock, Dictionary<string,int> block19to27)
        {
            int cnt = 19;

            for (int i=1;i<=7;i+=3)
                for (int j=1;j<=7;j+=3)
                {
                    var FieldKoorBlock = new List<int[]>();
                    for (int k=i; k<=i+2;k++)
                        for (int l=j; l<=j+2;l++)
                            FieldKoorBlock.Add(new int[]{k,l});

                    fieldsperblock[cnt] = FieldKoorBlock;

                    block19to27[String.Format("{0}{1}",i,j)] = cnt;
                    cnt++;
                }
        }

        private void Task2(int[,][] blockforfield, int[,] sudokufield, List<int>[,] potential, List<List<int>> potentialblock, List<int[]>[] fieldsperblock, List<int>[,] furtherinfluencingblocks, Dictionary<string,int> block19to27)
        {
            var FullPot = new List<int>(new int[]{1,2,3,4,5,6,7,8,9});
            var EmptyPot = new List<int>();

            for (int i = 1; i <=9; i++)
            {
                var FieldKoorHori = new List<int[]>();
                var FieldKoorVert = new List<int[]>();
                
                for(int j=1;j<=9;j++)
                {
                    int k = i - (i-1) % 3;
                    int l = j - (j-1) % 3;

                    var influencinglist = new List<int>();
                    
                    for (int m = k; m <= k+2;m++)
                        if (i!=m)
                            influencinglist.Add(m);
                    
                    for (int m = l; m <= l+2;m++)
                        if (j != m)
                            influencinglist.Add(m+9); 
                    
                    furtherinfluencingblocks[i,j] = influencinglist;
                    
                    blockforfield[i,j] = new int[] {i, j+9, block19to27[String.Format("{0}{1}",k,l)]};
                    
                    if (sudokufield[i,j] == default(int))
                        potential[i,j] = FullPot;
                    else
                        potential[i,j] = EmptyPot;

                    FieldKoorHori.Add(new int[] {i,j});
                    FieldKoorVert.Add(new int[] {j,i});
                }

                fieldsperblock[i] = FieldKoorHori;
                fieldsperblock[i+9] = FieldKoorVert;
            }

            for (int i=0;i<=27;i++)
                potentialblock.Add(FullPot);
        }
    }
}
