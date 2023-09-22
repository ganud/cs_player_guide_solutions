// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

Robot bot = new Robot();
for (int i = 0; i < bot.Commands.Length; i++)
{
    Console.WriteLine("Enter a command");
    RobotCommand command = Console.ReadLine() switch
    {
        "on" => new Oncommand(),
        "off" => new OffCommand(),
        "N" => new NorthCommand(),
        "W" => new WestCommand(),
        "E" => new EastCommand(),
        "S" => new SouthCommand(),
    };
    bot.Commands[i] = command;
}

bot.Run();
public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public abstract class RobotCommand
{
    public virtual void Run(Robot robot)
    {

    }
}

public class Oncommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}
public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y++;
        }
    }
}

public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y--;
        }
    }
}

public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X--;
        }
    }
}

public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X++;
        }
    }
}