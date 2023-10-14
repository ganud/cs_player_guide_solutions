
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

// Extension methods seem better. They appear to support overload(?), so there isn't naming collisions with extended fuctions that share the same name. 
// If it's adding functionality to a single class, than I rather keep using that class rather than create a new one.