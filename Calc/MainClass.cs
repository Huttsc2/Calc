using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calc
{
    internal class MainClass
    {
        public static void Main()
        {
            string example = Console.ReadLine();
            ExampleString exampleString = new(example);
            exampleString.Display();
        }
    }
}
