/*

Problem description: Given a single-dimensional array of scores, find the minimum, maximum, and average of the scores.

Software Engineer: Skyler Reising
Date: 1/8/24

Requirements:
(1) A single-dimensional array of scores.
(2) Write to the console.
    (2a) The minimum score of the array.
    (2b) The maximum score of the array.
    (2c) The average score of all scores in the array.

Algorithm:
(1) Using System.Linq, save the minimum score to an int variable.
(2) Using System.Linq, save the maximum score to an int variable.
(3) Using System.Linq, save the sum of all the scores to an int variable.
    (3a) Declare an average variable and save sum/array.Length to it.
(4) Print min, max, and average to the console

*/
// using System;
// using System.Linq;

// namespace Solution
// {
//     class Program
//     {
//         public static void Main(string[] args)
//         {
//             //The array of scores given
//             int[] scores = {10,10,9,8,10,8};

//             // (1) Using System.Linq, save the minimum score to an int variable.
//             int mini = scores.Min();

//             // (2) Using System.Linq, save the maximum score to an int variable.
//             int max = scores.Max();

//             // (3) Using System.Linq, save the sum of all the scores to an int variable.
//             int sum = scores.Sum();

//             //     (3a) Declare an average variable and save sum/array.Length to it.
//             double average = sum/(scores.Length);

//             // (4) Print min, max, and average to the console
//             Console.WriteLine($"Minimum: {mini}. Maximum: {max}. Average: {average}.");
//         }
//     }
// }

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
foreach int[] arr in array.
(1) save the sum of the array to a studentSum variable.
(2) Divide the studentSum by array[arr.length] and save that to a studentAverage variable.
(3) Print the studentAverage to the console.




*/