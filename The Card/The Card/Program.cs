// See https://aka.ms/new-console-template for more information
foreach (var color in Enum.GetNames(typeof(Color)))
{
    foreach (var rank in Enum.GetNames(typeof(Rank)))
    {
        Console.WriteLine($"The {color} {rank}");
    }
}

class Card
{
    public Rank Rank { get;}
    public Color Color { get;}

    public Card(Color color, Rank rank)
    {
        Rank = rank;
        Color = color;
    }

    public bool isSymbol()
    {
        if(Rank == Rank.Ampersand || Rank == Rank.Carrot || Rank == Rank.Dollar || Rank == Rank.Percentage)
        {
            return true;
        }
        else return false;
    }

    public bool isNumber()
    {
        if (isSymbol() != true) {
            return true;
        }
        else return false;
    }
}

enum Color
{
    Red,
    Green,
    Blue,
    Yellow
}

enum Rank
{
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Dollar,
    Percentage,
    Carrot,
    Ampersand,
}