// See https://aka.ms/new-console-template for more information
Console.WriteLine("Enter a numeric door passcode");
int passcode = Convert.ToInt32(Console.ReadLine());
Door door = new Door(passcode);
while (true)
{
    //Console.Clear();
    Console.WriteLine($"The door is {door.State}. What would you like to do?" +
        $"\n1 - Change passcode" +
        $"\n2 - Open door" +
        $"\n3 - Close door" +
        $"\n4 - Lock door" +
        $"\n5 - Unlock Door");
    int user_choice = Convert.ToInt32(Console.ReadLine());
    switch(user_choice)
    {
        case 1:
            Console.WriteLine("Enter current passcode");
            int currentpasscode = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter new passcode");
            int newpasscode = Convert.ToInt32(Console.ReadLine());
            door.ChangeCode(currentpasscode, newpasscode);
            Console.WriteLine(door.Passcode);
            break;
        case 2:
            door.openDoor();
            break;
        case 3:
            door.closeDoor();
            break;
        case 4:
            door.lockDoor();
            break;
        case 5:
            door.unlockDoor();
            break;
        default:
            Console.WriteLine("Invalid Command");
            break;
    }

}

class Door
{
    public int Passcode;
    public States State { get; private set; }
    public Door(int startingPasscode)
    {
        Passcode = startingPasscode;
    }

    public void ChangeCode(int oldPasscode, int newPasscode)
    {
        if (oldPasscode == Passcode)
        {
            Passcode = newPasscode;
        }
        else
        {
            Console.WriteLine("entered password does not match current");
        }
    }
    public void unlockDoor() { if (State == States.Locked) { State = States.Closed; } }
    public void openDoor() { if (State == States.Closed) { State = States.Opened; } }
    public void closeDoor() { if (State == States.Opened) { State = States.Closed; } }
    public void lockDoor() { if (State == States.Closed) { State = States.Locked; } }



}

enum States
{
    Locked, Opened, Closed
}