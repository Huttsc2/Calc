using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calc
{
    public class MainClass
    {
        public static void Main()
        {
            ExampleInBrackets exampleInBrackets = new("1+(2+(3+(9+6)+7)+8)+9");
            //ExampleInBrackets c = new("3+(6)+7");
            
        }

    }
}
