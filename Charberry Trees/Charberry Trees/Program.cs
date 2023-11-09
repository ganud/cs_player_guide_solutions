CharberryTree tree = new CharberryTree();
Notifier notifier = new Notifier(tree);
Harvester harvester = new Harvester(tree);

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
    private void OnTreeRipened() { Console.WriteLine("The fruit is ripe!"); }
    
    public Notifier(CharberryTree tree)
    {
        tree.Ripened += OnTreeRipened;
    }
}

public class Harvester

{
    private CharberryTree _tree;
    private void OnTreeRipened()
    {
        Console.WriteLine("Fruit harvested.");
        _tree.Ripe = false;
    }
    public Harvester(CharberryTree tree)
    {
        _tree = tree;
        _tree.Ripened += OnTreeRipened;
    }
}