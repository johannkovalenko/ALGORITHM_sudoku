using System.Collections.Generic;

public class Block
{
    public List<int>[] potential = new List<int>[19];
    public List<Coordinates>[] fields = new List<Coordinates>[19];

    public Square square = new Square();
    public Vertical vertical = new Vertical();
    public Horizontal horizontal = new Horizontal();

    public Block()
    {
        for (int i = 1; i<=9; i++)
        {
            this.fields[i]         = new List<Coordinates>();
            this.fields[i+9]       = new List<Coordinates>();
            this.potential[i]      = new List<int>(new int[]{1,2,3,4,5,6,7,8,9});
            this.potential[i+9]    = new List<int>(new int[]{1,2,3,4,5,6,7,8,9});

            for(int j=1; j<=9; j++)
            {                       
                this.fields[i].Add(new Coordinates(i,j));
                this.fields[i+9].Add(new Coordinates(j,i));
            }
        }
    }

    public class Square
    {
        public List<int>[] potential = new List<int>[10];
        public List<Coordinates>[] fields = new List<Coordinates>[10];

        public Square()
        {
            for (int i = 1; i <=9; i++)          
                this.potential[i] = new List<int>(new int[]{1,2,3,4,5,6,7,8,9});


            int cnt = 1;

            for (int i=1;i<=7;i+=3)
                for (int j=1;j<=7;j+=3)
                {
                    this.fields[cnt] = new List<Coordinates>();
                    for (int k=i; k<=i+2;k++)
                        for (int l=j; l<=j+2;l++)
                            this.fields[cnt].Add(new Coordinates(k,l));

                    cnt++;
                }
        }
    }    

    public class Horizontal
    {
        public List<int>[] potential = new List<int>[10];
        public List<Coordinates>[] fields = new List<Coordinates>[10];
    }  

    public class Vertical
    {
        public List<int>[] potential = new List<int>[10];
        public List<Coordinates>[] fields = new List<Coordinates>[10];
    }  
}