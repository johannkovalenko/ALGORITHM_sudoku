using System.Collections.Generic;

public class Field
{
    public readonly int x;
    public readonly int y;
    public readonly Coordinates blockCoordinates;

    public int number = 0;
    public List<int> potential = new List<int>();

    public List<int> furtherinfluencingblocksHorizontal = new List<int>();
    public List<int> furtherinfluencingblocksVertical = new List<int>();

    public Blocknumber blocknumber;

    public Field(int x, int y)
    {       
        this.x = x;
        this.y = y;

        int blockX = x - (x-1) % 3;
        int blockY = y - (y-1) % 3;

        blockCoordinates = new Coordinates(blockX, blockY);

        blocknumber = new Blocknumber(x, y, blockX + blockY/3);
        
        for (int m = this.blockCoordinates.x; m <= this.blockCoordinates.x+2; m++)
            if (x!=m)
                this.furtherinfluencingblocksHorizontal.Add(m);
        
        for (int m = this.blockCoordinates.y; m <= this.blockCoordinates.y+2;m++)
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

        public readonly int square;
        public readonly int horizontal;
        public readonly int vertical;
    }
}
