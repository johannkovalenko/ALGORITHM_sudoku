using System.Collections.Generic;

public class Block
{
    public List<List<int>> potential = new List<List<int>>();
    public List<Coordinates>[] fields = new List<Coordinates>[28];
}