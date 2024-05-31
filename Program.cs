namespace SnakeGame
{
    public class Map
    {

        public int[,] map = new int[12, 12]
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
    public class Tail
    {
        Character character1 = new Character();
        Map map1 = new Map();
        int vector_X;
        int vector_y;
        public int Vector_X
        {
            get 
            { 
                return vector_X; 
            }
            set
            {
                vector_X = value;
            }
        }
        public int Vector_Y
        {
            get
            {
                return vector_y;
            }
            set
            {
                vector_y = value;
            }
        }
       


        public void AddTail()
        {
            // int x,y 는 -1,1만 나와야하는데 잘못된 숫자가 들어옴
            int x = (character1.X/2) - (vector_X/2);
            int y = character1.Y- vector_y;

            if (map1.map[character1.Y + y, (character1.X / 2) + x] == 0)
            {
                map1.map[character1.Y + y, (character1.X / 2) + x] = 2;
            }
        }
        public void MoveTail()
        {

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Map map = new Map();
            Character character = new Character();
            Tail tail = new Tail();
            ConsoleKeyInfo key;

            //게임판에 꼬리가 화면을 전부 다채우면 승리
            for (int n = 0; n < 99; n++)
            {
                if(n == 99)
                {
                    Console.Clear();
                    Console.WriteLine("VICTORY");
                    Environment.Exit(0);
                }
                Console.Clear();

                // 랜덤한 좌표로 아이템 생성
                int rx = random.Next(1,11);
                int ry = random.Next(1,11);

                if (map.map[rx, ry] == 0 && map.map[rx,ry] != 2)
                {
                    map.map[rx, ry] = 3;
                }

                while (true)
                {
                    map.CreatMap();
                    // 캐릭터의 좌표에 뱀머리 생성
                    Console.SetCursorPosition(character.X, character.Y);
                    Console.Write("●");

                    key = Console.ReadKey();
                    // 입력받은 방향키에 따라 캐릭터의 위치좌표값 이동, 기존 위치값을 받아서
                    // 이동한 위치값을 계산하여 벡터방향 계산
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            tail.Vector_Y = character.Y;
                            character.Y--;
                            break;
                        case ConsoleKey.LeftArrow:
                            tail.Vector_X = character.X;
                            character.X -= 2;
                            break;
                        case ConsoleKey.RightArrow:
                            tail.Vector_X = character.X;
                            character.X += 2;
                            break;
                        case ConsoleKey.DownArrow:
                            tail.Vector_Y = character.Y;
                            character.Y++;
                            break;
                    }

                    // 캐릭터가 벽과 부딫힐 경우 게임종료
                    if (map.map[character.Y, character.X/2] == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Defeat");
                        Environment.Exit(0);
                    }
                    // 캐릭터가 본인의 꼬리와 부딫힐 경우 게임종료
                    else if ( map.map[character.Y, character.X/2] == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Defeat");
                        Environment.Exit(0);
                    }
                    // 캐릭터가 아이템을 먹을 시 해당 좌표값 0으로 설정, 꼬리추가
                    else if (map.map[character.Y,character.X/2] == 3)
                    {
                        map.map[character.Y, character.X/2] = 0;
                        tail.AddTail();
                        break;
                    }
                    Console.Clear();
                }
            }
        }
    }
}
