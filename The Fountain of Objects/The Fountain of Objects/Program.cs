// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// Player has a row and column value, alterable by functions
// Those values are used to index the board
// If the string in the board has a specific value, do something.

public class Map
{
    private string[,] Board = {
        {"entrance" ," " ,"fountain", " " }, // Row
        {" " ," " ," " , " "},
        {" " ," " ," " , " " },
        { " ", " ", " ", " " },
    };
    // Column
    private bool FountainisOn = false;
}

public class Player : Map
{
    private int Row { get; set; } = 0;
    private int Col { get; set; } = 0;
}