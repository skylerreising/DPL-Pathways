/*

Problem description: Your instructor needs to calculate individual student grades for another class.

Requirements/User stories:

The instructor will provide the number of students for which grades need to be calculated.  This number must be at least one.
For each student, the instructor will provide five homework grades, three quiz grades, and two exam grades.  All grades must be between 0 and 100 inclusively.
A student's final grade average is calculated by adding together 50% of the homework average, 30% of the quiz average and 20% of the exam average.
A student's final grade is calculated  based on the final grade average.  If it is 90% or greater, it is an A; 80% or better is a B; 70% or better is a C; 60% or better is a D; and anything less than 60% is an F.
Once calculated, the program will display the student's name, homework average, quiz average, exam average, final average and final grade.

Software Engineer: Skyler Reising
Date: 1/5/24

Requirements:
(1) The instructor has to provide 1 or more students.
(2) All homework grades should be 0-100.
(3) Each group of grades should be calculated as a weighted average to get the final grade.
(4) Written to the console should be the student's name, homework average, quiz average, exam average, final average, and final letter grade.

Algorithm:
do
(1) Prompt the instructor to provide the number of students who need grades to be calculated.
(2) Get the number of students from the instructor and store it in an int.
(3) If number is less than 1, give an error.
while number of students < 1

for loop i=1; i<= number of students
(4) Prompt the instructor to provide the students name.
(5) Store the student's name in a string.

do
(6) Prompt the instructor to provide five homework grades.
    (6a) Declare an int count = 0 and increment it every time a valid number is given.
(7) Get each homework grade from the instructor and accumulate the grades as they're received.
(8) If the number is valid, increment the count by 1
    (8a) If a grade is not 0-100, give an error.
while count < 5
(9) Divide homework grade by 5.

do
(10) Prompt the instructor to provide three quiz grades.
    (10a) Declare an int count = 0 and increment it every time a valid number is given.
(11) Get each quiz grade from the instructor and accumulate the grades as they're received.
(12) If the number is valid, increment the count by 1
    (12a) If a grade is not 0-100, give an error.
while count < 3
(13) Divide quiz grade by 3.

do
(14) Prompt the instructor to provide two exam grades.
    (14a) Declare an int count = 0 and increment it every time a valid number is given.
(15) Get each exam grade from the instructor and accumulate the grades as they're received.
(16) If the number is valid, increment the count by 1
    (16a) If a grade is not 0-100, give an error.
while count < 2
(17) Divide exam grade by 2.

(18) Declare a double final grade which is homework * 0.5 + quiz * 0.3 + exam * 0.2.
(19) Declare a char for final letter grade
    (19a) If final letter grade >= 90% - A
    (19b) If final letter grade >= 80% - B
    (19c) If final letter grade >= 70% - C
    (19d) If final letter grade >= 60% - D
    (19e) If final letter grade < 60% - F
(20) Write to the console the student's name, homework average, quiz average, exam average, final average, and final letter grade.
End for loop.

*/

using System;

class Grading
{
    static void FinalGrades()
    {
        int numOfStudents;
        do
        {
        // (1) Prompt the instructor to provide the number of students who need grades to be calculated.
        Console.WriteLine("Please provide the number of students who need grades calculated.");

        // (2) Get the number of students from the instructor and store it in an int.
        numOfStudents = Convert.ToInt32(Console.ReadLine());

        // (3) If number is less than 1, give an error.
        if(numOfStudents < 1)
        {
            Console.WriteLine("Please provide a number greater than 0.");
        }
        // while number of students < 1
        }while(numOfStudents < 1);

        // for loop i=1; i<= number of students
        for(int i=1; i<=numOfStudents; i++)
        {
            // (4) Prompt the instructor to provide the students name.
            Console.WriteLine("Please provide the name of the student you want to evaluate.");
            // (5) Store the student's name in a string.
            string studentName = Console.ReadLine();

            //All variables needed to calculate student's grades
            int count = 0;
            double homeworkGrade = 0;
            double quizGrade = 0;
            double examGrade = 0;

            do
            {
                // (6) Prompt the instructor to provide five homework grades.
                Console.WriteLine("Please enter a homework grade for " + studentName + ".");

                //     (6a) Declare an int count = 0 and increment it every time a valid number is given.
                
                // (7) Get each homework grade from the instructor and accumulate the grades as they're received.
                double grade;
                grade = Convert.ToDouble(Console.ReadLine());

                // (8) If the grade is valid, increment the count by 1
                if(grade >= 0 && grade <= 100)
                {
                    homeworkGrade += grade;
                    count++;
                }else
                {
                //     (8a) If a grade is not 0-100, give an error.  
                    Console.WriteLine("Oops, try again and enter a number 0-100.");
                }
            // while count < 5
            }while(count < 5);
            
            // (9) Divide homework grade by 5.
            homeworkGrade = homeworkGrade/5;
            Console.WriteLine($"The homework average grade for {studentName} is {homeworkGrade}%");

            //reset the count
            count = 0;

            do
            {
                // (10) Prompt the instructor to provide three quiz grades.
                Console.WriteLine("Please enter a quiz grade for " + studentName + ".");

                //     (10a) Declare an int count = 0 and increment it every time a valid number is given.

                // (11) Get each quiz grade from the instructor and accumulate the grades as they're received.
                double grade;
                grade = Convert.ToDouble(Console.ReadLine());

                // (12) If the number is valid, increment the count by 1
                if(grade >= 0 && grade <= 100)
                {
                    quizGrade += grade;
                    count++;
                }else
                {
                //     (12a) If a grade is not 0-100, give an error.
                Console.WriteLine("Oops, try again and enter a number 0-100.");
                }
            // while count < 3
            }while(count < 3);

            // (13) Divide quiz grade by 3.
            quizGrade = quizGrade/3;
            Console.WriteLine($"The quiz average grade for {studentName} is {quizGrade}%");

            //reset the count
            count = 0;

            do
            {
                // (14) Prompt the instructor to provide two exam grades.
                Console.WriteLine("Please enter an exam grade for " + studentName + ".");

                //     (14a) Declare an int count = 0 and increment it every time a valid number is given.

                // (15) Get each exam grade from the instructor and accumulate the grades as they're received.
                double grade;
                grade = Convert.ToDouble(Console.ReadLine());

                // (16) If the number is valid, increment the count by 1
                if(grade >= 0 && grade <= 100)
                {
                    examGrade += grade;
                    count++;
                }else
                {
                //     (16a) If a grade is not 0-100, give an error.
                Console.WriteLine("Oops, try again and enter a number 0-100.");
                }
            // while count < 2
            }while(count < 2);
            // (17) Divide exam grade by 2.
            examGrade = examGrade/2;
            Console.WriteLine($"The exam average grade for {studentName} is {examGrade}%");

            //reset the count
            count = 0;

            // (18) Declare a double final grade which is homework * 0.5 + quiz * 0.3 + exam * 0.2.
            double finalGrade = (homeworkGrade*.5) + (quizGrade*.3) + (examGrade*.2);
            Console.WriteLine($"{studentName}'s final grade is {finalGrade}%.");

            // (19) Declare a char for final letter grade
            char finalLetterGrade;
            if(finalGrade >= 90)
            {
                //     (19a) If final letter grade >= 90% - A
                finalLetterGrade = 'A';
            }else if(finalGrade >= 80)
            {
                //     (19b) If final letter grade >= 80% - B
                finalLetterGrade = 'B';
            }else if(finalGrade >= 70)
            {
                //     (19c) If final letter grade >= 70% - C
                finalLetterGrade = 'C';
            }else if(finalGrade >= 60)
            {
                //     (19d) If final letter grade >= 60% - D
                finalLetterGrade = 'D';
            }else
            {
                //     (19e) If final letter grade < 60% - F
                finalLetterGrade = 'F';
            }
            
            // (20) Write to the console the student's name, homework average, quiz average, exam average, final average, and final letter grade.
            Console.WriteLine($"{studentName} had a homework average of {homeworkGrade}%, a quiz average of {quizGrade}%, and an exam average of {examGrade}%. This resulted in a final grade of \"{finalLetterGrade}\" - {finalGrade}%.");
            // End for loop.
        }
    }

    static void Main(string[] args)
    {
        FinalGrades();
    }
}