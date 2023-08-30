// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;

Console.WriteLine("Enter Base");
string base_ = Console.ReadLine();
Console.WriteLine("Enter Height");
string height = Console.ReadLine();
float area = (Convert.ToSingle(height) * Convert.ToSingle(base_)) / 2;
Console.WriteLine(area);