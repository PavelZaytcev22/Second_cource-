using System;

namespace Lab_1_С__2
{
    internal class Program
    {
        static void Main()
        {
            double coordinateX, coordinateY; 
            bool result; 
            Console.WriteLine("Задача  2");
            Console.WriteLine("Введите координаты точки");

            do {
                Console.Write("\nX?");
                result = Double.TryParse(Console.ReadLine(), out coordinateX); //Проверка правильности ввода, и последующаю,при правильном вводе, инициализация переменной 
                if (!result) Console.WriteLine("Ошибка ввода переменной. Повторите попытку");
            } while (!result);

            do
            {
                Console.Write("\nY?");
                result = Double.TryParse(Console.ReadLine(), out coordinateY); //Проверка правильности ввода, и последующаю,при правильном вводе, инициализация переменной 
                if (!result) Console.WriteLine("Ошибка ввода переменной. Повторите попытку");
            } while (!result);

            result = (coordinateY * coordinateY + coordinateX * coordinateX <= 1) && (coordinateX >= 0); //Проверка на принадлежность фигуре координаты coordinateX и coordinateY
            Console.WriteLine("Ответ:" + result); //вывод результата
        }
    }
}
