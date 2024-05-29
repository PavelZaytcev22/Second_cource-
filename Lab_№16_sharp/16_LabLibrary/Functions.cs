using _10LabLibrary;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_LabLibrary
{
    public class Functions
    {
        static public Challenge GetChallenge(string str) 
        {
            int numberWord = 0; //номер слова 
            int indexstr = 0;//индекс строки 
            //Поля классов 
            string Name = "";
            int Questions = 0;
            string Date = "";
            string Teacher = "";
            //Буферная строка 
            string buff = "";

            bool ready = false; 
            
            do
            {
                if (str[indexstr] == '[') //Начало строки 
                {
                    numberWord++;
                    buff = "";
                }
                if (str[indexstr] == ',') //Разделитель полей класса  
                {
                    numberWord++;
                    ready = true;
                }
                if (str[indexstr+1] == ']') //конец строки
                {
                    numberWord++;
                    ready = true;
                }
                
                if (numberWord == 2 && ready ) 
                {
                    Name = buff;
                    ready = false; 
                }
                if (numberWord == 3 && ready )
                {
                    Questions =int.Parse(buff);
                    ready = false;
                }
                if (numberWord == 4 && ready)
                {
                    Date = buff;
                    ready = false;
                }
                if (numberWord == 5 && ready)
                {
                    Teacher = buff;
                    ready = false;
                }

                if (str[indexstr] == ',') //Разделитель полей класса 
                {
                    buff = "";
                }

                if (str[indexstr] != ' ' && str[indexstr] != ',' && str[indexstr] != '[') //Создание строки с полем класса 
                {
                    buff += str[indexstr];
                }
                
                indexstr++;//Перемещение индекса 

            } while (str[indexstr]!=']');
            
            //Возврат сформированного класса 
            if (numberWord ==5) return new Test(Name, Questions, Date,Teacher);
            return new Challenge(Name, Questions, Date);
        }
    }
}
