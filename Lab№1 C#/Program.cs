using System;

namespace Lab_1_C_
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Задача  1");
            Console.WriteLine("\nПример 1");
            int m, n, x;
            bool check;

            do {
                Console.Write("m?");
                check = Int32.TryParse(Console.ReadLine(), out m);//Проверка правильности ввода, и последующаю,при правильном вводе, инициализация переменной 
                if (!check) Console.WriteLine("!!!Переменная введена с ошибкой. Повторите ввод!!!\n");
            } while (!check);

            do
            {
                Console.Write("n?");
                check = Int32.TryParse(Console.ReadLine(), out n);//Проверка правильности ввода, и последующаю,при правильном вводе, инициализация переменной 
                if (!check) Console.WriteLine("!!!Переменная введена с ошибкой. Повторите ввод!!!\n");
            } while (!check);

            int resultInt = --m - n++;//Объявление и нициализация буверной переменной для вывода значения всего выражения 
            Console.WriteLine("m={0}, n={1}, --m-n++={2}", m, n, resultInt);//Вывод переменных 

            Console.WriteLine("\nПример 2");
            do
            {
                Console.Write("m?");
                check = Int32.TryParse(Console.ReadLine(), out m);//Проверка правильности ввода, и последующаю,при правильном вводе, инициализация переменной 
                if (!check) Console.WriteLine("!!!Переменная введена с ошибкой. Повторите ввод!!!\n");
            } while (!check);

            do
            {
                Console.Write("n?");
                check = Int32.TryParse(Console.ReadLine(), out n);//Проверка правильности ввода, и последующаю,при правильном вводе, инициализация переменной 
                if (!check) Console.WriteLine("!!!Переменная введена с ошибкой. Повторите ввод!!!\n");
            } while (!check);

            bool resultBool= m * m < n++;
            Console.WriteLine("m={0}, n={1}, m*m<n++={2}", m, n, resultBool);//Вывод переменных 
           

           Console.WriteLine("\nПример 3");
            do
            {
                Console.Write("m?");
                check = Int32.TryParse(Console.ReadLine(), out m);//Проверка правильности ввода, и последующаю,при правильном вводе, инициализация переменной 
                if (!check) Console.WriteLine("!!!Переменная введена с ошибкой. Повторите ввод!!!\n");
            } while (!check);

            do
            {
                Console.Write("n?");
                check = Int32.TryParse(Console.ReadLine(), out n);//Проверка правильности ввода, и последующаю,при правильном вводе, инициализация переменной 
                if (!check) Console.WriteLine("!!!Переменная введена с ошибкой. Повторите ввод!!!\n");
            } while (!check);

            bool buff = n-- > ++m;//Объявление и нициализация буверной переменной для вывода значения всего выражения 
            Console.WriteLine("m={0}, n={1}, n-->++m={2}", m, n, buff);//Вывод переменных 
            
            Console.WriteLine("\nПример 4");

            do
            {
                Console.Write("x?");
                check = Int32.TryParse(Console.ReadLine(), out x);//Проверка правильности ввода, и последующаю,при правильном вводе, инициализация переменной 
                if (!check) Console.WriteLine("!!!Переменная введена с ошибкой. Повторите ввод!!!\n");
                if (x == 270 || x==90 ) 
                {
                    Console.WriteLine("!!!Тангенса 90 и 270 градусов не существует!!!\n");
                    check = false;
                }
            } while (!check);
          
            double radians = x * (Math.PI / 180);//Объявление и нициализация переменной, в которой градусы переводятся в радианы 
            double resultDouble = Math.Tan(radians) - Math.Pow(5 - x, 4);//Объявление и нициализация буверной переменной для вывода значения всего выражения 
            Console.Write("\nx=" + x + '\n');//Вывод переменной "x"
            Console.Write("\ntg(x)=" + Math.Tan(radians) + '\n');//Вывод тангенса
            Console.WriteLine(" tg(x)-(5-x)^4={0}", resultDouble);//Вывод переменных 
        }
    }
}

