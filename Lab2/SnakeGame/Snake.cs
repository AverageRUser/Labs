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
        private int size = 3;
        
        public int Length { get { return size; } }

        /// <summary>
        /// Инициализирует тело змейки, начиная с указанной позиции.
        /// </summary>
        /// <param name="startX">Начальная координата X (голова будет смещена по Y).</param>
        /// <param name="startY">Начальная координата Y (первый сегмент хвоста).</param>
        public void InitializeBody(int startX, int startY)
        {
            body.Clear();
            headX = startX;
            headY = startY + size - 1;
           
            for (int i = 0; i < size; i++)
            {
                body.Enqueue(new Coord(startX,startY+i));
            }
          
        }
        /// <summary>
        /// Перемещает голову змейки в новые координаты и при необходимости удаляет последний сегмент хвоста.
        /// </summary>
        /// <param name="newX">Новая координата X головы.</param>
        /// <param name="newY">Новая координата Y головы.</param>
        /// <returns>
        /// Координаты удалённого сегмента хвоста, если длина превышает текущий размер; 
        /// иначе возвращает <c>new Coord(-1, 1)</c> (означает, что удаления не произошло).
        /// </returns>
        public Coord Move(int newX, int newY)
        {
            body.Enqueue(new Coord(newX, newY));

            return body.Count > size ? body.Dequeue() : new Coord(-1, 1);
        }
        /// <summary>
        /// Перерисовывает змейку на игровом поле, заменяя соответствующие ячейки символами головы и хвоста.
        /// </summary>
        /// <param name="m">Двумерный массив строк, представляющий игровое поле.</param>
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
        /// <summary>
        /// Устанавливает начальные координаты змейки в безопасной области поля, инициализирует её тело и отображает на поле.
        /// </summary>
        /// <param name="m">Двумерный массив строк, представляющий игровое поле.</param>
        public void Print(string[,] m)
        {
            Coord coord = new Coord(0,0);
            Game.SetSpawnCoord(coord, new Coord( m.GetLength(0), m.GetLength(1)));
            InitializeBody(coord.x, coord.y);
            Redraw(m);

        }
        /// <summary>Увеличивает длину змейки на один сегмент.</summary>
        public void Grow()
        {
            size++;
        }
        /// <summary>
        /// Возвращает очередь, содержащую координаты всех сегментов тела змейки.
        /// </summary>
        /// <returns>Очередь <see cref="Queue{Coord}"/> с координатами сегментов.</returns>
        public Queue<Coord> GetBody()
        {
            return body;
        }
    }
}
