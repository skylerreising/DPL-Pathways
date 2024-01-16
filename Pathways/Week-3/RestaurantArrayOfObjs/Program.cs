using System;

namespace restaurantAPP
{
  class Program
  {
    static void Main(string[] args)
    { 
        // Declare and instantiate a single Restaurant object using the default constructor
        Restaurant aRestaurant = new Restaurant();

        // Output to show the default constructor values
        Console.WriteLine(aRestaurant);

        // Declare and instantiate a single Restaurant object using the other constructor
        Restaurant bRestaurant = new Restaurant("Asian Fusion", 3);

        // Output to show the default constructor values
        Console.WriteLine(bRestaurant);

        // Declare and instantiate the array of Restaurant objects
        Restaurant[] restaurantArray=new Restaurant[25];

        // Now, loop through each array element and instantiate a Restaurant object for each.
        // Note that the constructor with no parameters will be used.

        for (int i = 0; i < restaurantArray.Length; i++)
        {
            restaurantArray[i] = new Restaurant();
        }

        // Load in some test data to test both ways to assign values

        restaurantArray[1].RName = "McDonalds";
        restaurantArray[1].RRating = 2;
        restaurantArray[10].RName = "Lazlos";
        restaurantArray[10].RRating = 4;
        restaurantArray[20].RName = "Venue";
        restaurantArray[20].RRating = 5;


        // print each restaurant to test the property gets and the toString

        for (int i = 0; i < restaurantArray.Length; i++)
        {
            if (!((restaurantArray[i]).RName == null))
                Console.WriteLine(restaurantArray[i]);
        }

        //load restaurants.txt into the restaurantArray LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL
        Console.WriteLine("In the L/l area");
        
        //Declare variables
        string fileName = "restaurants.txt";
        int index = 0;  // index for my array

        using (StreamReader sr = File.OpenText(fileName))
        {
            string s;
            int num = 0;
            Console.WriteLine(" ");
            Console.WriteLine($"Here is the content of the file {fileName}: ");
            Console.WriteLine(" ");
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();
                // Console.WriteLine(s);//s is the restaurant or ranking
                if(int.TryParse(s, out num))//if the line is a number
                {
                    restaurantArray[index].RRating = num;
                    Console.WriteLine(restaurantArray[index]);
                    index++;
                }
                else
                {
                    restaurantArray[index].RName = s;
                }
            }
            Console.WriteLine("");
        }

    } // Main
  } // class
} // namespace