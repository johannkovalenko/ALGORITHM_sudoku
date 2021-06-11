using System.Collections.Generic;

public class BlockSquareMap : Dictionary<int, int>
{
    public BlockSquareMap()
    {
        int cnt = 1;

        for (int i=1;i<=7;i+=3)
            for (int j=1;j<=7;j+=3)
                base[i*10 + j] = cnt++;
    }
}