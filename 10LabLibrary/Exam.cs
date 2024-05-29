using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10LabLibrary
{
    //Второй производный класс 
    public class Exam : Challenge
    {
        protected int time;
        private static Random randomer = new Random();

        public int Time
        {
            get
            {
                return time;
            }
            set
            {
                if (value < 0)
                {
                    time = 1;
                }
                else
                {
                    time = value;
                }
            }
        }

        public Exam(string Name1, int questions, string date, int time): base(Name1, questions, date)
        {
            Time = time;
        }

        public Exam():base()
        {
            Time = 0;
        }

        public override void Init()
        {
            base.Init();
            Time = Functions.InputInt32("Число минут:");
        }

        public override void RandomInit()
        {
            base.RandomInit();
           Time = randomer.Next(1, 300);
        }

        public override void Show()
        {
            Console.Write("\n[" + Name + ", " + Questions + " заданий , " + Time + " минут, ");
            Console.Write(Date + "  дата] ");
        }

        public void Query()
        {

            Console.WriteLine("ЭЛЕМЕНТЫ МАССИВА:");
            Challenge[] c2 = new Challenge[10];
            for (int i = 0; i < 9; i++)
            {
                Exam buff = new Exam();
                buff.RandomInit();
                c2[i] = buff;
                c2[i].Show();
            }
            int minutes;
            do
            {
                minutes = Functions.InputInt32("\nВведите число минут");
                if (minutes < 1) Console.WriteLine("!!!Число минут начинается с 1 !!!!");
            } while (minutes < 1);

            int count3 = 0;
            Exam f1 = new Exam();
            foreach (Challenge p in c2)
            {
                f1 = p as Exam;
                if (f1 != null && (f1.Time > minutes)) count3++;
            }
            Console.WriteLine("\n!!!В массиве " + count3 + " элемент(ов), где число минут больше чем " + minutes + " !!!");

        }

        public override bool Equals(object obj)
        {
            if (obj is Exam c1)
            {
                if (c1.Name == this.Name && c1.Questions == this.Questions && c1.Date == this.Date && c1.Time == this.Time)
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

        /*       public override int GetHashCode()
               {
                   int hashCode = 214511997;
                   hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
                   hashCode = hashCode * -1521134295 + Questions.GetHashCode();
                   hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Date);
                   hashCode = hashCode * -1521134295 + Time.GetHashCode();
                   return hashCode;
               }*/

        public override int GetHashCode()
        {
            return base.GetHashCode()+ Functions.StringValue(Name) ;
        }//11 Лаба

        //public virtual int CompareTo(object  obj) //Реализация интерфейса 
        //{
        //    if (obj is Test)
        //    {
        //        Test buff1 = (Test)obj;
        //        if (this.Questions > buff1.Questions) return 1;
        //        if (this.Questions < buff1.Questions) return -1;
        //        return 0;
        //    }
        //    Exam buff = (Exam)obj;
        //    if (this.Questions > buff.Questions) return 1;
        //    if (this.Questions < buff.Questions) return -1;
        //    return 0;

        //}

        //public int Compare(object obj1, object obj2) //Реализация интерфейса IComparer
        //{
        //    Exam buff1 = (Exam)obj1;
        //    Exam buff2 = (Exam)obj2;
        //    if (buff1.Name.Length > buff2.Name.Length) return 1;
        //    if (buff1.Name.Length < buff2.Name.Length) return -1;
        //    return 0;
        //}



        /* public static explicit operator Test(Exam s1)
         {
             Test buff = new Test();
             buff.Minutes = s1.Minutes;
             buff.Name = s1.Name;
             buff.Tasks = s1.Questions;
             return buff;
         }

         public static explicit operator FinalExam(Exam s1)
         {
             FinalExam buff = new FinalExam();
             buff.Minutes = s1.Minutes;
             buff.Name = s1.Name;
             buff.Questions = s1.Questions;
             buff.Day = s1.Day;
             buff.Mounth = s1.Mounth;
             return buff;
         }*/

    }
}
