using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12LabLibrary
{
    public class HashEnumerator<T> : IEnumerator<ListPoints<T>>
    {
        //+- работает
        public HashTable<T> table;
        int position = -1;

        public HashEnumerator(HashTable<T> oldTable)
        {
            table = oldTable;
        }

        public ListPoints<T> Current
        {
            get
            {
                if (position == -1) MoveNext();
                return table[position];
            }
        }

        object IEnumerator.Current
        {
            get 
            {
                return Current;
            }
        }


        public void Dispose()
        {
           
        }

        public bool MoveNext()
        {
            if (position < table.Length-1)
            {
                position++;
                return true;
            }
            else { return false; }
        }

        public void Reset()
        {
            position = -1;
        }

    }
}
