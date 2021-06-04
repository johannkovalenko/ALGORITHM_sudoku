using System;
using System.IO;
using System.Collections.Generic;

class Sudoku
{
    private static int[,] sudokufield = new int[10,10];
    private static List<int>[,] potential = new List<int>[10,10]; //Potential for each field
    private static List<int>[] potentialblock = new List<int>[28]; //Potential for each block
    private static List<int[]>[] fieldsperblock = new List<int[]>[28]; //

    private static int[,][] blockforfield = new int[10,10][];
    private static int globalcnt = 0;
    private static List<int>[,] furtherinfluencingblocks = new List<int>[10,10];

    public static void Main()
    {       
        int twotimesnothing = 0;

        new InputData.Sudoku().ReadOut(sudokufield, ref globalcnt);
        new Strategies.Preparation().Run(blockforfield, sudokufield, potential, potentialblock, fieldsperblock, furtherinfluencingblocks);
        //Sudoku.PrintFurtherInfluencingBlocks();
        //Sudoku.PrintBlockForField();
        new OutputData.Sudoku().Print(sudokufield);
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
        new OutputData.Sudoku().Print(sudokufield);

        //while(!Sudoku.PrintPotentialFlexible());

        Console.ReadLine(); 
    }

    public static bool ReducePot()
    {
        List<int[]> IntListArr = new List<int[]>();     

        new Strategies.Strategy1().Run(blockforfield, sudokufield, potential, potentialblock);
        new Strategies.Strategy2().Run(sudokufield, potential, fieldsperblock, IntListArr);
        new Strategies.Strategy3().Run(blockforfield, sudokufield, potential, fieldsperblock, IntListArr);
        if (new Strategies.Strategy4().Run(sudokufield, potential, ref globalcnt))
            return true;

        if (new Strategies.Strategy5().Run(sudokufield, potential, potentialblock, furtherinfluencingblocks, ref globalcnt))
            return true;

        if (new Strategies.Strategy6().Run(blockforfield, sudokufield, potential, fieldsperblock, ref globalcnt))
            return true;
        
        if (new Strategies.Strategy7().Run(sudokufield, potential, fieldsperblock, ref globalcnt))
            return true;

        return false;
    }
}