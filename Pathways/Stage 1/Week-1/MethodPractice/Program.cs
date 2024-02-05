// using System;
//   class Program  
//   {
//     //Method to return a user value
//     static int InputAndValidateInteger (int minValue, int maxValue, string prompt)
//     {
//     int value;

//     do
//     {
//         Console.WriteLine(prompt + " between " + minValue + " and " + maxValue);
//         value = Convert.ToInt32(Console.ReadLine());
//         if ((value < minValue) || (value > maxValue))
//             Console.WriteLine("Oops! the value needs to be between " + minValue + " and " + maxValue);
//     } while ((value < minValue) || (value > maxValue));
    
//     return value;
//     }

//     //find the sum of all user numbers
//     public static void Main(string[] args)
//     {
//       int numberOfNumbers = 0, numberValue = 0, sum = 0; 
      
//       numberOfNumbers = InputAndValidateInteger(1,5,"Please enter a number 1 - 5");

//         //Add the number values entered together and display the outcome.
//       for (int i = 1; i <= numberOfNumbers; i++)
//        {
//          numberValue = InputAndValidateInteger(-100,100, "Please enter a number -100 - 100");

//         sum += numberValue;

//        } //end for loop
      
//       Console.WriteLine("The total = " + sum);
//     }
// }

/*

Problem description:  Create a program that will obtain a base from the user and an exponent from the user and will print out the value of the base taken to the exponent power.  Use a method, Power, to calculate the value.  Be sure that both the base and exponent are integers greater than or equal to 1. Repeat the process until the user wants to quit.  

Software Engineer: Skyler Reising
Date: 1/4/24

Requirements
(1)Base >= 1 from the user.
(2)Exponent >= 1 from the user.
(3)Write your own Power method to calculate value.
(4)After writing the answer to the console, ask the user if they want to continue.

Algorithm:
do
(1)Prompt the user for a base.
(2)Store the base in an int variable.
while base is <1

do
(3)Prompt the user for an exponent.
(4)Store the exponent in an int variable.
while exponent is <1

(5)Calculate base to the exponent power and save it to an answer variable.
(6)Write the answer to the console.

do
(7)Prompt the user and ask if they want to do this again?
(8)Declare the answer in a variable above the do loop.
  (8a)Store the answer and control for Y, N, YES, NO, yes, and no casing of the string.
  (8b)If answer is yes, call the method again (recurse)
  while the answer isn't yes or no

*/

// using System;

// class Mathy
// {
//   static void ToThePowerOf()
//   {
//     int baseNum;
//     do
//     {
//       // (1)Prompt the user for a base.
//       Console.WriteLine("Please enter a base number greater than or equal to 1.");
//       // (2)Store the base in an int variable.
//       baseNum = Convert.ToInt32(Console.ReadLine());

//       if(baseNum < 1)
//       {
//         Console.WriteLine("There was a problem. Your base must be a number greater than or equal to 1.");
//       }
//     }while (baseNum < 1);
    
//     int exp;
//     do
//     {
//       // (3)Prompt the user for an exponent.
//       Console.WriteLine("Please enter an exponent number greater than or equal to 1.");

//       // (4)Store the exponent in an int variable.
//       exp = Convert.ToInt32(Console.ReadLine());

//       if(exp < 1)
//       {
//         Console.WriteLine("There was a problem. Your exponent must be a number greater than or equal to 1.");
//       }
//     }while (exp < 1);
    
//     // (5)Calculate base to the exponent power and save it to an answer variable.
//     int answer = baseNum;
//     for(int i=1; i<exp; i++)
//     {
//       answer = answer*baseNum;
//     }

//     // (6)Write the answer to the console.
//     Console.WriteLine($"{baseNum} to the power of {exp} = {answer}");

//     string again;
//     do
//     {
//       // (7)Prompt the user and ask if they want to do this again?
//       Console.WriteLine("Would you like to do this again? Enter yes or no.");

//       // (8)Declare the answer in a variable above the do loop.

//       // (8a)Store the answer and control for Y, N, YES, NO, yes, and no casing of the string
//       again = Console.ReadLine().ToLower();
      
//       // (8b)If answer is yes, call the method again (recurse)
//       if(again == "yes" || again == "y")
//       {
//         ToThePowerOf();
//         break;//have to break the first layer of the method after calling the method again
//       }else if(again == "no" || again == "n")
//       {
//         // (8c)If answer is no, write to the console confirming the end
//         Console.WriteLine("I hope you have enjoyed the math.");
//         break;
//       }else
//       {
//         Console.WriteLine("There was a problem. Please enter yes or no");
//       }
//     }while (again != "yes" || again != "y" || again != "no" || again != "n");
//   }

//   public static void Main(string[] args)
//   {
//     ToThePowerOf();
//   }
// }

/*

Problem description: Create a program that will obtain a base from the user, a beginning exponent from the user, and an ending exponent from the user and will print out the value of the base taken to the exponent power for all of the exponents from the beginning to the ending exponent.  Use a method, Power, to calculate the value.  Be sure that both the base and exponents are integers greater than or equal to 1, and that the ending exponent is greater than the beginning exponent. Repeat the process until the user wants to quit.  

Software Engineer: Skyler Reising
Date: 1/4/24

Requirements
(1)Base >= 1 from the user.
(2)Beginning Exponent >= 1 from the user.
(3)Ending Exponent >= Beginning Exponent from the user.
(4)Write your own Power method to calculate value.
(5)After writing the answer(s) to the console, ask the user if they want to continue.

Algorithm:
do
(1)Prompt the user for a base.
(2)Store the base in an int variable.
while base is <1

do
(3a)Prompt the user for a beginning exponent.
(3b)Store the exponent in an int variable.
while beginning exponent is <1

do
(4a)Prompt the user for an ending exponent.
(4b)Store the exponent in an int variable.
while ending exponent is <beginning exponent

for loop - from beginning exponent to ending exponent
(5)Calculate base to the exponent power and save it to an answer variable.
(6)Write the answer to the console.
end loop

do
(7)Prompt the user and ask if they want to do this again?
(8)Declare the answer in a variable above the do loop.
  (8a)Store the answer and control for Y, N, YES, NO, yes, and no casing of the string.
  (8b)If answer is yes, call the method again (recurse)
  while the answer isn't yes or no

*/

using System;

class Mathy
{
  static void ToThePowerOf()
  {
    int baseNum;
    do
    {
      // (1)Prompt the user for a base.
      Console.WriteLine("Please enter a base number greater than or equal to 1.");
      // (2)Store the base in an int variable.
      baseNum = Convert.ToInt32(Console.ReadLine());

      if(baseNum < 1)
      {
        Console.WriteLine("There was a problem. Your base must be a number greater than or equal to 1.");
      }
    }while (baseNum < 1);
    
    int beginningExponent;
    do
    {
      //(3a)Prompt the user for a beginning exponent.
      Console.WriteLine("Please enter a beginning exponent number greater than or equal to 1.");

      // (3b)Store the exponent in an int variable.
      beginningExponent = Convert.ToInt32(Console.ReadLine());

      if(beginningExponent < 1)
      {
        Console.WriteLine("There was a problem. Your beginning exponent must be a number greater than or equal to 1.");
      }
    }while (beginningExponent < 1);

    int endingExponent;
    do
    {
      //(4a)Prompt the user for an ending exponent.
      Console.WriteLine("Please enter an ending exponent number greater than " + beginningExponent + ".");

      //(4b)Store the exponent in an int variable.
      endingExponent = Convert.ToInt32(Console.ReadLine());

      if(endingExponent <= beginningExponent)
      {
        Console.WriteLine("There was a problem. Your ending exponent must be a number greater than your beginning exponent - " + beginningExponent + ".");
      }
    }while (endingExponent <= beginningExponent);
    
    //for loop - from beginning exponent to ending exponent
    int answer = baseNum;
    for(int i=beginningExponent; i<=endingExponent; i++)
    {
      //control for if i=1
      // if(i == 1)
      // {
      //   Console.WriteLine($"{baseNum} to the power of {i} = {answer}");
      // }
      // (5)Calculate base to the exponent power and save it to an answer variable.

      for(int j=1; j<i; j++)
      {
        answer *= baseNum;
      }

      // (6)Write the answer to the console.
      Console.WriteLine($"{baseNum} to the power of {i} = {answer}");

      answer = baseNum;
    }

    string again;
    do
    {
      // (7)Prompt the user and ask if they want to do this again?
      Console.WriteLine("Would you like to do this again? Enter yes or no.");

      // (8)Declare the answer in a variable above the do loop.

      // (8a)Store the answer and control for Y, N, YES, NO, yes, and no casing of the string
      again = Console.ReadLine().ToLower();
      
      // (8b)If answer is yes, call the method again (recurse)
      if(again == "yes" || again == "y")
      {
        ToThePowerOf();
        break;//have to break the first layer of the method after calling the method again
      }else if(again == "no" || again == "n")
      {
        // (8c)If answer is no, write to the console confirming the end
        Console.WriteLine("I hope you have enjoyed the math.");
        break;
      }else
      {
        Console.WriteLine("There was a problem. Please enter yes or no");
      }
    }while (again != "yes" || again != "y" || again != "no" || again != "n");
  }

  public static void Main(string[] args)
  {
    ToThePowerOf();
  }
}