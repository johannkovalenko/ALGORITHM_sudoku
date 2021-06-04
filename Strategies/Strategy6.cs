using System.Collections.Generic;
using System;

namespace Strategies
{
    public class Strategy6
    {
        public bool Run(object[,] blockforfield, int[,] sudokufield, object[,] potential, object[] potentialblock, object[,] furtherinfluencingblocks, object[] fieldsperblock, ref int globalcnt)
        {
            int value;
            Dictionary<int,int> howoften;
            
            for (int i=1;i<=9;i++)
            {
                for (int j=1;j<=9;j++)
                {
                    //Console.ReadLine();
                    howoften = new Dictionary<int,int>();
                    foreach (int blockno in blockforfield[i,j] as int[])
                    {
                        //Console.WriteLine(blockno + "   " + i + "   " + j);

                        foreach (int[] koors in fieldsperblock[blockno] as List<int[]>)
                        {
                            foreach (int number in potential[koors[0],koors[1]] as List<int>)
                            {
                                if (howoften.TryGetValue(number, out value))
                                {
                                    howoften[number] = value + 1;
                                }
                                else
                                {
                                    howoften.Add(number,1);
                                }
                            }
                        }
                        
                        var IntList = potential[i,j] as List<int>;
                        foreach (int ky in howoften.Keys)
                        {
                            //Console.WriteLine("{0}   {1}    {2}     {3}     {4}", ky, howoften[ky], i, j, blockno);
                            
                            if (howoften[ky] == 1 && IntList.Contains(ky))
                            {
                                sudokufield[i,j] = ky;
                                //Console.WriteLine("Case three {0},{1}", i, j);
                                potential[i,j] = new List<int>(new int[]{});
                                globalcnt++;
                                return true;
                            }
                        }
                    } 
                }
            }

            return false;
        }
    }
}