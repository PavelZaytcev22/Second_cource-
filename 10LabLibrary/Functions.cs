using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10LabLibrary
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

        public static int BinarySearchLab10(Challenge[] mass, int Questions) 
        {
            int start = 0, end = mass.Length-1;
            int midl;
            Challenge buff;
            do
            {
                midl = (start + end) / 2;
                buff = mass[midl];
                if (buff.Questions == Questions) return midl;
                if (buff.Questions > Questions) end = midl;
                if (buff.Questions < Questions) start = midl;         
                
            } while (end-start!=1);
          
            buff = mass[start];
            if (buff.Questions == Questions) return start;
                     
            buff = mass[end];
            if (buff.Questions == Questions) return end;
            return -1;
        } //Функция бинарного поиска 

        public static int StringValue(string ss) 
        {
            int count = 0;
            for (int i = 0; i < ss.Length; i++) 
            {
                count += ss[i];
            }
            return count; 
        }

    }
}
