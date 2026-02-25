using Lab2.SnakeGame.Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.SnakeGame.Snake
{
    public class Food
    {
        private int x;
        private int y;
        public string CFood = "♥";
        public int X { set { x = X; } get { return x; } }
        public int Y { set { y = Y; } get { return y; } }
        public void Spawn(string[,] field, Snake snake, List<Obstacle> obstacles)
        {

            bool isValid;

            do
            {

                Game.SetSpawnCoord(ref x, ref y, field.GetLength(0), field.GetLength(1));
                isValid = true;
                var body = snake.GetBody().ToArray();

                foreach (var segment in body)
                {
                    if (segment.x == x && segment.y == y)
                    {
                        isValid = false;
           
                    }

                }
                foreach (var segment in obstacles)
                {
                    if (segment.X == x && segment.Y == y)
                    {
                        isValid = false;
                  
                    }
                }

            } while (!isValid);
        }
        public void Print(string[,] field, Snake snake, List<Obstacle> obstacles)
        {
            Spawn(field, snake, obstacles);
            field[x, y] = CFood;
        }
    }
}
