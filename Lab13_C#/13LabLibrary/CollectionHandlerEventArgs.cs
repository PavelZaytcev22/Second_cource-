using _10LabLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13LabLibrary
{
    
    public class CollectionHandlerEventArgs: System.EventArgs
    {
        public string Name { get; set; }
        public string TypeOfChange { get; set; }
        public Challenge Obj { get; set; }
        public CollectionHandlerEventArgs()
        {
            Name = "";
            TypeOfChange = "";
            Obj = new Challenge();
        }
        public CollectionHandlerEventArgs(string name, string type, Challenge obj)
        {
            Name = name;
            TypeOfChange = type;
            Obj = obj;
        }
        public override string ToString()
        {
            return Name + TypeOfChange + Obj.ToString();
        }

    }
}
