using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10LabLibrary
{
    //Первый производный класс 

    [Serializable]
    public class Test : Challenge//, IComparable
    {
        [NonSerialized]
        private static Random randomer = new Random();

        protected string teacher;

        public string Teacher
        {
            get
            {
                return teacher;
            }
            set { teacher = value; }
        }

        //Конструкторы 
        public Test(string Name11, int Questions11, string date, string teacher):base(Name11, Questions11, date)
        {
            Teacher = teacher;
        }

        public Test():base()
        {
           Teacher = "?";
        }

        public Test(Test oldList) 
        {
            Name = oldList.Name; Date = oldList.Date;
            Teacher = oldList.Teacher; Questions = oldList.Questions;
        }

        //Методы ввода-вывода
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Имя учителя");
            Teacher = Console.ReadLine();
        }

        public override void RandomInit()
        {
            base.RandomInit();
            string[] Names = new string[] { "А.С.Жуков", "М.З. Чугайнова ", "С.М. Григорьев", "Ч.М. Мухин", "Ф.З.Лосев" };
            Teacher = Names[randomer.Next(0, Names.Length - 1)];
        }

        public override void Show()
        {
            Console.Write("\n[" + Name + ", " + Questions + " заданий , " + Date + " дата" + "] ");
        }

        public override bool Equals(object obj)//пЕРЕДЕЛАТЬ ДЛЯ 12 ЛАБЫ 
        {
            if (obj == null) return false;
            if (obj is Test) 
            {
                Test c1 = (Test)obj;
                if (c1.Name == this.Name && c1.Questions == this.Questions && c1.date == this.date)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public void Query()
        {
            Console.WriteLine("ЭЛЕМЕНТЫ МАССИВА:");
            Challenge[] c1 = new Challenge[10];
            for (int i = 0; i < 9; i++)
            {
                Test buff = new Test();
                buff.RandomInit();
                c1[i] = buff;
                c1[i].Show();
            }
            Console.Write("\nВведите название предмета:");
            string buff11 = Console.ReadLine();
            int count2 = 0;
            Test f = new Test();
            foreach (Challenge p in c1)
            {
                f = p as Test;
                if (f != null && (f.Name == buff11)) count2++;
            }
            Console.WriteLine("\n!!!В массиве " + count2 + " элемент(ов),где название предметов " + buff11 + " !!!");
            }

        public override string ToString()
        {
            return "[ " + Name + " , " + Questions.ToString() + " , " + Date + " , " + Teacher + " ]";
        }

     /*   public override void Print()
        {
            Console.WriteLine("[" + Name + " , " + Questions.ToString() + " , " + Date + " , " + Teacher + "]");
        }*/

        //public int CompareTo(object obj) //Реализация интерфейса IComparable 
        //{
        //    if (obj is Exam)
        //    {
        //        Exam buff1 = (Exam)obj;
        //        if (this.Questions > buff1.Questions) return 1;
        //        if (this.Questions < buff1.Questions) return -1;
        //        return 0;
        //    }
        //    Test buff = (Test)obj;
        //    if (this.Questions > buff.Questions) return 1;
        //    if (this.Questions < buff.Questions) return -1;
        //    return 0;
        //}

        //public int Compare(object obj1, object obj2) //Реализация интерфейса IComparer
        //{
        //    Test buff1 = (Test)obj1;
        //    Test buff2 = (Test)obj2;
        //    if (buff1.Name.Length > buff2.Name.Length) return 1;
        //    if (buff1.Name.Length < buff2.Name.Length) return -1;
        //    return 0;
        //}


        /*public static explicit operator Exam(Test s1)
        {
            Exam buff = new Exam();
            buff.Minutes = s1.Minutes;
            buff.Name = s1.Name;
            buff.Questions = s1.Tasks;
            return buff;
        }

        public static explicit operator FinalExam(Test s1)
        {
            FinalExam buff = new FinalExam();
            buff.Minutes = s1.Minutes;
            buff.Name = s1.Name;
            buff.Questions = s1.Tasks;
            return buff;
        }*/


    }
}
