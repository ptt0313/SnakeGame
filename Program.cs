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
        public void CreateMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    
                    if (map[i, j] == 1)
                    {
                        Console.Write("■");
                    }
                    else if (map[i, j] == 0)
                    {
                        Console.Write("  ");
                    }
                    else if (map[i, j] == 2)
                    {
                        Console.Write("○");
                    }
                    else if (map[i, j] == 3)
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
        int x = 10;
        int y = 8;

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
        private Queue<(int, int)> tail;
        private Map map;
        
        public Tail(Map map)
        {
            this.map = map;
            tail = new Queue<(int, int)>();
        }

        public void AddTail(int x, int y)
        {
            tail.Enqueue((x, y));
            if (map.map[x,y] != 3)
            {
                map.map[x, y] = 2;
            }
        }

        public void RemoveTail()
        {
            if (tail.Count > 0)
            {
                (int x,int y) = tail.Dequeue();
                map.map[x, y] = 0;
            }
        }
    }
    internal class Program
    {
        
        enum Direction
        {
            Up,
            Left,
            Right,
            Down
        }
        
        static void Main(string[] args)
        {
            Console.SetWindowSize(30, 15);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            
            Map map = new Map();
            Character character = new Character();
            Tail tail = new Tail(map);
            ConsoleKeyInfo key;
            Direction direction = new Direction();
            Random random = new Random();
            for (int n = 0; n < 100; n++)
            {
                if (n == 99)
                {
                    Console.Clear();
                    Console.WriteLine("VICTORY");
                    Environment.Exit(0);
                }

                // 랜덤한 좌표로 아이템 생성
                
                while(true)
                {
                    int rx = random.Next(1, 11);
                    int ry = random.Next(1, 11);
                    if (map.map[rx, ry] == 0 && map.map[rx, ry] != 2)
                    {
                        map.map[rx, ry] = 3;
                        break;
                    }
                }
             
                
                //게임 반복 로직
                while (true)
                {
                    Console.Clear();
                    // 2차원 배열 맵 생성
                    map.CreateMap();
                    // 캐릭터의 좌표에 뱀 생성
                    Console.SetCursorPosition(character.X, character.Y);
                    Console.Write("●");
                    // 게임 속도조절
                    Thread.Sleep(100);
                    // 뱀 이동시 꼬리추가
                    tail.AddTail(character.Y, character.X / 2);
                    // 키 입력값 변수선언
                    if (Console.KeyAvailable)
                    { 
                    key = Console.ReadKey();
                        switch (key.Key)
                        {
                            case ConsoleKey.UpArrow:
                                direction = Direction.Up;
                                break;
                            case ConsoleKey.LeftArrow:
                                direction = Direction.Left;
                                break;
                            case ConsoleKey.RightArrow:
                                direction = Direction.Right;
                                break;
                            case ConsoleKey.DownArrow:
                                direction = Direction.Down;
                                break;
                        }
                    }
                    // 키입력 변수 반환
                    switch (direction)
                    {
                        case Direction.Up:
                            character.Y--;
                            break;
                        case Direction.Left:
                            character.X -= 2;
                            break;
                        case Direction.Right:
                            character.X += 2;
                            break;
                        case Direction.Down:
                            character.Y++;
                            break;
                    }

                    // 캐릭터가 아이템을 먹을 시 해당 좌표값 0으로 설정, 꼬리 삭제 건너뛰기
                    if (map.map[character.Y, character.X / 2] == 3)
                    {
                        map.map[character.Y, character.X / 2] = 0;
                        break;
                    }
                    // 캐릭터가 벽과 부딪힐 경우 게임종료
                    else if (map.map[character.Y, character.X / 2] == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Defeat");
                        Environment.Exit(0);
                    }
                    // 캐릭터가 본인의 꼬리와 부딪힐 경우 게임종료
                    else if (map.map[character.Y, character.X / 2] == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Defeat");
                        Environment.Exit(0);
                    }
                    // 뱀 이동후 꼬리삭제
                    tail.RemoveTail();
                }
            }
        }
    }
}