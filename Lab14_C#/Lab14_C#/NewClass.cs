using _10LabLibrary;
using _12LabLibrary;
using _13LabLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14_C_
{
    static public class NewClass
    {

        static public IEnumerable<T> Select<T>(this HashTable<T> c1)
        {
            if (c1 == null) throw new ArgumentNullException();
            List<T> buff = new List<T>();
            foreach (var i in c1)
            {
                foreach (var j in i)
                {
                    buff.Add(j);
                }
            }
            return buff;
        }

        static public IEnumerable<T> Where<T>(this HashTable<T> c1, Func<T, bool> predicate)
        {
            if (c1 == null) throw new ArgumentNullException();
            if (predicate == null) throw new ArgumentNullException();

            List<T> buff = new List<T>();
            foreach (var i in c1)
            {
                foreach (var j in i)
                {
                    if (predicate(j))
                    {
                        buff.Add(j);
                    }
                }
            }
            return buff;
        }

        static public T Max<T>(this HashTable<T> c1) where T : IComparable<T>
        {
            if (c1 == null) throw new ArgumentNullException();
            T max = default;
            foreach (var i in c1)
            {
                foreach (var j in i)
                {
                    max = j;
                    break;
                }
            }
            foreach (var i in c1)
            {
                foreach (var j in i)
                {
                    if (j.CompareTo(max) > 0)
                    {
                        max = j;
                    }
                }
            }
            return max;
        }

        static public T Min<T>(this HashTable<T> c1) where T : IComparable<T>
        {
            if (c1 == null) throw new ArgumentNullException();
            T min = default;
            foreach (var i in c1)
            {
                foreach (var j in i)
                {
                    min = j;
                    break;
                }
            }
            foreach (var i in c1)
            {
                foreach (var j in i)
                {
                    if (j.CompareTo(min) < 0)
                    {
                        min = j;
                    }
                }
            }
            return min;
        }

        public static void Sort<T>(this HashTable<T> c1) where T : IComparable<T>
        {
            if (c1 == null) throw new ArgumentNullException();
            List<T> buff;
            foreach (ListPoints<T> i in c1)
            {
                buff = new List<T>();
                foreach (var j in i)
                {
                    if (j != null)
                    {
                        buff.Add(j);
                    }
                }
                buff.Sort();
                Point<T> head = i.Head;
                IEnumerator<T> b = buff.GetEnumerator();
                b.MoveNext();
                if (head != null)
                {
                    while (head.NextPoint != null)
                    {
                        head.Value = b.Current;
                        head = head.NextPoint;
                        b.MoveNext();
                    }
                    head.Value = b.Current;
                }
            }
        }





    }
}
