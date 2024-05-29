using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestLibrary
{
    public class DiapazonArray
    {
        private Diapazon[] mass=new Diapazon[8];
        private int massLong;
        Random Randomer = new Random();

        public int GetLeng()
        {
            return this.massLong;
        }

        private void IncreaseLength(ref Diapazon[] mass, int longMass)
        {
            Diapazon[] buffmass = mass;
            do 
            {
                mass = new Diapazon[mass.Length * 2];
            } while (mass.Length<longMass);

            for (int i = 0; i < buffmass.Length; i++) 
            {
                mass[i] = buffmass[i];
            }

        }

        public DiapazonArray()
        {
            massLong = 0;
        }//Конструктор без параметров 


        public DiapazonArray(int newLongArray, bool cc)
        {
            if (newLongArray > mass.Length)//Проверка достаточности длины коллекции
            {
                IncreaseLength(ref this.mass, newLongArray);
            }
            this.massLong = newLongArray;

            if (cc == true)
            {
                for (int i = 0; i < massLong; i++)
                {
                    Diapazon Buff = new Diapazon(Randomer.Next(-300, 300), Randomer.Next(-300, 300));
                    mass[i] = Buff;
                }
            }
            else
            {
                int index = 0;
                do
                {
                    double x;
                    double y;
                    x = Functions.InputDouble("\nВведите начало диапазона");
                    y = Functions.InputDouble("\nВведите конец диапазона");
                    mass[index] = new Diapazon(x, y);
                    index++;
                } while (index < massLong);
            }

        }//Конструктор с параметрами

        public void Print()
        {
            if (this.massLong == 0 )
            {
                Console.WriteLine("\n!!!Коллекция пуста!!!");
            }
            else 
            {
                Console.WriteLine("\nКоллекция:");
                for (int i = 0; i < massLong; i++)
                {
                    mass[i].Print();
                    Console.Write(" , ");
                }
                Console.WriteLine("\n");
            }
            
        }//Метод вывода коллекции в консоль

        public Diapazon this[int index]
        {
            get
            {
                if (index > massLong - 1 || index < 0)//Проверка индекса 
                {
                    throw new Exception("\nВыход за границы массива!!!!\n");
                }
                else
                {
                    return mass[index];
                }
            }
            set
            {
                if (index > massLong - 1 || index < 0)// Проверка индекса
                {
                    throw new Exception("\nВыход за границы массива!!!!\n");
                }
                else
                {
                    mass[index] = value;
                }
            }

        }//Индексатор

   

    }
}
