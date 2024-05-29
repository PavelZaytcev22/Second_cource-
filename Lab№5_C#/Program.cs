using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5_C_
{
    internal class Program
    {
        static int[] one_dimArray = null;//Одномерный массив
        static int[,] two_dimArray = null;//Двумерный массив
        static int[][] unevenArray= null;//Рваный массив
        static Random Randomer = new Random();//Датчик случайных чисел

        static void ShowArray(int[] array) //Функция для вывода одномерного массива 
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("\n!!!Массив пуст!!!\n");
            }
            else
            {
                Console.Write("\n[");
                foreach (int i in array)
                {
                    Console.Write(i + ",");
                }
                Console.Write("]");
            }
        }

        static void CreateArrayManually(ref int[] array)//Функция для создания одномерного массива вручную 
        {
            bool checkTheInput = false;
            int longArray;
            do
            {
                Console.WriteLine("Введите длину массива:");
                checkTheInput = Int32.TryParse(Console.ReadLine(), out longArray);
                if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                if (longArray < 0)
                {
                    Console.WriteLine("\n!!!Длина массива может быть только положительной!!!\n");
                    checkTheInput = false;
                }
            } while (!checkTheInput);

            array = new int[longArray];
            int buff;
            for (int i = 0; i < longArray; i++)
            {
                do
                {
                    Console.Write("\nВведите " +( i+1) + "-ый элемент массива:");
                    checkTheInput = Int32.TryParse(Console.ReadLine(), out buff);
                    if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                } while (!checkTheInput);
                array[i] = buff;
            }
            Console.WriteLine("\nМассив создан\n");
        }

        static void CreateArrayAuto(ref int[] array)//Функция для создания одномерного массива автоматически 
        {
            bool checkTheInput = false;
            int longArray;
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

            array = new int[longArray];
            int buff;
            for (int i = 0; i < longArray; i++)
            {
                buff = Randomer.Next(-150, 150);
                array[i] = buff;
            }
            Console.WriteLine("\nМассив создан\n");
        }

        static void DeleteElement(ref int[] array)//Функция для удаления элемента под номером 
        {
            int NumberOfElement;
            bool checkTheInput = false;
            if (array == null||array.Length==0)
            {
                Console.WriteLine("\n!!!Массив пуст!!!\n");
            }
            else 
            {
                do
                {
                    Console.WriteLine("\nВведите номер элемента:");
                    checkTheInput = Int32.TryParse(Console.ReadLine(), out NumberOfElement);
                    if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                    if (NumberOfElement < 1)
                    {
                        Console.WriteLine("\n!!!Номер элемента начинается с 1!!!\n");
                        checkTheInput = false;
                    }
                    if (NumberOfElement > array.Length)
                    {
                        Console.WriteLine("\n!!!Номер элемента больше длинны массива!!!\n");
                        checkTheInput = false;
                    }
                } while (!checkTheInput);

                int Counter = 0;
                int[] buffArray = new int[array.Length - 1];
                for (int i = 0; i < array.Length; i++)
                {
                    if (i + 1 != NumberOfElement)
                    {
                        buffArray[Counter] = array[i];
                        Counter++;
                    }
                }
                array = buffArray;
                if (array.Length == 0)
                {
                    Console.WriteLine("\nМассив стал пустым");
                }
                else
                {
                    Console.WriteLine("\nЭлемент под номером " + NumberOfElement + " был удален");
                }
            }
        }

        static void ShowArray(int[,] array) //Функция для вывода двумерного массива
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("\n!!!Массив пуст!!!\n");
            }
            else
            {
                Console.Write("\n");
                for (int i=0; i<array.GetLength(0);i++)
                {
                    Console.Write("\n[");
                    for (int j= 0; j < array.GetLength(1); j++) 
                    {
                        Console.Write(" "+array[i, j]);
                    }
                    Console.Write(" ]\n");
                }
            }
        }

        static void CreateArrayManually(ref int[,] array) //Функция для создания двумерного массива вручную
        {
            bool checkTheInput = false;
            int widthArray,longArray;
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

            array = new int[widthArray,longArray];
            int buff;
            for (int i = 0; i < widthArray; i++)
            {
                for (int j = 0; j < longArray; j++) 
                {
                    do
                    {
                        Console.Write("\nВведите [" + i +' '+j+ "]-ый элемент массива:");
                        checkTheInput = Int32.TryParse(Console.ReadLine(), out buff);
                        if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                    } while (!checkTheInput);
                    array[i,j] = buff;
                }
            }
        Console.WriteLine("\nМассив был создан");
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
                    array[i,j] = Randomer.Next(-150, 150);
                }
            }
            Console.WriteLine("\nМассив был создан");
        }

        static void AddLine(ref int[,] array) //Функция для добавление строки в начало двумерного массива 
        {
            bool checkTheInput;
            int[,] buffArray;
            int buff;
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("\n!!!Массив пуст!!!\n");
            }
            else
            {
                int command;
                do
                {
                    Console.Write("\nВведите номер команды:");
                    Console.Write("\n1)Автоматически");
                    Console.Write("\n2)Вручную\n");
                    checkTheInput = Int32.TryParse(Console.ReadLine(), out command);
                    if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                } while (!checkTheInput);
                switch (command) 
                {
                    case 1:
                        buffArray = new int[array.GetLength(0) + 1, array.GetLength(1)];
                        for (int i = 1; i < buffArray.GetLength(0); i++)
                        {

                            for (int j = 0; j < buffArray.GetLength(1); j++)
                            {
                                buffArray[i, j] = array[i - 1, j];
                            }

                        }
                        for (int i = 0; i < buffArray.GetLength(1); i++)
                        {
                            buffArray[0, i] = Randomer.Next(-150,100) ;
                        }
                        array = buffArray;
                        break;
                    case 2:
                        buffArray = new int[array.GetLength(0) + 1, array.GetLength(1)];
                        for (int i = 1; i < buffArray.GetLength(0); i++)
                        {

                            for (int j = 0; j < buffArray.GetLength(1); j++)
                            {
                                buffArray[i, j] = array[i - 1, j];
                            }

                        }
                        for (int i = 0; i < buffArray.GetLength(1); i++)
                        {
                            do
                            {
                                Console.Write("\nВведите [" + 0 + ' ' + i + "]-ый элемент нового массива массива:");
                                checkTheInput = Int32.TryParse(Console.ReadLine(), out buff);
                                if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                            } while (!checkTheInput);
                            buffArray[0, i] = buff;
                        }
                        array = buffArray;
                        break;
                    default:
                        Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                        break;
                }                
                Console.WriteLine("\nСтрока была добавлена в начало массива");
            }
        }

        static void ShowArray(int[][] array)//Функция для вывода рваного массива 
        {
            if (array == null || array.Length==0)
            {
                Console.WriteLine("\n!!!Массив пуст!!!\n");
            }
            else
            {
                Console.Write("\n");
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    Console.Write("\n[");
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        Console.Write(" " + array[i][j]);
                    }
                    Console.Write(" ]\n");
                }
            }
        }

        static void CreateArrayManually(ref int[][] array) //Функция для создания рваного массива автоматически
        {
            bool checkTheInput = false;
            int widthArray, longRow;
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

            array = new int[widthArray][];

            for (int i = 0; i < array.GetLength(0); i++) 
            {
                do
                {
                    Console.WriteLine("Введите длинну "+ (i+1)+"-ой строки- строки:");
                    checkTheInput = Int32.TryParse(Console.ReadLine(), out longRow);
                    if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                    if (longRow < 0)
                    {
                        Console.WriteLine("\n!!!Длинна строки может быть только положительной!!!\n");
                        checkTheInput = false;
                    }
                } while (!checkTheInput);

                array[i] = new int[longRow];
            }

            int buff;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    do
                    {
                        Console.Write("\nВведите [" + i + ' ' + j + "]-ый элемент массива:");
                        checkTheInput = Int32.TryParse(Console.ReadLine(), out buff);
                        if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                    } while (!checkTheInput);
                    array[i][j] = buff;
                }
            }
            Console.WriteLine("\nМассив создан\n");
        }

        static void CreateArrayAuto(ref int[][] array) //Функция для создания рваного массива автоматически
        {
            bool checkTheInput = false;
            int widthArray, longRow;
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

            array = new int[widthArray][];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                do
                {
                    Console.WriteLine("Введите длинну " + (i + 1) + "-ой строки- строки:");
                    checkTheInput = Int32.TryParse(Console.ReadLine(), out longRow);
                    if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                    if (longRow < 0)
                    {
                        Console.WriteLine("\n!!!Длинна строки может быть только положительной!!!\n");
                        checkTheInput = false;
                    }
                } while (!checkTheInput);

                array[i] = new int[longRow];
            }

            
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    
                    array[i][j] = Randomer.Next(-150,150);
                }
            }
            Console.WriteLine("\nМассив создан\n");
        }

        static void DeleteStrings(ref int[][] array) //Функция для удаления строк из рваного массива 
        {
            
            bool checkTheInput;
            int lineNumber, numberOfString;
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("\n!!!Массив пуст!!!\n");
            }
            else 
            {
                Console.WriteLine("Колличество строк в массиве =" + array.Length + '\n');
                do
                {
                    Console.WriteLine("Введите номер строки:");
                    checkTheInput = Int32.TryParse(Console.ReadLine(), out lineNumber);
                    if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                    if (lineNumber < 1 || lineNumber > array.Length)
                    {
                        Console.WriteLine("\n!!!Номер строки начинается с 1 и идет до "+array.Length + " !!!\n");
                        checkTheInput = false;
                    }
                } while (!checkTheInput);

                do
                {
                    Console.WriteLine("Введите количество строк:");
                    checkTheInput = Int32.TryParse(Console.ReadLine(), out numberOfString);
                    if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                    if (numberOfString < 0)
                    {
                        Console.WriteLine("\n!!!Нельзя удалить отрицательное количество строк!!!\n");
                        checkTheInput = false;
                    }
                } while (!checkTheInput);

                int[][] buffArray;
                if (array.Length - lineNumber + 1 < numberOfString)
                {
                    Console.WriteLine("\n!!!Такого числа элементов в массиве нет!!!\n");
                }

                if (array.Length - lineNumber+1 == numberOfString)
                {
                    buffArray = new int[array.Length - (array.Length-lineNumber+1)][];
                    for (int i = 0; i < buffArray.Length; i++)
                    {
                        buffArray[i] = array[i];
                    }
                    array = buffArray;
                }
                else 
                {
                    if (array.Length - lineNumber+1 > numberOfString) 
                    {
                        buffArray = new int[array.Length - numberOfString][];
                        int indexbuff = 0;
                        for (int index = 0; index < array.Length; index++) 
                        {                        
                            if (index< (lineNumber-1) || index > (lineNumber+ numberOfString-2) ) 
                            {
                                buffArray[indexbuff] = array[index];
                                indexbuff++;
                            }
                        }
                        array = buffArray;
                    }
                    
                }
                if (array.Length == 0)
                {
                    Console.WriteLine("\nМассив стал пустым");
                }
                else 
                {
                    Console.WriteLine("\nСтроки были удалены");
                }
            }
        }

        static void Main()
        {
            try
            {
                bool mainmenu = true;
                bool second_menu;
                bool checkTheInput;
                int command1, command2, command2_2;
                while (mainmenu) 
                {
                    Console.WriteLine("\n1)Работа с одномерным массивом");
                    Console.WriteLine("2)Работа с двумерным массивом");
                    Console.WriteLine("3)Работа с рваным массивом");
                    Console.WriteLine("4)Выход");
                    do
                    {
                        Console.WriteLine("\nВведите номер команды:");
                        
                        checkTheInput = Int32.TryParse(Console.ReadLine(), out command1);
                        if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                    } while (!checkTheInput);
              
                    switch (command1)
                    { 
                        case 1:
                            second_menu = true;

                            while (second_menu) 
                            {
                                Console.WriteLine("\n1)Создать одномерный массив");
                                Console.WriteLine("2)Вывести массив в консоль");
                                Console.WriteLine("3)Удалить элемент под номером");
                                Console.WriteLine("4)Назад");
                                do
                                {
                                    Console.WriteLine("\nВведите номер команды:");
                                    checkTheInput = Int32.TryParse(Console.ReadLine(), out command2);
                                    if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                                } while (!checkTheInput);
                                switch (command2)
                                {
                                    case 1:
                                        Console.WriteLine("\n1)Автоматически");
                                        Console.WriteLine("2)Вручную");
                                        do
                                        {
                                            Console.WriteLine("\nВведите номер команды:");
                                            checkTheInput = Int32.TryParse(Console.ReadLine(), out command2_2);
                                            if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                                        } while (!checkTheInput);
                                        switch (command2_2) 
                                        {
                                            case 1:
                                                CreateArrayAuto(ref one_dimArray);
                                                break;
                                            case 2:
                                                CreateArrayManually(ref one_dimArray);
                                                break;
                                            default: 
                                                Console.WriteLine("\n!!!Неправильный ввод!!!!");
                                                break;
                                        }
                                        break;
                                    case 2:
                                        ShowArray(one_dimArray);
                                        Console.WriteLine();
                                        break;
                                    case 3:
                                        DeleteElement(ref one_dimArray);
                                        break;
                                    case 4:
                                        second_menu = false;
                                        break;
                                    default:
                                        Console.WriteLine("\n!!!Неправильный ввод!!!!");
                                        break;
                                }
                            }
                            break;

                        case 2:
                            second_menu = true;

                            while (second_menu)
                            {
                                Console.WriteLine("\n1)Создать двумерный массив");
                                Console.WriteLine("2)Вывести массив в консоль");
                                Console.WriteLine("3)Добавить строку");
                                Console.WriteLine("4)Назад");
                                do
                                {
                                    Console.WriteLine("\nВведите номер команды:");
                                    checkTheInput = Int32.TryParse(Console.ReadLine(), out command2);
                                    if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                                } while (!checkTheInput);
                                switch (command2)
                                {
                                    case 1:
                                        Console.WriteLine("\n1)Автоматически");
                                        Console.WriteLine("2)Вручную");
                                        do
                                        {
                                            Console.WriteLine("\nВведите номер команды:");
                                            checkTheInput = Int32.TryParse(Console.ReadLine(), out command2_2);
                                            if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                                        } while (!checkTheInput);
                                        switch (command2_2)
                                        {
                                            case 1:
                                                CreateArrayAuto(ref two_dimArray);
                                                break;
                                            case 2:
                                                CreateArrayManually(ref two_dimArray);
                                                break;
                                            default:
                                                Console.WriteLine("\n!!!Неправильный ввод!!!!");
                                                break;
                                        }
                                        break;
                                    case 2:
                                        ShowArray(two_dimArray);
                                        Console.WriteLine();
                                        break;
                                    case 3:
                                        AddLine(ref two_dimArray);
                                        break;
                                    case 4:
                                        second_menu = false;
                                        break;
                                    default:
                                        Console.WriteLine("\n!!!Неправильный ввод!!!!");
                                        break;
                                }
                            }
                            break;
                        case 3:
                            second_menu = true;

                            while (second_menu)
                            {
                                Console.WriteLine("\n1)Создать рваный массив");
                                Console.WriteLine("2)Вывести массив в консоль");
                                Console.WriteLine("3)Уалить с N-ой позиции K строк");
                                Console.WriteLine("4)Назад");
                                do
                                {
                                    Console.WriteLine("\nВведите номер команды:");
                                    checkTheInput = Int32.TryParse(Console.ReadLine(), out command2);
                                    if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                                } while (!checkTheInput);
                                switch (command2)
                                {
                                    case 1:
                                        Console.WriteLine("\n1)Автоматически");
                                        Console.WriteLine("2)Вручную");
                                        do
                                        {
                                            Console.WriteLine("\nВведите номер команды:");
                                            checkTheInput = Int32.TryParse(Console.ReadLine(), out command2_2);
                                            if (!checkTheInput) Console.WriteLine("\n!!!Ошибка ввода!!!\n");
                                        } while (!checkTheInput);
                                        switch (command2_2)
                                        {
                                            case 1:
                                                CreateArrayAuto(ref unevenArray);
                                                break;
                                            case 2:
                                                CreateArrayManually(ref unevenArray);
                                                break;
                                            default:
                                                Console.WriteLine("\n!!!Неправильный ввод!!!!");
                                                break;
                                        }
                                        break;
                                    case 2:
                                        ShowArray(unevenArray);
                                        Console.WriteLine();
                                        break;
                                    case 3:
                                        DeleteStrings(ref unevenArray);
                                        break;
                                    case 4:
                                        second_menu = false;
                                        break;
                                    default:
                                        Console.WriteLine("\n!!!Неправильный ввод!!!!");
                                        break;
                                }
                            }
                            break;
                        case 4:
                            mainmenu = false;
                            break;
                        default:
                            Console.WriteLine("\n!!!Неправильный ввод!!!!");
                            break;
                    }
                }
                
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
