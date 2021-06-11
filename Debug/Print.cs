using System;
using System.Collections.Generic;

namespace Debug
{
    public class Print
    {
        public static void PrintPotential(object[,] potential)
        {
            List<int> IntList;
            for (int i = 1; i <=9; i++)
            {
                for(int j=1;j<=9;j++)
                {
                    IntList = potential[i,j] as List<int>;
                    Console.Write("{0},{1}   ", i, j);
                    foreach (int a in IntList)
                        Console.Write(a);
                    Console.Write("\n");
                }
            }
        }

        public static bool PrintPotentialFlexible(object[,] potential, object[] fieldsperblock)
        {
            Console.WriteLine("Print which block?");
            string answerstr = Console.ReadLine();

            if (answerstr == "exit") return true;

            int answer = int.Parse(answerstr);

            foreach (int[] k in fieldsperblock[answer] as List<int[]>)
            {
                Console.Write("{0},{1}   ", k[0], k[1]);
                foreach (int a in potential[k[0],k[1]] as List<int>)
                    Console.Write(a);
                Console.Write("\n");
            }

            return false;
        }

        public static void PrintBlockForField(object[,] blockforfield)
        {
            for (int i = 1; i <=9; i++)
            {
                for(int j=1;j<=9;j++)
                {
                    Console.Write("{0},{1}   ", i, j);
                    int[] inter = blockforfield[i,j] as int[];
                    foreach (int a in inter)
                        Console.Write(" {0}", a);
                    Console.Write("\n");
                }
            }

        }

        public static void PrintPotentialBlock(object[] potentialblock)
        {
            List<int> IntList;
            int[] whichblocks = new int[] {1,2,3,16,17,18,21};
            foreach(int i in whichblocks)
            //for (int i = 1; i <=27; i++)
            {
                IntList = potentialblock[i] as List<int>;
                Console.Write("Block {0}   ", i);
                foreach (int a in IntList)
                    Console.Write(a);
                Console.Write("\n");
        
            }

        }    

        public static void PrintPotentialFull(Field[,] fields)
        {
            var sb = new System.Text.StringBuilder();

            for (int x=1; x<=1; x++)
                for (int y=1; y<=1; y++)
                {
                    sb.Append(x + " " + y + "    " + fields[x, y].number + "    ");
                    foreach (int test in fields[x,y].potential)
                        sb.Append(test + " ");
                    sb.Append("\r\n");        
                }

            sb.Append("-------\r\n");
            //File.AppendAllText(@"working.txt", sb.ToString());
            Console.WriteLine(sb.ToString());
        }    
    }
}