// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

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

// Used in The Prototype
AskForNumberInRange("hi", 1, 100);