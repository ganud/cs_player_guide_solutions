using System.ComponentModel.DataAnnotations;
using System.Dynamic;


arrowheadType head = arrowheadType.Steel;
fletchingType fletch = fletchingType.Plastic;
// Switch statements branching from choices, run old code if custom.
Console.WriteLine("Choose from Elite, Marksman, Beginner, or Custom arrow choices");
string input = Console.ReadLine();
switch (input)
{
    case "elite":
        Arrow eArrow = Arrow.CreateEliteArrow();
        Console.WriteLine($"This arrow will cost {eArrow.GetCost()} gold.");
        break;
    case "marksman":
        Arrow mArrow = Arrow.CreateMarksmanArrow();
        Console.WriteLine($"This arrow will cost {mArrow.GetCost()} gold.");
        break;
    case "beginner":
        Arrow bArrow = Arrow.CreateMarksmanArrow();
        Console.WriteLine($"This arrow will cost {bArrow.GetCost()} gold.");
        break;
    case "custom":
        int len = AskForNumberInRange("Enter a length between 60 and 100", 60, 100);
        getArrowHead();
        getFletch();
        Arrow arrow = new Arrow(head, fletch, len);
        Console.WriteLine($"This arrow will cost {arrow.GetCost()} gold.");
        break;
}


int AskForNumber(string text)
{
    Console.WriteLine(text);
    int converted = Convert.ToInt32(Console.ReadLine());
    return converted;
}

int AskForNumberInRange(string text, int min, int max)
{
    int input = -1;
    do
    {
        input = AskForNumber(text);
    }
    while (input < min || max < input);
    return input;
}

void getArrowHead()
{
    Console.WriteLine("Enter arrow heads: steel, wood, or obsidian");
    string input = Console.ReadLine();
    Console.Clear();
    switch (input)
    {
        case "steel":
            head = arrowheadType.Steel;
            break;
        case "wood":
            head = arrowheadType.Wood;
            break;
        case "obsidian":
            head = arrowheadType.Obsidian;
            break;
        default:
            Console.WriteLine("Invalid Input");
            getArrowHead();
            break;
    }
}
void getFletch()
{
    Console.WriteLine("Enter fletch: plastic, turkey, or goose");
    string input = Console.ReadLine();
    Console.Clear();
    switch (input)
    {
        case "plastic":
            fletch = fletchingType.Plastic;
            break;
        case "turkey":
            fletch = fletchingType.Turkey;
            break;
        case "goose":
            fletch = fletchingType.Goose;
            break;
        default:
            Console.WriteLine("Invalid Input");
            getFletch();
            break;
    }
}
class Arrow
{

    private int _len;
    private arrowheadType _head;
    private fletchingType _fletch;

    public static Arrow CreateEliteArrow()
    {
        return new Arrow(arrowheadType.Steel, fletchingType.Plastic, 95);
    }
    public static Arrow CreateBeginnerArrow()
    {
        return new Arrow(arrowheadType.Wood, fletchingType.Goose, 75);
    }
    public static Arrow CreateMarksmanArrow()
    {
        return new Arrow(arrowheadType.Steel, fletchingType.Goose, 65);
    }
    // Default arrow without user input
    public Arrow()
    {
        _len = 60;
        _head = arrowheadType.Wood;
        _fletch = fletchingType.Goose;
    }
    // User input for custom parameters
    public Arrow(arrowheadType head, fletchingType fletch, int len)
    {
        _len = len;
        _head = head;
        _fletch = fletch;
        if (_len < 60)
        {
            _len = 60;
        }
        else if (len > 100)
        {
            _len = 100;
        }
    }
    public int Length
    {
        get => _len;
    }
    public arrowheadType Arrowhead
    {
        get => _head;
    }
    public fletchingType Fletch
    {
        get => _fletch;
    }
    public float GetCost()
    {
        float totalcost = 0; ;
        float arrowHeadCost = 0;
        float fletchCost = 0;
        float lenCost = _len * (float)0.05;

        switch (_head)
        {
            case arrowheadType.Wood:
                arrowHeadCost = 3;
                break;
            case arrowheadType.Steel:
                arrowHeadCost = 10;
                break;
            case arrowheadType.Obsidian:
                arrowHeadCost = 5;
                break;
        }
        switch (_fletch)
        {
            case fletchingType.Plastic:
                fletchCost = 10;
                break;
            case fletchingType.Turkey:
                fletchCost = 5;
                break;
            case fletchingType.Goose:
                fletchCost = 3;
                break;
        }

        totalcost = lenCost + fletchCost + arrowHeadCost;
        return totalcost;

    }
}


public enum arrowheadType
{
    Steel,
    Wood,
    Obsidian,
}

public enum fletchingType
{
    Plastic,
    Turkey,
    Goose,
}

