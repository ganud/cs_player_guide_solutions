namespace Dueling_Traditions
{
    internal partial class Program
    {
        public class GameController
        {
            public static void Intro()
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search\r\nof the Fountain of Objects.\r\nLight is visible only in the entrance, and no other light is seen anywhere in the caverns.\r\nYou must navigate the Caverns with your other senses.\r\nFind the Fountain of Objects, activate it, and return to the entrance");
                Console.WriteLine("Look out for pits. You will feel a breeze if a pit is in an adjacent room. If you enter a room with a pit, you will die.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            public static void Ending()
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("You reactivated the fountain and remained intact. You win!");
                Console.ForegroundColor = ConsoleColor.White;
            }

            public static void BadEnding()
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Your story meets an abrupt end. R.I.P city dwellers.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            public static void getHelp()
            {
                Console.WriteLine("Commands");
                Console.WriteLine("move north" +
                    "\nmove east" +
                    "\nmove south" +
                    "\nmove west" +
                    "\nenable fountain");
            }
        }
    }
}