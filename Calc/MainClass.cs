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
            SimpleExample exampleString = new("5+-3");
            Console.WriteLine(exampleString.GetAnswer());
            ReplaceMethod replaceMethod = new("3+(-3)*(-2)");
            Console.WriteLine(replaceMethod.GetAnswer());
        }
    }
}
