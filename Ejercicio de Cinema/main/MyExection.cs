using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    public class MyExection : Exception
    {
        public MyExection(string message) : base(message)
        {
        }
    }
}
