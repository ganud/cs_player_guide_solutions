// See https://aka.ms/new-console-template for more information
Console.WriteLine("Take in a number");
int num = Convert.ToInt32(Console.ReadLine());
if (num % 2 == 0)
{
    Console.WriteLine("Tick");
}
else if (num % 2 == 1)
{
    Console.WriteLine("Tock");
}


