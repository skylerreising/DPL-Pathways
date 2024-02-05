
/*

Problem description: Given a two-dimensional array of scores (a column contains the scores for a student), find the average score for each student, and the minimum, maximum and average for the class.

Software Engineer: Skyler Reising
Date: 1/8/24 - 1/9/24

Requirements:
(1) A two-dimensional array of scores
(2) Write to the console.
    (2a) The average score for each student.
    (2b) The minimum score for the class.
    (2b) The maximum score for the class.
    (2c) The average score for the class.

Algorithm:

Write to the console the average score for each student.
foreach int[] arr in the array.
(1) save the sum of the array to a studentSum variable.
(2) Divide the studentSum by the array length and save that to a studentAverage variable.
(3) Print the studentAverage to the console.

Write to the console the minimum score for the class.
(1) Declare a min variable = 100.
(2) Use a nested loop to loop through the multidimensional array.
    (3) If the value is less than min, assign min that value
(4) Write to the console the min.

Write to the console the maximum score for the class.
(1) Declare a max variable = 0.
(2) Use a nested loop to loop through the multidimensional array.
    (3) If the value is greater than max, assign max that value.
(4) Write to the console the min.

Write to the console the average score for the class.
(1) Declare a sum variable and a count variable. Set both to 0.
(2) Use a nested loop to loop through the multidimensional array.
(3) Add each score to the sum variable and increment the count by 1.
(4) Declare an ave variable and assign it sum/count.
(5) Write ave to the console.

*/

using System;
using System.Linq;

namespace Solution
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[,] scores = {{100,90,91},{98,95,94},{89,100,99},{88,99,94}};
            string[] studentNames = {"John","Paul","George","Ringo"};

            // Write to the console the average score for each student.
            // foreach int[] arr in the array. **Changed to nested for loop
            for (int i=0; i<scores.GetLength(0); i++)
            {
                // (1) save the sum of the array to a studentSum variable.
                int studentSum = 0;
                for (int j=0; j<scores.GetLength(1); j++)
                {
                    studentSum += scores[i, j];
                }

                // (2) Divide the studentSum by the array length and save that to a studentAverage variable.
                double studentAverage = studentSum/scores.GetLength(1);

                // (3) Print the studentAverage to the console.
                Console.WriteLine($"{studentNames[i]}'s average score is {studentAverage}.");
            }

            // Write to the console the minimum score for the class.
            // (1) Declare a min variable = 100.
            int min = 100;
            // (2) Use a nested loop to loop through the multidimensional array.
            for(int i=0; i<scores.GetLength(0); i++)
            {
                for(int j=0; j<scores.GetLength(1); j++)
                {
                    // (3) If the value is less than min, assign min that value
                    if(scores[i,j] < min)
                    {
                        min = scores[i,j];
                    }
                }
            }
            // (4) Write to the console the min.
            Console.WriteLine($"The lowest score in the class is {min}.");

            // Write to the console the maximum score for the class.
            // (1) Declare a max variable = 0.
            int max = 0;
            // (2) Use a nested loop to loop through the multidimensional array.
            for(int i=0; i<scores.GetLength(0); i++)
            {
                for(int j=0; j<scores.GetLength(1); j++)
                {
                    // (3) If the value is greater than max, assign max that value
                    if(scores[i,j] > max)
                    {
                        max = scores[i,j];
                    }
                }
            }
            // (4) Write to the console the min.
            Console.WriteLine($"The highest score in the class is {max}.");

            // Write to the console the average score for the class.
            // (1) Declare a sum variable and a count variable. Set both to 0.
            int sum = 0;
            int count = 0;

            // (2) Use a nested loop to loop through the multidimensional array.
            for(int i=0; i<scores.GetLength(0); i++)
            {
                for(int j=0; j<scores.GetLength(1); j++)
                {
                    // (3) Add each score to the sum variable and increment the count by 1.
                    sum += scores[i,j];
                    count++;
                }
            }
            
            // (4) Declare an ave variable and assign it sum/count.
            double ave = sum/count;

            // (5) Write ave to the console.
            Console.WriteLine($"The average score for the class is {ave}.");
        }
    }
}