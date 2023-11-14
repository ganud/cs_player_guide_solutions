Console.WriteLine("Enter your name");
string playerName = Console.ReadLine();
int playerscore = 0;

// Read previous score if name already exists
if (File.Exists($"{playerName}.txt"))
{
    string previous = File.ReadAllText($"{playerName}.txt");
    playerscore = int.Parse(previous);
}


while (true)
{
    if (Console.ReadKey().Key == ConsoleKey.Enter)
    {
        File.WriteAllText($"{playerName}.txt", Convert.ToString(playerscore));
        break;
    }
    else
    {
        Console.WriteLine();
        playerscore++;
        Console.WriteLine($"Score: {playerscore}");
    }
}
