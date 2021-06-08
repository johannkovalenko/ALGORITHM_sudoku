using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;


class Sudoku
{
    private static List<List<int>> potentialblock = new List<List<int>>(); //Potential for each block
    private static List<int[]>[] fieldsperblock = new List<int[]>[28]; //

    public static void Main()
    {
        var stopwatch = new Stopwatch();

        stopwatch.Start();

        var fields = new Field[10, 10];

        for (int i=1; i<=9; i++)
            for (int j=1; j<=9; j++)
                fields[i, j] = new Field();

    
        int twotimesnothing = 0;
        int globalcnt = 0;

        new InputData.Sudoku().ReadOut(fields, ref globalcnt);
        new Strategies.Preparation().Run(fields, potentialblock, fieldsperblock);
        new OutputData.Sudoku().Print(fields);

        while(globalcnt <81 && twotimesnothing < 2)
        {
            bool earlyExit = Sudoku.ReducePot(fields);

            if (earlyExit)
            {
                globalcnt++;
                twotimesnothing = 0; 
            }
            else 
            {
               Console.WriteLine("Not finished");
               twotimesnothing++;
            }                      
        }

        new OutputData.Sudoku().Print(fields);

        stopwatch.Stop();

        Console.WriteLine(stopwatch.Elapsed.Milliseconds);
    }

    public static bool ReducePot(Field[,] fields)
    {

        bool earlyExit;

        new Strategies.Strategy1().Run(fields, potentialblock);
        new Strategies.Strategy2().Run(fields, fieldsperblock);
        new Strategies.Strategy3().Run(fields, fieldsperblock);
        
        earlyExit = new Strategies.Strategy4().Run(fields);
        if (earlyExit) return true;

        earlyExit = new Strategies.Strategy5().Run(fields, potentialblock);
        if (earlyExit) return true;
        
        earlyExit = new Strategies.Strategy6().Run(fields, fieldsperblock);
        if (earlyExit) return true;

        earlyExit = new Strategies.Strategy7().Run(fields, fieldsperblock);
        if (earlyExit) return true;
    
        return false;
    }
}