using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using _10LabLibrary;
using _12LabLibrary;


namespace Lab12_C_
{
    internal class Program
    {
        static void Main()
        {
            HashTable<Challenge> table = new HashTable<Challenge>();
            HashTable<Challenge> ShallowCopy = new HashTable<Challenge>();
            HashTable<Challenge> DeepCopy = new HashTable<Challenge>();
            Challenge buffChallenge = new Challenge();
            Test buffTest = new Test();

            int counter = 1;

            bool menu = true;
            int commandMainMenu;
            do
            {
                Console.WriteLine("\n*****************************************************************" +
                    "\n1)Создать хэш таблицу" +
                    "\n2)Добавить случайный элемент в хэш таблицу" +
                    "\n3)Найти элемент" +
                    "\n4)Удаление элемента в таблице" +
                    "\n5)Количество элементов в таблице" +
                    "\n6)Очистить таблицу" +
                    "\n7)Копирование поверхностное и глубокое" +
                    "\n8)Печать таблицы" +
                    "\n9)Выход" +
                    "\n*****************************************************************");

                commandMainMenu = _10LabLibrary.Functions.InputInt32("Введите номер команды");
                switch (commandMainMenu)
                {
                    case 1:
                        int longArray = _10LabLibrary.Functions.InputInt32("Введите длину таблицы");
                        table = new HashTable<Challenge>(longArray);
                        Console.WriteLine("\nКоллекция проинициализирована");
                        break;
                    case 2:
                        if (counter % 2 == 0)
                        {
                            counter++;
                            buffChallenge.RandomInit();
                            try
                            {
                                table.Add(new Challenge(buffChallenge));
                            }
                            catch (Exception c) 
                            {
                                Console.WriteLine(c.Message);
                            }
                        }
                        else
                        {
                            counter++;
                            buffTest.RandomInit();
                            try
                            {
                                table.Add(new Test(buffTest));
                            }
                            catch (Exception c)
                            {
                                Console.WriteLine(c.Message);
                            }
                        }

                        if (table.Length != 0) Console.WriteLine("\n!!!Элемент добавлен!!");
                        break;
                    case 3:
                        Console.WriteLine("\n1)Класс бызовый" +
                            "\n2)Класс производный");
                        int command3 = _10LabLibrary.Functions.InputInt32("Выбирите класс:");
                        switch (command3)
                        {
                            case 1:
                                buffChallenge.Init();
                                Console.WriteLine("\nЭлемент {1} найден:{0}", table.Contains(buffChallenge), buffChallenge);
                                break;
                            case 2:
                                buffTest.Init();
                                Console.WriteLine("\nЭлемент {1} найден:{0}", table.Contains(buffTest), buffTest);
                                break;
                            default:
                                Console.WriteLine("Ошибка ввода");
                                break;
                        }
                        break;
                    case 4:
                        Console.WriteLine("\n1)Класс бызовый" +
                            "\n2)Класс производный");
                        int command4 = _10LabLibrary.Functions.InputInt32("Выбирете класс");

                        switch (command4)
                        {
                            case 1:
                                buffChallenge.Init();
                                Console.WriteLine("\nЭлемент {1} удален:{0}", table.Remove(buffChallenge), buffChallenge);
                                break;
                            case 2:
                                buffTest.Init();
                                Console.WriteLine("\nЭлемент {1} удален:{0}", table.Remove(buffTest), buffTest);
                                break;
                            default:
                                Console.WriteLine("Ошибка ввода");
                                break;
                        }

                        break;
                    case 5:
                        Console.WriteLine("Элементов в таблице:{0}", table.Count);
                        break;
                    case 6:
                        table.Clear();
                        Console.WriteLine("\nКоллекция пуста");
                        break;
                    case 7:
                        Console.WriteLine("1)Создать копии" +
                            "\n2)Вывести копии в консоль");
                        int command6 = _10LabLibrary.Functions.InputInt32("Введите номер комманды");
                        switch (command6)
                        {
                            case 1:
                                ShallowCopy = table.ShallowCopy();
                                DeepCopy = (HashTable<Challenge>)table.Clone();
                                Console.WriteLine("!!!Копии созданы!!!!");
                                break;
                            case 2:
                                Console.WriteLine("\nПоверхностная копия");
                                ShallowCopy.Print();
                                Console.WriteLine("\nГлубокая копия");
                                DeepCopy.Print();
                                break;
                            default:
                                Console.WriteLine("!!!Ошибка ввода!!");
                                break;
                        }
                        break;
                    case 8:
                        table.Print();
                        break;
                    case 9:
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("!!!Ошибка ввода!!");
                        break;
                }
            } while (menu);




        }


    }
}
