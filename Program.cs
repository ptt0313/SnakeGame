namespace SnakeGame
{
    public class Map
    {
        int[,] map = new int[12, 12]
        {
            { 1,1,1,1,1,1,1,1,1,1,1,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,1,1,1,1,1,1,1,1,1,1,1 }
        };
        public void CreatMap()
        { 
            for (int i = 0; i < map.GetLength(0); i++) 
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    if(map[i, j] == 1)
                    {
                        Console.Write("■");
                    }
                    else if (map[i, j] == 0)
                    {
                        Console.Write("  ");
                    }
                    
                    else if (map[i,j] == 2)
                    {
                        Console.Write("○");
                    }
                    else if (map[i,j] == 3)
                    {
                        Console.Write("★");
                    }
                }
                Console.WriteLine();
            }
        }
        
        
    }
    public class Character
    {
        int x = 6;
        int y = 4;

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value; 
            }
        }
        
    }
    public class Move
    {
        Character character1 = new Character();
        ConsoleKeyInfo key;
        public void MoveToArrow()
        {
            key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    character1.Y --;
                    break;
                case ConsoleKey.LeftArrow:
                    character1.X -= 2;
                    break;
                case ConsoleKey.RightArrow:
                    character1.X += 2;
                    break;
                case ConsoleKey.DownArrow:
                    character1.Y++;
                    break;
            }
        }
    }
    public class AddTail
    {

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            Character character = new Character();
            Move move = new Move();

            while (true)
            {
                map.CreatMap();

                Console.SetCursorPosition(character.X, character.Y);
                Console.Write("●");

                move.MoveToArrow();



                Console.Clear();
            }
        }
    }
}
