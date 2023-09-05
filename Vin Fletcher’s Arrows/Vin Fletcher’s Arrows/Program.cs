using System.ComponentModel.DataAnnotations;
using System.Dynamic;

arrowheadType head = arrowheadType.Steel;
fletchingType fletch = fletchingType.Plastic;

getArrowHead();
getFletch();
int len = AskForNumberInRange("Enter a length between 60 and 100", 60, 100);

Arrow arrow = new Arrow(head, fletch, len);
Console.WriteLine(arrow.GetCost());

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

    public int _len;
    public arrowheadType _head;
    public fletchingType _fletch;

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

