/*

You have been tasked with baking chocolate chip cookies. You have a great recipe to make the cookies, but you have a problem. The recipe gives the amount of sugar needed for the cookies in ounces, but you need the amount in cups. Write a program that will take the number of ounces of sugar given in the recipe and return the number of cups needed.

Programmer: Skyler Reising
Last update: January 2nd, 2024

Requirements:
(1) The number of ounces will be an integer obtained from the user's recipe that is greater than 0.
(2) The number of cups will be calculated by multiplying the number of ounces by 0.125 (8oz to 1 cup).
(3) The number of cups will be a double.

Algorithm:
do
    (1) Prompt the user for the number of ounces greater than 0 given by the recipe. 
    (2) Obtain the number of ounces from the user.
    (3) If number of ounces is less than or equal to 0. Provide error message .
    while number of ounces <= 0
(4) Calculate the number of cups.
(5) Write to the console the number of cups.

*/

using System;

namespace Conversions
{
    class OuncesToCups
    {
        static void Main(string[] args)
        {
            //declare an integer to hold the value of ounces
            int ounces = 0;
            do
            {
                //(1) Prompt the user for the number of ounces of sugar greater than 0 given by the recipe. 
                Console.WriteLine("Please enter the number of ounces of sugar called for in the recipe");

                //(2) Obtain the number of ounces from the user
                ounces = Convert.ToInt32(Console.ReadLine());

                //(3) If number of ounces is less than or equal to 0
                //  (3a) Go back to step 1  
                if(ounces <= 0)
                    {
                        Console.WriteLine("Oops! Enter a number greater than 0 please.");
                    }
            } while (ounces <= 0);
        
            //(4) Calculate the number of cups
            double cups = ounces * 0.125;

            //(5) Write to the console the number of cups
            Console.WriteLine($"Instead of using {ounces} ounces, use {cups} cups instead!");
        }
    }
}