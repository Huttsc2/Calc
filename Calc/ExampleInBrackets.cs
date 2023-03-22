using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calc
{
    public class ExampleInBrackets
    {
        public string example;
        public string patternExprecionInBrackets = "\\([\\(\\-\\d+,?\\d*\\)]*\\d+[+\\-*\\/][\\(\\-\\d+,?d*\\)]*\\)";
        public bool isExprecionInBrackets;
        public string shortExample;
        public bool isShortest;
        public bool isSinglePositive;
        public string newExample;


        public ExampleInBrackets(string example)
        {
            this.example = example;
            Console.WriteLine(example);
            exprecionInBrackets();
            if (isExprecionInBrackets)
            {
                SetShortExample();
                RemoveBrackets();
                SinglePositive();
                Shortest();
                Replace();
                Console.WriteLine(newExample);
            }
            else
            {
                Console.WriteLine("stop");
            }
        }

        public void exprecionInBrackets()
        {
            isExprecionInBrackets = Regex.IsMatch(example, patternExprecionInBrackets);
        }

        public void SetShortExample()
        {
            Match m = Regex.Match(example, patternExprecionInBrackets);
            if (m.Success)
            {
                shortExample = m.Groups[0].Value;
            }
        }

        public void Shortest()
        {
            Match m = Regex.Match(shortExample, patternExprecionInBrackets);
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
                if (!isSinglePositive)
                {
                    shortExample = "(" + shortExample + ")";
                }
                Regex replacePattern = new(patternExprecionInBrackets);
                newExample = replacePattern.Replace(example, shortExample, 1);
            }
            else
            {
                ExampleInBrackets exampleInBrackets = new(shortExample);
                shortExample = exampleInBrackets.newExample;
                if (!isSinglePositive)
                {
                    shortExample = "(" + shortExample + ")";
                }
                Regex replacePattern = new(patternExprecionInBrackets);
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
