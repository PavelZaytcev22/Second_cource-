using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13LabLibrary
{
    public  class Journal
    {
        private List<JournalEntry> journal = new List<JournalEntry>();
            
        public void Add(JournalEntry value) 
        {
            journal.Add(value);        
        }

        public void Print() 
        {
            if (journal.Count > 0)
            {
                Console.WriteLine("Журнал:");
                foreach (var i in journal)
                {
                    Console.WriteLine(i);
                }
            }
            else 
            {
                Console.WriteLine("!!!!Журнал пустой!!!");            
            }
        }

        public void CollectionCountChanged(object source, CollectionHandlerEventArgs args) //Это подпишем в событие 
        {

            JournalEntry buff;
            if (args.Obj == null)
            {
                buff = new JournalEntry(args.Name, args.TypeOfChange, "NULL");
            }
            else 
            {
                buff = new JournalEntry(args.Name, args.TypeOfChange, args.Obj.ToString());
            }
            journal.Add(buff);
        }

        public void CollectionReferenceChanged(object source, CollectionHandlerEventArgs args) //Это подпишем в событие 
        {
            JournalEntry buff = new JournalEntry(args.Name, args.TypeOfChange, args.Obj.ToString());
            journal.Add(buff);
        }
    }
}
