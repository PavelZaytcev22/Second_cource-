using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BestLibrary;

namespace Lab_9_C__beta
{
    internal class Program
    {
        static bool CheckPoint(Diapazon c1, double point) 
        {
            if (c1.GetX() > c1.GetY())
            {
                return point <= c1.GetX() && point >= c1.GetY();
            }
            else
            {
                return point >= c1.GetX() && point <= c1.GetY();
            }
        }

        static void FindMax(DiapazonArray zz)
        {
            if (zz == null || zz.GetLeng() == 0)
            {
                Console.WriteLine("\n!!!Коллекция пуста!!!");
            }
            else
            {
                double maxElemet = !zz[0];
                for (int i = 0; i < zz.GetLeng(); i++)
                {
                    if (maxElemet < !zz[i]) maxElemet = !zz[i];
                }
                Console.WriteLine("\n Максимальный диапазон: " + maxElemet);
            }
        }

        static void Main()
        {
            bool mainmenu = true;
            bool menu1 = true;
            int command1,maincommand;
            DiapazonArray c1 = null;
            do
            {
                maincommand = Functions.InputInt32("" +
                        "\n1)Первое задание" +
                        "\n2)Второе задание" +
                        "\n3)Третье задание" +
                        "\n4)Выход" +
                        "\nВведите номер команды");
                switch (maincommand) 
                {
                    case 1:
                        Diapazon firstDiapazon = new Diapazon(5.30,40.25);
                        Diapazon secondDiapazon = new Diapazon(-35.10, 15.25);
                        Console.WriteLine("Первый диапазон: ");
                        firstDiapazon.Print();
                        Console.WriteLine("\nВторой диапазон: ");
                        secondDiapazon.Print();
                        double firstpoint = 10.30;
                        double secondpoint = -100.30;
                        Console.WriteLine("\nПервая точка: "+firstpoint);
                        Console.WriteLine("\nВторая точка: " + secondpoint);
                        Console.WriteLine("\nПервая точка принадлежит первому диапазону ? Ответ: " +
                            firstDiapazon.CheckPoint(firstpoint));
                        Console.WriteLine("\nВторая точка принадлежит второму диапазону ? Ответ: " +
                            CheckPoint(secondDiapazon, secondpoint));
                        Console.Write("\n\nКолличество созданых Диапазонов = " + Diapazon.CountDiapazon+"\n\n");

                        break;

                    case 2:
                        Diapazon bigDiapazon = new Diapazon(10.30, 5.35);
                        Console.WriteLine("\nДиапазон: ");
                        bigDiapazon.Print();

                        Console.WriteLine("\n\nУнарные операции:");
                        Console.WriteLine("(!) Длина диапазона:"+!bigDiapazon);
                        Console.WriteLine("(++) Увеличение координат диапазона:");
                        bigDiapazon++;
                        bigDiapazon.Print();

                        Console.WriteLine("\n\nОперации приведения типа:");
                        int firstCommand = (int)bigDiapazon;
                        double secondCommand = bigDiapazon;
                        Console.WriteLine("int (явная) равна:" + firstCommand);
                        Console.WriteLine("double (неявная) равна:" + secondCommand);

                        Console.WriteLine("\n\nБинарные операции:");
                        Console.WriteLine("(+ int d ) Увеличение координат диапазона на число(например на 3):");
                        bigDiapazon = bigDiapazon + 3;
                        bigDiapazon.Print();
                        Console.WriteLine("\n(< Diapason d) Проверка принадлежности целого числа (например 8) :"+(8<bigDiapazon));
                        break;

                    case 3:
                        do
                        {
                            command1 = Functions.InputInt32("" +
                                "\n1)Создать коллекцию" +
                                "\n2)Вывести в консоль коллекцию" +
                                "\n3)Вывести элемент в консоль по индексу" +
                                "\n4)Вывести максимальную длину  диапазона из коллекции в консоль" +
                                "\n5)Подсчитать количество объектов в коллекции" +
                                "\n6)Выход" +
                                "\nВведите номер команды");
                            switch (command1)
                            {
                                case 1:
                                    int command2;
                                    int arrayLong;
                                    command2 = Functions.InputInt32("" +
                                        "\n1)Создать автоматически" +
                                        "\n2)Создать вручную" +
                                        "\nВведите номер команды");
                                    switch (command2)
                                    {
                                        case 1:

                                            do
                                            {
                                                arrayLong = Functions.InputInt32("\nВведите длину коллекции");
                                                if (arrayLong < 0)
                                                {
                                                    Console.WriteLine("\n!!Длина коллекции может быть только положительная!!\n");
                                                }
                                            } while (arrayLong < 0);

                                            c1 = new DiapazonArray(arrayLong, true);

                                            break;
                                        case 2:

                                            do
                                            {
                                                arrayLong = Functions.InputInt32("\nВведите длину коллекции");
                                                if (arrayLong < 0)
                                                {
                                                    Console.WriteLine("\n!!Длина коллекции может быть только положительная!!\n");
                                                }
                                            } while (arrayLong < 0);

                                            c1 = new DiapazonArray(arrayLong, false);
                                            break;
                                        default:
                                            Console.WriteLine("\n!!Ошибка ввода!!\n");
                                            break;
                                    }
                                    break;

                                case 2:
                                    if (c1 == null)
                                    {
                                        Console.WriteLine("\n!!!Коллекция неинициализирована!!!");
                                    }
                                    else
                                    {
                                        c1.Print();
                                    }

                                    break;
                                case 3:
                                    int index;
                                    do
                                    {
                                        index = Functions.InputInt32("\nВведите индекс");
                                        if (index < 0)
                                        {
                                            Console.WriteLine("\n!!Индекс может быть только положительным!!\n");
                                        }
                                    } while (index < 0);
                                    if (c1[index] == null)
                                    {
                                        Console.WriteLine("\nВыход за границы массива!!!!\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Элемент: [" + c1[index].GetX() + ";" + c1[index].GetY() + "]\n");
                                    }

                                    break;
                                case 4:
                                    FindMax(c1);
                                    break;
                                case 5:
                                    Console.WriteLine("Колличество элементов =" + c1.GetLeng());
                                    break;
                                case 6:
                                    menu1 = false;
                                    break;
                                default:
                                    Console.WriteLine("\n!!!Ошибка ввода!!!");
                                    break;
                            }
                        }while (menu1);
                        break;

                    case 4:
                        mainmenu = false;
                        break;

                    default:

                        break;
                }
            } while (mainmenu);

        }
    }

}
