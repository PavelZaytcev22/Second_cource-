using _10LabLibrary;
using _12LabLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _13LabLibrary
{
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);//Делегат


    public class MyNewHashTable:MyHashTable
    {
        private string name;
        public string Name 
        {
            get 
            {
                return name;
            }
            set 
            {
                name = value; 
            }
        }

        protected static Random randomer = new Random();

        public MyNewHashTable() 
        {
            table = null;
        }

        public MyNewHashTable(string name, int count) 
        {
            if (count > -1)
            {
                this.name = name;
                table = new ListPoints<Challenge>[count];
                for (int i = 0; i < count; i++)
                {
                    table[i] = new ListPoints<Challenge>();
                }
            }
            else 
            {
                Console.WriteLine("\n!!!Нельзя создать табдицу отрицательной длины!!!!");
            }               
        }
            
        
        public event CollectionHandler CollectionCountChanged;//Событие 
        public event CollectionHandler CollectionReferenceChanged;//Событие

        protected virtual void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)//Обработчик события  
        {
            if (CollectionCountChanged != null) 
            {
                CollectionCountChanged(source, args);
            }
        }
        protected virtual void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)//Обработчик события
        {
            if (CollectionReferenceChanged != null)
            {
                CollectionReferenceChanged(source, args);
            }
        }

        public  bool Remove(int j)//Удаление элемента по номеру 
        {            
            if (this.Count > 0 && j>0  && j<= this.Count) 
            {
                Challenge buff = null;
                int counter = 0;
                bool get = true; 
                foreach (var i in this ) 
                {
                    foreach (var jj in i) 
                    {
                        if (jj!=null) 
                            counter++;
                        if (counter == j && get)
                        {
                            buff = jj;
                            get = false;
                        }
                    }
                }
                if (buff != null) 
                {
                    OnCollectionCountChanged(this, new CollectionHandlerEventArgs(this.Name, "delete", buff));//Вызываем обработчик события 
                    return base.Remove(buff);
                }
                
            }
            return false;
        }

        public override void Add(Challenge value)
        {
            if (table.Length > 0)
            {
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs(this.Name, " add ", value));//Вызываем обработчик события
                base.Add(value);
            }
            else 
            {
                Console.WriteLine("В коллекцию нельзя ничего добавить");
            }
        }

        public void AddRandom()
        {
            if (table.Length > 0)
            {
                int number = randomer.Next(0, 2);
                if (number % 2 == 1)
                {
                    Challenge buff = new Challenge();
                    buff.RandomInit();
                    this.Add(new Challenge(buff));
                }
                else
                {
                    Test buff1 = new Test();
                    buff1.RandomInit();
                    this.Add(new Test(buff1));
                }
                Console.WriteLine("\nЭлемент добавлен");
            }
            else 
            {
                Console.WriteLine("!!!Коллекция нулевой длины!!!");
            }
        }

        public Challenge this[int index1, int index2] 
        {
            get 
            {
                return table[index1][index2];
            }
            set 
            {
               if (value is null) 
               {
                    OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs(this.Name, " changed ", table[index1][index2]));
                    table[index1][index2] = value;
               }
               
            }
        }

        

       /* public Challenge Min() 
        {
            Challenge buff = new Challenge("",32000,"");
            foreach (var i in this) 
            {
                foreach (var j in i) 
                {
                    if (j != null) 
                    {
                        if (j.Questions < buff.Questions) 
                        {
                            buff = j;
                        }
                    }
                }
            }
            if (!buff.Equals(new Challenge("", 32000, ""))) return buff;
            return null;
        }

        public Challenge Max()
        {
            Challenge buff = new Challenge("", 0, "");
            foreach (var i in this)
            {
                foreach (var j in i)
                {
                    if (j != null)
                    {
                        if (j.Questions > buff.Questions)
                        {
                            buff = j;
                        }
                    }
                }
            }
            if (!buff.Equals(new Challenge("", 0, ""))) return buff;
            return null;
        }

        public List<Challenge> Select() 
        {
            List<Challenge> buff = new List<Challenge>();
            foreach (var i in table) 
            {
                foreach (var j in i) 
                {
                    if (j!=null && j.Questions > 100) 
                    {
                        buff.Add(j);
                    }
                }
            }
            return buff;
        }

        public void Sort() //Потестить
        {
            List<Challenge> buff;
            foreach (ListPoints<Challenge> i in this) 
            {
                buff = new List<Challenge>();
                foreach (var j in i) 
                {
                    if (j!=null)
                    {
                        buff.Add(j);
                    }
                }
                buff.Sort();
                Point<Challenge> head = i.Head;
                IEnumerator<Challenge> b = buff.GetEnumerator();
                b.MoveNext();
                if (head != null) 
                {
                    while (head.NextPoint != null ) 
                    {
                        head.Value = b.Current;
                        head = head.NextPoint;
                        b.MoveNext();
                    }
                    head.Value = b.Current;
                }
            }
        
        }*/

        


    }
}
