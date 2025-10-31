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
        public int this[int index]
        {
            get { return _array[index]; }
             set { _array[index] = value; }
        }

        /// <summary>
        /// Конструктор по умолчанию (10 элементов)
        /// </summary>
        public ArrayProcess()
        {
            Length = 10;
            _array = new int[Length];
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="length">Количество элементов в массиве</param>
        public ArrayProcess(int length)
        {
            Length = length;
            _array = new int[Length];
        }


        /// <summary>
        /// Сортировка вставками
        /// </summary>
        /// <param name="arr">Массив для сортировки</param>
        /// <returns>Отсортированный массив</returns>
        public void InsertionSort()
        {
            for (int i = 1; i < Length; i++)
            {
                int temp = _array[i];
                for(int j = i - 1; j >= 0; j--)
                { 
                    if(_array[j] < temp)
                    {
                        _array[j + 1] = _array[j];
                        _array[j] = temp;
                    }
                }
            }
        }
        public int Min()
        {
            int min = _array[0];
            int index = 0;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                    index = i;
                }
            }
            return index;
        }
        public int Max()
        {
            int max = _array[0];
            int index = 0;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                    index = i;
                }
            }
            return index;
        }
        public int Avg()
        {
            int sum =0;

            foreach(int i in _array)
            {
                sum += i;
            }
            return sum / _array.Length;
        }
        /// <summary>
        /// Гномья сортировка
        /// </summary>
        /// <param name="arr">Массив для сортировки</param>
        /// <returns>Отсортированный массив</returns>
        public void GnomeSort()
        {
            for (int i = 0; i < Length;)
            {
                int temp = 0;
                if (i == 0)
                {
                    i++;
                }

                if (_array[i] >= _array[i - 1])
                {
                    i++;
                }
                else
                {
                    temp = _array[i];
                    _array[i] = _array[i - 1];
                    _array[i - 1] = temp;
                    i--;
                }
            }
        }

        /// <summary>
        /// Инициализирует массив случайными числами
        /// </summary>
        /// <param name="length">Длина массива</param>
        /// <returns>Заполненный массив</returns>
        public void InitializeArray()
        {
            
            Random rn = new Random();
            for (int i = 0; i < Length; i++)
            {
                _array[i] = rn.Next(1, 100);
            }

        }

        /// <summary>
        /// Создает копию массива
        /// </summary>
        /// <param name="arr">Исходный массив</param>
        /// <returns>Копия массива</returns>
        public ArrayProcess CloneArray()
        {
            if (_array == null)
                return null;

            ArrayProcess copy = new ArrayProcess(Length);
            for (int i = 0; i < Length; i++)
            {
                copy[i] = _array[i];
            }
            return copy;
        }




    }
}
