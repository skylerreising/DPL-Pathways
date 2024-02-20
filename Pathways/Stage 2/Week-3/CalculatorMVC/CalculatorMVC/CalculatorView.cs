using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMVC
{
    public class CalculatorView
    {
        public CalculatorView()
        {

        }

        public double GetNum1()
        {
            Console.WriteLine("Please enter the 1st number.");
            double num1 = double.Parse(Console.ReadLine());

            if(num1 is double)
            {
                return num1;
            }
            else
            {
                Console.WriteLine("Please enter a number");
                return GetNum1();
            }
        }

        public string GetOperator()
        {
            Console.WriteLine("Please enter the operation you would like to perform. Choose +, -, *, or /");
            string operatorSign = Console.ReadLine();

            if (operatorSign == "+" || operatorSign == "-" || operatorSign == "*" || operatorSign == "/")
            {
                return operatorSign;
            }
            else
            {
                Console.WriteLine("Please enter a plus (+), minus (-), multiply (*), or divide (/) sign.");
                return GetOperator();
            }
        }

        public double GetNum2()
        {
            Console.WriteLine("Please enter the 2nd number.");
            double num2 = double.Parse(Console.ReadLine());

            if (num2 is double)
            {
                return num2;
            }
            else
            {
                Console.WriteLine("Please enter a number");
                return GetNum2();
            }
        }

        public void ShowResult(double num1, double num2, string operatorSign)
        {
            double answer;

            if(operatorSign == "+")
            {
                answer = num1 + num2;
            }
            else if (operatorSign == "-")
            {
                answer = num1 - num2;
            }
            else if (operatorSign == "*")
            {
                answer = num1 * num2;
            }
            else
            {
                answer = num1 / num2;
            }
            Console.WriteLine($"The answer to {num1} {operatorSign} {num2} is {answer}");
        }
    }
}
