CharberryTree tree = new CharberryTree();
Notifier notifier = new Notifier(tree);
while (true)
{
    tree.MaybeGrow();
}

public class CharberryTree
{
    private Random _random = new Random();

    public event Action? Ripened;
    public bool Ripe { get; set; }
    public void MaybeGrow()
    {
        // Only a tiny chance of ripening each time, but we try a lot!
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened();
        }
    }
}

public class Notifier
{
    private void OnTreeRipened() => NotifyRipened();
    
    public void NotifyRipened()
    {
        Console.WriteLine("The fruit is ripe!");
    }
    public Notifier(CharberryTree tree)
    {
        tree.Ripened += OnTreeRipened;
    }
}

public class Harvester

{
    private void OnTreeRipened() => HarvestFruit();
    public void HarvestFruit(CharberryTree tree)
    {
        Console.WriteLine("Fruit harvested.");
        tree.Ripe = false;
    }
    public Harvester(CharberryTree tree)
    {
        tree.Ripened
    }
}