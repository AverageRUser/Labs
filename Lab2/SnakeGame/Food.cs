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
        private Coord coord;
    
        public string CFood = "♥";
        public int X { get { return coord.x; } }
        public int Y { get { return coord.y; } }
        /// <summary>
        /// Инициализирует еду
        /// </summary>
        /// <param name="field" >Игровое поле</param>
        /// <param name="obstacles">Список препятствии</param>
        /// <param name="snake">Объект "Змея"</param>
        public void Spawn(string[,] field, Snake snake, List<Obstacle> obstacles)
        {

            bool isValid;

            do
            {

                Game.SetSpawnCoord(coord,new Coord(field.GetLength(0), field.GetLength(1)));
                isValid = true;
                var body = snake.GetBody().ToArray();

                foreach (var segment in body)
                {
                    if (segment.x == X && segment.y == Y)
                    {
                        isValid = false;
           
                    }

                }
                foreach (var segment in obstacles)
                {
                    if (segment.X == X && segment.Y == Y)
                    {
                        isValid = false;
                  
                    }
                }

            } while (!isValid);
        }
        /// <summary>
        /// Отображает еду на игровом поле
        /// </summary>
        /// <param name="field" >Игровое поле</param>
        /// <param name="obstacles">Список препятствии</param>
        /// <param name="snake">Объект "Змея"</param>
        public void Print(string[,] field, Snake snake, List<Obstacle> obstacles)
        {
            Spawn(field, snake, obstacles);
            field[X, Y] = CFood;
        }
    }
}
