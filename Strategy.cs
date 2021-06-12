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

    public Strategy(Field[,] fields, Block block)
    {
        one     = new Strategies.Strategy1(fields, block);
        two     = new Strategies.Strategy2(fields, block);
        three   = new Strategies.Strategy3(fields, block);
        four    = new Strategies.Strategy4(fields);
        five    = new Strategies.Strategy5(fields, block);
        six     = new Strategies.Strategy6(fields, block);
        seven   = new Strategies.Strategy7(fields, block);
    }
}