using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;


class Sudoku
{
    private static List<List<int>> potentialblock = new List<List<int>>(); //Potential for each block
    private static List<int[]>[] fieldsperblock = new List<int[]>[28]; //
    private static int globalcnt = 0;

    public static void Main()
    {
        var stopwatch = new Stopwatch();

        stopwatch.Start();

        var fields = new Field[10, 10];

        for (int i=1; i<=9; i++)
            for (int j=1; j<=9; j++)
                fields[i, j] = new Field();

    
        int twotimesnothing = 0;

        new InputData.Sudoku().ReadOut(fields, ref globalcnt);
        new Strategies.Preparation().Run(fields, potentialblock, fieldsperblock);
        new OutputData.Sudoku().Print(fields);
        Console.WriteLine();

        while(globalcnt <81 && twotimesnothing < 2)
        {
            bool earlyExit = Sudoku.ReducePot(fields);

            if (!earlyExit) 
            {
               Console.WriteLine("Not finished");
               twotimesnothing++;
            }   
            else
                twotimesnothing = 0;    
        }

        new OutputData.Sudoku().Print(fields);

        stopwatch.Stop();

        Console.WriteLine(stopwatch.Elapsed.Milliseconds);
    }

    public static bool ReducePot(Field[,] fields)
    {
        List<int[]> IntListArr = new List<int[]>();     

        bool earlyExit;

        new Strategies.Strategy1().Run(fields, potentialblock);
        new Strategies.Strategy2().Run(fields, fieldsperblock, IntListArr);
        new Strategies.Strategy3().Run(fields, fieldsperblock, IntListArr);
        
        earlyExit = new Strategies.Strategy4().Run(fields, ref globalcnt);
        if (earlyExit) return true;

        earlyExit = new Strategies.Strategy5().Run(fields, potentialblock, ref globalcnt);
        if (earlyExit) return true;
        
        earlyExit = new Strategies.Strategy6().Run(fields, fieldsperblock, ref globalcnt);
        if (earlyExit) return true;

        earlyExit = new Strategies.Strategy7().Run(fields, fieldsperblock, ref globalcnt);
        if (earlyExit) return true;
    
        return false;
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