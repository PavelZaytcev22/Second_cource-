using System;

namespace Lab_1_С__3
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Задача  3");
            double a = 1000; 
            double b = 0.0001; 
            double numerator1, numerator2, denumerator1, result1;

            numerator1 = Math.Pow(a - b, 3);//Инициализация первой части числителя 
            numerator2 = (a * a * a - 3 * a * a * b);//Инициализация второй части числителя 
            denumerator1 = (3 * a * b * b - b * b * b);//Инициализация знаменателя 
            result1 = (numerator1 - numerator2) / denumerator1;//Инициализация всего выражения 
            Console.WriteLine("Ответ при double:({0}-{1})/({2})={3}", numerator1, numerator2, denumerator1, result1);//Вывод переменных 

            float numerator3, numerator4, denumerator2, result2;
            numerator3 = (float)Math.Pow(a - b, 3);//Инициализация первой части числителя 
            numerator4 = (float)(a * a * a - 3 * a * a * b);//Инициализация второй части числителя 
            denumerator2 = (float)(3 * a * b * b - b * b * b);//Инициализация знаменателя 
            result2 = ((numerator3 - numerator4) / denumerator2);//Инициализация всего выражения 
            Console.WriteLine("Ответ при float:({0}-{1})/({2})={3}", numerator3, numerator4, denumerator2, result2);//Вывод переменных 

        }
    }
}
