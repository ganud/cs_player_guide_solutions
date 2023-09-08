// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Point coord = new Point(2,3);
Console.WriteLine($"({coord.X}, {coord.Y})");
Point coord2 = new Point(-4,0);
Console.WriteLine($"({coord2.X}, {coord2.Y})");
class Point
{
    public int X { get;}
    public int Y { get;}
    
    public Point()
    {
        X = 0;
        Y = 0;
    }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

// Immutable. The reason why is to keep things simple, which is also why there are no floats as of now.