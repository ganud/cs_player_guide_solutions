// See https://aka.ms/new-console-template for more information
// The tic tac toe board is a 2D array. 0 is uncontested, 1 is player 1, 2 is player 2.

using System.Data;

TTTBoard board = new TTTBoard();
board.printBoard();
class TTTBoard
{
    private int[,] Board = { 
        {0,0,0},
        {0,0,0},
        {0,0,0},
    };
    public TTTBoard()
    {

    }

    public void printBoard()
    {
        // Code taken from a 2012 stack overflow answer with some edits https://stackoverflow.com/questions/12826760/printing-2d-array-in-matrix-format
        Console.WriteLine("-------");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(string.Format("|{0}", Board[i, j]));
            }
            Console.Write("|\n-------\n");
        }
    }
}
