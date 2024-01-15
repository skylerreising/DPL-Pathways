/*

Problem description: You want to maintain a list of the restaurants at which you have dined.

Requirements/User stories:

You want to keep track of the name and your review of restaurants (0-5 stars) and you want it to be persistent (stored in a text file).  Provide room for 25 restaurants.
You want a menu that will provide you the options of doing the following:
L - Load the user's list of restaurants and ratings (from a data file into a data structure),
S -  Save the user's list of restaurants (from a data structure to a data file)
Bonus - save them so there are no blank lines in the data file 
C - Add a restaurant and rating,
Make sure the user provides both a restaurant and rating
Make sure to handle the "file full" case
R - Print a list of all the restaurants and their rating,
Bonus - only print a list of the restaurants and ratings - no blank lines in your list
Make sure to handle the case where there are no restaurants in the list
U - Update the rating for a restaurant, (Bonus: Update the restaurant name)
D - Delete a restaurant
Q - Quit the program

*/

using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
            bool isLoaded = false;

            // Find the number of lines in the file
            int lineCount = File.ReadLines(fileName).Count();
            int arraySize = (lineCount/2);
            Console.WriteLine(" ");
            Console.WriteLine($"There are {lineCount} lines in {fileName}.");
            Console.WriteLine(" ");

            // Divide by 2 because each restaurant has two entries (name and ranking)
            string[,] nameArray = new string[2, lineCount];
            for(int i=0; i<arraySize; i++)
            {
                nameArray[0,i] = " ";
                nameArray[1,i] = " ";
            }

      // Repeat main loop
      do
      {
            do
            {
                //  Initialize variables
                userChoice = false;

                Console.WriteLine("What's your pleasure? ");
                Console.WriteLine("L: Load the data file into an array.");
                Console.WriteLine("S: Save the array to the data file.");
                Console.WriteLine("C: Add a restaurant and ranking to the array.");
                Console.WriteLine("R: Read the restaurants and rankings from the array.");
                Console.WriteLine("U: Update a restaurant and ranking in the array.");
                Console.WriteLine("D: Delete a restaurant and ranking from the array.");
                Console.WriteLine("Q: Quit the program.");

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

        //If the option is L or l then load the text file (names.txt) into the array of strings (nameArray)
        //LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL
            if (userChoiceString=="L" || userChoiceString=="l")
            {
                Console.WriteLine("In the L/l area");

                int index = 0;  // index for my array
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s;;
                    int num = 0;
                    Console.WriteLine(" ");
				    Console.WriteLine($"Here is the content of the file {fileName}: ");
                    Console.WriteLine(" ");
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
                    isLoaded = true;
                }
            }

        //Else if the option is an S or s then store the array of strings into the text file
        //SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
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
                    }
                    Console.WriteLine(" ");
                    Console.WriteLine("Your new file was saved.");
                    Console.WriteLine(" ");
                }
                catch (Exception MyExcep)
                {
                    Console.WriteLine(MyExcep.ToString());
                }
            }

        //Else if the option is a C or c then add a name to the array (if there's room there)
        //CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
            else if (userChoiceString=="C" || userChoiceString=="c")
            {
                Console.WriteLine("In the C/c area");
                Console.WriteLine(" ");
                //declare variables
                string newName;
                string newRating;
                int numRating;
                bool containsEmpty = false;

                do
                {
                    //check that restaurants have been loaded
                    if(!isLoaded)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Please load your file first. You cannot create a restaurant until you have loaded a file and made room for a new restaurant.");
                        Console.WriteLine(" ");
                        break;
                    }

                    //Print the array with ratings for each restaurant item.
                    for (int index = 0; index < arraySize; index++)
                    {
                        if ((nameArray[0,index])!=" ")
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
                        if(nameArray[0,i] == " ")
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("There is room to add a restaurant/rating.");
                            Console.WriteLine(" ");

                            //Ask the user what they would like to update that name to and save that name to a variable
                            Console.WriteLine($"Which restaurant would you like to create?");
                            Console.WriteLine(" ");
                            newName = Console.ReadLine();

                            //assign that restaurant name to the array item.
                            nameArray[0,i] = newName;

                            //Ask the user what rating they would like to give that restaurant and save it to a variable
                            do
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine($"What rating would you like to give {newName}? Please give a rating 1-5 stars");
                                Console.WriteLine(" ");
                                newRating = Console.ReadLine();

                                try
                                {
                                    //Change newRating to an int for evaluation
                                    numRating = Convert.ToInt32(newRating);
                                }
                                catch
                                {
                                    //Control for numRating not being an integer
                                    Console.WriteLine(" ");
                                    Console.WriteLine("Please enter a valid number 1,2,3,4, or 5.");
                                    numRating=0;
                                }
                            }while(numRating<1 || numRating>5);

                            //Assign the new rating to the new restaurant and print it for the user
                            nameArray[1,i] = newRating;
                            Console.WriteLine(" ");
                            Console.WriteLine($"You have given {nameArray[0,i]} {nameArray[1,i]} stars!");
                            Console.WriteLine(" ");
                            break;
                        }
                    }

                    // If there is no room, notify they should delete first
                    int count = 0;
                    for(int i=0; i<arraySize; i++)
                    {
                        if(nameArray[0,i] != " ")
                        {
                            count++;
                        }
                        if(count == arraySize)
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("The file is full and there is no room for another restaurant rating. Please delete one and try again");
                            Console.WriteLine(" ");
                        }
                    }

                    //use a bool to see if the do... while loop should stop
                    for(int i=0; i<arraySize; i++)
                    {
                        if(nameArray[0,i] == " ")
                        {
                            containsEmpty = true;
                            break;
                        }
                    }

                }while (containsEmpty);
            }

        //Else if the option is an R or r then print the array
        //RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR
            else if (userChoiceString=="R" || userChoiceString=="r")
            {
                Console.WriteLine("In the R/r area");
                Console.WriteLine(" ");
                //Print the array with ratings for each restaurant item.

                //if nameArray isn't loaded, propt the user to load nameArray
                if(isLoaded)
                {
                    for (int i=0; i<(nameArray.GetLength(1)/2); i++)
                    {
                        if ((nameArray[0, i])!=" ")
                        {
                            Console.WriteLine($"{nameArray[0, i]} has a rating of {nameArray[1,i]} stars.");
                        }
                    }
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Please load the list of restaurants using \"L\" and try again.");
                    Console.WriteLine(" ");
                }
            }

        //Else if the option is a U or u then update a restaurant in the array (if it's there)
        //UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU
            else if (userChoiceString=="U" || userChoiceString=="u")
            {
                Console.WriteLine("In the U/u area");
                Console.WriteLine(" ");

                //check that restaurants have been loaded
                if(!isLoaded)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Please load your file first. You cannot update a restaurant until you have loaded your file.");
                    Console.WriteLine(" ");
                    continue;
                }

                //declare variables
                string userRestaurant;
                string newName;
                string newRating;
                int numRating;

                bool found = false;

                    //Ask the user which restaurant they would like to update and save that string to a variable.
                    Console.WriteLine("Which restaurant would you like to update?");
                    Console.WriteLine(" ");
                    userRestaurant = (Console.ReadLine());

                    //Loop and if the userRestaurant matches a restaurant, continue. Else, prompt user to enter a valid restaurant name.


                    for(int i=0; i<arraySize; i++)
                    {
                        if(userRestaurant == nameArray[0,i])
                        {
                            //Ask the user what they would like to update that name to and save that name to a variable
                            Console.WriteLine(" ");
                            Console.WriteLine($"What restaurant would you like to update {userRestaurant} to?");
                            Console.WriteLine(" ");
                            newName = Console.ReadLine();

                            //assign that restaurant name to the array item.
                            nameArray[0,i] = newName;

                            //Ask the user what rating they would like to give that restaurant and save it to a variable
                            do
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine($"What rating would you like to give {newName}? Please give a rating 1-5 stars");
                                Console.WriteLine(" ");
                                newRating = Console.ReadLine();
                                try
                                {
                                    //Change newRating to an int for evaluation
                                    numRating = Convert.ToInt32(newRating);
                                }
                                catch
                                {
                                    //Control for numRating not being an integer
                                    Console.WriteLine(" ");
                                    Console.WriteLine("Please enter a valid number 1,2,3,4, or 5.");
                                    numRating=0;
                                }
                            }while(numRating<1 || numRating>5);

                            //Assign the new rating to the new restaurant and print it for the user
                            nameArray[1,i] = newRating;
                            Console.WriteLine(" ");
                            Console.WriteLine($"You have given {nameArray[0,i]} {nameArray[1,i]} stars!");
                            Console.WriteLine(" ");
                            found = true;
                        }

                        if(found)
                            break;
                    }

                    //Give message if not found, tell user couldn't find restaurant
                    if(!found)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Restaurant not found. Have you loaded your file?");
                        Console.WriteLine(" ");
                    }
            }

        //Else if the option is a D or d then delete the name in the array (if it's there)
        //DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD
            else if (userChoiceString=="D" || userChoiceString=="d")
            {
                Console.WriteLine("In the D/d area");
                Console.WriteLine(" ");
                //declare variables
                string userRestaurant;
                bool containsUserRestaurant = false;
                do
                {
                    if(!isLoaded)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Please load your file first. You cannot delete a restaurant until you have loaded a file.");
                        Console.WriteLine(" ");
                        break;
                    }

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
                    Console.WriteLine(" ");
                    Console.WriteLine("Which restaurant would you like to delete?");
                    Console.WriteLine(" ");
                    userRestaurant = Console.ReadLine();

                    //Loop and if the userRestaurant matches a restaurant, delete it. Else, prompt user to enter a valid restaurant name.
                    for(int i=0; i<arraySize; i++)
                    {
                        if(userRestaurant == nameArray[0,i])
                        {
                            //delete the restaurant and the rating
                            nameArray[0,i] = " ";
                            nameArray[1,i] = " ";

                            Console.WriteLine($"You have deleted {userRestaurant}.");
                            Console.WriteLine(" ");
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
        //Else if the option is a Q or q then quit the program

            else 
            {
                Console.WriteLine("Good-bye!");
                Console.WriteLine(" ");
            }
        } while (!(userChoiceString=="Q") && !(userChoiceString=="q"));
    }  // end main
  }  // end program
}  // end namespace