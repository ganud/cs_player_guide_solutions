// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

Robot bot = new Robot();
bool commandsOpen = true;
while (commandsOpen)
{
    Console.WriteLine("Enter a command:");
    Console.WriteLine("- on\n- off\n- N\n- W\n- E\n- S\n- stop");

    IRobotCommand command = null;
    string userCommand = Console.ReadLine();
    switch (userCommand)
    {
        case "on":
            command = new OnCommand();
            break;
        case "off":
            command = new OffCommand();
            break;
        case "E":
            command = new EastCommand();
            break;
        case "W":
            command = new WestCommand();
            break;
        case "N":
            command = new NorthCommand();
            break;
        case "S":
            command = new SouthCommand();
            break;
        case "stop":
            commandsOpen = false;
            break;
    }
    if (command != null)
    {
        bot.Commands.Add(command);
    }
}

bot.Run();
public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public List<IRobotCommand> Commands { get; } = new List<IRobotCommand>();
    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public interface IRobotCommand
{
    public void Run(Robot robot);
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}
public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y++;
        }
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y--;
        }
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X--;
        }
    }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X++;
        }
    }
}

// Answer this question: Do you feel this is an improvement over using an abstract base class? Why 
// or why not?

// I think is is an improvement in terms of readability. Interfaces are more explicitly named in what the inheriting class MUST have(e.g the run command). In abstract, you only get the keyword.