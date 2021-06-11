using System.Collections.Generic;

public class OneFourSevenMap : Dictionary<int, Coordinates>
{
    public OneFourSevenMap()
    {
        for (int i=1;i<=9;i++)
            for (int j=1;j<=9;j++)
            {
                int k = i - (i-1) % 3;
                int l = j - (j-1) % 3;

                base[i*10+j] = new Coordinates(k, l);
            }
        
    }
}