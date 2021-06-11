using System.Collections.Generic;

public class Field
{
    public readonly int x;
    public readonly int y;
    public int number = 0;
    public List<int> potential = new List<int>();

    public List<int> furtherinfluencingblocksHorizontal = new List<int>();
    public List<int> furtherinfluencingblocksVertical = new List<int>();

    public Blocknumber blocknumber;

    public Field(int x, int y, BlockSquareMap blockSquareMap, Coordinates block)
    {
        this.x = x;
        this.y = y;

        blocknumber = new Blocknumber(x, y, blockSquareMap[block.x*10 + block.y]);
        
        for (int m = block.x; m <= block.x+2; m++)
            if (x!=m)
                this.furtherinfluencingblocksHorizontal.Add(m);
        
        for (int m = block.y; m <= block.y+2;m++)
            if (y != m)
                this.furtherinfluencingblocksVertical.Add(m); 
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
