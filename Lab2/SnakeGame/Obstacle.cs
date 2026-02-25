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
    public class Obstacle
    {
        private Coord coord;
        public const string CObstacle = "▲" ;
        public int X { get { return coord.x; } }
        public int Y { get { return coord.y; } }

        /// <summary>
        /// Инициализирует припятствие
        /// </summary>
        /// <param name="field" >Игровое поле</param>
        /// <param name="food">Объект "Еда"</param>
        /// <param name="snake">Объект "Змея"</param>
        public void Spawn(string[,] field, Snake snake, Food food)
        {

            bool isValid;

            do
            {
                
                Game.SetSpawnCoord(coord, new Coord(field.GetLength(0), field.GetLength(1)));
                isValid = true;
                var body = snake.GetBody().ToArray();

                foreach (var segment in body)
                {
                    if (segment.x == X && segment.y == Y || X == food.X && Y == food.Y)
                    {
                        isValid = false;
                     
                    }
                }
            } while (!isValid);
        }
        /// <summary>
        /// Отображает припятствие на игровом поле
        /// </summary>
        /// <param name="field" >Игровое поле</param>
        /// <param name="food">Объект "Еда"</param>
        /// <param name="snake">Объект "Змея"</param>
        public void Print(string[,] field, Snake snake, Food food)
        {

            Spawn(field, snake, food);
            field[X, Y] = CObstacle;

        }
    }
}
