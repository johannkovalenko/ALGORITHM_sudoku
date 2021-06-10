using System.Collections.Generic;
using System;

namespace Strategies
{
    public class Preparation
    {
        public void Run(Field[,] fields, Block block)
        {
            var block19to27= new Dictionary<string,int>();

            Task1(block, block19to27);
            Task2(fields, block, block19to27);

            // for(int a=0; a<block.fields.Length; a++)
            //     if (block.fields[a] != null)
            //         foreach (int[] b in block.fields[a])
            //             if (b != null)
            //                 Console.WriteLine(a + "\t\t" + b[0] + " " + b[1]);
        }

        private void Task1(Block block, Dictionary<string,int> block19to27)
        {
            int cnt = 1;

            for (int i=1;i<=7;i+=3)
                for (int j=1;j<=7;j+=3)
                {
                    var FieldKoorBlock = new List<Coordinates>();
                    for (int k=i; k<=i+2;k++)
                        for (int l=j; l<=j+2;l++)
                            FieldKoorBlock.Add(new Coordinates(k,l));

                    block.square.fields[cnt] = FieldKoorBlock;

                    block19to27[String.Format("{0}{1}",i,j)] = cnt;
                    cnt++;
                }
        }

        private void Task2(Field[,] fields, Block block, Dictionary<string,int> block19to27)
        {
            var FullPot = new List<int>(new int[]{1,2,3,4,5,6,7,8,9});

            for (int i = 1; i <=9; i++)
            {
                var FieldKoorHori = new List<Coordinates>();
                var FieldKoorVert = new List<Coordinates>();
                
                for(int j=1; j<=9; j++)
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
                    
                    fields[i,j].furtherinfluencingblocks = influencinglist;
                    
                    fields[i, j].blocknumber.horizontal = i;
                    fields[i, j].blocknumber.vertical   = j + 9;
                    fields[i, j].blocknumber.square = block19to27[String.Format("{0}{1}",k,l)];
                    
                    if (fields[i,j].number == 0)
                        fields[i,j].potential = FullPot;

                    FieldKoorHori.Add(new Coordinates(i,j));
                    FieldKoorVert.Add(new Coordinates(j,i));
                }

                block.fields[i] = FieldKoorHori;
                block.fields[i+9] = FieldKoorVert;
            }

            for (int i=1;i<=18;i++)
                block.potential[i] = FullPot;

            for (int i=1;i<=9;i++)
                block.square.potential[i] = FullPot;
        }
    }
}
