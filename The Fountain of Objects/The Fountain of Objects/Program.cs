// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
Player player = new Player();
GameController.Intro();
while (true)
{
    if (player.gameOver == true)
    {
        break;
    }
    player.playTurn();
}
GameController.Ending();
// Player has a row and column value, alterable by functions
// Those values are used to index the board
// If the string in the board has a specific value, do something.

public class Map
{
    protected string[,] Board = {
        {"entrance" ," " ,"fountain", " " }, // Row 0
        {" " ," " ," " , " "},  // Row 1                                    
        {" " ," " ," " , " " }, // Row 2
        { " ", " ", " ", " " }, // Row 3
    };
    // Column 0 1 2 3 
    protected bool FountainisOn = false;
}

public class Player : Map
{
    public int Row { get; private set; } = 0;
    public int Col { get; private set; } = 0;

    public bool gameOver { get; private set; }
    public void reportPosition()
    {
        Console.WriteLine($"You are in the room at (Row={Row},  Column={Col}).");
        // Check position in board, if something portray a sense.
    }

    public void playTurn()
    {
        Console.WriteLine("----------------------------------------");
        reportPosition();
        reportSense();
        getMove();
    }
    public void reportSense()
    {
        if (Board[Row,Col] == " ")
        {
            Console.WriteLine("You sense nothing in particular in this room");
        }
        else if (Board[Row, Col] == "fountain" && FountainisOn == false)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if (Board[Row, Col] == "fountain" && FountainisOn == true)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if (Board[Row, Col] == "entrance" && FountainisOn == true)
        {
            Console.WriteLine("You finished the game!");
            gameOver = true;
        }
        else if (Board[Row, Col] == "entrance")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You see light coming from the cavern entrance.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public void getMove()
    {
        if (gameOver) { return; }
        Console.WriteLine("What do you want to do?\n----------------------------------------");
        string command = Console.ReadLine();
        switch (command)
        {
            case "move north":
                if (moveNorth() == false) { getMove(); }
                break;
            case "move south":
                if (moveSouth() == false) { getMove(); }
                break;
            case "move west":
                if (moveWest() == false) { getMove(); }
                break;
            case "move east":
                if (moveEast() == false) { getMove(); }
                break;
            case "enable fountain":
                if (Board[Row, Col] == "fountain" && FountainisOn == false)
                {
                    FountainisOn = true;
                    Console.WriteLine("The fountain is re-enabled");
                }
                else if (Board[Row, Col] == "fountain" && FountainisOn == true)
                {
                    FountainisOn = false;
                    Console.WriteLine("You disabled the fountain. But why?");
                }
                else
                {
                    Console.WriteLine("Can't do this right now.");
                }
                break;
            default:
                Console.WriteLine("Not a valid command");
                getMove();
                break;
        }
    }
    // If player is outside board, reject movement and prompt again.
    public bool moveEast()
    {
        if (Col + 1 > 3)
        {
            Console.WriteLine("You can't move outside the board");
            return false;
        }
        Col = Col + 1;
        return true;
    }
    public bool moveWest()
    {
        if (Col - 1 < 0)
        {
            Console.WriteLine("You can't move outside the board");
            return false;
        }
        Col = Col - 1;
        return true;
    }
    public bool moveNorth()
    {
        if (Row - 1 < 0)
        {
            Console.WriteLine("You can't move outside the board");
            return false;
        }
        Row = Row - 1;
        return true;
    }
    public bool moveSouth()
    {
        if (Row + 1 < 0)
        {
            Console.WriteLine("You can't move outside the board");
            return false;
        }
        Row = Row + 1;
        return true;
    }
}

public class GameController
{
    public static void Intro()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("You enter the Fountain of Objects. The fountain is in disrepair, and powers the City.");
        Console.WriteLine("Navigate the catacombs, repair the fountain, and get out of there ASAP.");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void Ending()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("You reactivted the fountain and remained intact. You win!");
        Console.ForegroundColor = ConsoleColor.White;
    }

}