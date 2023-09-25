
ColoredItem<Sword> coloredsword = new ColoredItem<Sword>(ConsoleColor.Green, new Sword());
ColoredItem<Bow> coloredbow = new ColoredItem<Bow>(ConsoleColor.Blue, new Bow());
ColoredItem<Axe> coloredaxe = new ColoredItem<Axe>(ConsoleColor.Red, new Axe());

coloredsword.Display();
coloredbow.Display();
coloredaxe.Display();

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