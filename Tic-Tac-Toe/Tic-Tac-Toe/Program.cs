// See https://aka.ms/new-console-template for more information
// The tic tac toe board is a 2D array. 0 is uncontested, 1 is player 1, 2 is player 2.

using System.Data;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;
// While true
// Prompt player 1's turn to the board with number commands, and replace with their symbol.
// Prompt player 2 next
// After each prompt check for a winner.

Player player1 = new Player("Player 1", "O");
Player player2 = new Player("Player 2", "X");

TTTBoard board = new TTTBoard();
board.printBoard();

while (true)
{
    board.userToBoard(player1.Name, player1.Symbol);
    Console.Clear();
    board.printBoard();
    if (board.checkBoard(player1) == true) { break; }
    board.userToBoard(player2.Name, player2.Symbol);
    Console.Clear();
    board.printBoard();
    if (board.checkBoard(player2) == true) { break; }
}


class TTTBoard
{
    private string[,] Board = { 
        {" " ," " ," " },
        {" " ," " ," " },
        {" " ," " ," " },
    };
    public TTTBoard()
    {

    }

    public void printBoard()
    {
        // Code taken from a 2012 stack overflow answer with some edits https://stackoverflow.com/questions/12826760/printing-2d-array-in-matrix-format
        Console.WriteLine("-------------");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(string.Format("| {0} ", Board[i, j]));
            }
            Console.Write("|\n-------------\n");
        }
    }

    public void userToBoard(string name, string symbol)
    {
        Console.WriteLine($"{name}, enter your tile (Use numpad as reference!)");
        string input = Console.ReadLine();

        // I'm not on board with code duplication, but I couldn't find a way for a function to work. 
        // Fix code duplication later
        switch (input)
        {
            case "1":
                if (!Board[0, 0].Contains(" "))
                {
                    Console.WriteLine("That tile is taken.");
                    userToBoard(name, symbol);
                }
                else { Board[0, 0] = symbol; }
                break;
            case "2":
                if (!Board[0, 1].Contains(" "))
                {
                    Console.WriteLine("That tile is taken.");
                    userToBoard(name, symbol);
                }
                else { Board[0, 1] = symbol; }
                break;
            case "3":
                if (!Board[0, 2].Contains(" "))
                {
                    Console.WriteLine("That tile is taken.");
                    userToBoard(name, symbol);
                }
                else { Board[0, 2] = symbol; }
                break;
            case "4":
                if (!Board[1, 0].Contains(" "))
                {
                    Console.WriteLine("That tile is taken.");
                    userToBoard(name, symbol);
                }
                else { Board[1, 0] = symbol; }
                break;
            case "5":
                if (!Board[1, 1].Contains(" "))
                {
                    Console.WriteLine("That tile is taken.");
                    userToBoard(name, symbol);
                }
                else { Board[1, 1] = symbol; }
                break;
            case "6":
                if (!Board[1, 2].Contains(" "))
                {
                    Console.WriteLine("That tile is taken.");
                    userToBoard(name, symbol);
                }
                else { Board[1, 2] = symbol; }
                break;
            case "7":
                if (!Board[2, 0].Contains(" "))
                {
                    Console.WriteLine("That tile is taken.");
                    userToBoard(name, symbol);
                }
                else { Board[2, 0] = symbol; }
                break;
            case "8":
                if (!Board[2, 1].Contains(" "))
                {
                    Console.WriteLine("That tile is taken.");
                    userToBoard(name, symbol);
                }
                else { Board[2, 1] = symbol; }
                break;
            case "9":
                if (!Board[2, 2].Contains(" "))
                {
                    Console.WriteLine("That tile is taken.");
                    userToBoard(name, symbol);
                }
                else { Board[2, 2] = symbol; }
                break;
            default:
                Console.WriteLine("Invalid position.");
                userToBoard(name, symbol);
                break;
           
        }
    }

    public Boolean checkBoard(Player player)
    {
        // Check rows
        if (Board[0, 0] == player.Symbol && Board[0,1] == player.Symbol && Board[0, 2] == player.Symbol)
        {
            Console.WriteLine($"{player.Name} has won.");
            return true;
        }
        else if (Board[1, 0] == player.Symbol && Board[1, 1] == player.Symbol && Board[1, 2] == player.Symbol)
        {
            Console.WriteLine($"{player.Name} has won.");
            return true;
        }
        else if (Board[2, 0] == player.Symbol && Board[2, 1] == player.Symbol && Board[2, 2] == player.Symbol)
        {
            Console.WriteLine($"{player.Name} has won.");
            return true;
        }

        // Check columns
        else if (Board[0, 0] == player.Symbol && Board[1, 0] == player.Symbol && Board[2, 0] == player.Symbol)
        {
            Console.WriteLine($"{player.Name} has won.");
            return true;
        }
        else if (Board[0, 1] == player.Symbol && Board[1, 1] == player.Symbol && Board[2, 1] == player.Symbol)
        {
            Console.WriteLine($"{player.Name} has won.");
            return true;
        }
        else if (Board[0, 2] == player.Symbol && Board[1, 2] == player.Symbol && Board[2, 2] == player.Symbol)
        {
            Console.WriteLine($"{player.Name} has won.");
            return true;
        }

        // Check diagonals
        else if (Board[0, 0] == player.Symbol && Board[1, 1] == player.Symbol && Board[2, 2] == player.Symbol)
        {
            Console.WriteLine($"{player.Name} has won.");
            return true;
        }
        else if (Board[0, 2] == player.Symbol && Board[1, 1] == player.Symbol && Board[2, 0] == player.Symbol)
        {
            Console.WriteLine($"{player.Name} has won.");
            return true;
        }
        else
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!Board[i, j].Contains(" "))
                    {
                        count++;
                    }
                }
            }

           if (count == 9)
            {
                Console.WriteLine("This game is a tie");
                return true
                    ;
            }
        }
        return false;
    }
}

class Player
{
    public string Name { get; private set; }
    public string Symbol { get; private set; }
    public Player(string name, string symbol)
    {
        Name = name;
        Symbol = symbol;
    }
}

