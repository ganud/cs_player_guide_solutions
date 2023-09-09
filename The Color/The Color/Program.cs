// See https://aka.ms/new-console-template for more information
using System.Drawing;
Color white = Color.White;
Console.WriteLine($"({white.R}, {white.G}, {white.B})");
Color random = new Color(123,13,12);
Console.WriteLine($"({random.R}, {random.G}, {random.B})");
class Color
{
    // Properties RGB
    public int R { get;}
    public int G { get;}
    public int B { get;}

    // Constructors
    public Color()
    {
        R = 0;
        G = 0;
        B = 0;
    }

    public Color(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }

    // Common colors factory

    public static Color White { get; } = new Color(255, 255, 255);
    public static Color Black { get; } = new Color(0, 0, 0);
    public static Color Red { get; } = new Color(255, 0, 0);
    public static Color Orange { get; } = new Color(255, 165, 0);
    public static Color Yellow { get; } = new Color(255, 255, 0);
    public static Color Green { get; } = new Color(0, 128, 0);
    public static Color Blue { get; } = new Color(0, 0, 255);
    public static Color Purple { get; } = new Color(128, 0, 128);


}