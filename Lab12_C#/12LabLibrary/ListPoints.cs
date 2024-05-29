using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace _12LabLibrary
{
    public class ListPoints<T>:ICollection<T>
    {
        protected Point<T> head;

        public Point<T> Head 
        {
            get { return head;}
        }

        public ListPoints()
        {
            head = null;
        }

        public ListPoints(T value)
        {
            head = new Point<T>(value);  
        }

        public ListPoints(ListPoints<T> oldList) //Конструктор копирования
        {
            if (oldList == null) head = null;
            else 
            {
                if (oldList.Head == null)
                {
                    head = null;
                }
                else 
                {
                    head = new Point<T>(oldList.Head.Value);
                    Point<T> buffOld = oldList.Head;
                    Point<T> buffNew = head;
                    while (buffOld.NextPoint != null) 
                    {
                        buffOld = buffOld.NextPoint;
                        buffNew.NextPoint = new Point<T>(buffOld.Value);
                        buffNew = buffNew.NextPoint;
                    }
                }
            }
        }

        public void Clear()
        {
            //head = null;//Было вот так 
            if (head != null) 
            {
                Point<T> buff = head;
                while (buff.NextPoint != null)
                {
                    buff.Value = default;
                    buff = buff.NextPoint;
                }
                buff.Value = default;
            }
            
        }

        public bool Contains(T value)//Доделать 
        {           
                foreach (T i in this) 
                {
                if (i == null && value==null) return true;
                if (i != null) 
                {
                    if (i.Equals(value)) return true;
                }
                
                }
            return false;                  
        }

        public void Add(T value) 
        {
            Point<T> buff;
            if (this.Contains(default) && head!=null)//Добавление в пустой узел 
            {
                buff = head;
                T check = default;//Нужна инициализация
                bool flag = true; 
                while (flag && buff.NextPoint !=null)
                {
                    if (buff.Value == null)//Для ссылок 
                    {
                        buff.Value = value;
                        flag = false;
                    }
                    else 
                    {
                        if (buff.Value.Equals(check))//Для значений 
                        {
                            buff.Value = value;
                            flag = false;
                        }
                    }
                  buff = buff.NextPoint;
                }                      
            }
            else //Формирование нового узла списка 
            {
                buff = new Point<T>(value);
                buff.NextPoint = head;
                head = buff;
            }            
        }

        public void CopyTo(T[] array, int arrayIndex) 
        {
            T[] buffarray = new T[this.Count];
            int buffindex = 0;
            if (head!=null) 
            {
                Point<T> point = head;
                array[buffindex] = point.Value;
                buffindex++;
                while (point.NextPoint != null) 
                {
                    point = point.NextPoint;
                    array[buffindex] = point.Value;
                    buffindex++;
                }
            }          

        }

        public bool Remove(T value) //++
        {
            if (Head == null) return false;
            Point<T> buff = Head;
            while (buff.NextPoint != null) 
            {
                if (buff.Value != null) 
                {
                    if (buff.Value.Equals(value))
                    {
                        buff.Value = default;
                        return true;
                    }
                }
                buff = buff.NextPoint;
            }
            if (buff.Value != null)//Проверка последнего элемента списка
            {
                if (buff.Value.Equals(value))
                {
                    buff.Value = default;
                    return true;
                }
            }        

            return false;//не нашлось похожих
            
        }     

        public int Count 
        {
            get 
            {
                int countElements = 0;
                if (head != null) 
                {
                    T check = default;
                    Point<T> buff = head;                   
                    do
                    {
                        if (buff.Value != null) //Для ссылок
                        {
                            if (!buff.Value.Equals(check)) //Для значений
                            {
                                countElements++;
                            }
                        }
                    buff = buff.NextPoint;
                    } while (buff!=null);
                    return countElements;
                }
                return 0;
            }

        }

        public bool IsReadOnly 
        {
            get { return true; }
        }

        public T this[int index] //Индексатор для списка
        {
            get 
            {
                if (index >= Count || index < 0)
                {
                    throw new IndexOutOfRangeException("Выход за границу списка");
                }
                else 
                {
                    Point<T> buff = head;
                    for (int i=0;i<index; i++) 
                    {
                        buff = buff.NextPoint;
                    }
                    return buff.Value;
                }
            }
            set 
            {
                if (index >= Count || index < 0)
                {
                    throw new IndexOutOfRangeException("Выход за границу списка");
                }
                else
                {
                    Point<T> buff = head;
                    for (int i = 0; i < index; i++)
                    {
                        buff = buff.NextPoint;
                    }
                    buff.Value = value;
                }
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new MyEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()//Фиктивная 
        {
            throw new NotImplementedException();
        }      

    }
}
