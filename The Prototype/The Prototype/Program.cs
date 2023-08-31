// See https://aka.ms/new-console-template for more information

int guessedNumber = -1;
int targetNumber = 0;
do
{
    Console.Write("User 1, enter a number between 0 and 100: ");
    targetNumber = Convert.ToInt32(Console.ReadLine());
}
while (targetNumber < 0 || targetNumber > 100);
Console.Clear();
do
{
    Console.Write("What is your guess?: ");
    guessedNumber = Convert.ToInt32(Console.ReadLine());
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