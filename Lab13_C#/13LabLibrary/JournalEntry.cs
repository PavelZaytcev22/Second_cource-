using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13LabLibrary
{
    public class JournalEntry
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public string Data { get; set; }

        public JournalEntry(string name, string type, string data) 
        {
            Name = name;
            Type = type;
            Data = data;
        }

        public override string ToString()
        {
            return "[ "+Name +" "+Type+" "+Data +" "+" ]";
        }

    }
}
