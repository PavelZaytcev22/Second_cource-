using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12LabLibrary
{
    public class Functions
    {
        public static int StringValue(string ss)
        {
            int count = 0;
            for (int i = 0; i < ss.Length; i++)
            {
                count += ss[i];
            }
            return count;
        }
    }
}
