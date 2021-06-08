using System;
using System.IO;
using System.Collections.Generic;

class Sudoku
{
    private static List<List<int>> potentialblock = new List<List<int>>(); //Potential for each block
    private static List<int[]>[] fieldsperblock = new List<int[]>[28]; //

    private static int[,][] blockforfield = new int[10,10][];
    private static int globalcnt = 0;
    private static List<int>[,] furtherinfluencingblocks = new List<int>[10,10];

    public static void Main()
    {       
        var fields = new Field[10, 10];

        for (int i=1; i<=9; i++)
            for (int j=1; j<=9; j++)
                fields[i, j] = new Field();

    
        int twotimesnothing = 0;

        new InputData.Sudoku().ReadOut(fields, ref globalcnt);
        new Strategies.Preparation().Run(blockforfield, fields, potentialblock, fieldsperblock, furtherinfluencingblocks);
        new OutputData.Sudoku().Print(fields);
        Console.WriteLine();

        while(globalcnt <81 && twotimesnothing < 2)
        {
            if (!Sudoku.ReducePot(fields)) 
            {
               Console.WriteLine("Not finished");
               twotimesnothing++;
            }   
            else
                twotimesnothing = 0;    
        }
        new OutputData.Sudoku().Print(fields);

        Console.ReadLine(); 
    }

    public static bool ReducePot(Field[,] fields)
    {
        List<int[]> IntListArr = new List<int[]>();     

        bool earlyExit;

        new Strategies.Strategy1().Run(blockforfield, fields, potentialblock);
        new Strategies.Strategy2().Run(fields, fieldsperblock, IntListArr);
        new Strategies.Strategy3().Run(blockforfield, fields, fieldsperblock, IntListArr);
        
        earlyExit = new Strategies.Strategy4().Run(fields, ref globalcnt);
        if (earlyExit) return true;

        earlyExit = new Strategies.Strategy5().Run(fields, potentialblock, furtherinfluencingblocks, ref globalcnt);
        if (earlyExit) return true;
        
        earlyExit = new Strategies.Strategy6().Run(blockforfield, fields, fieldsperblock, ref globalcnt);
        if (earlyExit) return true;

        earlyExit = new Strategies.Strategy7().Run(fields, fieldsperblock, ref globalcnt);
        if (earlyExit) return true;

        return false;
    }

    private static void PrintPotentialFull(Field[,] fields)
    {
        var sb = new System.Text.StringBuilder();

        for (int x=1; x<9; x++)
            for (int y=1; y<9; y++)
            {
                sb.Append(x + " " + y + "    " + fields[x, y].number + "    ");
                foreach (int test in fields[x,y].potential)
                    sb.Append(test + " ");
                sb.Append("\r\n");        
            }

        sb.Append("-------\r\n");
        File.AppendAllText(@"C:\Users\u540929\OneDrive - Lufthansa Group\johann\TL\Programming\Test\working.txt", sb.ToString());
    }
}