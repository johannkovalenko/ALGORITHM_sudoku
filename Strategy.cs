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

    public Strategy(Field[,] fields, List<List<int>> potentialblock, List<Coordinates>[] fieldsperblock)
    {
        one     = new Strategies.Strategy1(fields, potentialblock);
        two     = new Strategies.Strategy2(fields, fieldsperblock);
        three   = new Strategies.Strategy3(fields, fieldsperblock);
        four    = new Strategies.Strategy4(fields);
        five    = new Strategies.Strategy5(fields, potentialblock);
        six     = new Strategies.Strategy6(fields, fieldsperblock);
        seven   = new Strategies.Strategy7(fields, fieldsperblock);
    }
}