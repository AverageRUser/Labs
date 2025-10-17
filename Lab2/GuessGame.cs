using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal static class GuessGame
    {
        public static double CalculateFunction(int a, int b)
        {
            double f = -4 * Math.Pow(Math.Sin(3 * a), 3) + (Math.Sqrt(b) / Math.Log(b + 2));
            return f;
        }
        public static void Start()
        {
            while (true)
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
                    break;
                }
                catch (Exception ex)
                {
                    InputValidator.WrongInputForegroundColor("Ошибка - " + ex.Message);
                }


            }
        }
    }
}
