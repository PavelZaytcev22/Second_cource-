using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using _10LabLibrary;
using _11LabLibrary;

namespace Lab_11_С_
{
    internal class Program
    {

        static void Main()
        {
            TestCollections c1 = new TestCollections(1000);

            c1.CheckTime();
          /*  FinalExam buff = new FinalExam();
            buff.RandomInit();
            buff.Show();*/
        }

        public static void Querry(Hashtable table) 
        {
            int counter = 0;
            Test f;
            Exam z;
            FinalExam c;
            foreach (DictionaryEntry xx in table)
            {
                object p = xx.Value;
                if (p is Test) 
                {
                    f = (Test)p;
                    if (f != null && f.Name == "Геометрия") counter++;
                }
                if (p is Exam) 
                {
                    z = (Exam)p;
                    if (z != null && z.Name == "Геометрия") counter++;
                }
                if (p is FinalExam) 
                {
                    c = (FinalExam)p;
                    if (c != null && c.Name == "Геометрия") counter++;
                }
            }
            Console.WriteLine("\n\nПридеметов c названием Геометрия в хэш таблице ="+counter);
            counter = 0;

            foreach (DictionaryEntry xx in table)
            {
                object p = xx.Value;
                if (p is Test)
                {
                    f = (Test)p;
                    if (f != null && f.Questions>10) counter++;
                }
                if (p is Exam)
                {
                    z = (Exam)p;
                    if (z != null && z.Questions > 10) counter++;
                }
                if (p is FinalExam)
                {
                    c = (FinalExam)p;
                    if (c != null && c.Questions > 10) counter++;
                }
            }

            Console.WriteLine("Количество элементов, где заданий больше 10 =" + counter);
            counter = 0;
            foreach (DictionaryEntry xx in table)
            {
                object p = xx.Value;
                if (p is Test)
                {
                    f = (Test)p;
                    if (f != null && f.Date == "10/10/10") counter++;
                }
                if (p is Exam)
                {
                    z = (Exam)p;
                    if (z != null && z.Date == "10/10/10") counter++;
                }
                if (p is FinalExam)
                {
                    c = (FinalExam)p;
                    if (c != null && c.Date == "10/10/10") counter++;
                }
            }

            Console.WriteLine("Количество элементов, где дата равна 10/10/10 = " + counter);
        }

        public static void Querry(Queue<Challenge> table)
        {
            int counter = 0;
            Test f;
            Exam z;
            FinalExam c;
            foreach (Challenge xx in table)
            {
                object p = xx;
                if (p is Test)
                {
                    f = (Test)p;
                    if (f != null && f.Name == "Геометрия") counter++;
                }
                if (p is Exam)
                {
                    z = (Exam)p;
                    if (z != null && z.Name == "Геометрия") counter++;
                }
                if (p is FinalExam)
                {
                    c = (FinalExam)p;
                    if (c != null && c.Name == "Геометрия") counter++;
                }
            }
            Console.WriteLine("\n\nПридеметов c названием Геометрия в хэш таблице =" + counter);
            counter = 0;

            foreach (Challenge xx in table)
            {
                object p = xx;
                if (p is Test)
                {
                    f = (Test)p;
                    if (f != null && f.Questions > 10) counter++;
                }
                if (p is Exam)
                {
                    z = (Exam)p;
                    if (z != null && z.Questions > 10) counter++;
                }
                if (p is FinalExam)
                {
                    c = (FinalExam)p;
                    if (c != null && c.Questions > 10) counter++;
                }
            }

            Console.WriteLine("Количество элементов, где заданий больше 10 =" + counter);
            counter = 0;
            foreach (Challenge xx in table)
            {
                object p = xx;
                if (p is Test)
                {
                    f = (Test)p;
                    if (f != null && f.Date == "10/10/10") counter++;
                }
                if (p is Exam)
                {
                    z = (Exam)p;
                    if (z != null && z.Date == "10/10/10") counter++;
                }
                if (p is FinalExam)
                {
                    c = (FinalExam)p;
                    if (c != null && c.Date == "10/10/10") counter++;
                }
            }

            Console.WriteLine("Количество элементов, где дата равна 10/10/10 = " + counter);
        }

     
        public static void FirstMenu() 
        {
            bool menu1 = true;
            Hashtable firstArray = new Hashtable();
            Random randomer = new Random();
            while (menu1) 
              {
                Console.WriteLine("\n\n1)Добавить элемент");
                Console.WriteLine("2)Удалить элемент");
                Console.WriteLine("3)Запросы");
                Console.WriteLine("4)Вывод хэш таблицы в консоль");
                Console.WriteLine("5)Клонирование");
                Console.WriteLine("6)Поиск");
                Console.WriteLine("7)Выход");
                int command = Functions.InputInt32("Введите команду");   
                switch (command) 
                {
                    case 1:
                        Console.WriteLine("\n\n1)Класс Test");
                        Console.WriteLine("2)Класс Exam");
                        Console.WriteLine("3)Класс FinalExam");
                        int command2 = Functions.InputInt32("Введите команду");
                        switch(command2)
                        {
                            case 1:
                                Test test = new Test();
                                test.RandomInit();
                                firstArray.Add(randomer.Next(0, 100), test);
                                Console.WriteLine("!!!Элемент добавлен!!!");
                                break;
                            case 2:
                                Exam zzzz = new Exam();
                                zzzz.RandomInit();
                                firstArray.Add(randomer.Next(0, 100), zzzz);
                                Console.WriteLine("!!!Элемент добавлен!!!");
                                break;
                            case 3:
                                FinalExam ccccc = new FinalExam();
                                ccccc.RandomInit();
                                firstArray.Add(randomer.Next(0, 100), ccccc);
                                Console.WriteLine("!!!Элемент добавлен!!!");
                                break;
                            default:
                                Console.WriteLine("!!!Неправильный ввод!!!");
                                break;
                        }
                        break;
                    case 2:
                        int key = Functions.InputInt32("Введите ключ для удаления");
                        firstArray.Remove(key);
                        Console.WriteLine("\n!!!Элемент удален!!!");
                        break;
                            case 3:
                        Querry(firstArray);

                            break;
                    case 4:
                       
                        if (firstArray.Count==0)
                        {
                            Console.WriteLine("\n!!!Хэш таблица пуста!!!");
                        }
                        else 
                        {
                            Console.WriteLine();
                            foreach (DictionaryEntry i in firstArray)
                            {
                                Challenge vv = new Challenge();
                                if (i.Value is Test)
                                {
                                    vv = (Test)i.Value;
                                }
                                if (i.Value is Exam)
                                {
                                    vv = (Exam)i.Value;
                                }
                                if (i.Value is FinalExam)
                                {
                                    vv = (FinalExam)i.Value;
                                }
                                Console.Write("\n [{0}]", i.Key);
                                vv.Show();
                            }
                        }   
                        break;
                    case 5:
                        Hashtable ht = (Hashtable)firstArray.Clone();
                        Console.WriteLine("!!!Клон инициализирован!!!");
                        break;
                    case 6:
                        int key1 = Functions.InputInt32("Введите ключ");
                        Console.WriteLine("Содержится ли по данному ключу значение в таблице?\n Ответ: "+firstArray.ContainsKey(key1));
                        break;
                    case 7:
                        menu1 = false;
                        break;
                }
            }  
        }

        public static void SecondMenu()
        {
            bool menu1 = true;
            Queue<Challenge>firstArray = new Queue<Challenge>();
            Random randomer = new Random();
            while (menu1)
            {
                Console.WriteLine("\n\n1)Добавить элемент в конец");
                Console.WriteLine("2)Удалить элемент c начала очереди");
                Console.WriteLine("3)Запросы");
                Console.WriteLine("4)Вывод очереди в консоль");
                Console.WriteLine("5)Клонирование");
                Console.WriteLine("6)Поиск");
                Console.WriteLine("7)Выход");
                int command = Functions.InputInt32("Введите команду");
                switch (command) 
                {
                    case 1:
                        Console.WriteLine("\n\n1)Класс Test");
                        Console.WriteLine("2)Класс Exam");
                        Console.WriteLine("3)Класс FinalExam");
                        int command2 = Functions.InputInt32("Введите команду");
                        switch (command2)
                        {
                            case 1:
                                Test test = new Test();
                                test.RandomInit();
                                firstArray.Enqueue(test);
                                Console.WriteLine("!!!Элемент добавлен!!!");
                                break;
                            case 2:
                                Exam zzzz = new Exam();
                                zzzz.RandomInit();
                                firstArray.Enqueue(zzzz);
                                Console.WriteLine("!!!Элемент добавлен!!!");
                                break;
                            case 3:
                                FinalExam ccccc = new FinalExam();
                                ccccc.RandomInit();
                                firstArray.Enqueue(ccccc);
                                Console.WriteLine("!!!Элемент добавлен!!!");
                                break;
                            default:
                                Console.WriteLine("!!!Неправильный ввод!!!");
                                break;
                        }
                        break;
                    case 2:
                        firstArray.Dequeue();
                        Console.WriteLine("\n!!!Элемент удален!!!");
                        break;
                    case 3:
                        Querry(firstArray);
                        break;

                    case 4:
                        Console.WriteLine();
                        int index = 0;
                        foreach (Challenge i in firstArray)
                        {
                            Challenge vv = new Challenge();
                            if (i is Test)
                            {
                                vv = (Test)i;
                            }
                            if (i is Exam)
                            {
                                vv = (Exam)i;
                            }
                            if (i is FinalExam)
                            {
                                vv = (FinalExam)i;
                            }
                            Console.Write("\n["+index+"]");
                            index++;
                            vv.Show();
                        }
                        break;

                    case 5:
                        Queue<Challenge> c1 = new Queue<Challenge>();
                        foreach (Challenge zz in firstArray) 
                        {
                            c1.Enqueue(zz);
                        }
                        Console.WriteLine("Клонирование произошло с помощью переписывания");
                        break;
                    case 6:
                        Test v1 = new Test();
                        v1.Init();
                        Console.WriteLine("Входит введеный элемент в очередь? \n Ответ:"+firstArray.Contains(v1));
                        break;
                    case 7:
                        menu1 = false;
                        break; 
                }
            }
        }


    }
}
