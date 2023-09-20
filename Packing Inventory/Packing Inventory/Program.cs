
using System.IO.Pipes;

Pack backpack = new Pack(10, 50, 50);
while (true)
{
    backpack.packStatus();
    Console.WriteLine("Choose an item to add:" +
        "\n1 - Arrow" +
        "\n2 - Bow" +
        "\n3 - Rope" +
        "\n4 - Water" +
        "\n5 - Rations" +
        "\n6 - Sword");
    string input = Console.ReadLine();
    Console.Clear();
    // Probably not the best way to protect against non-exhaustive switch cases
    if (input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6")
    {
        InventoryItem item = input switch
        {
            "1" => new Arrow(),
            "2" => new Bow(),
            "3" => new Rope(),
            "4" => new Water(),
            "5" => new Rations(),
            "6" => new Sword(),
        };
        backpack.Add(item);
    }
    else
    {
        Console.WriteLine("Not a valid command");
    }
}
class InventoryItem
{
    public float Weight { get; protected set; }
    public float Volume { get; protected set; }
    public InventoryItem()
    {
        Weight = 0;
        Volume = 0;
    }

    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
}

class Arrow : InventoryItem
{
    public Arrow() {
        Weight = (float)0.1;
        Volume = (float)0.05;
    }
}

class Bow : InventoryItem
{
    public Bow()
    {
        Weight = 1;
        Volume = 4;
    }
}

class Rope: InventoryItem
{
    public Rope()
    {
        Weight = 1;
        Volume = (float)1.5;
    }
}

class Water : InventoryItem
{

    public Water()
    {
        Weight = 2;
        Volume = 3;
    }
}

class Rations : InventoryItem
{
    public Rations()
    {
        Weight = 1;
        Volume = (float)0.5;
    }

}

class Sword : InventoryItem
{
    public Sword()
    {
        Weight = 5;
        Volume = 3;
    }

}

class Pack : InventoryItem
{
    public InventoryItem[] items { get;}
    public float maxWeight { get;}
    public float maxVolume { get;}
    public int currentItems { get; private set;}
    public float currentWeight { get; private set; }
    public float currentVolume { get; private set; }

    public Pack(int totalItems, float maxWeight_, float maxVolume_)
    {
        items = new InventoryItem[totalItems];
        maxWeight = maxWeight_;
        maxVolume = maxVolume_;

    }

    public bool Add(InventoryItem item)
    {
        // Check whether an item can be added so far.
        if (currentItems >= items.Length) { Console.WriteLine("You are at max item capacity"); return false; }
        else if (maxWeight < currentWeight + item.Weight) { Console.WriteLine("You are at max weight capacity"); return false; }
        else if (maxVolume < currentVolume + item.Volume) { Console.WriteLine("You are at max volume capacity"); return false; }
        // Add the item
        items[currentItems] = item;
        currentItems++;

        // Update currents
        currentWeight += item.Weight;
        currentVolume += item.Volume;

        return true;
    }

    public void packStatus()
    {
        Console.WriteLine($"Your backpack:");
        Console.WriteLine($"Items: {currentItems}/{items.Length}");
        Console.WriteLine($"Weight: {currentWeight}/{maxWeight}");
        Console.WriteLine($"Volume: {currentVolume}/{maxVolume}");
    }

}