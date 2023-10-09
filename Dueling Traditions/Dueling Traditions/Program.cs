namespace Dueling_Traditions
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            DateTime timeStart = DateTime.Now;
            Player player = new Player();
            GameController.Intro();
            player.chooseBoard();
            while (true)
            {
                if (player.gameOver == true || player.dead == true)
                {
                    break;
                }
                player.playTurn();
            }
            if (player.gameOver == true)
            {
                GameController.Ending();
            }
            else if (player.dead == true)
            {
                GameController.BadEnding();
            }
            DateTime timeEnd = DateTime.Now;
            TimeSpan timeElapsed = timeEnd - timeStart;
            Console.WriteLine(($"Time elapsed: {timeElapsed.Days}d {timeElapsed.Hours}h {timeElapsed.Minutes}m {timeElapsed.Seconds}s"));
        }
    }
}

// I prefer top-level statements. We're going to almost always type the basic boilerplate, so why not abstract it away?
// I see the merit in multiple files however. The main method is small, and the types are thw real meat that should be analyzed as its own package.
// I wished I read about the SOLID principles earlier so I didn't throw in every responsibility imaginable to the Player class.