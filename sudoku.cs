using System;
using System.IO;
using System.Collections.Generic;

class Sudoku
{
    public static int[,] sudokufield = new int[10,10];
    public static object[,] potential = new object[10,10]; //Potential for each field
    public static object[] potentialblock = new object[28]; //Potential for each block
    public static object[] fieldsperblock = new object[28]; //

    public static object[,] blockforfield = new object[10,10];
    public static int globalcnt = 0;
    public static object[,] furtherinfluencingblocks = new object[10,10];

    public static void Main()
    {
        int twotimesnothing = 0;

        Sudoku.ReadFile();
        Sudoku.StartPot();
        //Sudoku.PrintFurtherInfluencingBlocks();
        //Sudoku.PrintBlockForField();
        Sudoku.PrintSudokuField();
        Console.WriteLine();

        while(globalcnt <81 && twotimesnothing < 2)
        {
            // foreach (int test in potential[7,5] as List<int>)
            //     Console.Write(test + " ");
            // Console.WriteLine();
            if (!Sudoku.ReducePot()) 
            {
               Console.WriteLine("Not finished");
               twotimesnothing++;
            }   
            else
            {
                twotimesnothing = 0;
            }
        

            //Sudoku.PrintSudokuField();
            //Console.WriteLine();
            //Console.ReadLine();        
        }
        //Sudoku.PrintPotential();
        //Sudoku.PrintPotentialBlock();
        Sudoku.PrintSudokuField();

        //while(!Sudoku.PrintPotentialFlexible());

        Console.ReadLine(); 
    }

    public static bool ReducePot()
    {
        List<int[]> IntListArr = new List<int[]>();     

        new Strategies.Strategy1().Run(blockforfield, sudokufield, potential, potentialblock);
        new Strategies.Strategy2().Run(blockforfield, sudokufield, potential, potentialblock, fieldsperblock, IntListArr);
        new Strategies.Strategy3().Run(blockforfield, sudokufield, potential, potentialblock, fieldsperblock, IntListArr);
        if (new Strategies.Strategy4().Run(blockforfield, sudokufield, potential, potentialblock, ref globalcnt))
            return true;

        if (new Strategies.Strategy5().Run(blockforfield, sudokufield, potential, potentialblock, furtherinfluencingblocks, ref globalcnt))
            return true;

        if (new Strategies.Strategy6().Run(blockforfield, sudokufield, potential, potentialblock, furtherinfluencingblocks, fieldsperblock, ref globalcnt))
            return true;
        
        if (new Strategies.Strategy7().Run(blockforfield, sudokufield, potential, potentialblock, furtherinfluencingblocks, fieldsperblock, ref globalcnt))
            return true;

        return false;
    }

    public static void ReadFile()
    {
        using (StreamReader sr = File.OpenText("./sudoku.txt"))
        {
            
            int cnt = 0;
            string line = default(string);

            while (cnt < 9)
            {
                line = sr.ReadLine();
                cnt++;
                for (int a=0;a<9;a++)
                {
                    if (line.Substring(a,1) != ".")
                    {
                        sudokufield[cnt,a+1] = int.Parse(line.Substring(a,1));
                        globalcnt++;
                    }
                }
            }
        }
    }
    public static void StartPot()
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

    public static void PrintPotential()
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

    public static bool PrintPotentialFlexible()
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

    public static void PrintBlockForField()
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
    public static void PrintFurtherInfluencingBlocks()
    {
        for (int i = 1; i <=9; i++)
        {
            for(int j=1;j<=9;j++)
            {
                Console.Write("{0},{1}   ", i, j);
                List<int> inter = furtherinfluencingblocks[i,j] as List<int>;
                foreach (int a in inter)
                    Console.Write(" {0}", a);
                Console.Write("\n");
            }
        }

    }
    public static void PrintPotentialBlock()
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
    public static void PrintSudokuField()
    {
        for (int i = 1; i <=9; i++)
        {
            for(int j=1;j<=9;j++)
            {
                if (sudokufield[i,j] == 0)
                {
                    Console.Write("  ");
                }
                else
                {
                    Console.Write("{0} ", sudokufield[i,j]);
                }
                
            }
            Console.Write("\n");
        }

    }
}