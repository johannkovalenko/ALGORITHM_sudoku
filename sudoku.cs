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
        int totalFound = 0;

        new InputData.Sudoku().ReadOut(fields, ref totalFound);
        new Strategies.Preparation().Run(fields, potentialblock, fieldsperblock);
        new OutputData.Sudoku().Print(fields);

        while(totalFound <81 && twotimesnothing < 2)
        {
            bool found = Sudoku.ReducePot(fields);

            if (found)
            {
                totalFound++;
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

        bool found;

        new Strategies.Strategy1().Run(fields, potentialblock);
        new Strategies.Strategy2().Run(fields, fieldsperblock);
        new Strategies.Strategy3().Run(fields, fieldsperblock);
        
        found = new Strategies.Strategy4().Run(fields);
        if (found) return true;

        found = new Strategies.Strategy5().Run(fields, potentialblock);
        if (found) return true;
        
        found = new Strategies.Strategy6().Run(fields, fieldsperblock);
        if (found) return true;

        found = new Strategies.Strategy7().Run(fields, fieldsperblock);
        if (found) return true;
    
        return false;
    }
}