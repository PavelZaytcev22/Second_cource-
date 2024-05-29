using System;
using System.Collections.Generic;
using _10LabLibrary;

namespace _12LabLibrary
{
    public class Point<T>:IEquatable<Point<T>>
    {
        private T value1; 
        private Point<T> nextPoint;
      

        public T Value 
        {
            get { return value1; }
            set 
            {
             value1 = value;                
            }
        }

        public Point<T> NextPoint //Свойсто для доступа к следующему узлу списка
        {
            get { return nextPoint; }
            set 
            {
                if (value is Point<T>)
                {
                    nextPoint = value;//Присваиваю полю ссылку 
                }
                else 
                {
                    if (value is null) { nextPoint = null; }
                   // else { throw new Exception("!!Неверный тип данных!!!"); }
                }
            }
        }
      

        public Point(T value) 
        {
            Value = value;
            NextPoint = null;
        }
        public Point()
        {
            Value = default;
            NextPoint = null;
        }

        public bool Equals(Point<T> other) 
        {
            return other.Value.Equals(Value);
        }

    }
}
