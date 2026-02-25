using Lab2;
using System.Diagnostics;

namespace Lab3
{
    internal class Program
    {
        public static void InsertionSort(int[] arr)
        {
            
            for (int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    arr[j] = temp;
                    j--;
                }
            }
        
        }

        /// <summary>
        /// Гномья сортировка
        /// </summary>
        /// <param name="arr">Массив для сортировки</param>
        /// <returns>Отсортированный массив</returns>
        public static int[] GnomeSort(int[] arr)
        {
            for (int i = 0; i < arr.Length;)
            {
                int temp = 0;
                if (i == 0)
                {
                    i++;
                }

                if (arr[i] >= arr[i - 1])
                {
                    i++;
                }
                else
                {
                    temp = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = temp;
                    i--;
                }
            }
            return arr;
        }

        /// <summary>
        /// Инициализирует массив случайными числами
        /// </summary>
        /// <param name="length">Длина массива</param>
        /// <returns>Заполненный массив</returns>
        private static int[] InitializeArray(int length)
        {
            int[] array = new int[length];
            Random rn = new Random();
            for (int i = 0; i < length; i++)
            {
                array[i] = rn.Next(1, 100);
            }
            return array;
        }
        public static int[] CloneArray(int[] arr)
        {

            int[] copy = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                copy[i] = arr[i];
            }
            return copy;
        }
        public static void PrintArray(int[] arr)
        {
            if (arr.Length > 10)
            {
                Console.WriteLine("Невозможно вывести массив так как его длина больше 10");
                return;
            }

            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(" " + arr[i] + " ");
            }
            Console.WriteLine();
        }
        public static void SortingArray()
        {
            int n;

            Console.WriteLine("Введите размер массива: ");

            InputValidator.InputLengthArray(out n);
           int[] array = InitializeArray(n);

            int[] ArrClone = CloneArray(array);
            Console.WriteLine("Исходный массив: ");
            PrintArray(array);
            Console.WriteLine("Сортировка вставками: ");

            var sw = new Stopwatch();
            var se = new Stopwatch();
            sw.Start();
            InsertionSort(array);
            sw.Stop();
            PrintArray(array);


            Console.WriteLine("Гномья сортировка");
            se.Start();
            GnomeSort(ArrClone);
            se.Stop();
            PrintArray(ArrClone);

            if (se.Elapsed == sw.Elapsed)
            {
                Console.WriteLine("Время выполнения методов сортировок одинаковы");

            }
            Console.WriteLine("Время работы сортировки вставками: " + sw.Elapsed.TotalMilliseconds + " мс");
            Console.WriteLine("Время работы гномьи сортировки: " + se.Elapsed.TotalMilliseconds + " мс");
        }
        public static void About()
        {
            Console.Clear();
            Console.WriteLine("2. Об авторе");
            Console.WriteLine("Масалов Александр Андреевич");
            Console.WriteLine("Группа 6104-090301D");
            Console.ReadLine();
        }
        public static double CalculateFunction(int a, int b)
        {
            double f = -4 * Math.Pow(Math.Sin(3 * a), 3) + (Math.Sqrt(b) / Math.Log(b + 2));
            return f;
        }
 
        public static void GameStart()
        {
            bool isPlaying = true;
            while (isPlaying)
            {

                int a = InputValidator.FillInt("Введите значение а: ");
                int b = InputValidator.FillInt("Введите значение b: ");
                bool isAnswerCorrect = false;
                try
                {
                    double f = CalculateFunction(a, b);
                    int attempts = 3;
                    double answer;

                    while (attempts != 0 && !isAnswerCorrect)
                    {
                        Console.WriteLine("Вычислите значение функции f = -4*pow(sin(3*{0}),3) + (sqrt({1}) / ln({1}+2)) округлённый до 2 знаков после запятой", a, b);
                        Console.WriteLine(String.Format("У вас есть {0} попытки", attempts));

                        if (double.TryParse(Console.ReadLine(), out answer))
                        {
                            if (answer != Math.Round(f, 2))
                            {
                                Console.WriteLine("Ответ неверный!");
                                attempts--;
                            }
                            else
                            {
                                Console.WriteLine("Ответ верный!\n");
                                isAnswerCorrect = true;
                            }
                        }
                        else
                        {
                            throw new Exception("Некорректный тип значения");
                        }
                    }

                    Console.WriteLine("Игра окончена!");
                    if (!isAnswerCorrect)
                    {
                        Console.WriteLine("Правильный ответ: " + Math.Round(f, 2));
                    }
                    isPlaying = false;
                }
                catch (Exception ex)
                {
                    InputValidator.WrongInputForegroundColor("Ошибка - " + ex.Message);
                }


            }
        }
        static void Main(string[] args)
        {
            int enter;

            bool exit = false;


            do
            {

                Console.WriteLine("1. Отгадай число");
                Console.WriteLine("2. Об авторе");
                Console.WriteLine("3. Сортировка массива");
                Console.WriteLine("5. Выход");

                enter = InputValidator.FillInt("Выберите действие: ");
                switch (enter)
                {
                    case 1:

                        GameStart();
                        break;

                    case 2:
                        About();
                        break;
                    case 3:
                        SortingArray();
                        break;
                    case 4:
                
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
