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
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public void Spawn(DataGridView gameGrid, Snake snake, Food food)
        {

            bool isValid;

            do
            {

                Game.SetSpawnCoord(ref x, ref y, gameGrid.RowCount, gameGrid.ColumnCount);
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
                if (x == food.X && y == food.Y)
                {
                    isValid = false;
                }
            } while (!isValid);
        }
        public void Print(DataGridView grid, Snake snake, Food food)
        {

            Spawn(grid, snake, food);
            UpdateGridCell(grid, x, y, Color.DarkMagenta);

        }
        private void UpdateGridCell(DataGridView grid, int row, int col, Color color)
        {
            if (row >= 0 && row < grid.RowCount && col >= 0 && col < grid.ColumnCount)
            {
                grid.Rows[row].Cells[col].Style.BackColor = color;
            }
        }
    }
}
