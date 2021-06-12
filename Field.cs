using System.Collections.Generic;

public class Field
{
    public readonly int x;
    public readonly int y;
    public readonly Coordinates blockCoordinates;

    public int number = 0;
    public readonly List<int> potential;

    public readonly List<int> furtherinfluencingblocksHorizontal = new List<int>();
    public readonly List<int> furtherinfluencingblocksVertical = new List<int>();

    public Blocknumber blocknumber;

    public Field(int x, int y, int number)
    {       
        this.x = x;
        this.y = y;
        this.number = number;

        this.potential = number == 0 ? new List<int>(new int[]{1,2,3,4,5,6,7,8,9}) : new List<int>();

        int blockX = x - (x-1) % 3;
        int blockY = y - (y-1) % 3;

        this.blockCoordinates = new Coordinates(blockX, blockY);
        this.blocknumber = new Blocknumber(x, y, blockX + blockY/3);
        
        for (int m = this.blockCoordinates.x; m <= this.blockCoordinates.x+2; m++)
            furtherinfluencingblocksHorizontal.Add(m);

        for (int m = this.blockCoordinates.y; m <= this.blockCoordinates.y+2;m++)
            furtherinfluencingblocksVertical.Add(m); 

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
