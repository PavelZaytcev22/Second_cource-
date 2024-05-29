using _10LabLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14_C_
{
    public class Queries
    {
        public static List<Challenge> Select1(Stack<Dictionary<string, Challenge>> book)
        {
            if (book != null)
            {
                List<Challenge> buff = new List<Challenge>();
                var subjects = from c in book select c;
                foreach (var i in subjects)
                {
                    var buff1 = from c in i select c;
                    foreach (var j in buff1)
                    {
                        if (j.Value is Challenge)
                        {
                            buff.Add(j.Value);
                        }

                    }
                }
                return buff;
            }
            else
            {
                throw new Exception("Коллекция пустая!!!!");
            }
        }

        public static int Count1(List<Challenge> Persons)
        {
            if (Persons != null)
            {
                return (from x in Persons where x.Questions > 50 select x).Count<Challenge>();
            }
            else
            {
                throw new Exception("Коллекция пустая!!!!");
            }
        }

        public static IEnumerable<Challenge> SetOperation1(List<Challenge> Persons1, List<Challenge> Persons2)
        {
            if (Persons1 != null && Persons2 != null)
            {
                var buff = (from c in Persons1 select c).Intersect(from c2 in Persons2 select c2);
                return buff;
            }
            else
            {
                throw new Exception("Коллекция пустая!!!!");
            }
        }

        public static void MaxMin(List<Challenge> Persons1) 
        {
            if (Persons1 != null )
            {
                Console.WriteLine("Максимальный элемент по вопросам = {0}", (from c in Persons1 select c).Max());
                Console.WriteLine("Минимальный элемент по вопросам = {0}", (from c in Persons1 select c).Min());
            }
            else
            {
                throw new Exception("Коллекция пустая!!!!");
            }
        }

        public static IEnumerable<IGrouping<string, Challenge>> Group1(List<Challenge> Persons1) 
        {
            if (Persons1 != null)
            {
                return (from c in Persons1 group c by c.Name);
            }
            else
            {
                throw new Exception("Коллекция пустая!!!!");
            }
        }


        public static List<Challenge> Select2(Stack<Dictionary<string, Challenge>> book)
        {
            if (book != null)
            {
                List<Challenge> buff = new List<Challenge>();

                Func<Dictionary<string, Challenge>, Dictionary<string, Challenge>> vv =
                    delegate (Dictionary<string, Challenge> c1) { return c1; };

                var subjects = book.Select(vv);//Через прописанный делегат  
                foreach (var i in subjects)
                {
                    var buff1 = i.Select(p => p);//Через лямда выражение 
                    foreach (var j in buff1)
                    {
                        buff.Add(j.Value);
                    }
                }
                return buff;
            }
            else
            {
                throw new Exception("Коллекция пустая!!!!");
            }
        }

        public static int Count2(List<Challenge> Persons1) 
        {
            if (Persons1 != null)
            {
                Func<Challenge, bool> nnn = delegate (Challenge bb)
                {
                    if (bb.Questions > 50) return true;
                    return false;
                };
                return Persons1.Where(nnn).Count();;
            }
            else
            {
                throw new Exception("Коллекция пустая!!!!");
            }
        }

        public static IEnumerable<Challenge> SetOperation2(List<Challenge> Persons1, List<Challenge> Persons2)
        {
            if (Persons1 != null && Persons2 != null)
            {
                var buff = Persons1.Except(Persons2);
                return buff;
            }
            else
            {
                throw new Exception("Коллекция пустая!!!!");
            }
        }

        public static void MaxMin2(List<Challenge> Persons1) 
        {
            if (Persons1 != null)
            {
                Func<Challenge, Challenge, Challenge> minCh = delegate (Challenge v1, Challenge v2) //Прописанный делегат
                {
                    if (v1.Questions > v2.Questions) return v2;
                    else return v1;
                };

                Func<Challenge, Challenge, Challenge> maxCh = delegate (Challenge v1, Challenge v2)//Прописанный делегат
                {
                    if (v1.Questions > v2.Questions) return v1;
                    else return v2;
                };
                Console.WriteLine("\nАгрегация:");
                Console.WriteLine("Максимальный элемент по вопросам = {0}", Persons1.Aggregate(maxCh));
                Console.WriteLine("Минимальный элемент по вопросам = {0}", Persons1.Aggregate(minCh));
            }
            else
            {
                throw new Exception("Коллекция пустая!!!!");
            }
        }

        public static IEnumerable<IGrouping<bool, Challenge>> Group2(List<Challenge> Persons1) 
        {
            if (Persons1 != null)
            {
                Func<Challenge , bool> groupMade = delegate (Challenge c1)
                {
                    if (c1.Questions < 100) return false;
                    else return true;
                };

               return  Persons1.GroupBy(groupMade);
            }
            else
            {
                throw new Exception("Коллекция пустая!!!!");
            }
        }

    }
}
