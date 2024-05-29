using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10LabLibrary
{
    //Класс не из иерархии классов
    public class SuperTest : IInit, ICloneable
    {
        private int countpeople;
        private Test test11;
        private static Random randomer = new Random();

        public int People
        {
            set
            {
                if (value < 0) countpeople = 0;
                else countpeople = value;
            }
            get
            {
                return countpeople;
            }
        }
        public Test Test
        {
            set
            {
                Test f1 = value as Test;
                if (f1 != null)
                {
                    test11 = f1;
                }
            }
            get
            {
                return test11;
            }
        }

        public SuperTest()
        {
            Test = new Test();
            People = 0;
        }

        public SuperTest(string Name11, int Questions11, string date, string teacher, int People11)
        {
            Test = new Test(Name11, Questions11, date, teacher);
            People = People11;
        }

        public void Init()
        {
            Test buff = new Test();
            buff.Init();
            Test = buff;
            do
            {
                People = Functions.InputInt32("Введите количество человек");
            } while (People == 0);
        }

        public void RandomInit()
        {
            Test buff = new Test();
            buff.RandomInit();
            Test = buff;
            People = randomer.Next(1, 40);
        }

        public void Show()
        {
            Test.Show();
            Console.Write("[ Количество людей " + People + " ] ");
        }

        public object Clone()//Реализация интефейса ICloneable
        {
            return new SuperTest(this.Test.Name, this.Test.Questions, this.Test.Date, this.Test.Teacher, this.People);
        }

        public SuperTest ShallowCopy()
        {
            return (SuperTest)this.MemberwiseClone();
        } //Поверхностное копирование

    }
}
