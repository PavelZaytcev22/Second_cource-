using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestLibrary
{
    public class Functions
    {
        public static int InputInt32(string massage)
        {
            bool checkTheInput = false;
            int number;
            do
            {
                Console.WriteLine(massage + ": ");
                checkTheInput = Int32.TryParse(Console.ReadLine(), out number);
                if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
            } while (!checkTheInput);
            return number;
        }//Функция для считывания с консоли числа типа Int32 

        public static double InputDouble(string massage)
        {
            bool checkTheInput = false;
            double number;
            do
            {
                Console.WriteLine(massage + ": ");
                checkTheInput = double.TryParse(Console.ReadLine(), out number);
                if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
            } while (!checkTheInput);
            return number;
        }//Функция для считывания с консоли числа типа double 

    }
}
