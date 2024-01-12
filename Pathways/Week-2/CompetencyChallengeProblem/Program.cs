using System;
using System.Linq;

namespace HelloWorld
{
  class Program
  {
    static void Main(string[] args)
    {
        // Declare variables
            bool userChoice;
            string userChoiceString;
            string fileName = "restaurants.txt";

            // Find the number of lines in the file
            int lineCount = File.ReadLines(fileName).Count();
            int arraySize = (lineCount/2);
            Console.WriteLine($"There are {lineCount} lines in {fileName}.");

            // Divide by 2 because each restaurant has two entries (name and ranking)
            string[,] nameArray = new string[2, lineCount];

      // Repeat main loop
      do
      {

        // TODO: Get a valid input
            do
            {
                //  Initialize variables
                userChoice = false;

                //  TODO: Provide the user a menu of options

                Console.WriteLine("What's your pleasure? ");
                Console.WriteLine("L: Load the data file into an array.");
                Console.WriteLine("S: Save the array to the data file.");
                Console.WriteLine("C: Add a restaurant and ranking to the array.");
                Console.WriteLine("R: Read the restaurants and rankings from the array.");
                Console.WriteLine("U: Update a restaurant and ranking in the array.");
                Console.WriteLine("D: Delete a restaurant and ranking from the array.");
                Console.WriteLine("Q: Quit the program.");

                //  TODO: Get a user option (valid means its on the menu)

                userChoiceString = Console.ReadLine();

                userChoice = (userChoiceString=="L" || userChoiceString=="l" ||
                            userChoiceString == "S" || userChoiceString == "s" ||
                            userChoiceString == "C" || userChoiceString == "c" ||
                            userChoiceString == "R" || userChoiceString == "r" ||
                            userChoiceString == "U" || userChoiceString == "u" ||
                            userChoiceString == "D" || userChoiceString == "d" ||
                            userChoiceString == "Q" || userChoiceString == "q");

                if (!userChoice)
                {
                    Console.WriteLine("Please enter a valid option.");
                }

            } while (!userChoice);

        //  TODO: If the option is L or l then load the text file (names.txt) into the array of strings (nameArray)

            if (userChoiceString=="L" || userChoiceString=="l")
            {
                Console.WriteLine("In the L/l area");

                int index = 0;  // index for my array
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s;;
                    int num = 0;
				    Console.WriteLine($"Here is the content of the file {fileName} : ");
                    while (!sr.EndOfStream)
                    {
                        s = sr.ReadLine();
                        // Console.WriteLine(s);//s is the restaurant or ranking
                        if(int.TryParse(s, out num))
                        {
                            nameArray[1,index] = s;
                            Console.WriteLine(nameArray[1,index]);
                            index++;
                        }
                        else
                        {
                            nameArray[0,index] = s;
                            Console.WriteLine(nameArray[0,index]);
                        }
                    }
                    Console.WriteLine("");
                }
            }

        //  TODO: Else if the option is an S or s then store the array of strings into the text file

            else if (userChoiceString=="S" || userChoiceString=="s")
            {
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
                    int index = 0;  // index for my array
                    using (StreamWriter fileStr = File.CreateText(fileName))
                    {
                        for(index = 0; index < (nameArray.GetLength(1)/2); index++)
                        {
                            for(int i=0; i<=1; i++)
                            {
                                fileStr.WriteLine(nameArray[i,index]);
                            }
                        }
                        // foreach (string name in nameArray)
                        // {
                        //     fileStr.WriteLine(name);
                        // }
                    }
                }
                catch (Exception MyExcep)
                {
                    Console.WriteLine(MyExcep.ToString());
                }
            }

        //  TODO: Else if the option is a C or c then add a name to the array (if there's room there)

            else if (userChoiceString=="C" || userChoiceString=="c")
            {
                Console.WriteLine("In the C/c area");
                //declare variables
                string newName;
                string newRating;
                int numRating;
                bool containsEmpty = false;

                do
                {
                //Print the array with ratings for each restaurant item.
                    for (int index = 0; index < arraySize; index++)
                    {
                        if ((nameArray[0,index])!="")
                        {
                            Console.WriteLine($"{nameArray[0, index]}: {nameArray[1, index]} stars");
                        }
                        else
                        {
                            Console.WriteLine("");
                        }
                    }

                //Tell the user if there is room to create a restaurant/rating.
                    for(int i=0; i<arraySize; i++)
                    {
                        if(nameArray[0,i] == "")
                        {
                            Console.WriteLine("There is room to add a restaurant/rating.");

                            //Ask the user what they would like to update that name to and save that name to a variable
                            Console.WriteLine($"Which restaurant would you like to create?");
                            newName = Console.ReadLine();

                            //assign that restaurant name to the array item.
                            nameArray[0,i] = newName;

                            //Ask the user what rating they would like to give that restaurant and save it to a variable
                            do
                            {
                                Console.WriteLine($"What rating would you like to give {newName}? Please give a rating 1-5 stars");
                                newRating = Console.ReadLine();

                                //Change newRating to an int for evaluation
                                numRating = Convert.ToInt32(newRating);
                            }while(numRating<1 || numRating>5);

                            //Assign the new rating to the new restaurant and print it for the user
                            nameArray[1,i] = newRating;
                            Console.WriteLine($"You have given {nameArray[0,i]} {nameArray[1,i]} stars!");

                            break;
                        }
                    }

                    // If there is no room, notify they should delete first
                    int count = 0;
                    for(int i=0; i<arraySize; i++)
                    {
                        if(nameArray[0,i] != "")
                        {
                            count++;
                        }
                        if(count == arraySize)
                        {
                            Console.WriteLine("There is no room for another restaurant rating. Please delete one and try again");
                        }
                    }

                    //use a bool to see if the do... while loop should stop
                    for(int i=0; i<arraySize; i++)
                    {
                        if(nameArray[0,i] == "")
                        {
                            containsEmpty = true;
                            break;
                        }
                    }

                }while (containsEmpty);
            }

        //  TODO: Else if the option is an R or r then print the array

            else if (userChoiceString=="R" || userChoiceString=="r")
            {
                Console.WriteLine("In the R/r area");
                //Print the array with ratings for each restaurant item.
                for (int i=0; i<(nameArray.GetLength(1)/2); i++)
                {
                    if ((nameArray[0, i])!="")
                    {
                        Console.WriteLine($"{nameArray[0, i]} has a rating of {nameArray[1,i]} stars.");
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                }

            }
        //  TODO: Else if the option is a U or u then update a restaurant in the array (if it's there)

            else if (userChoiceString=="U" || userChoiceString=="u")
            {
                Console.WriteLine("In the U/u area");
                //declare variables
                string userRestaurant;
                string newName;
                string newRating;
                int numRating;
                bool containsUserRestaurant = false;

                do
                {
                    //Ask the user which restaurant they would like to update and save that string to a variable.
                    Console.WriteLine("Which restaurant would you like to update?");
                    userRestaurant = (Console.ReadLine());

                    //Loop and if the userRestaurant matches a restaurant, continue. Else, prompt user to enter a valid restaurant name.
                    for(int i=0; i<arraySize; i++)
                    {
                        if(userRestaurant == nameArray[0,i])
                        {
                            //Ask the user what they would like to update that name to and save that name to a variable
                            Console.WriteLine($"What restaurant would you like to update {userRestaurant} to?");
                            newName = Console.ReadLine();

                            //assign that restaurant name to the array item.
                            nameArray[0,i] = newName;

                            //Ask the user what rating they would like to give that restaurant and save it to a variable
                            do
                            {
                                Console.WriteLine($"What rating would you like to give {newName}? Please give a rating 1-5 stars");
                                newRating = Console.ReadLine();

                                //Change newRating to an int for evaluation
                                numRating = Convert.ToInt32(newRating);
                            }while(numRating<1 || numRating>5);

                            //Assign the new rating to the new restaurant and print it for the user
                            nameArray[1,i] = newRating;
                            Console.WriteLine($"You have given {nameArray[0,i]} {nameArray[1,i]} stars!");
                        }
                    }

                    //use a bool to see if the do... while loop should stop
                    for(int i=0; i<arraySize; i++)
                    {
                        if(nameArray[0,i] == userRestaurant)
                        {
                            containsUserRestaurant = true;
                            break;
                        }
                    }

                }while (containsUserRestaurant);
                
            }

        //  TODO: Else if the option is a D or d then delete the name in the array (if it's there)

            else if (userChoiceString=="D" || userChoiceString=="d")
            {
                Console.WriteLine("In the D/d area");
                //declare variables
                string userRestaurant;
                bool containsUserRestaurant = false;
                do
                {
                    //Print the array with ratings for each restaurant item. Even indicies are always restaurants.
                    for (int index = 0; index < arraySize; index++)
                    {
                        if ((nameArray[0,index])!="")
                        {
                            Console.WriteLine($"{nameArray[0, index]}: {nameArray[1, index]} stars");
                        }
                        else
                        {
                            Console.WriteLine("");
                        }
                    }

                    //Ask the user which restaurant they would like to delete and save that string to a variable.
                    Console.WriteLine("Which restaurant would you like to delete?");
                    userRestaurant = (Console.ReadLine());

                    //Loop and if the userRestaurant matches a restaurant, delete it. Else, prompt user to enter a valid restaurant name.
                    for(int i=0; i<arraySize; i++)
                    {
                        if(userRestaurant == nameArray[0,i])
                        {
                            //delete the restaurant and the rating
                            nameArray[0,i] = "";
                            nameArray[1,i] = "";

                            Console.WriteLine($"You have deleted {userRestaurant}.");
                        }
                    }

                    //use a bool to see if the do... while loop should stop
                    for(int i=0; i<arraySize; i++)
                    {
                        if(nameArray[0,i] == userRestaurant)
                        {
                            containsUserRestaurant = true;
                            break;
                        }
                    }

                }while (containsUserRestaurant);
            }
        //  TODO: Else if the option is a Q or q then quit the program

            else 
            {
                Console.WriteLine("Good-bye!");
            }
        } while (!(userChoiceString=="Q") && !(userChoiceString=="q"));
    }  // end main
  }  // end program
}  // end namespace