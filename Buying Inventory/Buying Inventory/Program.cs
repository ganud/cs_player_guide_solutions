// See https://aka.ms/new-console-template for more information

// Probably a better idea to wrap this into multiple lines instead
Console.Title = "Tortuga Shop";
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine($"The following items are available\n1 - Rope\n2 - Torches\n3 - Climbing Equipment\n4 - Clean Water\n5 - Machete\n6 - Canoe\n7 - Food Supplies");
int choice = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("What is your Name?");
string name = Console.ReadLine();
float price;


switch (choice)
{
    case 1:
        price = name == "ganud" ? price = 10 / 2 : price = 10;
        Console.WriteLine(price + "G");
        break;
    case 2:
        price = name == "ganud" ? price = 15 / 2 : price = 15;
        Console.WriteLine(price + "G");
        break;
    case 3:
        price = name == "ganud" ? price = 25 / 2 : price = 25;
        Console.WriteLine(price + "G");
        break;
    case 4:
        price = name == "ganud" ? price = 1 / 2 : price = 1;
        Console.WriteLine(price + "G");
        break;
    case 5:
        price = name == "ganud" ? price = 20 / 2 : price = 20;
        Console.WriteLine(price + "G");
        break;
    case 6:
        price = name == "ganud" ? price = 200 / 2 : price = 200;
        Console.WriteLine(price + "G");
        break;
    case 7:
        price = name == "ganud" ? price = 1 / 2 : price = 1;
        Console.WriteLine(price + "G");
        break;
    default:
        Console.WriteLine("what");
        break;
}