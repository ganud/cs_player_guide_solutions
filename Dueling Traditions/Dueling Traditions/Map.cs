namespace Dueling_Traditions
{
    internal partial class Program
    {
        public class Map
        {
            protected string[,] Board = {
        {"entrance" ,"amarok" ,"fountain", " " }, // Row 0
        {" " ," " ,"pit" , " "},  // Row 1                                    
        {" " ," " ," " , " " }, // Row 2
        { " ", " ", " ", " " }, // Row 3
    };
            // Column 0 1 2 3 
            protected bool FountainisOn = false;
        }
    }
}