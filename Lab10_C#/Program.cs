using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _10LabLibrary;


namespace Lab10_C_
{
    internal class Program
    {       
        static void Main()
        {
            bool mainMenu=true;
            int command1;
            do 
            {
                Console.Write("\n1)Задание 1" +
                    "\n2)Задание 2 " +
                    "\n3)Задание 3" +
                    "\n4)Выход");
                command1 = Functions.InputInt32("\nВведите команду");
                switch (command1) 
                {
                    case 1:
                        Challenge[] c1 = new Challenge[20];
                        for (int i = 0; i < 15; i++)
                        {
                            if (i >= 0 && i <= 5)
                            {
                                Test buff = new Test();
                                buff.RandomInit();
                                c1[i] = buff;
                            }
                            if (i > 5 && i <= 9)
                            {
                                Exam buff1 = new Exam();
                                buff1.RandomInit();
                                c1[i] = buff1;
                            }
                            if (i > 9 && i <= 14)
                            {
                                FinalExam buff2 = new FinalExam();
                                buff2.RandomInit();
                                c1[i] = buff2;
                            }
                        }
                        Console.WriteLine("\n\n");
                        for (int i = 0; i < 15; i++)
                        {
                            c1[i].Show();
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        Test c3 = new Test();
                        c3.Query();
                        Exam c4 = new Exam();
                        c4.Query();
                        FinalExam c5 = new FinalExam();
                        c5.Query();
                        break;
                    case 3:
                       Challenge[] c6 = new Challenge[10];
                        for (int i = 0; i < 15; i++)
                        {
                            if (i >= 0 && i <= 3)
                            {
                                Test buff = new Test();
                                buff.RandomInit();
                                c6[i] = buff;
                            }
                            if (i >= 4 && i <= 5)
                            {
                                Exam buff1 = new Exam();
                                buff1.RandomInit();
                                c6[i] = buff1;
                            }
                            if (i >= 6 && i <= 9)
                            {
                                FinalExam buff2 = new FinalExam();
                                buff2.RandomInit();
                                c6[i] = buff2;
                            }
                        }
                        Console.Write("\n\nИзначальный массив экземпляров класса:");
                        for (int i = 0; i < 10; i++)
                        {
                            c6[i].Show();
                        }

                        Console.Write("\n\nОтсортированный массив:");
                        Array.Sort(c6, new ChallengeCoparer());//Сортировка
                        for (int i = 0; i < 10; i++)
                        {
                            c6[i].Show();
                        }
                        Console.WriteLine();

                        Array.Sort(c6);//Сортировка
                        Console.Write("\n\nОтсортированный массив:");
                        for (int i = 0; i < 10; i++)
                        {
                            c6[i].Show();
                        }
                        Console.WriteLine();

                        
                        Console.WriteLine();
                        Console.Write("\nБинарный поиск\n");
                        int count = Functions.InputInt32("Введите минуты");
                        Console.WriteLine("Объект находится по индексу[" + Functions.BinarySearchLab10(c6, count) + "]");
                        Console.WriteLine("____________________________________________________________________________");

                        Console.WriteLine("\nРабота c интерфейсом IInit");
                        IInit[] v1= new IInit[8];
                          for(int i=0; i<8; i++)
                          {
                              if (i >= 0 && i <= 1) 
                              {
                                  SuperTest buff = new SuperTest();
                                  buff.RandomInit();
                                  v1[i] = buff;
                              }
                              if (i >= 2 && i <= 3)
                              {
                                  Test buff = new Test();
                                  buff.RandomInit();
                                  v1[i] = buff;
                              }
                              if (i >= 4 && i <= 5)
                              {
                                  Exam buff = new Exam();
                                  buff.RandomInit();
                                  v1[i] = buff;
                              }
                              if (i >= 6 && i <= 7)
                              {
                                  FinalExam buff = new FinalExam();
                                  buff.RandomInit();
                                  v1[i] = buff;
                              }
                          }
                        Console.WriteLine("Массив элементов c интерфейсом IInit");
                        for (int i = 0; i < 8; i++)
                          {
                              object obj = v1[i];
                              if (obj is SuperTest) 
                              {
                                  SuperTest buff = (SuperTest)obj;
                                  buff.Show();
                              }
                              if (obj is Test)
                              {
                                  Test buff = (Test)obj;
                                  buff.Show();
                              }
                              if (obj is Exam)
                              {
                                  Exam buff = (Exam)obj;
                                  buff.Show();
                              }
                              if (obj is FinalExam)
                              {
                                  FinalExam buff = (FinalExam)obj;
                                  buff.Show();
                              }
                          }
                        Console.WriteLine();
                        Console.WriteLine("____________________________________________________________________________");
                        SuperTest mainTest = new SuperTest();

                        mainTest.RandomInit();
                        //Создание клонов
                        SuperTest firstClone = (SuperTest)mainTest.Clone();
                        SuperTest secondClone = mainTest.ShallowCopy();

                        Console.Write("\nОсновной класс:");
                        mainTest.Show();
                        Console.Write("\nГлубокая клон класса:");
                        firstClone.Show();
                        Console.Write("\nПоверхностная копия класса:");
                        secondClone.Show();
                        Console.Write("\n\n!!!Изменяем название в основном классе на Русский язык и меняем количество заданий на 30 и количество людей на 15 !!!");

                        mainTest.Test.Name = "Русский язык";
                        mainTest.Test.Questions = 30;
                        mainTest.People = 15;
                        
                        Console.Write("\n\nОсновной класс:");
                        mainTest.Show();
                        Console.Write("\nГлубокая клон класса:");
                        firstClone.Show();
                        Console.Write("\nПоверхностная копия класса:");
                        secondClone.Show();
                        Console.WriteLine("\n____________________________________________________________________________");
                        break;
                    case 4:
                        mainMenu = false;
                        break;
                    default:
                        Console.WriteLine("!!Неправильный ввод!!");
                        break;
                }
            }
            while (mainMenu);
            /*Challenge[] c1 = new Challenge[15];
            for (int i = 0; i < 15; i++)
            {
                if (i >= 0 && i <= 5)
                {
                    Test buff = new Test();
                    buff.RandomInit();
                    c1[i] = buff;
                }
                if (i > 5 && i <= 9)
                {
                    Exam buff1 = new Exam();
                    buff1.RandomInit();
                    c1[i] = buff1;
                }
                if (i > 9 && i <= 14)
                {
                    FinalExam buff2 = new FinalExam();
                    buff2.RandomInit();
                    c1[i] = buff2;

                }
            }
            Console.WriteLine("\n\n");
            Array.Sort(c1);
            for (int i = 0; i < 15; i++)
            {
                c1[i].Show();
            }
            Console.WriteLine();
            int count = Functions.InputInt32("Введите минуты");
            Console.WriteLine("Объект находится по индексу[" + Functions.BinarySearchLab10(c1, count) + "]");
*/

   


           /* Test buff = new Test("Математика",20,26);
            Test buffClone = buff.ShallowCopy();
            buff.Minutes = 5;
            buffClone.Show();*/
        }
    }
}
