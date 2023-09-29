// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
Player player = new Player();
GameController.Intro();
player.reportPosition();
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

    public void reportPosition()
    {
        Console.WriteLine($"You are in the room at (Row={Row},  Column={Col}).");
        // Check position in board, if something portray a sense.
    }

    // If player is outside board, reject movement and prompt again.
    public bool moveEast()
    {
        return false;
    }
}

public class GameController
{
    public static void Intro()
    {
        Console.WriteLine("You enter the Fountain of Objects. The fountain is in disrepair, and powers the City.");
        Console.WriteLine("Navigate the catacombs, repair the fountain, and get out of there ASAP.");
    }
}