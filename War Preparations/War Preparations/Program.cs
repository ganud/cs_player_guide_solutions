// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Sword sword1 = new Sword(Material.iron, Gemstone.none, 1, 1);
Sword sword2 = sword1 with { material = Material.wood };
Sword sword3 = sword1 with { material = Material.binarium, length = 12 };
Console.WriteLine(sword1);
Console.WriteLine(sword2);
Console.WriteLine(sword3);

public record Sword( Material material, Gemstone gemstone, float length, float width);
public enum Material { wood, bronze, iron, steel, binarium};
public enum Gemstone { emerald, amber, sapphire, diamond, bitstone, none};