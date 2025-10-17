using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class ArrayProcess
    {
        private int _length;
        private int[] _array;

        /// <summary>
        /// Количество элементов в массиве
        /// </summary>
        public int Length
        {
            get { return _length; }
            private set { _length = value; }
        }

        /// <summary>
        /// Массив элементов
        /// </summary>
        public int[] Array
        {
            get { return _array; }
            private set { _array = value; }
        }

        /// <summary>
        /// Конструктор по умолчанию (10 элементов)
        /// </summary>
        public ArrayProcess()
        {
            Length = 10;
            Array = InitializeArray(Length);
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="length">Количество элементов в массиве</param>
        public ArrayProcess(int length)
        {
            Length = length;
            Array = InitializeArray(Length);
        }

        /// <summary>
        /// Сортировка вставками
        /// </summary>
        /// <param name="arr">Массив для сортировки</param>
        /// <returns>Отсортированный массив</returns>
        public int[] InsertionSort()
        {
            for (int i = 1; i < Length; i++)
            {
                int temp = Array[i];
                int j = i - 1;

                while (j >= 0 && Array[j] > temp)
                {
                    Array[j + 1] =  Array[j];
                    Array[j] = temp;
                    j--;
                }
            }
            return Array;
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

        /// <summary>
        /// Создает копию массива
        /// </summary>
        /// <param name="arr">Исходный массив</param>
        /// <returns>Копия массива</returns>
        public ArrayProcess CloneArray(int[] arr)
        {
            if (arr == null)
                return null;

            ArrayProcess copy = new ArrayProcess(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                copy.Array[i] = arr[i];
            }
            return copy;
        }

        /// <summary>
        /// Выводит массив на консоль
        /// </summary>
        /// <param name="array">Массив для вывода</param>
        public void PrintArray()
        {
            if (Length > 10)
            {
                Console.WriteLine("Невозможно вывести массив так как его длина больше 10");
                return;
            }

            Console.WriteLine();
            for (int i = 0; i < Length; i++)
            {
                Console.Write(" " + Array[i] + " ");
            }
            Console.WriteLine();
        }

        
    }
}
