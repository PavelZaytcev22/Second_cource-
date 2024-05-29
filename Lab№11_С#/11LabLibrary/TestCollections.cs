using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _10LabLibrary;
using System.Diagnostics;

namespace _11LabLibrary
{
    public class TestCollections
    {
        private Stack<FinalExam> col1=new Stack<FinalExam>();
        private Stack<string> col2 = new Stack<string>();
        private Dictionary<Exam, FinalExam> col3 = new Dictionary<Exam, FinalExam>();
        private Dictionary<string, FinalExam> col4 = new Dictionary<string, FinalExam>();

        public TestCollections(int countElements) 
        {
            if (countElements < 0)
            {
                throw new Exception("Нельзя инициализировать коллекцию длиной меньше 0");
            }
            else 
            {
                if (countElements > 0 ) 
                {
                    for (int i = 0; i < countElements; i++) 
                    {
                        FinalExam buff = new FinalExam();
                        buff.RandomInit();
                        col1.Push(buff);
                        col2.Push(buff.ToString());
                        col3.Add(buff.BaseExam, buff);
                        col4.Add(buff.ToString(), buff);
                    }
                }
            }
        }

        public void Delete() 
        {
            if (col1.Count > 0) 
            {
                FinalExam c1 = col1.Peek();
                Exam key = c1.BaseExam;
                col1.Pop();
                col2.Pop();    
                col3.Remove(key);
                col4.Remove(key.ToString());
            }
            else { throw new Exception("Коллекции пуста"); }
        }

        public void Add()
        {
            FinalExam buff = new FinalExam();
            buff.RandomInit();
            col1.Push(buff);
            col2.Push(buff.ToString());
            col3.Add(buff.BaseExam, buff);
            col4.Add(buff.ToString(), buff);
        }

        public void CheckTime() 
        {
            Stopwatch stopwatch = new Stopwatch();
            IEnumerator enuminator = col1.GetEnumerator();
            for (int i = 0; i < col1.Count / 2; i++) { enuminator.MoveNext(); }
            FinalExam buff = (FinalExam)enuminator.Current;
            FinalExam midlElement = new FinalExam(buff.Name, buff.Questions, buff.Date, buff.Time, buff.Mark);
            FinalExam  firstElement = new FinalExam(col1.Peek().Name, col1.Peek().Questions, col1.Peek().Date, col1.Peek().Time, col1.Peek().Mark);
            FinalExam lastElement = new FinalExam(col1.Last().Name, col1.Last().Questions, col1.Last().Date, col1.Last().Time, col1.Last().Mark);
            
            string midlName= midlElement.ToString();
            string firstName = col2.First();
            string lastName =col2.Last();



            /*firstElement.Show();
            col1.First().Show();
            Console.WriteLine(firstName);*/

            
            Console.WriteLine("Коллекция Stack<string> по значению:");
            stopwatch.Start();
            if (col2.Contains(firstName)) 
            {
                stopwatch.Stop();
                Console.WriteLine("Первый элемент найден за {0} тиков", stopwatch.ElapsedTicks);
            }
            stopwatch.Restart();
            if (col2.Contains(lastName))
            {
                stopwatch.Stop();
                Console.WriteLine("Последний элемент найден за {0} тиков", stopwatch.ElapsedTicks);
            }
            stopwatch.Restart();
            if (col2.Contains(midlName))
            {
                stopwatch.Stop();
                Console.WriteLine("Средний элемент найден за {0} тиков", stopwatch.ElapsedTicks);
            }
            firstName = "";
            stopwatch.Restart();
            col2.Contains(firstName);
            stopwatch.Stop();
            Console.WriteLine("Несущ. элемент за {0} тиков", stopwatch.ElapsedTicks);
            
            Console.WriteLine("\n\nКоллекция Stack<FinalExam> по значению:");
            stopwatch.Restart();
            if (col1.Contains(firstElement))
            {
                stopwatch.Stop();
                Console.WriteLine("Первый элемент найден за {0} тиков", stopwatch.Elapsed.Ticks);
            }
            stopwatch.Restart();
            if (col1.Contains(lastElement))
            {
                stopwatch.Stop();
                Console.WriteLine("Последний элемент найден за {0} тиков", stopwatch.ElapsedTicks);
            }
            stopwatch.Restart();
            if (col1.Contains(midlElement))
            {
                stopwatch.Stop();
                Console.WriteLine("Средний элемент найден за {0} тиков", stopwatch.ElapsedTicks);
            }
            stopwatch.Restart();
            col1.Contains(new FinalExam());
            stopwatch.Stop();
            Console.WriteLine("Несущ. элемент за {0} тиков", stopwatch.ElapsedTicks);
            ///////////////////////////////////////////////////////////////
            Console.WriteLine("\n\nКоллекция Dictionary<Exam,FinalExam> по ключу:");
            stopwatch.Restart();
            if (col3.ContainsKey(firstElement.BaseExam))
            {
                stopwatch.Stop();
                Console.WriteLine("Первый элемент найден за {0} тиков", stopwatch.Elapsed.Ticks);
            }
            stopwatch.Restart();
            if (col3.ContainsKey(lastElement.BaseExam))
            {
                stopwatch.Stop();
                Console.WriteLine("Последний элемент найден за {0} тиков", stopwatch.ElapsedTicks);
            }
            stopwatch.Restart();
            if (col3.ContainsKey(midlElement.BaseExam))
            {
                stopwatch.Stop();
                Console.WriteLine("Средний элемент найден за {0} тиков", stopwatch.ElapsedTicks);
            }
            stopwatch.Restart();
            col3.ContainsKey(new FinalExam().BaseExam);
            stopwatch.Stop();
            Console.WriteLine("Несущ. элемент за {0} тиков", stopwatch.ElapsedTicks);

            ///////////////////////////////////////////////////////////////
            Console.WriteLine("\n\nКоллекция Dictionary<Exam,FinalExam> по значению:");
            stopwatch.Restart();
            if (col3.ContainsValue(firstElement))
            {
                stopwatch.Stop();
                Console.WriteLine("Первый элемент найден за {0} тиков", stopwatch.Elapsed.Ticks);
            }
            stopwatch.Restart();
            if (col3.ContainsValue(lastElement))
            {
                stopwatch.Stop();
                Console.WriteLine("Последний элемент найден за {0} тиков", stopwatch.ElapsedTicks);
            }
            stopwatch.Restart();
            if (col3.ContainsValue(midlElement))
            {
                stopwatch.Stop();
                Console.WriteLine("Средний элемент найден за {0} тиков", stopwatch.ElapsedTicks);
            }
            stopwatch.Restart();
            col3.ContainsValue(new FinalExam());
            stopwatch.Stop();
            Console.WriteLine("Несущ. элемент за {0} тиков", stopwatch.ElapsedTicks);

            ///////////////////////////////////////////////////////////////
            Console.WriteLine("\n\nКоллекция Dictionary<string,FinalExam> по ключу:");
            stopwatch.Restart();
            if (col4.ContainsKey(firstElement.ToString()))
            {
                stopwatch.Stop();
                Console.WriteLine("Первый элемент найден за {0} тиков", stopwatch.Elapsed.Ticks);
            }
            stopwatch.Restart();
            if (col4.ContainsKey(firstElement.ToString()))
            {
                stopwatch.Stop();
                Console.WriteLine("Последний элемент найден за {0} тиков", stopwatch.ElapsedTicks);
            }
            stopwatch.Restart();
            if (col4.ContainsKey(firstElement.ToString()))
            {
                stopwatch.Stop();
                Console.WriteLine("Средний элемент найден за {0} тиков", stopwatch.ElapsedTicks);
            }
            stopwatch.Restart();
            col4.ContainsKey(new FinalExam().ToString());
            stopwatch.Stop();
            Console.WriteLine("Несущ. элемент за {0} тиков", stopwatch.ElapsedTicks);
            /////////////////////////////////////////////////////////////////////
            Console.WriteLine("\n\nКоллекция Dictionary<string,FinalExam> по значению:");
            stopwatch.Restart();
            if (col4.ContainsValue(firstElement))
            {
                stopwatch.Stop();
                Console.WriteLine("Первый элемент найден за {0} тиков", stopwatch.Elapsed.Ticks);
            }
            stopwatch.Restart();
            if (col4.ContainsValue(firstElement))
            {
                stopwatch.Stop();
                Console.WriteLine("Последний элемент найден за {0} тиков", stopwatch.ElapsedTicks);
            }
            stopwatch.Restart();
            if (col4.ContainsValue(firstElement))
            {
                stopwatch.Stop();
                Console.WriteLine("Средний элемент найден за {0} тиков", stopwatch.ElapsedTicks);
            }
            stopwatch.Restart();
            col4.ContainsValue(new FinalExam());
            stopwatch.Stop();
            Console.WriteLine("Несущ. элемент за {0} тиков", stopwatch.ElapsedTicks);
        }

    }
}
