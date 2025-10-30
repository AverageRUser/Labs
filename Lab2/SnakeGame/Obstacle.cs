using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.SnakeGame.Snake
{
    /// <summary>
    /// Класс припятствия
    /// </summary>
    /// <param name="x,y">Координаты припятсвия</param>
    public class Obstacle
    {
        private int x;
        private int y;
        public const string CObstacle = "▲" ;
        public int X { set { x = X; } get { return x; } }
        public int Y { set { y = Y; } get { return y; } }
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
                    if (segment.x == x && segment.y == y || x == food.X && y == food.Y)
                    {
                        isValid = false;
                        break;
                    }
                }
            } while (!isValid);
        }
        public void Print(string[,] field, Snake snake, Food food)
        {

            Spawn(field, snake, food);
            field[x, y] = CObstacle;

        }
    }
}
