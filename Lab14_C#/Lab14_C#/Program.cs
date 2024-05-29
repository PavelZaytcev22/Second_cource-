using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using _10LabLibrary;
using _12LabLibrary;
using _13LabLibrary;

namespace Lab14_C_
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Stack<Dictionary<string,Challenge>> book = new Stack<Dictionary<string,Challenge>>(40);//Коллекция для первой части 
            HashTable<Challenge> table = new HashTable<Challenge>();
            Challenge buffChallenge = new Challenge();
            Test buffTest = new Test();
            int randomer = 0;
            int longArray = 0;

            bool menu = true;
            do 
            {
                Console.WriteLine("\n****************************************************************************" +
                       "\n1)Первая часть" +
                       "\n2)Вторая часть");
                int commmandMain = _10LabLibrary.Functions.InputInt32("Введите номер команды");
                switch (commmandMain) 
                {
                    case 1:
                        bool menu1 = true;
                        int commandMenu1 = 0;

                        do
                        {
                            Console.WriteLine("\n--------------------------------------------------------------------" +
                                "\n1)Создать коллекцию" +
                                "\n2)Заполнить коллекцию" +
                                "\n3)Печать Стека" +
                                "\n4)Запросы" +
                                "\n5)Выход");
                            commandMenu1 = _10LabLibrary.Functions.InputInt32("Введите номер команды");
                            switch (commandMenu1)
                            {
                                case 1:
                                    longArray = _10LabLibrary.Functions.InputInt32("Введите длину коллекции:");
                                    if (longArray < 0)
                                    {
                                        Console.WriteLine("Нельзя создать коллекцию отрицательной длины");
                                    }
                                    else
                                    {
                                        book = new Stack<Dictionary<string, Challenge>>(longArray);
                                    }
                                    break;
                                case 2:
                                    if (longArray > 0)
                                    {
                                        for (int y = 0; y < longArray; y++)
                                        {
                                            Dictionary<string, Challenge> buffDictionary = new Dictionary<string, Challenge>();
                                            for (int i = 0; i < 4; i++)
                                            {
                                                if (randomer % 2 == 1)
                                                {
                                                    randomer++;
                                                    Challenge buff = new Challenge();
                                                    buff.RandomInit();
                                                    buffDictionary.Add(buff.ToString(), new Challenge(buff));
                                                }
                                                else
                                                {
                                                    randomer++;
                                                    Test buff1 = new Test();
                                                    buff1.RandomInit();
                                                    buffDictionary.Add(buff1.ToString(), new Test(buff1));
                                                }
                                                Console.WriteLine("\nЭлемент добавлен");
                                            }
                                            book.Push(buffDictionary);
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("!!!Коллекция нулевой длины!!!");
                                    }
                                    break;
                                case 3:
                                    if (longArray <= 0) Console.WriteLine("\n!!!!Таблица не создана!!!!");
                                    int counter = 0;
                                    foreach (var i in book)
                                    {
                                        Console.WriteLine("[" + counter + "]");
                                        foreach (var j in i)
                                        {
                                            var b1 = j.Value;
                                            if (b1 != null)
                                            {
                                                Console.WriteLine("|\nV");
                                                Console.WriteLine(b1);
                                            }
                                            else
                                            {
                                                Console.WriteLine("|\nV");
                                                Console.WriteLine("[ NULL ]");
                                            }
                                        }
                                        Console.WriteLine("|\nV\nNULL\n");
                                        counter++;
                                    }
                                    break;

                                case 4:
                                    
                                    Console.WriteLine("\nЗапросы:\n");

                                    List<Challenge> Persons = Queries.Select1(book);
                                    Console.WriteLine("Выборка:");
                                    foreach (var i in Persons)
                                    {
                                        Console.WriteLine(i);
                                    }

                                    int plus = Queries.Count1(Persons);

                                    Console.WriteLine("\nСчетчик где вопросов больше 50 :{0}", plus);

                                    List<Challenge> Persons2 = new List<Challenge>();
                                    IEnumerator<Challenge> bbb = Persons.GetEnumerator();
                                    bbb.MoveNext();
                                    for (int y = 0; y < Persons.Count / 2; y++)
                                    {
                                        Persons2.Add(bbb.Current);
                                        bbb.MoveNext();
                                    }

                                    var Excepted = Queries.SetOperation1(Persons, Persons2);//Операция над множествами(коллекциями)
                                    Console.WriteLine("\nПересечение множеств:");
                                    foreach (Challenge bb in Excepted)
                                    {
                                        Console.WriteLine(bb);
                                    }


                                    Console.WriteLine("\nАгрегация:");

                                    Console.WriteLine("Максимальный элемент по вопросам = {0}", (from c in Persons select c).Max());
                                    Console.WriteLine("Минимальный элемент по вопросам = {0}", (from c in Persons select c).Min());

                                    /* Func<Challenge, string> group = delegate (Challenge c1)//Для группировки 
                                     {
                                         return c1.Name;
                                     };*/

                                    IEnumerable<IGrouping<string, Challenge>> Group = Queries.Group1(Persons);
                                    Console.WriteLine("\nГруппировка по названию:");
                                    int count = 0;
                                    foreach (var i in Group)
                                    {
                                        int bb = i.Count();
                                        foreach (var j in i)
                                        {
                                            
                                            Console.WriteLine(j);
                                        }
                                        Console.WriteLine("\nКоличество"+bb);
                                    }

                                    Console.WriteLine("Философия ={0}",count);

                                    


                                    Console.WriteLine("\n*******************************************************************************");

                                    Persons = Queries.Select2(book);
                                    
                                    Console.WriteLine("Выборка:");
                                    foreach (var i in Persons)
                                    {
                                        Console.WriteLine(i);
                                    }

                                    Func<Challenge, bool> nnn = delegate (Challenge bb)
                                    {
                                        if (bb.Questions > 50) return true;
                                        return false;
                                    };
                                    plus = Persons.Where(nnn).Count();
                                    Console.WriteLine("\nСчетчик где вопросов больше 50 :{0}", plus);

                                    Excepted = Queries.SetOperation2(Persons,Persons2);//Операция над множествами(коллекциями)
                                    Console.WriteLine("\nРазность множеств:");
                                    foreach (Challenge bb in Excepted)
                                    {
                                        Console.WriteLine(bb);
                                    }

                                    Queries.MaxMin2(Persons);                              

                                    var group11 = Queries.Group2(Persons);

                                    Console.WriteLine("\nГруппировка меньше и больше 100 заданий:");
                                    foreach (var i in group11)
                                    {
                                        foreach (var j in i)
                                        {
                                            Console.WriteLine(j);
                                        }
                                    }
                                    break;
                                case 5:
                                    menu1 = false;
                                    break;
                                default:
                                    Console.WriteLine("!!!!!Ошибка ввода !!");
                                    break;
                            }
                        } while (menu1);
                        break;
                    case 2:
                        bool menu2 = true;

                        do 
                        {
                            Console.WriteLine("\n--------------------------------------------------------------"+
                                "\n1)Создать хэш таблицу" +
                                "\n2)Печать хэш таблицы" +
                                "\n3)Добавить случайный элемент в хэш таблицу"+
                                "\n4)Выборка по условию(больше 150) " +
                                "\n5)Агрегация" +
                                "\n6)Сортировка " +
                                "\n7)Выход");
                            int commandMenu2 = _10LabLibrary.Functions.InputInt32("Введите номер комманды");

                            switch (commandMenu2)
                            {
                                case 1:
                                    int longArray1 = _10LabLibrary.Functions.InputInt32("Введите длину таблицы");
                                    table = new HashTable<Challenge>(longArray1);
                                    Console.WriteLine("\nКоллекция проинициализирована");                          

                                    break;
                                case 2:
                                    if (table != null)
                                    {
                                        table.Print();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Коллекция не проинициализированна");
                                    }
                                    break;

                                case 3:
                                    if (table != null)
                                    {
                                        if (randomer % 2 == 1)
                                        {
                                            randomer++;
                                            buffChallenge.RandomInit();
                                            table.Add(new Challenge(buffChallenge));
                                        }
                                        else
                                        {
                                            randomer++;
                                            Test buff1 = new Test();
                                            buff1.RandomInit();
                                            table.Add(new Test(buff1));
                                        }
                                        Console.WriteLine("+++++");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Коллекция не проинициализированна");
                                    }
                                    break;
                                case 4:
                                    if (table != null)
                                    {
                                        var collection=table.Where( p => p.Questions>150 );
                                        Console.WriteLine("Выборка где заданий больше 150:");
                                        foreach (var i in collection) 
                                        {
                                            Console.WriteLine(i);
                                        }
                                    }
                                    else 
                                    {
                                        Console.WriteLine("Коллекция не проинициализированна");
                                    }
                                    break;
                                case 5:
                                    if (table != null)
                                    {
                                        Console.WriteLine("Минимальный элемент: {0}",table.Min());
                                        Console.WriteLine("Максимальный элемент: {0}", table.Max());
                                    }
                                    else
                                    {
                                        Console.WriteLine("Коллекция не проинициализированна");
                                    }
                                    break;
                                case 6:
                                    table.Sort();
                                    Console.WriteLine("Сортировка:+");
                                    break;
                                case 7:
                                    menu2 = false;
                                    break;
                                default:
                                    Console.WriteLine("!!!!!Ошибка ввода !!");
                                    break;
                            }
                        } while (menu2);
                        break; 

                }

            } while (menu);

            

        }
    }
}
