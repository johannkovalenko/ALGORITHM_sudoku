using System.Collections.Generic;

class Strategy
{
    public readonly Strategies.Strategy1 one;
    public readonly Strategies.Strategy2 two;
    public readonly Strategies.Strategy3 three;
    public readonly Strategies.Strategy4 four;
    public readonly Strategies.Strategy5 five;
    public readonly Strategies.Strategy6 six;
    public readonly Strategies.Strategy7 seven;

    public Strategy(Field[,] board, Block block)
    {
        one     = new Strategies.Strategy1(board, block);
        two     = new Strategies.Strategy2(board, block);
        three   = new Strategies.Strategy3(board, block);
        four    = new Strategies.Strategy4(board);
        five    = new Strategies.Strategy5(board, block);
        six     = new Strategies.Strategy6(board, block);
        seven   = new Strategies.Strategy7(board, block);
    }
}