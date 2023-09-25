
ColoredItem<Sword> coloredsword = new ColoredItem<Sword>(ConsoleColor.Green, new Sword());
coloredsword.Display();
public class Sword { }
public class Bow { }
public class Axe { }

public class ColoredItem<T>
{
    public ConsoleColor Color {  get;}
    public T Item { get;}
    public ColoredItem(ConsoleColor color, T item)
    {
        Color = color;
        Item = item;
    }
    public void Display()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(Item);
    }
}