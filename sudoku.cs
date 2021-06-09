using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;


class Sudoku
{
    private static List<List<int>> potentialblock = new List<List<int>>(); //Potential for each block
    private static List<int[]>[] fieldsperblock = new List<int[]>[28]; //


    private static OutputData.Sudoku outputData = new OutputData.Sudoku();

    private static Strategies.Strategy1 strategy1 = new Strategies.Strategy1();
    private static Strategies.Strategy2 strategy2 = new Strategies.Strategy2();
    private static Strategies.Strategy3 strategy3 = new Strategies.Strategy3();
    private static Strategies.Strategy4 strategy4 = new Strategies.Strategy4();
    private static Strategies.Strategy5 strategy5 = new Strategies.Strategy5();
    private static Strategies.Strategy6 strategy6 = new Strategies.Strategy6();
    private static Strategies.Strategy7 strategy7 = new Strategies.Strategy7();


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
        outputData.Print(fields);

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

        outputData.Print(fields);

        stopwatch.Stop();

        Console.WriteLine(stopwatch.Elapsed.Milliseconds);
    }

    public static bool ReducePot(Field[,] fields)
    {
        bool found;

        strategy1.Run(fields, potentialblock);
        strategy2.Run(fields, fieldsperblock);
        strategy3.Run(fields, fieldsperblock);
        
        found = strategy4.Run(fields);
        if (found) return true;

        found = strategy5.Run(fields, potentialblock);
        if (found) return true;
        
        found = strategy6.Run(fields, fieldsperblock);
        if (found) return true;

        found = strategy7.Run(fields, fieldsperblock);
        if (found) return true;
    
        return false;
    }
}