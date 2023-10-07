// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;
using System.Security.Cryptography;

int manticoreHealth = 10;
int cityHealth  = 15;
int round = 1;

int AskForNumber(string text)
{
    Console.WriteLine(text);
    int converted = Convert.ToInt32(Console.ReadLine());
    return converted;
}

int AskForNumberInRange(string text, int min, int max)
{
    int input = -1;
    do
    {
        input = AskForNumber(text);
    }
    while (input < min || max < input);
    return input;
}

void displayProgress()
{
    Console.WriteLine($"Round {round}");
    Console.WriteLine($"City Health: {cityHealth}");
    Console.WriteLine($"Manticore Health {manticoreHealth}");
}

int computeDamage(int round)
{
    if ((round % 5 == 0) && (round % 3 == 0))
    {
        return 10;
    }
    else if ((round % 5 == 0) || (round % 3 == 0))
    {
        return 3;
    }
    else { return 1; }
}
void aimManticore(int manticorePosition, int cannonDamage)
{
    int targetPosition = AskForNumberInRange("Player 2, choose a number from 0 to 100", 0, 100);
    Console.Clear();
    if (targetPosition == manticorePosition)
    {
        manticoreHealth -= cannonDamage;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"You hit the manticore for {cannonDamage} damage.");
    }
    else if (manticorePosition < targetPosition)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You overshot!");
    }
    else if (manticorePosition > targetPosition)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You undershot!");
    }
    Console.ForegroundColor = ConsoleColor.White;
}

int manticoreDistance = 0;

do
{
    Console.WriteLine("singleplayer or multiplayer?");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "singleplayer":
            Random random = new Random();
            manticoreDistance = random.Next(0, 100);
            break;
        case "multiplayer":
            manticoreDistance = AskForNumberInRange("Player 1, choose a number from 0 to 100", 0, 100);
            break;
        default:
            Console.WriteLine("Invalid command");
            break;

    }
}
while (manticoreDistance == 0);

Console.Clear();

do
{
    displayProgress();
    int cannonDamage = computeDamage(round);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"The cannon will do {cannonDamage} damage this round.");
    Console.ForegroundColor = ConsoleColor.White;
    aimManticore(manticoreDistance, cannonDamage);
    cityHealth--;
    round++;
}
while (manticoreHealth > 0 && cityHealth != 0);


if (manticoreHealth < 0)
{
    Console.WriteLine("Player 2 wins! The defense is successful");
}
else
{
    Console.WriteLine("Player 1 wins! The city is destroyed.");
}