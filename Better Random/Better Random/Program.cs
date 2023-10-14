Random rand = new Random();
Console.WriteLine(rand.NextDouble(12));
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
        return random.NextDouble() > probHeads;
    }
}