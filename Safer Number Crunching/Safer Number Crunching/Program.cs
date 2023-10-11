int integer;
do
{
    Console.WriteLine("Enter an integer");
}
while (!int.TryParse(Console.ReadLine(), out integer));

Console.WriteLine(integer);

double duo;
do
{
    Console.WriteLine("Enter an integer: output double");
}
while (!double.TryParse(Console.ReadLine(), out duo));

Console.WriteLine(duo);

bool truth;
do
{
    Console.WriteLine("Enter true/false");
}
while (!bool.TryParse(Console.ReadLine(), out truth));

Console.WriteLine(truth);