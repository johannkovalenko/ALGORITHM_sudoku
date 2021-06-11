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

        int totalFound = 0;

        var outputData = new OutputData.Sudoku();
        var blockSquareMap = new BlockSquareMap();
        var oneFourSevenMap = new OneFourSevenMap();

        Field[,] fields = new InputData.Sudoku().Preparation(blockSquareMap, oneFourSevenMap, ref totalFound);  
        var block       = new Block();
        var strategy    = new Strategy(fields, block, oneFourSevenMap);
        
        int twotimesnothing = 0;

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