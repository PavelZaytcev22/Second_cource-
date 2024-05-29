using SFML.System;
using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;


namespace _10LabLibrary
{
    public interface IInit
    {
        void Init();
        void RandomInit();
    }

    [Serializable]
   // [JsonDerivedType(typeof(Challenge),typeDiscriminator:"ссссс")]
    //[JsonDerivedType(typeof(Test), typeDiscriminator: "vvvvv")]
    [JsonDerivedType(typeof(Test))]
    [XmlInclude(typeof(Challenge))]
    [XmlInclude(typeof(Test))]
    public class Challenge: IInit, IComparable<Challenge>
    {
        
        protected string name;
        protected int countQuestions;
        protected string date;

        [NonSerialized]
        private static Random randomer = new Random();

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public int Questions
        {
            set
            {
                if (value < 1)
                {
                    countQuestions = 1;
                }
                else
                {
                    countQuestions = value;
                }
            }
            get { return countQuestions; }
        }

        public string Date
        {
            set
            {
                date = value;
            }
            get { return date; }
        }

        public Challenge() 
        {
            Name = "?"; Questions = 1; Date = "?"; 
        }

        public Challenge(string Name1, int questions, string date) 
        {
            Name = Name1;
            Questions = questions;
            Date = date;
        }

        public Challenge(Challenge oldChallenge )
        {
            Name = oldChallenge.Name;
            Questions = oldChallenge.Questions;
            Date = oldChallenge.Date;
        }

        public virtual void Init() 
        {
            int day, mounth, year; 
            string buf;
            Console.WriteLine("Название теста:");
            buf = Console.ReadLine();
            Name = Convert.ToString(buf);
            Questions = Functions.InputInt32("Число заданий");
            do
            {
                day = _10LabLibrary.Functions.InputInt32("\nВведите день");
            } while (day < 1 || day > 31);
            do
            {
                mounth = _10LabLibrary.Functions.InputInt32("\nВведите месяц");
            } while (mounth < 1 || mounth > 12);
            do
            {
                year = _10LabLibrary.Functions.InputInt32("\nВведите год");
            } while (year < 0 || year > 99);
            Console.WriteLine("Дата теста:");
            Date = day+"/"+mounth+"/"+year;
        }

        public virtual void Show() 
        {
            Console.Write("\n[" + Name + ", " + Questions + " заданий , " + Date + "  дата] ");
        }

        public virtual void RandomInit() 
        {
            string[] obj = new string[] { "Алгебра", "Русский язык", "Информатика", "География", "История", "Геометрия", "Физика", "Философия", "Черчение","Социология","Экономика"};
            name = obj[randomer.Next(0, obj.Length - 1)];
            Questions = randomer.Next(5, 220);
            Date = (randomer.Next(5, 30) + "/" + randomer.Next(1, 12) + "/" + randomer.Next(1, 99));
        }

        public override bool Equals(object obj) 
        {
            if (obj == null) return false;
            if (obj is Challenge) 
            {
                Challenge c1 = (Challenge)obj;
                if (c1.Name == this.Name && c1.Questions == this.Questions && c1.Questions == this.Questions && c1.Date == this.Date)
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

        public int CompareTo(Challenge other)
        {
            return Questions.CompareTo(other.Questions);
        }

        public override int GetHashCode()
        {
            return Questions + Functions.StringValue(Name)+Functions.StringValue(Date);
        }//11 Лаба

        public override string ToString()//для 12 лабы 
        {
            return "[ " + Name + " , " + Questions + " , " + Date + " ]";
        }

      /*  public virtual void Print() 
        {
            Console.WriteLine("["+Name+" , "+Questions+" , "+Date +"]");
        }*/

        /* public int Compare(object first, object second) 
         {
             Challenge buff1 = (Challenge)first;
             Challenge buff2 = (Challenge)second;
             if (buff1.Name.Length > buff2.Name.Length) return 1;
             if (buff1.Name.Length < buff2.Name.Length) return -1;
             return 0;
         }*/



    }

}
