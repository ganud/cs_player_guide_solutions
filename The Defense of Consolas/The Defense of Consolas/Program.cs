Console.Title = "Defense of Consolas";
Console.WriteLine("Target Row? ");
int row = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Target Column? ");
int column = Convert.ToInt32(Console.ReadLine());
Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine($"Deploy to :\n({row + 1}, {column})\n({row - 1}, {column})\n({row}, {column - 1})\n({row}, {column + 1})");
Console.Beep();