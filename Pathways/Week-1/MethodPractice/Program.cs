using System;
  class Program  
  {
    //Method to return a user value
    static int InputAndValidateInteger (int minValue, int maxValue, string prompt)
    {
    int value;

    do
    {
        Console.WriteLine(prompt + " between " + minValue + " and " + maxValue);
        value = Convert.ToInt32(Console.ReadLine());
        if ((value < minValue) || (value > maxValue))
            Console.WriteLine("Oops! the value needs to be between " + minValue + " and " + maxValue);
    } while ((value < minValue) || (value > maxValue));
    
    return value;
    }

    //find the sum of all user numbers
    public static void Main(string[] args)
    {
      int numberOfNumbers = 0, numberValue = 0, sum = 0; 
      
      numberOfNumbers = InputAndValidateInteger(1,5,"Please enter a number 1 - 5");

        //Add the number values entered together and display the outcome.
      for (int i = 1; i <= numberOfNumbers; i++)
       {
         numberValue = InputAndValidateInteger(-100,100, "Please enter a number -100 - 100");

        sum += numberValue;

       } //end for loop
      
      Console.WriteLine("The total = " + sum);
    }
}