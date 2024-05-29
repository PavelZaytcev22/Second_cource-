using _10LabLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace _12LabLibrary
{
    public class HashTable<Tvalue> : ICollection<Tvalue>,IEnumerable<ListPoints<Tvalue>>,ICloneable
    {

        protected ListPoints<Tvalue>[] table;//Хэш таблица из списков 

        public  HashTable()
        {
            table = new ListPoints<Tvalue>[0];
        }

        public HashTable(int longHashTable)//++
        {
            if (longHashTable < 0) 
            {
                Console.WriteLine("!!!Нельзя создавать таблицу с отрицательной длиной!!!");//Сделать ошибку 
            }
            else
            {
                table = new ListPoints<Tvalue>[longHashTable];
                for (int i = 0; i < longHashTable; i++)
                {
                    table[i] = new ListPoints<Tvalue>();
                }
            }
        }
                
        public HashTable(HashTable<Tvalue> oldTable)//Конструктор копирования 
        {
            table = new ListPoints<Tvalue>[oldTable.table.Length];
            for (int i = 0; i < oldTable.table.Length; i++)
            {
                table[i] = new ListPoints<Tvalue>(oldTable.table[i]);
            }
        }

        public HashTable<Tvalue> ShallowCopy() 
        {
            HashTable<Tvalue> buff = new HashTable<Tvalue>(this.Length);
            for (int i = 0; i < this.Length; i++) 
            {
                buff.table[i] = table[i];
            }
            return buff;
        }

        private int HashFunction(Tvalue key)//Хэш функция
        {
            string key1;
            if (key is string)
            {
                key1 = key as string;
                return Functions.StringValue(key1) % table.Length;
            }
            else
            {
                key1 = key.ToString();
                return Functions.StringValue(key1) % table.Length;
            }
            /*if (table.Length == 0)
            {
                Console.WriteLine("!! Таблица равна 0 !!");
                return 0;
            }
            else
            {
                return Functions.StringValue(key) % table.Length;
            }*/
        }

        public virtual void Add(Tvalue value)//++
        {
            if (table.Length == 0)
            {
                throw new Exception("!!!Таблица нулевой длинны!!");
            }
            else
            {
                int index = HashFunction(value);
                table[index].Add(value);
            }
        }

        public virtual void Clear()//++
        {
            for (int i = 0; i < table.Length; i++)
            {
                table[i].Clear();
            }
        }

        public virtual bool Contains(Tvalue value)//++
        {
            if (table.Length == 0)
            {
                return false;
            }
            else
            {
                int index = HashFunction(value);
                return table[index].Contains(value);
            }
        }

        public virtual bool Remove(Tvalue value)//++
        {
            if (table.Length == 0)
            {
                
                return false;
            }
            else
            {
                int index = HashFunction(value);
                return table[index].Remove(value);
            }
        }

        public virtual int Count
        {
            get
            {
                int count = 0;
                for (int i = 0; i < table.Length; i++)
                {
                    count += table[i].Count;
                }
                return count;
            }
        }

        public virtual int Length 
        {
            get { return table.Length; }
        }

        public virtual ListPoints<Tvalue> this[int index] 
        {
            get 
            {
                if (index > -1 && index < table.Length)
                {
                    return table [index];                   
                }
                else 
                {
                    throw new IndexOutOfRangeException("Выход за границу таблицы");
                }
            }
        }

        public virtual void CopyTo(Tvalue[] array, int indexArray) 
        {
            if (indexArray < 0 || indexArray >= table.Length)
            {
                Console.WriteLine("Выход за границы таблицы");
            }
            else
            {
                array = new Tvalue[this.Count];
                int buffindex =0;
                for (int i = indexArray; i < table.Length; i++) 
                {
                    if (table[i].Count > 0)
                    {
                        Tvalue[] buffarray = null;
                        table[i].CopyTo(buffarray, 0);
                        for (int j = 0; j < buffarray.Length; j++) 
                        {
                            array[buffindex] = buffarray[j];
                            buffindex++;
                        }
                    }                
                }
            }
        }

        public  bool IsReadOnly 
        {
            get 
            {
                return true;
            }
        }

        public virtual object Clone() 
        {
            HashTable<Tvalue> buff = new HashTable<Tvalue>(this.Length);
            for (int i=0; i<this.Length;i++)
            {
                buff.table[i] = new ListPoints<Tvalue>(this.table[i]);
            }
            return buff;
        }

        public virtual void Print() 
        {
            if (Length == 0) Console.WriteLine("\n!!!!Таблица не создана!!!!");
            int counter = 0;
            foreach (var i in this) 
            {
                Console.WriteLine("["+counter+"]");
                foreach (var j in i) 
                {
                    if (j != null)
                    {
                        Console.WriteLine("|\nV");
                        Console.WriteLine(j);
                    }
                    else 
                    {
                        Console.WriteLine("|\nV");
                        Console.WriteLine("[ NULL ]");
                    }
                }
                Console.WriteLine("|\nV\nNULL\n");
                counter++;
            }
        }

        public IEnumerator<ListPoints<Tvalue>> GetEnumerator()
        {
            return new HashEnumerator<Tvalue>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()//Фиктивная 
        {
            throw new NotImplementedException();
        }

        IEnumerator<Tvalue> IEnumerable<Tvalue>.GetEnumerator()//Фиктивная 
        {
            throw new NotImplementedException();
        }

    }
}
