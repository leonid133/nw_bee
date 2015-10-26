using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace perceptron_web_beeline
{
    class Web_perceptron
    {
        public int[,] m_mul; // Тут будем хранить отмасштабированные сигналы
        public int[,] m_weight; // Массив для хранения весов
        public int[,] m_input; // Входная информация
        public int m_limit = 9; // Порог - выбран экспериментально, для быстрого обучения
        public int m_sum; // Тут сохраним сумму масштабированных сигналов
        public int m_size_x;
        public int m_size_y;

        public Web_perceptron(int sizex, int sizey, int[,] inP) // Задаем свойства при создании объекта
        {
            m_size_x = sizex;
            m_size_y = sizey;
            m_weight = new int[m_size_x, m_size_y]; // Определяемся с размером массива (число входов)
            m_mul = new int[m_size_x, m_size_y];

            m_input = new int[m_size_x, m_size_y];
            m_input = inP; // Получаем входные данные
        }
        public void mul_w()
        {
            for (int x = 0; x < m_size_x; x++)
            {
                for (int y = 0; y < m_size_y; y++) // Пробегаем по каждому аксону
                {
                    m_mul[x, y] = m_input[x, y] * m_weight[x, y]; // Умножаем его сигнал (0 или 1) на его собственный вес и сохраняем в массив.
                }
            }
        }
        public void Sum()
        {
            m_sum = 0;
            for (int x = 0; x < m_size_x; x++)
            {
                for (int y = 0; y < m_size_y; y++)
                {
                    m_sum += m_mul[x, y];
                }
            }
        }
        public bool Rez()
        {
            if (m_sum >= m_limit)
                return true;
            else return false;
        }
        public void incW(int[,] inP)
        {
            for (int x = 0; x < m_size_x; x++)
            {
                for (int y = 0; y < m_size_y; y++)
                {
                    m_weight[x, y] += inP[x, y];
                }
            }
        }
        public void decW(int[,] inP)
        {
            for (int x = 0; x < m_size_x; x++)
            {
                for (int y = 0; y < m_size_y; y++)
                {
                    m_weight[x, y] -= inP[x, y];
                }
            }
        }
  
    }
}
