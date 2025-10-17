using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    internal class Snake
    {
        public int headX;
        public int headY;
        public string Chead = "@";
        public string Ctail = "o";
        private int directionX = 0, directionY = 1;
        public void Grow()
        {
            size++;
        }
        public int GetSize()
        {
            return this.size;
        }
        public void SetDirection(int dx, int dy)
        {
            directionX = dx;
            directionY = dy;
        }

        public (int dx, int dy) GetDirection()
        {
           return (directionX, directionY);
        }
        private int size = 3;
    }
}
