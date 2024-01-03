/*

Find the maximum (highest) number of a given number of numbers (1-5) from a user. Each number given by the user can be between and include -100 and 100.

Programmer: Skyler Reising
Last update: January 2nd, 2024

Requirements:
(1) All numbers in the problem should be integers.
(2) The number of numbers should be between and include 1-5.
(3) Each number given should be between and include -100 and 100.
(4) Use variables instead of arrays or other objects.

Algorithm:
do
(1) Prompt the user for the number of numbers between and including 1-5.
    (1a) While number isn't between or including 1-5, error message and prompt for number again.
(2) Store the number of numbers in a variable i because this will determine how many times we ask for a number.
(3) Declare a variable maxNum and assign it the lowest possible value.
(4) Ask the user for each number and store that number in maxNum if that number is greater than maxNum.
(5) Write maxNum to the console.

*/

using System;

namespace NumberComparisons
{
    class MaximumNumber
    {
        static void Main(string[] args)
        {
            //declare an integer to hold the number of numbers
            int amount;

            do
            {
                // (1) Prompt the user for the number of numbers between and including 1-5
                Console.WriteLine("Please enter the amount of numbers you would like to compare. The amount can be 1, 2, 3, 4, or 5");

                // (2) Store the number of numbers in a variable amount because this will determine how many times we ask for a number
                amount = Convert.ToInt32(Console.ReadLine());

                //     (2a) While amount isn't between or including 1-5, error message and prompt for number again
                if(amount < 1 || amount > 5)
                    {
                        Console.WriteLine("That number was not between 1 and 5");
                    }

            }while (amount < 1 || amount > 5);

            // (3) Declare a variable maxNum and assign it the lowest possible value
            int maxNum = -100;

            // (4) Ask the user for each number and store that number in maxNum if that number is greater than maxNum
            for(int i=1; i<=amount; i++)
            {
                int userNum;
                do
                    {
                        //Prompt the user the number they want compared
                        Console.WriteLine("Please enter a number you want compared between and including -100 and 100.");

                        //declare a variable to hold each number the user wants compared
                        userNum = Convert.ToInt32(Console.ReadLine());

                        //if number isn'g between -100 and 100, error message and prompt for number again
                        if(userNum < -100 || userNum > 100)
                            {
                                Console.WriteLine("That number was not between -100 and 100");
                            }
                    }while (userNum < -100 || userNum > 100);

                //store userNum in maxNum if that number is greater than maxNum
                if(userNum > maxNum)
                {
                    maxNum = userNum;
                }
            }

            // (5) Write maxNum to the console
            Console.WriteLine("The highest number you provided was " + maxNum);
        }
    }
}