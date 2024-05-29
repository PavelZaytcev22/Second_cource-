using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestLibrary
{
    public class Diapazon
    {

        private double x, y;
        public static int CountDiapazon;

        public double GetX()//геттер
        {
            return x;
        }

        public double GetY()//геттер
        {
            return y;
        }

        public Diapazon()
        {
            x = 0;
            y = 0;
            CountDiapazon++; 
        }//Конструктор без параметров 

        public Diapazon(double x, double y) //Конструктор с параметрами
        {
            this.x = x;
            this.y = y;
            CountDiapazon++;
        }
     

        public Diapazon(Diapazon c1) //Конструктор копирования
        {
            this.x = c1.GetX();
            this.y = c1.GetY();
            CountDiapazon++;
        }

        
        public void SetX(double x)//Сеттер
        {
            this.x = x;
        }

        public void SetY(double y)//Сеттер
        {
            this.y = y;
        }

        public void Print() => Console.Write("[" + x + " , " + y + "]");//Метод для вывода в консоль

        public bool CheckPoint(double point)//Метод принадлежности точки
        {
            if (x > y)
            {
                return point <= x && point >= y;
            }
            else
            {
                return point >= x && point <= y;
            }
        }


        //Перегрузка унарные операций 
        public static double operator !(Diapazon c1)
        {
            if (c1.x > c1.y)
            {
                return (c1.x - c1.y);
            }
            else
            {
                return (c1.y - c1.x);
            }
        }

        public static Diapazon operator ++(Diapazon c1)
        {
            Diapazon buff = new Diapazon(c1.GetX() + 1, c1.GetY() + 1);
            return buff;
        }

        //Перегрузка операций приведения типа 
        public static explicit operator int(Diapazon c1)
        {
            return (int)c1.GetX();
        }

        public static implicit operator double(Diapazon c1)
        {
            return c1.GetY();
        }

        //Перегрузка бинарных операций 
        public static Diapazon operator +(Diapazon c1, int d)
        {
            Diapazon buff = new Diapazon(c1.GetX() + d, c1.GetY() + d);
            return buff;
        }

        public static bool operator <(int d, Diapazon c1)
        {
            if (c1.GetX() > c1.GetY())
            {
                return d <= c1.GetX() && d >= c1.GetY();
            }
            else
            {
                return d >= c1.GetX() && d <= c1.GetY();
            }
        }

        public static bool operator >(int d, Diapazon c1)
        {
            if (c1.GetX() > c1.GetY())
            {
                return d <= c1.GetX() && d >= c1.GetY();
            }
            else
            {
                return d >= c1.GetX() && d <= c1.GetY();
            }
        }
    }
}
