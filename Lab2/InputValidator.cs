using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    /// <summary>
    /// Статический класс для проверки вводимых данных
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Выводит сообщение об ошибке красным цветом
        /// </summary>
        /// <param name="description">Текст сообщения об ошибке</param>
        public static void WrongInputForegroundColor(string description)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(description);
            Console.ResetColor();
        }

        /// <summary>
        /// Запрашивает и проверяет ввод целого положительного числа
        /// </summary>
        /// <param name="description">Описание запрашиваемого числа</param>
        /// <returns>Введенное пользователем число</returns>
        public static int FillInt(string description)
        {
            Console.WriteLine(description);
            while (true)
            {
                try
                {
                    int num;
                    if (!int.TryParse(Console.ReadLine(), out num))
                        throw new Exception("Некорректный тип данных");
                    if (num < 0)
                        throw new Exception("Число должно быть положительным");

                    return num;
                }
                catch (Exception e)
                {
                    WrongInputForegroundColor("Ошибка! - " + e.Message);
                }
            }
        }
        public static int InputLengthArray(out int length)
        {

            while (true)
            {
                try
                {

                    if (!int.TryParse(Console.ReadLine(), out length))
                        throw new Exception("Некорректный тип данных");
                    if (length <= 0)
                        throw new Exception("Длина массива должна быть больше 0");

                    return length;



                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка! - " + e.Message);
                }
            }

        }
        /// <summary>
        /// Подтверждение выхода из программы
        /// </summary>
        /// <returns>true - если пользователь подтвердил выход нажав д, false - если отменил нажав н</returns>
        public static bool Exit()
        {
            Console.Clear();
            Console.WriteLine("5. Выход");
            string s = "";
            while (s != "н" && s != "д")
            {
                Console.WriteLine("Вы уверены? д/н");
                s = Console.ReadLine();
                if (s == "д")
                {
                    return true;
                }
                else
                {
                    WrongInputForegroundColor("Неверно введено значение. Нужно ввести либо д либо н");
                }
            }
            return false;
        }
    }
}
