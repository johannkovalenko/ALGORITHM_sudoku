using System.Collections.Generic;

public class Field
{
    public int number = 0;
    public List<int> potential = new List<int>();
    public int[] block;

    public List<int> furtherinfluencingblocks = new List<int>();

    public Blocknumber blocknumber;

    public Field(int i, int j, BlockSquareMap blockSquareMap, Coordinates block)
    {
        blocknumber = new Blocknumber(i, j + 9, blockSquareMap[block.x*10 + block.y]);
        
        for (int m = block.x; m <= block.x+2; m++)
            if (i!=m)
                this.furtherinfluencingblocks.Add(m);
        
        for (int m = block.y; m <= block.y+2;m++)
            if (j != m)
                this.furtherinfluencingblocks.Add(m + 9); 
    }

    public class Blocknumber
    {
        public Blocknumber(int horizontal, int vertical, int square)
        {
            this.horizontal = horizontal;
            this.vertical = vertical;
            this.square = square;
        }

        public int square;
        public int horizontal;
        public int vertical;
    }
}
