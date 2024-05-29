using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10LabLibrary
{
    //Третий производный класс 
    public class FinalExam : Exam
    {
        protected int mark;
        private static Random randomer = new Random();

        public int Mark
        {
            get
            {
                return mark;
            }
            set
            {
                if (value < 0 || value > 5)
                {
                    mark = 0;
                }
                else
                {
                    mark = value;
                }
            }
        }

        public FinalExam(string Name1, int questions, string date, int time, int mark11):base(Name1, questions, date, time)
        {
            Mark = mark11;
        }

        public FinalExam():base()
        {
            Mark = 0;
        }

        public override void Init()
        {
            base.Init();
            Mark = Functions.InputInt32("Оценка:");
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Mark = randomer.Next(0, 5);
        }

        public override void Show()
        {
            Console.Write("\n[" + Name + ", " + Questions + " заданий , " + Time + " минут, ");
            Console.Write(Date + "  дата, " + Mark + " Оценка ]");
        }

        public new void Query()
        {

            Console.WriteLine("ЭЛЕМЕНТЫ МАССИВА:");
            Challenge[] c2 = new Challenge[10];
            for (int i = 0; i < 9; i++)
            {
                FinalExam buff = new FinalExam();
                buff.RandomInit();
                c2[i] = buff;
                c2[i].Show();
            }
            int mark;
            do
            {
                mark = Functions.InputInt32("\nВведите оценку");
                if (mark < 0 || mark > 5) Console.WriteLine("!!Оценка может быть в диапазоне [0,5]!!!");
            } while (mark < 0 || mark > 5);


            int count3 = 0;
            FinalExam f1 = new FinalExam();
            foreach (Challenge p in c2)
            {
                f1 = p as FinalExam;
                if (f1 != null && (f1.Mark == mark))
                {
                    count3++;
                }

            }
            Console.WriteLine("\n!!!В массиве " + count3 + " элемент(ов), где оценка совпадает !!!");

        }

        public override bool Equals(object obj)
        {
            if (obj is FinalExam) 
            {
                FinalExam c1 = (FinalExam)obj;
                if (c1.Name == this.Name && c1.Questions == this.Questions && c1.Date == this.Date && c1.Time == this.Time && c1.Mark == this.Mark)
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

        public Exam BaseExam//11 Лаба
        {
            get
            {
                return new Exam(Name, Questions, Date, Time);
            }

        }

        //Для 11 лабы
        public override string ToString()
        {
            return Name+Questions.ToString() + Time.ToString()+Date;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode()+Mark;
        }

        /*
                public static explicit operator Test(FinalExam s1)
                {
                    Test buff = new Test();
                    buff.Minutes = s1.Minutes;
                    buff.Name = s1.Name;
                    buff.Tasks = s1.Questions;
                    return buff;
                }

                public static explicit operator Exam(FinalExam s1)
                {
                    Exam buff = new Exam();
                    buff.Minutes = s1.Minutes;
                    buff.Name = s1.Name;
                    buff.Questions = s1.Questions;
                    buff.Day = s1.Day;
                    buff.Mounth = s1.Mounth;
                    return buff;
                }
        */

    }

}
