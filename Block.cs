using System.Collections.Generic;

public class Block
{
    public readonly Square square = new Square();
    public readonly Vertical vertical = new Vertical();
    public readonly Horizontal horizontal = new Horizontal();

    public class Horizontal
    {
        public readonly List<int>[] potential = new List<int>[9];
        public readonly Coordinates[][] fields = new Coordinates[9][];

        public Horizontal()
        {
            for (int i=0; i<9; i++)
            {
                this.fields[i]         = new Coordinates[9];
                this.potential[i]      = new List<int>(new int[]{1,2,3,4,5,6,7,8,9});

                for(int j=0; j<9; j++)                     
                    this.fields[i][j] = new Coordinates(i,j);
            }
        }
    }

    public class Vertical
    {
        public readonly List<int>[] potential = new List<int>[9];
        public readonly Coordinates[][] fields = new Coordinates[9][];

        public Vertical()
        {
            for (int i =0; i<9; i++)
            {
                this.fields[i]         = new Coordinates[9];
                this.potential[i]      = new List<int>(new int[]{1,2,3,4,5,6,7,8,9});

                for(int j=0; j<9; j++)                     
                    this.fields[i][j] = new Coordinates(j,i);
            }
        }
    }

    public class Square
    {
        public readonly List<int>[] potential = new List<int>[9];
        public readonly Coordinates[][] fields = new Coordinates[9][];

        public Square()
        {
            for (int i =0; i<9; i++)          
                this.potential[i] = new List<int>(new int[]{1,2,3,4,5,6,7,8,9});


            int cnt =0;

            for (int i=0;i<=7;i+=3)
                for (int j=0;j<=7;j+=3)
                {
                    this.fields[cnt] = new Coordinates[9];

                    int cnt1 =0;
                    for (int k=i; k<=i+2;k++)
                        for (int l=j; l<=j+2;l++)
                            this.fields[cnt][cnt1++] = new Coordinates(k,l);

                    cnt++;
                }
        }
    }    
}