using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

class Sudoku
{
    public static void Main()
    {
        var stopwatch   = new Stopwatch();
        stopwatch.Start();

        var outputData = new OutputData.Sudoku();
        var fields      = new Field[10, 10];
        var block       = new Block();
        var strategy    = new Strategy(fields, block);
        
        var blockSquareMap = new BlockSquareMap();

        for (int i=1; i<=9; i++)
            for (int j=1; j<=9; j++)
                fields[i, j] = new Field(i, j, blockSquareMap);

        int twotimesnothing = 0;
        int totalFound = 0;

        new InputData.Sudoku().ReadOut(fields, ref totalFound);
        
        outputData.Print(fields);

        while(totalFound <81 && twotimesnothing < 2)
        {
            bool found = Sudoku.ReducePot(strategy, fields);

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

    public static bool ReducePot(Strategy strategy, Field[,] fields)
    {
        bool found;

        strategy.one.Run();
        strategy.two.Run();
        strategy.three.Run();
        
        found = strategy.four.Run();
        if (found) return true;

        found = strategy.five.Run();
        if (found) return true;
        
        found = strategy.six.Run();
        if (found) return true;

        found = strategy.seven.Run();
        if (found) return true;
    
        return false;
    }
}