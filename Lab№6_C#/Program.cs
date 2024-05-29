using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_6_C_
{
    internal class Program
    {
        static int[,] matrix = null;
        static Random Randomer = new Random();
        static string MainString; 
        

        static void ShowArray(int[,] array) //Функция для вывода двумерного массива
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("\n!!!Массив пуст!!!\n");
            }
            else
            {
                Console.Write("\n");
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    Console.Write("\n[");
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write(" " + array[i, j]);
                    }
                    Console.Write(" ]\n");
                }
            }
        }

        static void CreateArrayManually(ref int[,] array) //Функция для создания двумерного массива вручную
        {
            bool checkTheInput = false;
            int widthArray, longArray;
            do
            {
                Console.WriteLine("Введите ширину массива:");
                checkTheInput = Int32.TryParse(Console.ReadLine(), out widthArray);
                if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                if (widthArray < 0)
                {
                    Console.WriteLine("\n!!!Длинна массива может быть только положительной!!!\n");
                    checkTheInput = false;
                }
            } while (!checkTheInput);

            do
            {
                Console.WriteLine("Введите длинну массива:");
                checkTheInput = Int32.TryParse(Console.ReadLine(), out longArray);
                if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                if (longArray < 0)
                {
                    Console.WriteLine("\n!!!Длинна массива может быть только положительной!!!\n");
                    checkTheInput = false;
                }
            } while (!checkTheInput);

            array = new int[widthArray, longArray];
            int buff;
            for (int i = 0; i < widthArray; i++)
            {
                for (int j = 0; j < longArray; j++)
                {
                    do
                    {
                        Console.Write("\nВведите [" + i + ' ' + j + "]-ый элемент массива:");
                        checkTheInput = Int32.TryParse(Console.ReadLine(), out buff);
                        if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                    } while (!checkTheInput);
                    array[i, j] = buff;
                }
            }
            Console.WriteLine("\n!!Массив был создан!!");
        }

        static void CreateArrayAuto(ref int[,] array) //Функция для создания двумерного массива автоматически
        {
            bool checkTheInput = false;
            int widthArray, longArray;
            do
            {
                Console.WriteLine("Введите ширину массива:");
                checkTheInput = Int32.TryParse(Console.ReadLine(), out widthArray);
                if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                if (widthArray < 0)
                {
                    Console.WriteLine("\n!!!Длинна массива может быть только положительной!!!\n");
                    checkTheInput = false;
                }
            } while (!checkTheInput);

            do
            {
                Console.WriteLine("Введите длинну массива:");
                checkTheInput = Int32.TryParse(Console.ReadLine(), out longArray);
                if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                if (longArray < 0)
                {
                    Console.WriteLine("\n!!!Длинна массива может быть только положительной!!!\n");
                    checkTheInput = false;
                }
            } while (!checkTheInput);

            array = new int[widthArray, longArray];

            for (int i = 0; i < widthArray; i++)
            {
                for (int j = 0; j < longArray; j++)
                {
                    array[i, j] = Randomer.Next(-150, 150);
                }
            }
            Console.WriteLine("\n!!!Массив был создан!!!");
        }

        static void DeleteColumn(ref int[,] array)
        {
            if (array == null || array.Length == 0) 
            {
                Console.WriteLine("\n!!!Массив пуст!!!");
            }
            else 
            { 
            int minElement=array[0,0];
            int columnIndex=0;
            for (int i=0; i<array.GetLength(0); i++) //Поиск минимального элемента 
            {
                for (int j = 0; j < array.GetLength(1); j++) 
                {
                    if (minElement > array[i, j]) 
                    {
                        minElement = array[i,j];
                        columnIndex = j;
                    }
                }
            }

            for (int i = 0; i < array.GetLength(0); i++)//Поиск индекса столбца с мин элементом 
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (minElement ==array[i, j] && j<columnIndex)
                    {
                        columnIndex = j;
                    }
                }
            }

            int[,] buffMatrix = new int[array.GetLength(0), array.GetLength(1)-1];
            
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int buff_index=0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (j != columnIndex)
                    {
                        buffMatrix[i, buff_index] = array[i, j];
                        buff_index++;
                    }
                }
            }
            array = buffMatrix;
                if (array.Length == 0)
                {
                    Console.WriteLine("\n!!!Массив стал пустым!!!");
                }
                else 
                {
                    Console.WriteLine("\n!!!Массив был изменен!!!");
                }
            
        }

        }//Функция удаления из массива столбца с наименьшим элементом

        static void CreateStringManually(ref string ss) 
        {
            bool checkTheInput = false;
            string buffString;
            do
            {
                Console.WriteLine("Введите строку:");
                buffString = Console.ReadLine();
                if (buffString.Length == 0)
                {
                    Console.WriteLine("\n!!!Строка не была введена!!!\n");
                    checkTheInput = false;
                }
                else checkTheInput = true;
            } while (!checkTheInput);
            ss = buffString;
            Console.WriteLine("\nCтрока создана");
        }//Функция создания строки с помощью клавиатуры 

        static void CreateStringAuto(ref string ss, string[] mass)
        {
            int command;
            bool checkTheInput = false;
            do
            {
                Console.WriteLine("Введите номер предложения");
                Console.WriteLine("1)" + mass[0]);
                Console.WriteLine("2)" + mass[1]);
                Console.WriteLine("3)" + mass[2]);
                Console.WriteLine("4)" + mass[3]);
                Console.WriteLine("5)" + mass[4]);
                checkTheInput = Int32.TryParse(Console.ReadLine(), out command);
                if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
            } while (!checkTheInput);
            switch (command) 
            {
                case 1:
                    ss = mass[0];
                    Console.WriteLine("\nCтрока создана");
                    break;
                case 2:
                    ss = mass[1];
                    Console.WriteLine("\nCтрока создана");
                    break;
                case 3:
                    ss = mass[2];
                    Console.WriteLine("\nCтрока создана");
                    break;
                case 4:
                    ss = mass[3];
                    Console.WriteLine("\nCтрока создана");
                    break;
                case 5:
                    ss = mass[4];
                    Console.WriteLine("\nCтрока создана");
                    break;
                default:
                    break;
            }
            
        }

        static bool CorrectSentence(string aa) 
        {
            Regex reg = new Regex(@"(?:^|(?<=[.!?]\s))\p{P}");
            return reg.IsMatch(aa);
        }
        static void ReverseFirstLast(ref string ss)
        {
            if (ss == null || ss.Length == 0)
            {
                Console.WriteLine("\n!!!Строка пуста!!!\n");
            }
            else
            {
                if (!CorrectSentence(ss))
                {
                    string buffString = "";
                    string[] words = ss.Split(' ', ',', '.', ';', ':', '?', '!');
                    int indexFirstWord = 0;
                    int indexLastWord = 0;
                    string Firstword = "";
                    string Secondword = "";
                    bool Check = false;
                    for (int i = 0; i < words.Length && !Check; i++)
                    {
                        if (words[i] != "")
                        {
                            Firstword = words[i];
                            Check = true;
                        }
                    }
                    for (int i = words.Length - 1; i >= 0 && Check; i--)
                    {
                        if (words[i] != "")
                        {
                            Secondword = words[i];
                            Check = false;
                        }
                    }

                    indexFirstWord = ss.IndexOf(Firstword);
                    indexLastWord = ss.IndexOf(Secondword);

                    for (int i = 0; i < ss.Length; i++)
                    {
                        if (i == indexFirstWord)
                        {
                            buffString += Secondword;
                            i += (Firstword.Length - 1);
                        }
                        else
                        {
                            if (i == indexLastWord)
                            {
                                buffString += Firstword;
                                i += (Secondword.Length - 1);
                            }
                            else
                            {
                                buffString += ss[i];
                            }
                        }
                    }
                    ss = buffString;
                    Console.WriteLine("\n!!!Строка была изменена!!!");
                }
                else
                {
                    Console.WriteLine("\nНеправильная строка");
                }
            }//Функция перемещения первого и последнего слова местами 
        }
        

        static void Main(string[] args)
        {
            string[] arraystrings ={
                "Привет, как у тебя дела?",
                "Павел пошел гулять по улице !",
                "Good day to die!!!",
                "Bad boys went in new area, that's good!!",
                " Goodbye" };
            bool mainMenu = true;
            int command1,command2, command3;
            bool checkTheInput = false;
            do
            {
               bool  SecondMenu = true;
                do
                {
                    Console.WriteLine("1)Работа с двумерным массивом");
                    Console.WriteLine("2)Работа с строкой");
                    Console.WriteLine("3)Выход");
                    checkTheInput = Int32.TryParse(Console.ReadLine(), out command1);
                    if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                } while (!checkTheInput);
                switch(command1)
                {
                    case 1:
                        do {
                            do
                            {
                                Console.WriteLine("\n1)Создание массива");
                                Console.WriteLine("2)Вывод массива в консоль");
                                Console.WriteLine("3)Удаление столбца с наименьшим элементом");
                                Console.WriteLine("4)Выход");
                                checkTheInput = Int32.TryParse(Console.ReadLine(), out command2);
                                if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                            } while (!checkTheInput);
                            switch (command2)
                            {
                                case 1:
                                    do
                                    {
                                        Console.WriteLine("\n1)Создать массив автоматически");
                                        Console.WriteLine("2)Создать массив вручную");
                                        checkTheInput = Int32.TryParse(Console.ReadLine(), out command3);
                                        if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                                    } while (!checkTheInput);
                                    switch (command3) 
                                    {
                                        case 1:
                                            CreateArrayAuto(ref matrix);
                                            break;
                                        case 2:
                                            CreateArrayManually(ref matrix);
                                            break;
                                        default:
                                            Console.WriteLine("\nНеправильный ввод!!!");
                                            break; 
                                    }
                                    break;
                                case 2:
                                    ShowArray(matrix);
                                    break;
                                case 3:
                                    DeleteColumn(ref matrix);
                                    break;
                                case 4:
                                    SecondMenu = false;
                                    break;
                                default:
                                    Console.WriteLine("\nНеправильный ввод!!!");
                                    break;
                            }
                        } while (SecondMenu);
                        
                        break;
                    case 2:
                        
                        do {
                            do
                            {
                                Console.WriteLine("\n1)Создание строки");
                                Console.WriteLine("2)Вывод строки в консоль");
                                Console.WriteLine("3)Поменять местами первое и последнее слово в строке");
                                Console.WriteLine("4)Выход");
                                checkTheInput = Int32.TryParse(Console.ReadLine(), out command2);
                                if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                            } while (!checkTheInput);
                            switch (command2)
                            {
                                case 1:
                                    do
                                    {
                                        Console.Write("\n\n1)Создать строку автоматически");
                                        Console.Write("\n2)Создать строку вручную\n");
                                        checkTheInput = Int32.TryParse(Console.ReadLine(), out command3);
                                        if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                                    } while (!checkTheInput);
                                    switch (command3)
                                    {
                                        case 1:
                                            CreateStringAuto(ref MainString,arraystrings);
                                            break;
                                        case 2:
                                            CreateStringManually(ref MainString);
                                            break;
                                        default:
                                            Console.WriteLine("\nНеправильный ввод!!!");
                                            break;
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("\nСтрока:"+MainString);
                                    break;
                                case 3:
                                    ReverseFirstLast(ref MainString);
                                    break;
                                case 4:
                                    SecondMenu = false;
                                    break;
                                default:
                                    Console.WriteLine("\nНеправильный ввод!!!");
                                    break;
                            }
                        } while (SecondMenu) ;

                        break;
                    case 3:
                        mainMenu = false;
                        break;
                    default:
                        Console.WriteLine("\nНеправильный ввод!!!");
                        break; 
                }
            } while(mainMenu);
                       

        }
    }
}




/*
         static void ReverseFirstLast(ref string ss) 
        {
            string buffString="";
            string[] words = ss.Split(' ', ',', '.','?','!');
            string[] marks = ss.Split('0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z');
            int indexFirstWord = 0;
            int indexLastWord = 0;
            bool Check=false;
            
          
            for (int i = 0; i < words.Length && !Check; i++) 
            {
                if (words[i] != "") 
                {
                    indexFirstWord = i;
                    Check = true; 
                }
            }
            

            for (int i = words.Length-1; i >=0&&Check; i--)
            {
                if (words[i] != "")
                {
                    indexLastWord = i;
                    Check = false;
                }
            }
            Console.WriteLine("1)" + words[indexFirstWord]+"  2)" + words[indexLastWord]);

            int indexWords = 0;
            int indexMarks = 0;
            if (ss[0] ==' '|| ss[0] == ','|| ss[0] == '.'||ss[0] == '?'||ss[0] == '!') 
            {
                buffString += marks[indexMarks];
                buffString += words[indexWords];
                while (indexWords < words.Length || indexMarks < marks.Length)
                {
                    indexWords++;
                    if (indexWords < words.Length)
                    {
                        while (words[indexWords] == "" && indexWords < words.Length - 1)
                        {
                            indexWords++;
                        }
                        buffString += words[indexWords];
                    }
                    indexMarks++;
                    if (indexMarks < marks.Length)
                    {
                        while (marks[indexMarks] == "" && indexMarks < marks.Length - 1)
                        {
                            indexMarks++;
                        }
                        buffString += marks[indexMarks];
                    }

                    
                }
            }
            else 
            {
                buffString += words[indexWords];
                buffString += marks[indexMarks];
                while (indexWords < words.Length || indexMarks < marks.Length) 
                {
                    indexMarks++;
                    if(indexMarks < marks.Length)
                    {
                        while (marks[indexMarks] == ""&& indexMarks < marks.Length-1)
                        {
                            indexMarks++;
                        }
                        buffString += marks[indexMarks];
                    }
                                      
                    indexWords++;
                    if (indexWords < words.Length)
                    {
                        while (words[indexWords] == ""&& indexWords < words.Length-1)
                        {
                        indexWords++;
                        }
                    
                        buffString += words[indexWords];
                    }
                }      
            }
            Console.WriteLine(buffString);
        }
         */