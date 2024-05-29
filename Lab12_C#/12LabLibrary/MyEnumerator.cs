using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _12LabLibrary
{
    public class MyEnumerator<T> : IEnumerator<T>
    {
        Point<T> first;
        Point<T> current;

        public object Current//Фиктивная
        {
            get { throw new Exception("!!!!!!"); }
        }

        T IEnumerator<T>.Current  //Эта вещь меня утомила
        {
            get
            {
                if (current == null && first != null)
                {
                    MoveNext();
                    return current.Value;
                }
                else { return current.Value; }
            }
        }

        public MyEnumerator(ListPoints<T> c1)
        {
            if (c1 == null || c1.Count == 0)//Коллекция пуста 
            {
                first = null;
                current = null;
                //throw new Exception("!!!!Коллекция пуста!!!!!");
            }
            else 
            {
                first = c1.Head;
                current = null;
            }          
            
            // current = new Point<T>(c1.Head.Value);//Чтобы выводились все узлы списка (раньше было current=c1.Head) 
            //current.NextPoint = first;//При foreach применяется MoveNext()
        }

        public bool MoveNext()
        {
            if (current == null && first == null) return false; //Если коллекция пустая
            if (current == null) //для foreach()
            {
                current = first;
                return true;
            }
            if (current !=null && current.NextPoint != null)//для движения по списку 
            {
                current = current.NextPoint;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            current = first;
        }

        public void Dispose()
        {

        }    

    }
}
