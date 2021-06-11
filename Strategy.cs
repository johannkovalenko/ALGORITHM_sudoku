using System.Collections.Generic;

class Strategy
{
    public Strategies.Strategy1 one;
    public Strategies.Strategy2 two;
    public Strategies.Strategy3 three;
    public Strategies.Strategy4 four;
    public Strategies.Strategy5 five;
    public Strategies.Strategy6 six;
    public Strategies.Strategy7 seven;

    public Strategy(Field[,] fields, Block block, OneFourSevenMap oneFourSevenMap)
    {
        one     = new Strategies.Strategy1(fields, block, oneFourSevenMap);
        two     = new Strategies.Strategy2(fields, block);
        three   = new Strategies.Strategy3(fields, block);
        four    = new Strategies.Strategy4(fields);
        five    = new Strategies.Strategy5(fields, block, oneFourSevenMap);
        six     = new Strategies.Strategy6(fields, block);
        seven   = new Strategies.Strategy7(fields, block);
    }
}