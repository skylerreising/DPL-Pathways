using System;

namespace HelloWorld
{
  class Program
  {
    static void Main(string[] args)
    {
        
        // Declare variables
        bool userChoice;
        string userChoiceString;
        const int arraySize=8;
        string[] nameArray = new string[arraySize];
        string fileName = "names.txt";

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
                Console.WriteLine("C: Add a name to the array.");
                Console.WriteLine("R: Read a name from the array.");
                Console.WriteLine("U: Update a name in the array.");
                Console.WriteLine("D: Delete a name from the array.");
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
                    string s = "";
				    Console.WriteLine(" Here is the content of the file names.txt : ");
                    while ((s = sr.ReadLine()) != null)
                    {
                       Console.WriteLine(s);
                       nameArray[index] = s;
                        index++;
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
                        foreach (string name in nameArray)
                        {
                            fileStr.WriteLine(name);
                        }
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
                int userNumber;
                string newName;
                List<int> updateLine = new List<int>();

                do
                {
                //Print the array *with numbers* for each array item. 
                for (int index = 0; index < arraySize; index++)
                {
                    if ((nameArray[index])!="")
                    {
                        Console.WriteLine($"{index+1}: {nameArray[index]}");
                    }
                    else
                    {
                        Console.WriteLine("Index " + (index+1) + " is available.");
                        updateLine.Add(index+1);
                    }
                }

                //Tell the user which lines they may create.
                foreach (int num in updateLine)
                {
                    Console.WriteLine($"You may update line {num}");
                }

                //Ask the user which number they would like to create and save that number to a variable.
                Console.WriteLine("Which space would you like to create your name in? Please enter the number of an available index.");
                userNumber = Convert.ToInt32(Console.ReadLine());

                }while (!updateLine.Contains(userNumber));
                
                //Ask the user what name they want to create and save that name to a variable
                Console.WriteLine($"What name would you to put on line {userNumber}?");
                newName = Console.ReadLine();

                //assign that name to the array item.
                nameArray[userNumber-1] = newName;

                //print the new array.
                Console.WriteLine("Here are your updated names.");
                for (int index = 0; index < arraySize; index++)
                {
                    if ((nameArray[index])!="")
                        Console.WriteLine(nameArray[index]);
                    else
                        Console.WriteLine("Space " + (index+1) + " is available.");
                }
            }

        //  TODO: Else if the option is an R or r then print the array

            else if (userChoiceString=="R" || userChoiceString=="r")
            {
                Console.WriteLine("In the R/r area");
                for (int index = 0; index < arraySize; index++)
                {
                    if ((nameArray[index])!="")
                        Console.WriteLine(nameArray[index]);
                    else
                        Console.WriteLine("Index " + index + " is available.");
                }

            }
        //  TODO: Else if the option is a U or u then update a name in the array (if it's there)

            else if (userChoiceString=="U" || userChoiceString=="u")
            {
                Console.WriteLine("In the U/u area");
                //declare variables
                int userNumber;
                string newName;

                do
                {
                    //Print the array *with numbers* for each array item.
                    for (int index = 0; index < arraySize; index++)
                    {
                        if ((nameArray[index])!="")
                        {
                            Console.WriteLine($"{index+1}: {nameArray[index]}");
                        }
                        else
                        {
                            Console.WriteLine("Index " + (index+1) + " is available.");
                        }
                    }

                    //Ask the user which number they would like to update and save that number to a variable.
                    Console.WriteLine("Which name would you like to update? Please enter a number.");
                    userNumber = Convert.ToInt32(Console.ReadLine());
                }while (userNumber > arraySize+1 || userNumber < 1);
                
                //Ask the user what they would like to update that name to and save that name to a variable
                Console.WriteLine($"What name would you to put on line {userNumber}?");
                newName = Console.ReadLine();

                //assign that name to the array item.
                nameArray[userNumber-1] = newName;

                //print the new array.
                Console.WriteLine("Here are your updated names.");
                for (int index = 0; index < arraySize; index++)
                {
                    if ((nameArray[index])!="")
                        Console.WriteLine(nameArray[index]);
                    else
                        Console.WriteLine("Space " + (index+1) + " is available.");
                }
            }

        //  TODO: Else if the option is a D or d then delete the name in the array (if it's there)

            else if (userChoiceString=="D" || userChoiceString=="d")
            {
                Console.WriteLine("In the D/d area");
                //declare variables
                int userNumber;

                do
                {
                    //Print the array *with numbers* for each array item.
                    for (int index = 0; index < arraySize; index++)
                    {
                        if ((nameArray[index])!="")
                        {
                            Console.WriteLine($"{index+1}: {nameArray[index]}");
                        }
                        else
                        {
                            Console.WriteLine("Index " + (index+1) + " is available.");
                        }
                    }

                    //Ask the user which number they would like to delet and save that number to a variable.
                    Console.WriteLine("Which name would you like to delete? Please enter a number.");
                    userNumber = Convert.ToInt32(Console.ReadLine());
                    
                }while (userNumber > arraySize+1 || userNumber < 1);

                //Delete the array item the user selected.
                nameArray[userNumber-1] = "";

                //print the new array.
                Console.WriteLine("Here are your updated names with your selection deleted.");
                for (int index = 0; index < arraySize; index++)
                {
                    if ((nameArray[index])!="")
                        Console.WriteLine(nameArray[index]);
                    else
                        Console.WriteLine("Space " + (index+1) + " is available.");
                }
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