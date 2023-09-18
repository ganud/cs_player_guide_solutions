

class InventoryItem
{
    public float Weight { get; private set; }
    public float Volume { get; private set; }
    public InventoryItem()
    {
        Weight = 0;
        Volume = 0;
    }
}

class Arrow : InventoryItem
{

}

class Bow : InventoryItem
{

}

class Rope: InventoryItem
{

}

class Water : InventoryItem
{


}

class Rations : InventoryItem
{


}

class Sword : InventoryItem
{


}

class Pack : InventoryItem
{

}