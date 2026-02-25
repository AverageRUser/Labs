using Lab2;

namespace Lab1
{
    internal class Program
    {
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
            Console.WriteLine("Hello, World!");
            int enter;

            bool exit = false;


            do
            {

                Console.WriteLine("1. Отгадай число");
                Console.WriteLine("2. Выход");

                enter = InputValidator.FillInt("Выберите действие: ");
                switch (enter)
                {
                    case 1:

                        GameStart();
                        break;

                    case 2:
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
