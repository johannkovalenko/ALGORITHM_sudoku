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
        new Strategies.Strategy2().Run(blockforfield, sudokufield, potential, potentialblock, fieldsperblock, IntListArr);
        new Strategies.Strategy3().Run(blockforfield, sudokufield, potential, potentialblock, fieldsperblock, IntListArr);
        if (new Strategies.Strategy4().Run(blockforfield, sudokufield, potential, potentialblock, ref globalcnt))
            return true;

        if (new Strategies.Strategy5().Run(blockforfield, sudokufield, potential, potentialblock, furtherinfluencingblocks, ref globalcnt))
            return true;

        if (new Strategies.Strategy6().Run(blockforfield, sudokufield, potential, potentialblock, furtherinfluencingblocks, fieldsperblock, ref globalcnt))
            return true;
        
        if (new Strategies.Strategy7().Run(blockforfield, sudokufield, potential, potentialblock, furtherinfluencingblocks, fieldsperblock, ref globalcnt))
            return true;

        return false;
    }
}