using System.Collections.Generic;
using System;

namespace Strategies
{
    public class Preparation
    {
        public void Run(int[,][] blockforfield, int[,] sudokufield, List<int>[,] potential, List<int>[] potentialblock, object[] fieldsperblock, List<int>[,] furtherinfluencingblocks)
        {
            List<int> FullPot = new List<int>(new int[]{1,2,3,4,5,6,7,8,9});
            List<int[]> FieldKoorHori;
            List<int[]> FieldKoorVert;
            List<int[]> FieldKoorBlock;

            List<int> EmptyPot = new List<int>();
            List<int> influencinglist;
            int k,l;
            Dictionary<string,int> block19to27= new Dictionary<string,int>();

            int cnt = 19;

            for (int i=1;i<=7;i+=3)
            {
                for (int j=1;j<=7;j+=3)
                {
                    FieldKoorBlock = new List<int[]>();
                    for (k=i; k<=i+2;k++)
                    {
                        for (l=j; l<=j+2;l++)
                        {
                            FieldKoorBlock.Add(new int[]{k,l});
                        }
                    }
                    fieldsperblock[cnt] = FieldKoorBlock;

                    block19to27[String.Format("{0}{1}",i,j)] = cnt;
                    cnt++;
                }
            }

            for (int i = 1; i <=9; i++)
            {
                FieldKoorHori = new List<int[]>();
                FieldKoorVert = new List<int[]>();
                
                for(int j=1;j<=9;j++)
                {
                    k = i - (i-1) % 3;
                    l = j - (j-1) % 3;

                    influencinglist = new List<int>();
                    
                    for (int m = k; m <= k+2;m++)
                        if (i!=m)
                            influencinglist.Add(m);
                    
                    for (int m = l; m <= l+2;m++)
                        if (j != m)
                            influencinglist.Add(m+9); 
                    
                    furtherinfluencingblocks[i,j] = influencinglist;
                    
                    blockforfield[i,j] = new int[] {i, j+9, block19to27[String.Format("{0}{1}",k,l)]};
                    if (sudokufield[i,j] == default(int))
                    {
                        potential[i,j] = FullPot;
                    }
                    else
                    {
                        potential[i,j] = EmptyPot;
                    }

                    FieldKoorHori.Add(new int[] {i,j});
                    FieldKoorVert.Add(new int[] {j,i});


                }
                fieldsperblock[i] = FieldKoorHori;
                fieldsperblock[i+9] = FieldKoorVert;
            }
            for (int i=1;i<=27;i++)
                potentialblock[i] = FullPot;


        }

    }
}
