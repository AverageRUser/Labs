using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.SnakeGame.Snake
{

    public struct Coord
    {
        public int x;
        public int y;
        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }


        public static bool operator ==(Coord left, Coord right)
        {
            return left.x == right.x && left.y == right.y;
        }
        public static bool operator != (Coord left, Coord right)
        {
            return !(left.x == right.x && left.y == right.y);
        }
    }
    /// <summary>
    /// Класс для иниициализации и отображения змейки
    /// </summary>
    
    public class Snake
    {
        public int headX;
        public int headY;
        public const string Chead = "@";
        public const string Ctail = "o";
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
          //  body.Enqueue(new Coord(headX,headY));
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
        public void Redraw(string[,] m)
        {

            var bodyArray = GetBody().ToArray();

            for (int i = 0; i < bodyArray.Length; i++)
            {
                Coord coord = bodyArray[i];
                if (i == bodyArray.Length - 1) 
                {
                    m[coord.x, coord.y] = Chead;
                }
                else
                {
                    m[coord.x, coord.y] = Ctail;
                }
            }
        }
        public void Print(string[,] m)
        {
            int x= 0, y=0;
            Game.SetSpawnCoord(ref x, ref y, m.GetLength(0), m.GetLength(1));
            InitializeBody(x, y);
            Redraw(m);

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
