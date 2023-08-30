// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// | | |
// | X |
// | | |
Console.Title = "Watchtower";
Console.WriteLine("Enemy position x: ");
int xPos = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enemy position y: ");
int yPos = Convert.ToInt32(Console.ReadLine());


if (yPos > 0  && xPos < 0)
{
    Console.WriteLine("NW");
}
else if (yPos > 0 && xPos == 0)
{
    Console.WriteLine("N");
}
else if (yPos > 0 && xPos > 0)
{
    Console.WriteLine("NE");
}
else if (yPos == 0 && xPos < 0)
{
    Console.WriteLine("W");
}
else if (yPos == 0 && xPos == 0)
{
    Console.WriteLine("Oh noes you've been breached");
}
else if (yPos == 0 && xPos > 0)
{
    Console.WriteLine("E");
}
else if (yPos > 0 && xPos == 0)
{
    Console.WriteLine("N");
}
else if (yPos < 0 && xPos < 0)
{
    Console.WriteLine("SW");
}
else if (yPos < 0 && xPos == 0)
{
    Console.WriteLine("S");
}
else if (yPos < 0 && xPos > 0)
{
    Console.WriteLine("SE");
}