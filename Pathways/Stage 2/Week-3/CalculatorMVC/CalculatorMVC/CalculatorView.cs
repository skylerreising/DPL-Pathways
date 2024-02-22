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

        //View method to ask if user wants to calculate or quit
        public bool CalcOrQuit()
        {
            //Ask user if they want to calc or quit and save answer in string variable
            Console.WriteLine("Enter \"C\" to make a calculation or \"Q\" to quit.");
            string calcOrQuit = Console.ReadLine();
            if (calcOrQuit.ToLower() == "c" )
            {
                return true;
            }
            else if(calcOrQuit.ToLower() == "q")
            {
                Console.WriteLine("Good bye.");
                return false;
            }
            else
            {
                Console.WriteLine("Invalid entry. Please enter \"C\" to make a calculation or \"Q\" to quit.");
                return CalcOrQuit();
            }
        }
        public double GetNum1()
        {
            double num1;

            Console.WriteLine("Please enter the 1st number.");
            

            if(double.TryParse(Console.ReadLine(), out num1))
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
            double num2;
            Console.WriteLine("Please enter the 2nd number.");
            

            if (double.TryParse(Console.ReadLine(), out num2))
            {
                return num2;
            }
            else
            {
                Console.WriteLine("Please enter a number");
                return GetNum2();
            }
        }

        public void ShowResult(double num1, string op, double num2, double answer)
        {
            Console.WriteLine($"The answer to {num1} {op} {num2} is {answer}");
        }
    }
}
