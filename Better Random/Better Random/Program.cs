using System.Collections.Generic;

Random rand = new Random();
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(rand.CoinFlip(0.2));
}
public static class RandomExtension
{
    public static double NextDouble(this Random random, int max = 1)
    {
        return random.NextDouble() * max;
    }
    public static string RandString(this Random random, params string[] strings)
    {
        int randIndex = random.Next(0, strings.Length);
        return strings[randIndex];
    }

    public static bool CoinFlip(this Random random, double probHeads = 0.5)
    {
        return random.NextDouble() < probHeads;
    }
}