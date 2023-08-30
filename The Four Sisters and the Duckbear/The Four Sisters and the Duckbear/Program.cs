// See https://aka.ms/new-console-template for more information
Console.WriteLine("Eggs Gathered: ");
string numberOfEggs = Console.ReadLine();
// Four sisters
int numberForEach = Convert.ToInt32(numberOfEggs) / 4;
int remainder = Convert.ToInt32(numberOfEggs) % 4;
Console.WriteLine($"Each Sister gets {numberForEach} and the Duck-Bear gets {remainder}");

