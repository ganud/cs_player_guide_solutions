namespace Dueling_Traditions
{
    internal partial class Program
    {
        public class Player : Map
        {
            private int Row { get; set; } = 0;
            private int Col { get; set; } = 0;

            private int Arrows = 5;
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
                Console.WriteLine($"You have {Arrows} arrows.");
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

                if (Board[Row, Col] == " ")
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
                        shootNorth();
                        break;
                    case "shoot south":
                        shootSouth();
                        break;
                    case "shoot east":
                        shootEast();
                        break;
                    case "shoot west":
                        shootWest();
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
                else { Row = Row + 1; }

                if (Col - 2 < 0) { Col = 0; }
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

                for (var i = xlower; i <= xupper; i++)
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

            private void shootNorth()
            {
                int Rowcopy = Row;
                if (Arrows == 0) { Console.WriteLine("You have no arrows."); return; }
                if (Rowcopy - 1 < 0)
                {
                    Console.WriteLine("You shot at the wall. Why?");
                    Arrows--;
                }
                else
                {
                    Rowcopy = Rowcopy - 1;
                    if (Board[Rowcopy, Col] == "maelstrom" || Board[Rowcopy, Col] == "amarok")
                    {
                        Board[Rowcopy, Col] = " ";
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("You hit something. Whatever you hit no longer bothers you.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else { Console.WriteLine("You hit nothing."); }
                    Arrows--;
                }
            }
            private void shootSouth()
            {
                int Rowcopy = Row;
                if (Arrows == 0) { Console.WriteLine("You have no arrows."); return; }
                if (Rowcopy + 1 > mapSize)
                {
                    Console.WriteLine("You shot at the wall. Why?");
                    Arrows--;
                }
                else
                {
                    Rowcopy = Rowcopy + 1;
                    if (Board[Rowcopy, Col] == "maelstrom" || Board[Rowcopy, Col] == "amarok")
                    {
                        Board[Rowcopy, Col] = " ";
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("You hit something. Whatever you hit no longer bothers you.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else { Console.WriteLine("You hit nothing."); }
                    Arrows--;
                }
            }
            private void shootEast()
            {
                int Colcopy = Col;
                if (Arrows == 0) { Console.WriteLine("You have no arrows."); return; }
                if (Colcopy + 1 > mapSize)
                {
                    Console.WriteLine("You shot at the wall. Why?");
                    Arrows--;
                }
                else
                {
                    Colcopy = Colcopy + 1;
                    if (Board[Row, Colcopy] == "maelstrom" || Board[Row, Colcopy] == "amarok")
                    {
                        Board[Row, Colcopy] = " ";
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("You hit something. Whatever you hit no longer bothers you.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else { Console.WriteLine("You hit nothing."); }
                    Arrows--;
                }
            }
            private void shootWest()
            {
                int Colcopy = Col;
                if (Arrows == 0) { Console.WriteLine("You have no arrows."); return; }
                if (Colcopy - 1 < 0)
                {
                    Console.WriteLine("You shot at the wall. Why?");
                    Arrows--;
                }
                else
                {
                    Colcopy = Colcopy - 1;
                    if (Board[Row, Colcopy] == "maelstrom" || Board[Row, Colcopy] == "amarok")
                    {
                        Board[Row, Colcopy] = " ";
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("You hit something. Whatever you hit no longer bothers you.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else { Console.WriteLine("You hit nothing."); }
                    Arrows--;
                }
            }
        }
    }
}