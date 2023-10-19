Console.WriteLine("Choose a filter:");
Console.WriteLine("1 - Even");
Console.WriteLine("2 - Positive");
Console.WriteLine("3 - Multiples of 10");
string input = Console.ReadLine();

Sieve sieve = new Sieve(IsEven);

switch (input) {
    case "1":
        sieve = new Sieve(IsEven);
        break;
    case "2":
        sieve = new Sieve(IsPositive);
        break;
    case "3":
        sieve = new Sieve(IsMultipleOf10);
        break;
}
while (true)
{
    Console.WriteLine("Enter a number");
    int userNumber = Convert.ToInt32(Console.ReadLine());
    if (sieve.IsGood(userNumber))
    {
        Console.WriteLine("Valid number");
    }
    else { Console.WriteLine("bad!"); }
}
bool IsEven(int number)
{
    return (number % 2 == 0);
}

bool IsPositive(int number)
{
    return (number > 0);
}

bool IsMultipleOf10(int number)
{
    return (number % 10 == 0);
}
public class Sieve
{
    private Func<int, bool> filter;
    
    public Sieve(Func<int, bool> filter)
    {
        this.filter = filter;
    }
    public bool IsGood(int number)
    {
        return filter(number);
    }
}

// Answer this question: Describe how you could have also solved this problem with inheritance and 
// polymorphism. Which solution seems more straightforward to you, and why?

// Have a parent class with an abstract method, and have deriving classes implement the method with overrides.
// Inheritence and polymorphism seem more straightforward. You make the rules to what is implemented, and those rules remind you what to add.