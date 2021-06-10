using System.Collections.Generic;

public class Field
{
    public int number;
    public List<int> potential = new List<int>();
    public int[] block;

    public List<int> furtherinfluencingblocks;

    public Blocknumber blocknumber = new Blocknumber();

    public class Blocknumber
    {
        public int square;
        public int horizontal;
        public int vertical;
    }
}
