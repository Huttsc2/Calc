using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calc
{
    public class SimpleExample
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

        public SimpleExample(string example)
        {
            example = example.Replace('.', ',').Replace(")", "").Replace("(", ""); //убрать потом replace
            this.example = example;
            Regex regex = new Regex("(?<=\\d)[*\\-+\\/]");
            numbers = regex.Split(example);
            x = double.Parse(numbers[0]);
            y = double.Parse(numbers[1]);
            MathSign();
            SetAnswer();
        }
        public void SetAnswer()
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

        public string Addition()
        {
            string example = Math.Round((x + y), 2).ToString();
            return example;
        }

        public string Subtraction()
        {
            string example = Math.Round((x - y), 2).ToString();
            return example;
        }

        public string Multiplicationt()
        {
            string example = Math.Round((x * y), 2).ToString();
            return example;
        }

        public string Division()
        {
            string example = Math.Round((x / y), 2).ToString();
            return example;
        }

        public string GetAnswer()
        {
            return answer;
        }
    }
}
