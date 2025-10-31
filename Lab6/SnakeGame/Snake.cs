using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.SnakeGame.Snake
{

    public struct Coord
    {
        public int X;
        public int Y;
        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }


        public static bool operator ==(Coord left, Coord right)
        {
            return left.X == right.X && left.Y == right.Y;
        }
        public static bool operator != (Coord left, Coord right)
        {
            return !(left.X == right.X && left.Y == right.Y);
        }
    }
    /// <summary>
    /// Класс для иниициализации и отображения змейки
    /// </summary>
    
    public class Snake
    {
        public int headX;
        public int headY;
        private Queue<Coord> body = new Queue<Coord>();
        private int _size = 3;
        
        public int Length { get { return _size; } }
        /// <summary>
        /// Инициализация тела змейки
        /// </summary>
        /// <param name="startX,startY">Начаьные координаты головы змейки</param>

        public void InitializeBody(int startX, int startY)
        {
            body.Clear();
            headX = startX;
            headY = startY + _size - 1;
           
            for (int i = 0; i < _size; i++)
            {
                body.Enqueue(new Coord(startX,startY+i));
            }
        }

        public Coord Move(int newX, int newY)
        {
            body.Enqueue(new Coord(newX, newY));

            if (body.Count > _size)
            {
              return body.Dequeue();

            }
            return new Coord(-1, 1);
        }
        public void Redraw(DataGridView grid)
        {

            var bodyArray = GetBody().ToArray();

            for (int i = 0; i < bodyArray.Length; i++)
            {
                Coord coord = bodyArray[i];
                if (i == bodyArray.Length - 1)
                {
                    UpdateGridCell(grid, coord.X, coord.Y, Color.DarkGreen);
                }
                else
                {
                    UpdateGridCell(grid, coord.X, coord.Y, Color.Green);
                }
            }
        }
        private void UpdateGridCell(DataGridView grid, int row, int col, Color color)
        {
            if (row >= 0 && row < grid.RowCount && col >= 0 && col < grid.ColumnCount)
            {
                grid.Rows[row].Cells[col].Style.BackColor = color;
                grid.Rows[row].Cells[col].Style.ForeColor = Color.White;
                grid.Rows[row].Cells[col].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        public void Print(DataGridView grid)
        {
            int x= 0, y=0;
            Game.SetSpawnCoord(ref x, ref y, grid.RowCount, grid.ColumnCount);
            InitializeBody(x, y);
            Redraw(grid);

        }
        public void Grow()
        {
            _size++;
        }

        public Queue<Coord> GetBody()
        {
            return body;
        }
    }
}
