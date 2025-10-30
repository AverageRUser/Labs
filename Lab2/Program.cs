using Lab2.SnakeGame.Snake;
using System.Diagnostics;

namespace Lab2
{
    internal class Program
    {

   
        public static void SortingArray()
        {
            int n;
            
            Console.WriteLine("Введите размер массива: ");
            
            InputValidator.InputLengthArray(out n);
            ArrayProcess array = new ArrayProcess(n);
            ArrayProcess ArrClone = new ArrayProcess(array);
            Console.WriteLine("Исходный массив: ");
            array.PrintArray();
            Console.WriteLine("Сортировка вставками: ");

            var sw = new Stopwatch();
            var se = new Stopwatch();
            sw.Start();
            array.InsertionSort();
            sw.Stop();
            array.PrintArray();
           
            
            Console.WriteLine("Гномья сортировка");
            se.Start();
            ArrayProcess.GnomeSort(ArrClone.Array);
            se.Stop();
            ArrClone.PrintArray();
           
            if(se.Elapsed == sw.Elapsed)
            {
                Console.WriteLine("Время выполнения методов сортировок одинаковы");
                
            }
            Console.WriteLine("Время работы сортировки вставками: " + sw.Elapsed + "мс");
            Console.WriteLine("Время работы гномьи сортировки: " + sw.Elapsed + "мс");
        }
        public static void SnakeGame()
        {
            Game game = new Game();
            game.Start();
            ConsoleKey Direction = ConsoleKey.RightArrow;

            while (Game.IsPlaying)
            {
                Console.Clear();
                Console.WriteLine("Змея x:{1} y:{0}\n\nСъеденно: {2}", Game.SnakeHead.x, Game.SnakeHead.y, Game.CountFeed);
                if (Game.IsPaused == true)
                {
                    Console.WriteLine("\t\tПауза");
                }
                game.PrintField();
                ConsoleKey? currentKey = null;
                while (Game.IsPaused)
                {
                    if (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                        Game.IsPaused = false;
                    }
                }
                if (Console.KeyAvailable)
                {
                    var move = Console.ReadKey(true);
                    if (move.Key == ConsoleKey.P)
                        Game.IsPaused = true;
                    else
                    {
                        Direction = move.Key;
                        currentKey = move.Key;
                    }
                }

                if (!Game.IsPaused)
                {
                    game.StateUpdate(Direction);
                }
                Thread.Sleep(300);
            }
            Console.WriteLine("Игра окончена! Очков набранно: {0}", Game.CountFeed);
            
        }
        public static void About()
        {
            Console.Clear();
            Console.WriteLine("2. Об авторе");
            Console.WriteLine("Масалов Александр Андреевич");
            Console.WriteLine("Группа 6104-090301D");
            Console.ReadLine();
        }
        
        public static void Main(string[] args)
        {
            int enter;
            
            bool exit = false;
            
            
            do
            {

                Console.WriteLine("1. Отгадай число");
                Console.WriteLine("2. Об авторе");
                Console.WriteLine("3. Сортировка массива");
                Console.WriteLine("4. Игра");
                Console.WriteLine("5. Выход");
                
                enter = InputValidator.FillInt("Выберите действие: ");
                    switch (enter)
                    {
                        case 1:

                        GuessGame.Start();
                        break;

                        case 2:
                             About();
                            break;
                        case 3:
                            SortingArray();
                        break;
                        case 4:
                            SnakeGame();
                        break;
                         case 5:
                            exit = InputValidator.Exit(); 
                           
                            break;
                        default:
                            Console.WriteLine("Введённое число не соотвествует пункту меню");
                            break;

                    }
                
                
            } while (!exit);


        }
    }
}
