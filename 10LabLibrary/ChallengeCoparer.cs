using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10LabLibrary
{
    public class ChallengeCoparer:IComparer<Challenge>
    {
        public int Compare(Challenge obj1, Challenge obj2) 
        {
            if (obj1 != null && obj2 != null) 
            {
                return obj1.Name.CompareTo(obj2.Name);
            }
            return 0;
        }
    }
}
