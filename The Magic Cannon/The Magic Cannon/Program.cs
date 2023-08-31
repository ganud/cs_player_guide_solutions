// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
for (int i = 1; i <= 100; i++)
{
    if (i % 3 == 0 &&  i % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Combined");
    }
    else if (i % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Electric");
    }
    else if (i % 3 == 0)
    {

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Fire");
    }
    else {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Normal"); }
}