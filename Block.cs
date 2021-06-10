using System.Collections.Generic;

public class Block
{
    public List<int>[] potential = new List<int>[19];
    public List<Coordinates>[] fields = new List<Coordinates>[19];

    public Square square = new Square();

    public class Square
    {
        public List<int>[] potential = new List<int>[10];
        public List<Coordinates>[] fields = new List<Coordinates>[10];
    }    
}