// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Chest box = Chest.locked;
while (true) {
    Console.WriteLine($"The chest is {box}. What would you like to do?");
    string input = Console.ReadLine();
    if (input == "open" && box == Chest.closed)
    {
        box = Chest.opened;
    }
    else if (input == "unlock" &&  box == Chest.locked) {
        box = Chest.closed;
    }
    else if (input == "close" && box == Chest.opened)
    {
        box = Chest.closed;
    }
    else if (input == "lock" && box == Chest.closed)
    {
        box = Chest.locked;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Clear();
        Console.WriteLine("Invalid: Can't transition between two states at once, or the state does not support that input");
        Console.ForegroundColor= ConsoleColor.White;
    }
}
enum Chest
{
    opened,
    closed,
    locked,
}

