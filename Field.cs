using System.Collections.Generic;

public class Field
{
    public int number = 0;
    public List<int> potential = new List<int>();
    public int[] block;

    public List<int> furtherinfluencingblocks = new List<int>();

    public Blocknumber blocknumber;

    public Field(int i, int j, BlockSquareMap blockSquareMap)
    {
        int k = i - (i-1) % 3;
        int l = j - (j-1) % 3;

        blocknumber = new Blocknumber(i, j + 9, blockSquareMap[k*10 + l]);
        
        for (int m = k; m <= k+2;m++)
            if (i!=m)
                this.furtherinfluencingblocks.Add(m);
        
        for (int m = l; m <= l+2;m++)
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
