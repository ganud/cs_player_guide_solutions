// See https://aka.ms/new-console-template for more information
void CountDown(int count)
{
    if (count == 0)
    {
        Console.WriteLine("0");
        return;
    }
    Console.WriteLine(count);
    count--;
    CountDown(count);
}

CountDown(10);