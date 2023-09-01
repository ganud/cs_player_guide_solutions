// See https://aka.ms/new-console-template for more information

int guessedNumber = -1;
int targetNumber = 0;
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



AskForNumberInRange("User 1, enter a number between 0 and 100: ", 0, 100);
Console.Clear();
do
{
    guessedNumber = AskForNumber("What is your guess?: ");
    if (guessedNumber > targetNumber)
    {
        Console.WriteLine("Too high");
    }
    else if (guessedNumber < targetNumber)
    {
        Console.WriteLine("Too low");
    }

}
while (targetNumber != guessedNumber);
Console.WriteLine("You did it");