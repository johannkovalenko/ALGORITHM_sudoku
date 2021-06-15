public class Coordinates
{
    public int x;
    public int y;

    public Coordinates(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(object inObject)
    {
        Coordinates inObjectCast = (Coordinates) inObject;
        return inObjectCast.x == this.x && inObjectCast.y == this.y;
    }

    public override int GetHashCode()
    {
        return 1;
    }
}