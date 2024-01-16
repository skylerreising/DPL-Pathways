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
        Restaurant bRestaurant = new Restaurant("Asian Fusion", "3");

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
        restaurantArray[1].RRating = "2";
        restaurantArray[10].RName = "Lazlos";
        restaurantArray[10].RRating = "4";
        restaurantArray[20].RName = "Venue";
        restaurantArray[20].RRating = "5";


        // print each restaurant to test the property gets and the toString

        for (int i = 0; i < restaurantArray.Length; i++)
        {
            if (!((restaurantArray[i]).RName == null))
                Console.WriteLine(restaurantArray[i]);
        }

        //Load restaurants.txt into the restaurantArray LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL
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
                    restaurantArray[index].RRating = s;
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

        //Delete a restaurant from the array DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD
        Console.WriteLine("In the D/d area");
        Console.WriteLine(" ");

        //declare variables
        string userRestaurant;
        bool containsUserRestaurant = false;

        do
        {
            //Ask the user which restaurant they would like to delete and save that string to a variable.
            Console.WriteLine(" ");
            Console.WriteLine("Which restaurant would you like to delete?");
            Console.WriteLine(" ");
            userRestaurant = Console.ReadLine();

            //Loop and if the userRestaurant matches a restaurant, delete it. Else, prompt user to enter a valid restaurant name.
            for(int i=0; i<restaurantArray.Length; i++)
            {
                if(userRestaurant == restaurantArray[i].RName)
                {
                    containsUserRestaurant = true;
                    //delete the restaurant and the rating
                    restaurantArray[i].RName = " ";
                    restaurantArray[i].RRating = " ";

                    Console.WriteLine(" ");
                    Console.WriteLine($"You have deleted {userRestaurant}.");
                    Console.WriteLine(" ");
                    break;
                }
            }

            //Print the array with ratings for each restaurant item. Even indicies are always restaurants.
            if(containsUserRestaurant)
            {
                for (int i = 0; i < restaurantArray.Length; i++)
                {
                    if ((restaurantArray[i].RName)!=" ")
                    {
                        Console.WriteLine($"{restaurantArray[i].RName}: {restaurantArray[i].RRating} stars");
                    }
                    else
                    {
                        Console.WriteLine($"{userRestaurant} has been... DELETED!!!!!!!!!!!!!!!!!!!!!");
                    }
                }
                break;
            }

            Console.WriteLine(" ");
            Console.WriteLine("We couldn't find that restaurant. Please try again.");
            Console.WriteLine(" ");
        }while(!containsUserRestaurant);

        //Code to save the new array to the text file SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
        Console.WriteLine("In the S/s area");

        try
        {
            // Delete the file if it exists.
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            Console.Write("\n\n Create a file with text and read the file  :\n");
            Console.Write("-------------------------------------------------\n");

            //Create the file
            index = 0;  // index for my array
            using (StreamWriter fileStr = File.CreateText(fileName))
            {
                for(index = 0; index < restaurantArray.Length; index++)
                {
                    if(restaurantArray[index].RName != " ")
                    {
                        fileStr.WriteLine(restaurantArray[index].RName);
                        fileStr.WriteLine(restaurantArray[index].RRating);
                    }
                    else
                    {
                        fileStr.WriteLine(" ");
                        fileStr.WriteLine(" ");
                    }
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("Your new file was saved.");
            Console.WriteLine(" ");

            //Load and print the file

            using (StreamReader sr = File.OpenText(fileName))
            {
                string s;
                int num = 0;
                index = 0;
                Console.WriteLine(" ");
                Console.WriteLine($"Here is the content of the file {fileName}: ");
                Console.WriteLine(" ");
                while (!sr.EndOfStream)
                {
                    s = sr.ReadLine();
                    // Console.WriteLine(s);//s is the restaurant or ranking
                    if(int.TryParse(s, out num))//if the line is a number
                    {
                        restaurantArray[index].RRating = s;
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

        }
        catch (Exception MyExcep)
        {
            Console.WriteLine(MyExcep.ToString());
        }

        //Create a restaurant in the array

    } // Main
  } // class
} // namespace