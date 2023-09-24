// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Coordinate coord1 = new Coordinate(2,3);
Coordinate coord2 = new Coordinate(6,9); 
Coordinate coord3 = new Coordinate(3, 3);

Console.WriteLine(Coordinate.isAdjacent(coord1, coord2));
Console.WriteLine(Coordinate.isAdjacent(coord1, coord3));


public struct Coordinate
{
    public int Column { get; }
    public int Row { get; }

    public Coordinate(int column, int row)
    {
        Column = column;
        Row = row;
    }

    public static bool isAdjacent(Coordinate coord1, Coordinate coord2)
    {
        // Adjacency is all tiles in a plus formation relative to this one
        // or differing only by a single row or column
        int rowChange = coord1.Row - coord2.Row; 
        int columnChange = coord1.Column - coord2.Column;

        if (Math.Abs(rowChange) == 1 && columnChange == 0) return true;
        if (Math.Abs(columnChange) == 1 && rowChange == 0) return true;

        return false;
    }
}