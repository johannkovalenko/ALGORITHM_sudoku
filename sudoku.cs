using System;
using System.IO;
using System.Collections.Generic;

class Sudoku
{
    private static int[,] sudokufield = new int[10,10];
    private static List<int>[,] potential = new List<int>[10,10]; //Potential for each field
    private static List<List<int>> potentialblock = new List<List<int>>(); //Potential for each block
    private static List<int[]>[] fieldsperblock = new List<int[]>[28]; //

    private static int[,][] blockforfield = new int[10,10][];
    private static int globalcnt = 0;
    private static List<int>[,] furtherinfluencingblocks = new List<int>[10,10];

    public static void Main()
    {       
        int twotimesnothing = 0;

        new InputData.Sudoku().ReadOut(sudokufield, ref globalcnt);
        new Strategies.Preparation().Run(blockforfield, sudokufield, potential, potentialblock, fieldsperblock, furtherinfluencingblocks);
        new OutputData.Sudoku().Print(sudokufield);
        new OutputData.Sudoku().SaveInTxt(sudokufield, "working.txt");
        Console.WriteLine();

        while(globalcnt <81 && twotimesnothing < 2)
        {
            if (!Sudoku.ReducePot()) 
            {
               Console.WriteLine("Not finished");
               twotimesnothing++;
            }   
            else
            {
                twotimesnothing = 0;
            }
        
            Environment.Exit(-1);      
        }
        
        new OutputData.Sudoku().Print(sudokufield);

        Console.ReadLine(); 
    }

    public static bool ReducePot()
    {
        List<int[]> IntListArr = new List<int[]>();     

        bool earlyExit;

        PrintPotential(3, 2);

        new Strategies.Strategy1().Run(blockforfield, sudokufield, potential, potentialblock);
        //new OutputData.Sudoku().SaveInTxt(sudokufield, "working.txt");
        PrintPotential(3, 2);
            
        new Strategies.Strategy2().Run(sudokufield, potential, fieldsperblock, IntListArr);
        //new OutputData.Sudoku().SaveInTxt(sudokufield, "working.txt");
        PrintPotential(3, 2);

        new Strategies.Strategy3().Run(blockforfield, sudokufield, potential, fieldsperblock, IntListArr);
        //new OutputData.Sudoku().SaveInTxt(sudokufield, "working.txt");
        PrintPotential(3, 2);

        earlyExit = new Strategies.Strategy4().Run(sudokufield, potential, ref globalcnt);
        //new OutputData.Sudoku().SaveInTxt(sudokufield, "working.txt");
        PrintPotential(3, 2);

        if (earlyExit) return true;

        earlyExit = new Strategies.Strategy5().Run(sudokufield, potential, potentialblock, furtherinfluencingblocks, ref globalcnt);
        //new OutputData.Sudoku().SaveInTxt(sudokufield, "working.txt");
        PrintPotential(3, 2);

        if (earlyExit) return true;
        
        earlyExit = new Strategies.Strategy6().Run(blockforfield, sudokufield, potential, fieldsperblock, ref globalcnt);
        //new OutputData.Sudoku().SaveInTxt(sudokufield, "working.txt");
        PrintPotential(3, 2);

        if (earlyExit) return true;

        earlyExit = new Strategies.Strategy7().Run(sudokufield, potential, fieldsperblock, ref globalcnt);
        //new OutputData.Sudoku().SaveInTxt(sudokufield, "working.txt");
        PrintPotential(3, 2);

        if (earlyExit) return true;

        return false;
    }

    private static void PrintPotential(int x, int y)
    {
        Console.Write(x + " " + y + "\t" + sudokufield[x, y] + "\t");
        foreach (int test in potential[x,y])
            Console.Write(test + " ");
        Console.WriteLine();
    }
}