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

        while(!Sudoku.PrintPotentialFlexible());

        Console.ReadLine(); 
    }

    public static bool ReducePot()
    {
        List<int> IntList, IntList2;
        List<int[]> IntListArr = new List<int[]>();
        List<string> BorderingBlock = new List<string>();
        int k = default(int);
        int l = default(int);
        Dictionary<int,int> howoften;
        int value, cnt;
        int[] blockarr;
        int x, y;
        bool DontDoIt;

        //Strategy 1
        for (int i = 1; i <=9; i++)
        {
            for(int j=1;j<=9;j++)
            {
                if (sudokufield[i,j] != default(int))
                {     
                    k = i - (i-1) % 3;
                    l = j - (j-1) % 3;

                    foreach (int a in blockforfield[i,j] as int[])
                    {
                        IntList = new List<int>(potentialblock[a] as List<int>);
                        IntList.Remove(sudokufield[i,j]);
                        potentialblock[a] = IntList;
                    }

                    for (int m = k; m <= k+2; m++)
                    {
                        for (int n = l; n <= l+2; n++)
                        {
                            IntList = new List<int>(potential[m,n] as List<int>);
                            IntList.Remove(sudokufield[i,j]);
                            potential[m,n] = IntList;                           
                        }
                    }
                    
                    for (k = 1; k <=9; k++)
                    {
                        IntList = new List<int>(potential[i,k] as List<int>);
                        IntList.Remove(sudokufield[i,j]);
                        potential[i,k] = IntList;
                        IntList = new List<int>(potential[k,j] as List<int>);
                        IntList.Remove(sudokufield[i,j]);
                        potential[k,j] = IntList;                      
                    }
                }
            }
        }
        //Strategy 2

        for (int i=19;i<=27;i++)
        {
            for (int j=1;j<=9;j++)
            {
                IntListArr.Clear();
                foreach (int[] kk in fieldsperblock[i] as List<int[]>)
                    if ((potential[kk[0],kk[1]] as List<int>).Contains(j))
                        IntListArr.Add(new int[] {kk[0],kk[1]});

                if (IntListArr.Count == 2)
                {
                    if (IntListArr[0][0] == IntListArr[1][0])
                    {
                        for (l = 1; l <=9; l++)
                        {
                            if (l != IntListArr[0][1] && l != IntListArr[1][1])
                            {
                                IntList = new List<int>(potential[IntListArr[0][0],l] as List<int>);
                                IntList.Remove(j);
                                potential[IntListArr[0][0],l] = IntList;   
                            }
                        }
                    }
                    if (IntListArr[0][1] == IntListArr[1][1])
                    {
                        for (l = 1; l <=9; l++)
                        {
                            if (l != IntListArr[0][0] && l != IntListArr[1][0])
                            {
                                IntList = new List<int>(potential[l,IntListArr[0][1]] as List<int>);
                                IntList.Remove(j);
                                potential[l,IntListArr[0][1]] = IntList;
                            }                   
                        }
                    }
                }
            }
        }

        ///Strategy 3
        for (int i=1;i<=9;i++)
        {
            foreach (int j in new int[]{1,4,7})
            {
                //Hori
                IntListArr.Clear();
                for (int m=j;m<=j+2;m++)
                {
                    IntList = potential[i,m] as List<int>;
                    if((IntList).Count == 2)
                    {
                        IntListArr.Add(new int[]{IntList[0], IntList[1]});
                    }
                }
                if (IntListArr.Count == 2)
                {
                    if (IntListArr[0][0] == IntListArr[1][0] && IntListArr[0][1] == IntListArr[1][1])
                    {
                        blockarr = blockforfield[i,j] as int[];
                        foreach (int[] n in fieldsperblock[blockarr[2]] as List<int[]>)
                        {
                            if (n[0] != i)
                            {
                                IntList2 = new List<int>(potential[n[0],n[1]] as List<int>);
                                IntList2.Remove(IntListArr[0][0]);
                                IntList2.Remove(IntListArr[0][1]);
                                potential[n[0],n[1]] = IntList2;   
                            }
                        }
                        for (l = 1; l <=9; l++)
                        {
                            if (l != j && l != j+1 && l!= j+2)
                            {
                                IntList2 = new List<int>(potential[i,l] as List<int>);
                                IntList2.Remove(IntListArr[0][0]);
                                IntList2.Remove(IntListArr[0][1]);
                                potential[i,l] = IntList2;   
                            }
                        }
                    }
                }
                //Verti
                IntListArr.Clear();
                for (int m=j;m<=j+2;m++)
                {
                    IntList = potential[m,i] as List<int>;
                    if((IntList).Count == 2)
                    {
                        IntListArr.Add(new int[]{IntList[0], IntList[1]});
                    }
                }
                if (IntListArr.Count == 2)
                {
                    if (IntListArr[0][0] == IntListArr[1][0] && IntListArr[0][1] == IntListArr[1][1])
                    {
                        blockarr = blockforfield[j,i] as int[];
                        foreach (int[] n in fieldsperblock[blockarr[2]] as List<int[]>)
                        {
                            if (n[1] != i)
                            {
                                IntList2 = new List<int>(potential[n[0],n[1]] as List<int>);
                                IntList2.Remove(IntListArr[0][0]);
                                IntList2.Remove(IntListArr[0][1]);
                                potential[n[0],n[1]] = IntList2;   
                            }
                        }
                        for (l = 1; l <=9; l++)
                        {
                            if (l != j && l != j+1 && l!= j+2)
                            {
                                IntList2 = new List<int>(potential[l,i] as List<int>);
                                IntList2.Remove(IntListArr[0][0]);
                                IntList2.Remove(IntListArr[0][1]);
                                potential[l,i] = IntList2;   
                            }
                        }
                    }
                }
            }  


        }

        ///Strategy 3
        for (int i=1;i<=9;i++)
        {
            for (int j=1;j<=9;j++)
            {
                if ((potential[i,j] as List<int>).Count == 1)
                {
                    sudokufield[i,j] = (potential[i,j] as List<int>)[0];
                    //Console.WriteLine("Case one {0},{1}", i, j);
                    potential[i,j] = new List<int>(new int[]{});
                    globalcnt++;
                    return true;
                }
            }
        }
        
        ///Strategy 4
        for (int i=1;i<=9;i++)
        {
            for (int j=1;j<=9;j++)
            {
                k = i - (i-1) % 3;
                l = j - (j-1) % 3;

                foreach (int a in potential[i,j] as List<int>)
                {
                    DontDoIt = false;
                    BorderingBlock.Clear();
   
                    for (int m=k;m<=k+2;m++)
                    {
                        for (int n=l;n<=l+2;n++)
                        {
                            if (!(m == i && n == j))
                            {
                                BorderingBlock.Add(String.Format("{0}{1}",m, n));
                            }
                        }
                    }
                     
                    foreach (int b in furtherinfluencingblocks[i,j] as List<int>)
                    {
                        if (!(potentialblock[b] as List<int>).Contains(a))
                        {
                            for (int c = 0; c < BorderingBlock.Count; c++)
                            {
                                if (BorderingBlock[c] != default(string))
                                {
                                    if (b <= 9)
                                    {
                                        if (BorderingBlock[c].Substring(0,1) == String.Format("{0}", b))
                                            BorderingBlock[c] = default(string);
                                    }
                                    else
                                    {
                                        if (BorderingBlock[c].Substring(1,1) == String.Format("{0}", b-9))
                                            BorderingBlock[c] = default(string);
                                    }
                                }

                            }
                        }
                    }
                    foreach (string c in BorderingBlock)
                    {
                        if (c != default(string))
                        {
                            x = int.Parse(c.Substring(0,1));
                            y = int.Parse(c.Substring(1,1)); 
                            if (sudokufield[x,y] == default(int))
                            {
                                DontDoIt = true;
                            }
                        }
                    }
                    if (!DontDoIt)
                    {
                        sudokufield[i,j] = a;
                        //Console.WriteLine("Case two  {0},{1}", i, j);
                        potential[i,j] = new List<int>(new int[]{});
                        globalcnt++;
                        return true;
                    }
                }
            }
        }
        //Strategy 5
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
                    
                    IntList = potential[i,j] as List<int>;
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

        //Strategy 7
        for (int i=1;i<=27;i++)
        {
            for (int o=1;o<=9;o++)
            {  
                cnt = 0;
                foreach (int[] j in fieldsperblock[i] as List<int[]>)
                {
                    IntList = potential[j[0],j[1]] as List<int>;
                    foreach (int m in IntList)
                        if (o == m)
                            cnt++;
                }
                if (cnt==1)
                {
                    foreach (int[] j in fieldsperblock[i] as List<int[]>)
                    {
                        if ((potential[j[0],j[1]] as List<int>).Contains(o))
                        {
                            sudokufield[j[0],j[1]] = o;
                            //Console.WriteLine("Case three {0},{1}", i, j);
                            potential[j[0],j[1]] = new List<int>(new int[]{});
                            globalcnt++;
                            return true;
                        }
                  
                    }
                }
            }
        }
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