using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calc
{
    internal class ExampleInBrackets
    {
        public string example;
        public string pattern = "\\([\\(\\-\\d+,?\\d*\\)]*\\d+[+\\-*\\/][\\(\\-\\d+,?d*\\)]*\\)";
        public string shortExample;
        public bool isShortest;
        public bool isSinglePositive;
        public string newExample;


        public ExampleInBrackets(string example)
        {
            this.example = example;
            Console.WriteLine(example);
            SetShortExample();
            RemoveBrackets();
            Shortest();
            Replace();
            Console.WriteLine(newExample);
        }

        public void SetShortExample()
        {
            Match m = Regex.Match(example, pattern);
            if (m.Success)
            {
                shortExample = m.Groups[0].Value;
            }
        }

        public void Shortest()
        {
            Match m = Regex.Match(shortExample, pattern);
            if (m.Success)
            {
                isShortest = false;
            }
            else
            {
                isShortest = true;
            }
        }

        public void SinglePositive()
        {
            isSinglePositive = Regex.IsMatch(shortExample, "^\\d+,?\\d*$");
        }

        public void RemoveBrackets()
        {
            Regex firstBracket = new("^\\(");
            Regex lastBracket = new("\\)$");
            shortExample = firstBracket.Replace(shortExample, "", 1);
            shortExample = lastBracket.Replace(shortExample, "", 1);
        }

        public void Replace()
        {
            if (isShortest)
            {
                ReplaceMethod replaceMethod = new(shortExample);
                shortExample = replaceMethod.newFullExample;
                SinglePositive();
                if (!isSinglePositive)
                {
                    shortExample = "(" + shortExample + ")";
                }
                Regex replacePattern = new(pattern);
                newExample = replacePattern.Replace(example, shortExample, 1);
            }
            else
            {
                Console.WriteLine("qwe");
                ExampleInBrackets exampleInBrackets = new(shortExample);
                ReplaceMethod replaceMethod = new(exampleInBrackets.shortExample);
                shortExample = replaceMethod.newFullExample;
                exampleInBrackets.SinglePositive();
                if (!exampleInBrackets.isSinglePositive) 
                {
                    shortExample = "(" + shortExample + ")";
                }
                Regex replacePattern = new(pattern);
                newExample = replacePattern.Replace(example, shortExample, 1);
            }
        }

        public void Display()
        {
            Console.WriteLine(example);
            Console.WriteLine(newExample);
        }
    }
}
