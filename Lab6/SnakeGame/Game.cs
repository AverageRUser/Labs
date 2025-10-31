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

        public const int GRID_SIZE = 20;
        public const int CELL_SIZE = 20;
        public const int GAME_SPEED = 150;

        private DataGridView GameField;
        private static Snake snake;
        private static List<Obstacle> obstacles;
        private static Food food;
        public static Coord SnakeHead { get { return new Coord(snake.headX,snake.headY); } }
        public Game(DataGridView grid)
        {
            GameField = grid;
        }
        public  bool WallCollision()
        {
            if (snake.headX < 0 || snake.headX >= GameField.RowCount || snake.headY < 0 || snake.headY >= GameField.ColumnCount)
            {
                return true;
            }
            return false;
        }
        public static bool SnakeTailCollision()
        {
            foreach (var segment in snake.GetBody())
            {
                if (segment.X == snake.headX && segment.Y == snake.headY)
                    return true;
            }
            return false;
        }

        public void StateUpdate(Keys? direction = null)
        {
            if (direction.HasValue)
            {
                switch (direction)
                {
                    case Keys.Up:
                        snake.headX--;
                        break;
                    case Keys.Down:
                        snake.headX++;
                        break;
                    case Keys.Left:
                        snake.headY--;
                        break;
                    case Keys.Right:
                        snake.headY++;
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
                    food.Print(GameField, snake, obstacles);

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
                    ClearCell(removedTail.X, removedTail.Y);
                }

                snake.Redraw(GameField);
            }
        }
      
        private void ClearCell(int x, int y)
        {
            if (x >= 0 && x < GameField.RowCount && y >= 0 && y < GameField.ColumnCount)
            {
                GameField.Rows[x].Cells[y].Value = "";
                GameField.Rows[x].Cells[y].Style.BackColor = Color.White;
            }
        }
       
        public static void SetSpawnCoord(ref int x, ref int y, int maxX, int maxY)
        {
            Random random = new Random();
            x = random.Next(1, maxX - 1);
            y = random.Next(1, maxY - 3);
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
           
            Random random = new Random();
            for (int x = 0; x < random.Next(2, 13); x++)
            {
                Obstacle obstacle = new Obstacle();
                obstacle.Spawn(GameField, snake, food);
                obstacle.Print(GameField, snake, food);
                obstacles.Add(obstacle);
            }
            snake.Print(GameField);
            food.Print(GameField, snake, obstacles);
            IsPlaying = true;
        }
    }
}
