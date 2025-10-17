// See https://aka.ms/new-console-template for more information

using Labs;
using System.ComponentModel.Design;
using System.Xml.Serialization;


void PrintField(string[,] matrix)
{
    int rows = matrix.GetUpperBound(0) + 1;
    int columns = matrix.Length / rows;
    for (int x = 0; x < rows; x++)
    {
        for (int y = 0; y < columns; y++)
        {
            Console.Write($"{matrix[x, y]} ");
        }
        Console.WriteLine();
    }
}
void InitializeField(ref string[,] matrix)
{
    int rows = matrix.GetUpperBound(0) + 1;  
    int columns = matrix.Length / rows;
    for (int x = 0; x < rows; x++)
    {
        for (int y = 0; y < columns; y++)
        {
            matrix[x, y] = ".";
        }
        
    }
}
void SetSpawnCoord(ref int x, ref int y, int maxX, int maxY)
{
    Random random = new Random();
    x = random.Next(1, maxX - 1);  
    y = random.Next(1, maxY - 1);
}
void SnakeMove(Snake snake, string[,] m, ConsoleKey key)
{

    /*
    switch (key)
    {
        case ConsoleKey.UpArrow:

        snake.headX--;
    if (snake.headX >= 0)
    {
        m[snake.headX, snake.headY] = snake.Chead;
        m[snake.headX + 1, snake.headY] = snake.Ctail;
        if (snake.headX + snake.GetSize() + 1 < m.GetLength(1))
            m[snake.headX + snake.GetSize(), snake.headY] = "#";

        
    }
            break;
    case ConsoleKey.DownArrow:
            snake.headX++;
            if (snake.headX >= 0)
            {
                m[snake.headX, snake.headY] = snake.Chead;
                m[snake.headX - 1, snake.headY] = snake.Ctail;
              //  if (snake.headX + snake.GetSize() + 1 < m.GetLength(1))
                    m[snake.headX - snake.GetSize(), snake.headY] = "#";

                
            }
            break;
    case ConsoleKey.LeftArrow:
            snake.headY--;
          
                m[snake.headX, snake.headY] = snake.Chead;
                m[snake.headX, snake.headY + 1] = snake.Ctail;
                //  if (snake.headX + snake.GetSize() + 1 < m.GetLength(1))
                m[snake.headX + snake.GetSize(), snake.headY] = "#";


            
            break;
    case ConsoleKey.RightArrow:
            snake.headY++;

            m[snake.headX, snake.headY] = snake.Chead;
            m[snake.headX, snake.headY - 1] = snake.Ctail;
            //  if (snake.headX + snake.GetSize() + 1 < m.GetLength(1))
            m[snake.headX - snake.GetSize(), snake.headY] = "#";
            break;
    }
    */
    int prevX = snake.headX;
    int prevY = snake.headY;

    switch (key)
    {
        case ConsoleKey.UpArrow:
            snake.headX--;
            snake.SetDirection(-1, 0);
            break;
        case ConsoleKey.DownArrow:
            snake.headX++;
            snake.SetDirection(1, 0);
            break;
        case ConsoleKey.LeftArrow:
            snake.headY--;
            snake.SetDirection(0, -1);
            break;
        case ConsoleKey.RightArrow:
            snake.headY++;
            snake.SetDirection(0, 1);
            break;
    }

    if (snake.headX < 0 || snake.headX >= m.GetLength(0) || snake.headY < 0 || snake.headY >= m.GetLength(1))
    {
        snake.headX = prevX;
        snake.headY = prevY;
        return;
    }

    var (dirX, dirY) = snake.GetDirection();
    int tailX = snake.headX - (dirX * snake.GetSize());
    int tailY = snake.headY - (dirY * snake.GetSize());

    // Очищаем старый хвост (если в пределах поля)
    if (tailX >= 0 && tailX < m.GetLength(0) && tailY >= 0 && tailY < m.GetLength(1))
    {
        m[tailX, tailY] = ".";
    }


    m[prevX, prevY] = snake.Ctail;
    m[snake.headX, snake.headY] = snake.Chead;
}
void PrintSnake(Snake snake,ref string[,] m)
{
    int x = 0, y=0;
    SetSpawnCoord(ref x, ref y, m.GetLength(0), m.GetLength(1));
    snake.headX = x;
    snake.headY = y;
    m[x,y] = snake.Chead;
    for (int i = 1; i < snake.GetSize(); i++)
    {
        m[x+i,y] = snake.Ctail;
    }
    
  
}
string[,] m = new string[20,20];

bool game = true;
bool isGamePaused = false;
Snake snake = new Snake();
InitializeField(ref m);
PrintSnake(snake,ref  m);
while (game)
{
    Console.Clear();
    Console.WriteLine("Head x:{1} y:{0}", snake.headX, snake.headY);
    PrintField(m);

    //while (!isGamePaused)
    if (Console.KeyAvailable)
    {
        var move = Console.ReadKey(true);
        SnakeMove(snake, m, move.Key);
    }

    Thread.Sleep(300);

}





