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
            Character character;
            character = new Character();
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
                    else if (map[character.Y,character.X/2] == 2)
                    {
                        Console.Write("○");
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
        Character? character;
        public Queue<Character> tail = new Queue<Character> ();
        public void AddTail(int x, int y)
        {
            character = new Character();
            character.X = x;
            character.Y = y;
            
            tail.Enqueue(character);

        }
        public void RemoveTail()
        {
            if(tail.Count > 0)
            {
                tail.Dequeue();
            }
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
            
            for (int n = 0; n < 100; n++)
            {
                //게임판에 꼬리가 화면을 전부 다채우면 승리
                if (n == 99)
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
                    tail.AddTail(character.Y, character.X/2);
                    tail.RemoveTail();
                    // 키입력 반환
                    key = Console.ReadKey();
                        switch (key.Key)
                        {
                            case ConsoleKey.UpArrow:
                                character.Y--;
                                break;
                            case ConsoleKey.LeftArrow:
                                character.X -= 2;
                                break;
                            case ConsoleKey.RightArrow:
                                character.X += 2;
                                break;
                            case ConsoleKey.DownArrow:
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
                        map.map[character.Y, character.X / 2] = 0;
                        tail.AddTail(character.Y,character.X/2);
                        
                        break;
                    }
                    Console.Clear();
                }
            }
        }
    }
}
