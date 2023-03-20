using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calc
{
    public class ReplaceMethod
    {
        public string fullExample;
        public string shortExample;
        public string decidedShortExample;
        public bool isFirstPriority;
        public bool isNegative;
        public string firstPriorityPattern = "^\\-\\d,?\\d*[\\/\\*]\\(?-?\\d+,?\\d*\\)?|" +
                    "\\d+,?\\d*[\\/\\*]\\(?-?\\d+,?\\d*\\)?|\\(\\-\\d+,?\\d*\\)[\\/\\*]\\(?-?\\d+,?\\d*\\)?";
        public string secondPriorityPattern = "^\\-\\d,?\\d*[+\\-]\\(?-?\\d+,?\\d*\\)?|" +
                    "\\d+,?\\d*[+\\-]\\(?-?\\d+,?\\d*\\)?|\\(\\-\\d+,?\\d*\\)[+\\-]\\(?-?\\d+,?\\d*\\)?";
        public string newFullExample;

        public ReplaceMethod(string fullExample)
        {
            fullExample = fullExample.Replace('.', ','); //убрать потом replace
            this.fullExample = fullExample;
            Priority();
            SetShortExample();
            SetDecide();
            ChangeExample();
        }

        public void Priority()
        {
            isFirstPriority = Regex.IsMatch(fullExample, "[*\\/]");
        }

        public void Negative()
        {
            isNegative = Regex.IsMatch(decidedShortExample, "-");
        }

        public void SetShortExample()
        {
            if (isFirstPriority)
            {
                Match m = Regex.Match(fullExample, firstPriorityPattern);
                if (m.Success)
                {
                    shortExample = m.Groups[0].Value;
                }
            }
            else
            {
                Match m = Regex.Match(fullExample, secondPriorityPattern);
                if (m.Success)
                {
                    shortExample = m.Groups[0].Value;
                }
            }
        }

        public void SetDecide()
        {
            SimpleExample simpleExample = new SimpleExample(shortExample);
            decidedShortExample = simpleExample.GetAnswer();
            Negative();
            if (isNegative)
            {
                decidedShortExample = "(" + decidedShortExample + ")";
            }
        }

        public void ChangeExample()
        {
            if (isFirstPriority)
            {
                Regex rgx = new Regex(firstPriorityPattern);
                newFullExample = rgx.Replace(fullExample, decidedShortExample, 1);
            } 
            else
            {
                Regex rgx = new Regex(secondPriorityPattern);
                newFullExample = rgx.Replace(fullExample, decidedShortExample, 1);
            }
        }

        public string GetAnswer()
        {
            return newFullExample;
        }
    }
}
