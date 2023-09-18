




class Inventory
{
    public float Weight { get; private set; }
    public float Volume { get; private set; }
    public Inventory()
    {
        Weight = 0;
        Volume = 0;
    }
}

class Arrow : Inventory
{

}

class Bow : Inventory
{

}

class Rope: Inventory
{

}

class Water : Inventory
{


}

class Rations : Inventory
{


}

class Sword : Inventory
{


}

class Pack
{

}