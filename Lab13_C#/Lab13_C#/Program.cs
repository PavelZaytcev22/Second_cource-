using _10LabLibrary;
using _12LabLibrary;
using _13LabLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab13_C_
{
    public  class Program
    {
        static void Main(string[] args)
        {
            MyNewHashTable table1 = null;
            MyNewHashTable table2 = null;
            Journal journal1 = new Journal();
            Journal journal2 = new Journal();
            Challenge buffChallenge = new Challenge();
            Test buffTest = new Test();

            bool menu = true;
            int commandMainMenu;
            do 
            {
                Console.WriteLine("\n----------------------------------------------------------------------" +//ДОДЕЛАТЬ МЕНЮ 
                                   "\n1)Первая хэш таблица" +
                                   "\n2)Вторая хэш таблица" +
                                   "\n3)Журнал 1" +
                                   "\n4)Журнал 2" +                                       
                                   "\n-------------------------------------------------------------------");
                commandMainMenu = _10LabLibrary.Functions.InputInt32("Введите номер команды");
                switch (commandMainMenu) 
                {
                    case 1:
                        bool menu1 = true;
                        int commandMainMenu1;
                        do
                        {
                            Console.WriteLine("\n*****************************************************************" +//ДОДЕЛАТЬ МЕНЮ 
                                "\n1)Создать хэш таблицу" +
                                "\n2)Печать хэш таблицы" +
                                "\n3)Добавить случайный элемент в хэш таблицу" +
                                "\n4)Вывести количество элементов в хэш таблице" +
                                "\n5)Удалить элемент по номеру" +
                                "\n6)Сделать ссылку 'null' элемента по индексу" +
                                "\n7)Выход" +
                                "\n*****************************************************************");

                            commandMainMenu1 = _10LabLibrary.Functions.InputInt32("Введите номер команды");
                            switch (commandMainMenu1)
                            {
                                case 1:
                                    int longArray = _10LabLibrary.Functions.InputInt32("Введите длину таблицы");
                                    table1 = new MyNewHashTable("FIRST ", longArray);
                                    Console.WriteLine("\nКоллекция проинициализирована");
                                    if (table1.Length > 0) //Подписываем 
                                    {
                                        table1.CollectionCountChanged += new CollectionHandler(journal1.CollectionCountChanged);
                                        table1.CollectionReferenceChanged += new CollectionHandler(journal1.CollectionReferenceChanged);
                                        table1.CollectionReferenceChanged += new CollectionHandler(journal2.CollectionReferenceChanged);
                                    }

                                    break;
                                case 2:
                                    if (table1 != null)
                                    {
                                        table1.Print();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Коллекция не проинициализированна");
                                    }
                                    break;

                                case 3:
                                    if (table1 != null)
                                    {
                                        table1.AddRandom();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Коллекция не проинициализированна");
                                    }
                                    break;

                                case 4:
                                    if (table1 != null)
                                    {
                                        Console.WriteLine("Количество элементов в таблице:{0}", table1.Count);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Коллекция не проинициализированна");
                                    }
                                    break;
                                case 5:
                                    if (table1 != null) 
                                    {
                                        int number = _10LabLibrary.Functions.InputInt32("Введите номер элемента");
                                        Console.WriteLine("Удаление элемента по номеру {0} : {1}", number, table1.Remove(number));
                                    }
                                    else
                                    {
                                        Console.WriteLine("Коллекция не проинициализированна");
                                    }
                                    break;
                                case 6:
                                    int index1 = _10LabLibrary.Functions.InputInt32("Введите первый индекс");
                                    int index2 = _10LabLibrary.Functions.InputInt32("Введите второй индекс");
                                    try
                                    {
                                        table1[index1, index2] = null;
                                        Console.WriteLine("Получилось");
                                    }
                                    catch (IndexOutOfRangeException c)
                                    {
                                        Console.WriteLine(c.Message);
                                    }
                                    break;
                                case 7:
                                    menu1 = false;                                   
                                    break;
                                default:
                                    Console.WriteLine("!!!Ошибка ввода!!");
                                    break;
                            }
                        } while (menu1);
                        break;
                    case 2:

                        bool menu2 = true;
                        int commandMainMenu2;
                        do
                        {
                            Console.WriteLine("\n*****************************************************************" +//ДОДЕЛАТЬ МЕНЮ 
                                "\n1)Создать хэш таблицу" +
                                "\n2)Печать хэш таблицы" +
                                "\n3)Добавить случайный элемент в хэш таблицу" +
                                "\n4)Вывести количество элементов в хэш таблице" +
                                "\n5)Удалить элемент по номеру" +
                                "\n6)Сделать ссылку 'null' элемента по индексу" +
                                "\n7)Выход" +
                                "\n*****************************************************************");

                            commandMainMenu2 = _10LabLibrary.Functions.InputInt32("Введите номер команды");
                            switch (commandMainMenu2)
                            {
                                case 1:
                                    int longArray = _10LabLibrary.Functions.InputInt32("Введите длину таблицы");
                                    table2 = new MyNewHashTable("Second", longArray);
                                    Console.WriteLine("\nКоллекция проинициализирована");
                                    if (table2.Length > 0) //Подписываем 
                                    {
                                        table2.CollectionReferenceChanged += new CollectionHandler(journal2.CollectionReferenceChanged);
                                    }

                                    break;
                                case 2:
                                    if (table2 != null)
                                    {
                                        table2.Print();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Коллекция не проинициализированна");
                                    }
                                    break;

                                case 3:
                                    if (table2 != null)
                                    {
                                        table2.AddRandom();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Коллекция не проинициализированна");
                                    }
                                    break;

                                case 4:
                                    if (table2 != null)
                                    {
                                        Console.WriteLine("Количество элементов в таблице:{0}", table2.Count);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Коллекция не проинициализированна");
                                    }
                                    break;
                                case 5:
                                    if (table2 != null)
                                    {
                                        int number = _10LabLibrary.Functions.InputInt32("Введите номер элемента");
                                        Console.WriteLine("Удаление элемента по номеру {0} : {1}", number, table2.Remove(number));
                                    }
                                    else
                                    {
                                        Console.WriteLine("Коллекция не проинициализированна");
                                    }
                                    break;
                                case 6:
                                    int index1 = _10LabLibrary.Functions.InputInt32("Введите первый индекс");
                                    int index2 = _10LabLibrary.Functions.InputInt32("Введите второй индекс");
                                    try
                                    {
                                        table2[index1, index2] = null;
                                        Console.WriteLine("Получилось");
                                    }
                                    catch (IndexOutOfRangeException c)
                                    {
                                        Console.WriteLine(c.Message);
                                    }
                                    break;
                                case 7:
                                    menu2 = false;
                                    break;
                                default:
                                    Console.WriteLine("!!!Ошибка ввода!!");
                                    break;
                            }
                        } while (menu2);
                        break;
                    case 3:
                        Console.WriteLine("Первый");
                        journal1.Print();
                        break;
                    case 4:
                        Console.WriteLine("Второй");
                        journal2.Print();
                        break;
                }
            }
            while (menu);


           

            

        }
    }
}
