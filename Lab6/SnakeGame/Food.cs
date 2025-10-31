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
        public int X { set { x = value; } get { return x; } }
        public int Y { set { y = value; } get { return y; } }
        public void Spawn(DataGridView gameGrid, Snake snake, List<Obstacle> obstacles)
        {

            bool isValid;

            do
            {

                Game.SetSpawnCoord(ref x, ref y, gameGrid.RowCount, gameGrid.ColumnCount);
                isValid = true;
                var body = snake.GetBody().ToArray();

                foreach (var segment in body)
                {
                    if (segment.X == x && segment.Y == y)
                    {
                        isValid = false;
                        break;
                    }

                }
                foreach (var segment in obstacles)
                {
                    if (segment.X == x && segment.Y == y)
                    {
                        isValid = false;
                        break;
                    }
                }

            } while (!isValid);
        }
        public void Print(DataGridView gameGrid, Snake snake, List<Obstacle> obstacles)
        {
            Spawn(gameGrid, snake, obstacles);
            UpdateGridCell(gameGrid, x, y, Color.Red);
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

