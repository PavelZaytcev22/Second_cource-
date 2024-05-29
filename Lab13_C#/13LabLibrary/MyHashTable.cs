using _10LabLibrary;
using _12LabLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _13LabLibrary
{
    public class MyHashTable: _12LabLibrary.HashTable<Challenge>
    {

        public MyHashTable():base() 
        {
        }

        public MyHashTable(int t) : base(t) { }

        public override void Add(Challenge value)
        {
            base.Add(value);
        }

        public override bool Contains(Challenge value)
        {
            return base.Contains(value);
        }

        public override void Clear()
        {
            base.Clear();
        }           

        public override bool Remove(Challenge value)
        {
            return base.Remove(value);
        }

        public override int Length
        {
            get 
            {
                return base.Length;
            }
        }

        public override int Count => base.Count;

        public override ListPoints<Challenge> this[int index] => base[index];

        

   /*     public bool Remove(Challenge j)//Нужно чтобы по значению удалял
        {
            int countElem = 0;
            for (int i = 0; i < table.Length; i++)
            {
                if (countElem + 1 >= j && j <= table[i].Count + countElem)
                {
                    int index = 0;
                    while (index + countElem != j-1) 
                    {
                        index++;
                    } 
                    table[i][index] = null;
                    return true;
                }
                else
                {
                    countElem += table[i].Count;
                }
            }
            return false;
        }*/

    }
}
