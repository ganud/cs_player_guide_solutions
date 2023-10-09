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