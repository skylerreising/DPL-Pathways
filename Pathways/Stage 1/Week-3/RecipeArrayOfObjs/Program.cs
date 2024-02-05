using System;

namespace recipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare and instantiate a single Recipe object using the default constructor
            // Recipe spaghetti = new Recipe();

            // Output to show the default constructor values
            // Console.WriteLine(spaghetti);

            // Declare and instantiate a single Recipe object using the other constructor
            Recipe realSpaghetti =  new Recipe("1 Pot \n1 wooden spoon \n1 collander", 
                                    "4 cups of water and 1 package of spaghetti\n", 
                                    "1. Pour the water in the pot. \n2. Heat the water until boiling. \n3. Place spaghetti in boiling water and boil for 10-12 minutes. \n4 Set collander in the sink and pour spaghetti and water into the collander to drain the water. \n5. Serve spaghetti");

            // Output to show the default constructor values
            Console.WriteLine(realSpaghetti);

            // Declare and instantiate the array of Recipe objects
            Recipe[] recipeArray = new Recipe[3];

            // Now, loop through each array element and instantiate a Recipe object for each.
            // Note that the constructor with no parameters will be used.
            for(int i=0; i<recipeArray.Length; i++)
            {
                recipeArray[i] = new Recipe();
            }

            // Load in some test data to test both ways to assign values

            // print each recipe to test the property gets and the toString
        }
    }
}