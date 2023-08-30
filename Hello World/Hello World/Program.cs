// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;

//Console.WriteLine("Bread is ready.");
//Console.WriteLine("Who's bread?");
//string name = Console.ReadLine();
//Console.WriteLine(name + " got bread.");

Console.WriteLine("What kind of thing are we talking about?");
// An item
string a = Console.ReadLine();
Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
// The item adjective
string b = Console.ReadLine();
// These two should be concatenated
string c = "of Doom";
string d = "3000";
Console.WriteLine("The " + b + " " + a + " " + c + " " + d + "!");