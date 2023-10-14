// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Random rand = new Random();

// Print 10 random floating point numbers 
Console.WriteLine("Printing 10 random floating point numbers");

public static class RandomExtension
{
    public static double NextDouble(int max = 1)
    {
        Random random = new Random();
        return random.NextDouble() * max;
    }
    public static string RandString(params string[] strings)
    {
        Random rand = new Random();
        int randIndex = rand.Next(0, strings.Length);
        return strings[randIndex];
    }

    public static bool CoinFlip(double prob = 0.5)
    {
        Random rand = new Random();
        return rand.NextDouble() > prob;
    }
}