using Lab2.SnakeGame.Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.SnakeGame.Snake
{

    public class Game
    {
        public static bool IsPaused;
        public static bool IsPlaying;
        public static int CountFeed;
        const int m =20, n = 20;
        public string[,] GameField;
        private static Snake snake;
        private static List<Obstacle> obstacles;
        private static Food food;
        public static Coord SnakeHead { get { return new Coord(snake.headX,snake.headY); } }
        public Game()
        {
            GameField = new string[m,n];
        }
        public  bool WallCollision()
        {
            if (snake.headX < 0 || snake.headX >= GameField.GetLength(0) || snake.headY < 0 || snake.headY >= GameField.GetLength(1))
            {
                return true;
            }
            return false;
        }
        public static bool SnakeTailCollision()
        {
            foreach (var segment in snake.GetBody())
            {
                if (segment.x == snake.headX && segment.y == snake.headY)
                    return true;
            }
            return false;
        }

        public void StateUpdate(ConsoleKey? direction = null)
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
                if (WallCollision() || SnakeTailCollision())
                {
                    IsPlaying = false;
                    return;
                }


                if (snake.headX == food.X && snake.headY == food.Y)
                {
                    snake.Grow();
                    food.Spawn(GameField, snake, obstacles);
                    food.Print(ref GameField, snake, obstacles);

                    CountFeed++;
                }
                foreach (var obstacle in obstacles)
                {
                    if (snake.headX == obstacle.X && snake.headY == obstacle.Y)
                    {
                        IsPlaying = false;
                        return;
                    }
                }

                var removedTail = snake.Move(snake.headX, snake.headY);


                if (removedTail != new Coord(-1, 1))
                {
                    GameField[removedTail.x, removedTail.y] = ".";
                }

                snake.Redraw(GameField);
            }
        }
        public static void SetSpawnCoord(ref int x, ref int y, int maxX, int maxY)
        {
            Random random = new Random();
            x = random.Next(1, maxX - 1);
            y = random.Next(1, maxY - 3);
        }
        public void InitializeField()
        {
            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    GameField[x, y] = ".";
                }

            }
        }
        public  void PrintField()
        {
            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    Console.Write($"{GameField[x, y]} ");
                }
                Console.WriteLine();
            }
        }
        public static void Restart()
        {
            CountFeed = 0;
        }
        public  void Start()
        {
            snake = new Snake();
            food = new Food();
            obstacles = new List<Obstacle>();
            InitializeField();
            Random random = new Random();
            for (int x = 0; x < random.Next(2, 13); x++)
            {
                obstacles.Add(new Obstacle());
                obstacles[x].Spawn(GameField, snake, food);
                obstacles[x].Print(GameField, snake, food);
            }
            snake.Print(GameField);
            food.Print(ref GameField, snake, obstacles);
            IsPlaying = true;
        }
    }
}
