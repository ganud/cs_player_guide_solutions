// See https://aka.ms/new-console-template for more information
int pointCounter = 0;
Console.WriteLine("How many estates?");
string estates = Console.ReadLine();
Console.WriteLine("How many duchys?");
string duchys = Console.ReadLine();
Console.WriteLine("How many provinces?");
string provinces = Console.ReadLine();

int totalScore = Convert.ToInt32(estates) + (3 * Convert.ToInt32(duchys)) + (6 * Convert.ToInt32(provinces));
Console.WriteLine($"Total score = {totalScore}");