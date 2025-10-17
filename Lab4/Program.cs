using System.Transactions;
using static System.Formats.Asn1.AsnWriter;

namespace Lab4
{
    class Snake
    {
        public int headX;
        public int headY;
        public string Chead = "@";
        public string Ctail = "o";
        private Queue<(int x, int y)> body = new Queue<(int x, int y)>();
        private int size = 1;

        public int GetSize() => size;

        public void InitializeBody(int startX, int startY)
        {
            body.Clear();
            headX = startX;
            headY = startY + size - 1;

            for (int i = 0; i < size; i++)
            {
                body.Enqueue((startX, startY+i));
            }

        }

        public (int x, int y) Move(int newX, int newY)
        {
            // Добавляем новую голову
            body.Enqueue((newX, newY));
            headX = newX;
            headY = newY;

            // Если змея не растет, удаляем хвост
            if (body.Count > size)
            {
                return body.Dequeue();
            }
            return (-1, 1);
        }
        public void Redraw(string[,] m)
        {
            
            var bodyArray = GetBody().ToArray();

            for (int i = 0; i < bodyArray.Length; i++)
            {
                var (x, y) = bodyArray[i];
                if (i == bodyArray.Length - 1) // последний - голова
                {
                    m[x, y] = Chead;
                }
                else
                {
                    m[x, y] = Ctail;
                }
            }
        }
        public void Print(ref string[,] m)
        {
            int x = 0, y = 0;
            Game.SetSpawnCoord(ref x, ref y, m.GetLength(0), m.GetLength(1));
            InitializeBody(x, y);
            Redraw(m);

        }
        public void Grow()
        {
            size++;
        }

        public Queue<(int x, int y)> GetBody()
        {
            return body;
        }
    }
    class Obstacle
    {
        public int x;
        public int y;
        public string CObstacle = "▲";
        public void Spawn(string[,] field, Snake snake, Food food)
        {

            bool isValid;

            do
            {

                Game.SetSpawnCoord(ref x, ref y, field.GetLength(0), field.GetLength(1));
                isValid = true;
                var body = snake.GetBody().ToArray();

                foreach (var segment in body)
                {
                    if (segment.x == x && segment.y == y || x == food.x && y == food.y)
                    {
                        isValid = false;
                        break;
                    }
                }
            } while (!isValid);
        }
        public void Print(ref string[,] field, Snake snake,Food food)
        {

                Spawn(field, snake, food);
                field[x, y] = CObstacle;
            
        }
    }
    class Food
    {
        public int x;
        public int y;
        public string CFood = "♥";
       
        public void Spawn(string[,] field, Snake snake, List<Obstacle> obstacles)
        {
        
            bool isValid;

            do
            {

                Game.SetSpawnCoord(ref x, ref y,field.GetLength(0), field.GetLength(1));
                isValid = true;
                var body = snake.GetBody().ToArray();
              
                foreach (var segment in body)
                {
                    if (segment.x == x && segment.y == y)
                    {
                        isValid = false;
                        break;
                    }
                    
                }
                foreach (var segment in obstacles)
                {
                    if (segment.x == x && segment.y == y)
                    {
                        isValid = false;
                        break;
                    }
                }

            } while (!isValid);
        }
        public void Print(ref string[,] field, Snake snake,List<Obstacle> obstacles)
        {
            Spawn(field, snake,obstacles);
            field[x, y] = CFood;
        }
    }
    static class Game
    {
        public static bool IsPaused;
        public static bool IsPlaying;
        public static int CountFeed;
        public static string[,] GameField = new string[20,20];
        public static bool WallCollision(Snake snake, string[,] field)
        {
            if (snake.headX < 0 || snake.headX >= field.GetLength(0) || snake.headY < 0 || snake.headY >= field.GetLength(1))
            {
                return true;
            }
            return false;
        }
        public static bool SnakeTailCollision(Snake snake, string[,] field)
        {
            foreach (var segment in snake.GetBody())
            {
                if (segment.x == snake.headX && segment.y == snake.headY)
                    return true;
            }
            return false;
        }

        public static void StateUpdate(Snake snake, Food food,List<Obstacle> obstacles,ConsoleKey? direction=null)
        {
            if (direction.HasValue)
            {
                switch (direction)
                {
                    case ConsoleKey.UpArrow:
                        snake.headX--;

                        break;
                    case ConsoleKey.DownArrow:
                        snake.headX++;

                        break;
                    case ConsoleKey.LeftArrow:
                        snake.headY--;

                        break;
                    case ConsoleKey.RightArrow:
                        snake.headY++;
                        break;
                    default:
                        snake.headX--;
                        break;

                }
                if (WallCollision(snake, GameField) || SnakeTailCollision(snake, GameField))
                {
                    IsPlaying = false;
                    return;
                }


                if (snake.headX == food.x && snake.headY == food.y)
                {
                    snake.Grow();
                    food.Spawn(GameField, snake, obstacles);
                    food.Print(ref GameField, snake, obstacles);

                    CountFeed++;
                }
                foreach (var obstacle in obstacles)
                {
                    if (snake.headX == obstacle.x && snake.headY == obstacle.y)
                    {
                        IsPlaying = false;
                        return;
                    }
                }

                var removedTail = snake.Move(snake.headX, snake.headY);


                if (removedTail != (-1, 1))
                {
                    GameField[removedTail.x, removedTail.y] = ".";
                }

                // Рисуем новую голову
                GameField[snake.headX, snake.headY] = snake.Chead;

                snake.Redraw(GameField);
            }
        }
        public static void SetSpawnCoord(ref int x, ref int y, int maxX, int maxY)
        {
            Random random = new Random();
            x = random.Next(1, maxX - 1);
            y = random.Next(1, maxY - 3);
        }
        static void InitializeField()
        {
            int rows = GameField.GetLength(0);
            int columns = GameField.GetLength(1);
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    GameField[x, y] = ".";
                }

            }
        }
        public static void PrintField()
        {
            int rows = GameField.GetLength(0);
            int columns = GameField.GetLength(1);
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    Console.Write($"{GameField[x, y]} ");
                }
                Console.WriteLine();
            }
        }
        public static void Start(Snake snake,Food food,List<Obstacle> obstacles)
        {
            InitializeField();
            Random random = new Random();
            for (int x = 0; x < random.Next(2,13); x++)
            {
                obstacles.Add(new Obstacle());
                obstacles[x].Spawn(GameField,snake,food);
                obstacles[x].Print(ref GameField,snake,food);
            }
            snake.Print(ref GameField);
            food.Print(ref GameField,snake, obstacles);
            IsPlaying = true;
        }
    }
    internal class Program
    {
       

        static void Main(string[] args)
        {

     
            Snake snake = new Snake();
            Food food = new Food();
            List<Obstacle> obstacles = new List<Obstacle>();
            Game.Start(snake,food, obstacles);
            ConsoleKey Direction = ConsoleKey.RightArrow;

            while (Game.IsPlaying)
            {
                Console.Clear();
                Console.WriteLine("Змея x:{1} y:{0}\nРазмер: {2}\nСъеденно: {3}", snake.headX, snake.headY, snake.GetSize(), Game.CountFeed);
                if(Game.IsPaused == true)
                {
                    Console.WriteLine("\t\tПауза");
                }
                Game.PrintField();
                ConsoleKey? currentKey = null;
                while (Game.IsPaused)
                {
                    if (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                        Game.IsPaused = false;
                    }
                }
                if (Console.KeyAvailable)
                {
                    var move = Console.ReadKey(true);
                    if (move.Key == ConsoleKey.P)
                        Game.IsPaused = true;
                    else
                    {
                        Direction = move.Key;
                        currentKey = move.Key;
                    }
                }
                   
                if (!Game.IsPaused )
                {
                    Game.StateUpdate(snake, food, obstacles, Direction);
                }
                Thread.Sleep(300);
            }
            Console.WriteLine("Игра окончена! Очков набранно: {0}",Game.CountFeed );
        }
    }
}
