﻿// See https://aka.ms/new-console-template for more information
using System.Drawing;
Color white = Color.White();
Console.WriteLine($"({white.R}, {white.G}, {white.B})");
Color random = new Color(123,13,12);
Console.WriteLine($"({random.R}, {random.G}, {random.B})");
class Color
{
    // Properties RGB
    public int R { get; set; }
    public int G { get; set; }
    public int B { get; set; }

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

    public static Color White()
    {
        return new Color(255, 255, 255);
    }
    public static Color Red()
    {
        return new Color(255, 0, 0);
    }
    public static Color Black()
    {
        return new Color(0, 0, 0);
    }
    public static Color Orange()
    {
        return new Color(255, 165, 0);
    }
    public static Color Yellow()
    {
        return new Color(255, 255, 0);
    }
    public static Color Green()
    {
        return new Color(0, 128, 0);
    }
    public static Color Blue()
    {
        return new Color(0, 0, 255);
    }
    public static Color Purple()
    {
        return new Color(128, 0, 128);
    }


}