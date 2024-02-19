using System;
using System.Linq;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            Console.WriteLine("Welcome to the console calculator. What would you like to do?");
            Console.WriteLine("Please enter a number between 1,2,3, or 4. Enter Q to quit.");
            Console.WriteLine("1 - Add");
            Console.WriteLine("2 - Subtract");
            Console.WriteLine("3 - Multiply");
            Console.WriteLine("4 - Divide");

            string operation = Console.ReadLine();

            if (operation == "1" || operation == "2" || operation == "3" || operation == "4")
            {
                Console.WriteLine($"The answer is {Operate(operation)}");
                Console.WriteLine("");
                MainMenu();
            }
            else if (operation == "Q".ToLower())
            {
                Quit();
            }
            else
            {
                Console.WriteLine("Please choose 1, 2, 3, 4, or Q");
                MainMenu();
            }
        }

        static double Operate(string operation)
        {
            Console.WriteLine("Enter your first number");
            double num1;

            while (!double.TryParse(Console.ReadLine(), out num1))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            Console.WriteLine("Enter your second number");
            double num2;

            while (!double.TryParse(Console.ReadLine(), out num2))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            if (operation == "1")
            {
                return num1 + num2;
            }
            else if(operation == "2")
            {
                return num1 - num2;
            }
            else if(operation == "3")
            {
                return num1 * num2;
            }
            else
            {
                if (num2 == 0)
                {
                    Console.WriteLine("Cannot divide by 0. Please try again");
                    Operate(operation);
                }
                return num1 / num2;
            }
        }

        static void Quit()
        {
            Console.WriteLine("Good bye!");
        }
    }
}