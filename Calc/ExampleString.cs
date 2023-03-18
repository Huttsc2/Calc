using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calc
{
    internal class ExampleString
    {
        public string example;
        public string[] numbers;
        public double x;
        public double y;
        public string answer;
        public bool isPlus;
        public bool isMinus;
        public bool isMultiplication;
        public bool isDivision;

        public ExampleString(string example)
        {
            example = example.Replace('.', ',').Replace(")", "").Replace("(", "");
            this.example = example;
            Regex regex = new Regex("(?<=\\d)[*\\-+\\/]");
            numbers = regex.Split(example);
            x = double.Parse(numbers[0]);
            y = double.Parse(numbers[1]);
            MathSign();
            GetAnswer();
        }
        public void GetAnswer()
        {
            if (isPlus)
            {
                answer = Addition();
            }
            if (isMinus)
            {
                answer = Subtraction();
            }
            if (isMultiplication)
            {
                answer = Multiplicationt();
            }
            if (isDivision)
            {
                answer = Division();
            }
        }

        public void MathSign()
        {
            isPlus = Regex.IsMatch(example, "\\+");
            isMinus = Regex.IsMatch(example, "\\d-");
            isMultiplication = Regex.IsMatch(example, "\\*");
            isDivision = Regex.IsMatch(example, "/");
        }

        public void Display()
        {
            Console.WriteLine(answer);
        }

        public string Addition()
        {
            string example = (x + y).ToString();
            return example;
        }

        public string Subtraction()
        {
            string example = (x - y).ToString();
            return example;
        }

        public string Multiplicationt()
        {
            string example = (x * y).ToString();
            return example;
        }

        public string Division()
        {
            string example = (x / y).ToString();
            return example;
        }
    }
}
