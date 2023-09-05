// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World!");

arrowheadType head = arrowheadType.Steel;
fletchingType fletch = fletchingType.Plastic;
int len = 60;

Arrow arrow = new Arrow(head, fletch, 60);
Console.WriteLine(arrow.GetCost());
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