Random random = new Random();
int cookieNumber = random.Next(10);
List<int> choices = new List<int>();

while (true)
{
    int choice = AskForNumberInRange("Enter a number 0-9. Beware the awful oatmeal raisen cookie!", 0, 9);
    Console.Clear();
    if (choices.Contains(choice))
    {
        Console.WriteLine("Choose another number");
    }
    else
    {
        choices.Add(choice);
    }

    try
    {
        if (choice == cookieNumber) { throw new BadCookieException(); }
    }
    catch { Console.WriteLine("NOT THIS ONE"); }
}

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

public class BadCookieException : Exception
{
    public BadCookieException() { }
    public BadCookieException(string message) : base(message) { }
}

// I made a custom exception. The default exception variants aren't concise for this scenario, so it makes sense to create a new one.
// No. This can be handled by simple conditional logic, which is easier to read.