// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

Player player = new Player();
GameController.Intro();
player.chooseBoard();
while (true)
{
    if (player.gameOver == true || player.dead == true)
    {
        break;
    }
    player.playTurn();
}
if (player.gameOver == true)
{
    GameController.Ending();
}
else if (player.dead == true)
{
    GameController.BadEnding();
}
// Player has a row and column value, alterable by functions
// Those values are used to index the board
// If the string in the board has a specific value, do something.

public class Map
{
    protected string[,] Board = {
        {"entrance" ,"amarok" ,"fountain", " " }, // Row 0
        {" " ," " ,"pit" , " "},  // Row 1                                    
        {" " ," " ," " , " " }, // Row 2
        { " ", " ", " ", " " }, // Row 3
    };
    // Column 0 1 2 3 
    protected bool FountainisOn = false;
}

public class Player : Map
{
    private int Row { get; set; } = 0;
    private int Col { get; set; } = 0;

    public bool gameOver { get; private set; }
    public bool dead { get; private set; }


    private int mapSize = 3;
    public void chooseBoard()
    {
        Console.WriteLine("Choose a board size from small, medium, or large");
        string size = Console.ReadLine();
        switch (size)
        {
            case "small":
                mapSize = 3;
                break;
            case "medium":
                string[,] BoardcopyM =
                {
                    {"entrance", " ", " ", " ", " ", " "},
                    {" ", "maelstrom", " ", " ", "pit", " "},
                    {" ", "pit", " ", "fountain", " ", " "},
                    {" ", " ", " ", " ", " ", " "},
                    {" ", " ", "amarok", " ", " ", " "},
                    {" ", " ", " ", " ", " ", "amarok"},
                };
                Board = BoardcopyM;
                mapSize = 5;
                break;
            case "large":
                string[,] BoardcopyL =
                {
                    {"entrance", " ", " ", " ", "amarok", " ", " ", " "},
                    {" ", " ", "maelstrom", " ", " ", " ", " ", " "},
                    {" ", " ", " ", " ", "pit", " ", "amarok", " "},
                    {" ", "pit", " ", "maelstrom", " ", " ", " ", " "},
                    {" ", " ", " ", " ", "fountain", " ", " ", " "},
                    {" ", " ", "amarok", " ", " ", " ", " ", " "},
                    {" ", " ", " ", " ", "pit", " ", " ", " "},
                    {" ", " ", " ", " ", " ", " ", " ", " "},
                };
                Board = BoardcopyL;
                mapSize = 7;
                break;
            default:
                Console.WriteLine("Not a valid size");
                chooseBoard();
                break;
        }
    }
    public void playTurn()
    {
        Console.WriteLine("----------------------------------------");
        checkAdjacents();
        reportPosition();
        reportSense();
        getMove();
    }
    private void reportPosition()
    {
        Console.WriteLine($"You are in the room at (Row={Row},  Column={Col}).");
        // Check position in board, if something portray a sense.
    }

    private void reportSense()
    {
        // Check maelstrom first, since repositioning can trigger the new room's effects
        if (Board[Row, Col] == "maelstrom")
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("A maelstrom moves you!");
            maelstromReposition(Row, Col);
            reportPosition();
            Console.ForegroundColor = ConsoleColor.White;
        }

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
        else if (Board[Row, Col] == "pit")
        {
            dead = true;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You fell into a pit!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if (Board[Row, Col] == "amarok")
        {
            dead = true;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An amarok turns you into a snack!");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }

    private void getMove()
    {
        if (gameOver || dead) { return; } // Close immediately if game is over
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
            case "help":
                GameController.getHelp();
                getMove();
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
            case "shoot north":
                break;
            default:
                Console.WriteLine("Not a valid command");
                getMove();
                break;
        }
    }
    // If player is outside board, reject movement and prompt again.
    private bool moveEast()
    {
        if (Col + 1 > mapSize)
        {
            Console.WriteLine("You can't move outside the board");
            return false;
        }
        Col = Col + 1;
        return true;
    }
    private bool moveWest()
    {
        if (Col - 1 < 0)
        {
            Console.WriteLine("You can't move outside the board");
            return false;
        }
        Col = Col - 1;
        return true;
    }
    private bool moveNorth()
    {
        if (Row - 1 < 0)
        {
            Console.WriteLine("You can't move outside the board");
            return false;
        }
        Row = Row - 1;
        return true;
    }
    private bool moveSouth()
    {
        if (Row + 1 > mapSize)
        {
            Console.WriteLine("You can't move outside the board");
            return false;
        }
        Row = Row + 1;
        return true;
    }

    private void maelstromReposition(int Row, int Col)
    {
        // Move player designated spaces
        moveNorth();
        moveEast();
        moveEast();

        // Remove maelstrom from current position 
        Board[Row, Col] = " ";

        // Calculate appropriate maelstrom index
        if (Row + 1 > mapSize) { Row = mapSize; }
        else { Row = Row + 1;}

        if ( Col - 2 < 0) { Col = 0; }
        else { Col = Col - 2; }

        // Update the maelstrom position
        Board[Row, Col] = "maelstrom";
    }

    private bool checkAdjacents()
    {
        int xlower = Col - 1; 
        int xupper = Col + 1;
        int ylower = Row - 1; // error if below 0
        int yupper = Row + 1; // error if above max

        // Fixes indexes if they go outside board
        if (ylower < 0) { ylower++; }
        if (yupper > mapSize) { yupper--; }
        if (xlower < 0) { xlower++; }
        if (xupper > mapSize) { xupper--; }

        for ( var  i = xlower; i <= xupper; i++)
        {
            for (var j = ylower; j <= yupper; j++)
            {
                if (Board[j, i] == "pit")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You feel a draft. There is a pit in a nearby room.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return true;
                }
                if (Board[j, i] == "maelstrom")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You hear the growling and groaning of a maelstrom nearby.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (Board[j, i] == "amarok")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You can smell the rotten stench of an amarok nearby.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        return false;
    }
}

public class GameController
{
    public static void Intro()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search\r\nof the Fountain of Objects.\r\nLight is visible only in the entrance, and no other light is seen anywhere in the caverns.\r\nYou must navigate the Caverns with your other senses.\r\nFind the Fountain of Objects, activate it, and return to the entrance");
        Console.WriteLine("Look out for pits. You will feel a breeze if a pit is in an adjacent room. If you enter a room with a pit, you will die.");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void Ending()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("You reactivated the fountain and remained intact. You win!");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void BadEnding()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Your story meets an abrupt end. R.I.P city dwellers.");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void getHelp() {
        Console.WriteLine("Commands");
        Console.WriteLine("move north" +
            "\nmove east" +
            "\nmove south" +
            "\nmove west" +
            "\nenable fountain");
    }
}