// See https://aka.ms/new-console-template for more information
// The tic tac toe board is a 2D array. 0 is uncontested, 1 is player 1, 2 is player 2.

using System.Data;
using System.Diagnostics.Contracts;
// While true
// Prompt player 1's turn to the board with number commands, and replace with their symbol.
// Prompt player 2 next
// After each prompt check for a winner.
Player player1 = new Player("Player 1", "O");
Player player2 = new Player("Player 2", "X");

TTTBoard board = new TTTBoard();
board.printBoard();
class TTTBoard
{
    private string[,] Board = { 
        {"0" ,"0" ,"0" },
        {"0" ,"0" ,"0" },
        {"0" ,"0" ,"0" },
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

