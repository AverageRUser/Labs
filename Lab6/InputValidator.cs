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
        /// Запрашивает и проверяет ввод целого положительного числа
        /// </summary>
        /// <param name="Input">Число вводимое пользователем в формате string</param>
        /// <returns>Введенное пользователем число</returns>
        public static int FillInt(string Input)
        {


                    int num;
                    if (!int.TryParse(Input, out num))
                        throw new Exception("Некорректный тип данных");
                    if (num < 0)
                        throw new Exception("Число должно быть положительным");

                    return num;
                

        }
        public static double FillDouble(string Input)
        {


                double num;
                if (!double.TryParse(Input, out num))
                    throw new Exception("Некорректный тип данных");
                if (num < 0)
                    throw new Exception("Число должно быть положительным");

                return num;
            

        }
        public static int InputLengthArray(string num)
        {

                    if (!int.TryParse(num, out int length))
                        throw new Exception("Некорректный тип данных");
                    if (length <= 0)
                        throw new Exception("Длина массива должна быть больше 0");

                    return length;



        }

    }
}
