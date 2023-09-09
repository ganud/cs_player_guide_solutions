
// Print all possible card variations with a nested loop.
foreach (var color in Enum.GetNames(typeof(Color)))
{
    foreach (var rank in Enum.GetNames(typeof(Rank)))
    {
        // Checking back on the solution it states to create a new card instance. However, the cards in the solution aren't saved in the for loop,
        // they don't persist outside and exist solely for printing. I skipped the step of using the Class I created, but the effective output
        // between the two programs are the same.
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


// Enums
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

// We used a color enumeration because we didn't need the complex inner workings of the RGB values of each color for this deck.
// I'm just going to assume no one will draw a "The rgb(231, 13, 0) Dollar" and say it out loud. Just human readable names will do fine!