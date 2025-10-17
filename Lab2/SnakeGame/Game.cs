using Lab2.SnakeGame.Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.SnakeGame.Snake
{
    public static class Game
    {
        public static bool IsPaused;
        public static bool IsPlaying;
        public static int CountFeed;
        public static string[,] GameField = new string[20, 20];
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

        public static void StateUpdate(Snake snake, Food food, List<Obstacle> obstacles, ConsoleKey? direction = null)
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

                GameField[snake.headX, snake.headY] = Snake.Chead;

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
        public static void Restart()
        {
            CountFeed = 0;
        }
        public static void Start(Snake snake, Food food, List<Obstacle> obstacles)
        {
            InitializeField();
            Random random = new Random();
            for (int x = 0; x < random.Next(2, 13); x++)
            {
                obstacles.Add(new Obstacle());
                obstacles[x].Spawn(GameField, snake, food);
                obstacles[x].Print(ref GameField, snake, food);
            }
            snake.Print(ref GameField);
            food.Print(ref GameField, snake, obstacles);
            IsPlaying = true;
        }
    }
}
