/*Meal Collection
 * Classes
 * Parent - Meal
 *  A. String drink
 *  B. String entree
 *  C. ToString()
 * 1. Breakfast
 *  A. Bool coffee
 *  B. Overriding ToString()
 * 2. Lunch
 *  A. Bool SaladOrSoup
 *      i. if true
 *          a. Salad
 *              1.Garden
 *              2.Caesar
 *          b. Soup du jour
 *  B. Overriding ToString()
 *      i. Default to no salad or soup or state the choice
 * 3. Dinner
 *  A. String appetizer
 *      i. int amount
 *  B. String desert
 *  C. Overriding ToString()
 *  
 *  Program
 *  
 *  Create
 *  1. Ask user which meal they are eating
 *  2. Point user to either Breakfast, lunch, or dinner
 *  3. Breakfast
 *      A. Ask coffee or no?
 *      B. Meal questions
 *          i. Drink?
 *          ii. Entree?
 *  4. Lunch
 *      i. if true
 *          a. Salad
 *              1.Garden
 *              2.Caesar
 *          b. Soup du jour
 *      B. Meal questions
 *          i. Drink?
 *          ii. Entree?
 *  5. Dinner
 *      i. Appetizer?
 *          a. int amount?
 *      B. Meal questions
 *          i. Drink?
 *          ii. Entree?
 *      iiiC. Desert?
 *      
 *  Read - list of meals
 *  
 *  Delete a meal by number in list
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Meals
{
    public static class Program
    {
        static void Main(string[] args)
        {
            //instanciate a meal list
            List<Meal> mealList = new();

            MainMenu(mealList);
        }

        static void MainMenu(List<Meal> mealList)
        {
            var menuChoice = "";
            do
            {
                Console.WriteLine("Please choose an option\n1. Create a meal\n2. Read the list of meals\n3. Delete a meal\n");
                Console.WriteLine("Please enter a number or \"Q\" to quit.");
                do
                {
                    menuChoice = Console.ReadLine();
                    if (menuChoice != "1" && menuChoice != "2" && menuChoice != "3" && menuChoice.ToLower() != "q")
                    {
                        Console.WriteLine("Please choose menu option 1, 2, or 3");
                    }

                } while (menuChoice != "1" && menuChoice != "2" && menuChoice != "3" && menuChoice.ToLower() != "q");

                if (menuChoice.ToLower() == "q")
                {
                    Quit();
                }
                else if (menuChoice == "1")
                {
                    CreateMeal(mealList);
                }
                else if(menuChoice == "2")
                {
                    IPayForMeal payForMeal = new Meal();
                    MealService howMuchAreMeals = new MealService(payForMeal);

                    foreach(var meal in mealList)
                    {
                        Console.WriteLine($"{meal} Price: ${howMuchAreMeals.PayForMeal(meal.Entree.Length)}");
                    }
                }
                else if(menuChoice == "3")
                {
                    for(int i=0; i<mealList.Count; i++)
                    {
                        Console.WriteLine($"{i+1}. {mealList[i]}");
                    }
                    Console.WriteLine("\nPlease select the number of the meal you would like to delete.\n");
                    int userChoice = Convert.ToInt32(Console.ReadLine());
                    mealList.RemoveAt(userChoice - 1);
                    Console.WriteLine($"Meal {userChoice} has been deleted");
                }
            } while (menuChoice.ToLower() != "q");
        }

        static void CreateMeal(List<Meal> mealList)
        {
            //*1.Ask user which meal they are eating
            Console.WriteLine("Is this meal for breakfast, lunch, or dinner?");
            var mealChoice = Console.ReadLine();

            if(mealChoice.ToLower() == "breakfast")
            {
                Breakfast(mealList);
            }
            else if(mealChoice.ToLower() == "lunch")
            {
               Lunch(mealList);
            }
            else if (mealChoice.ToLower() == "dinner")
            {
                Dinner(mealList);
            }
            else
            {
                Console.WriteLine("Please choose either breakfast or lunch. Double check spelling.");
                CreateMeal(mealList);
            }
        }

        static void Breakfast(List<Meal> mealList)
        {
            Console.WriteLine("Will you be having coffee with breakfast? Y or N?");
            var coffeeChoice = Console.ReadLine();
            bool userCoffeeChoice = false;

            if(coffeeChoice.ToLower() == "y" || coffeeChoice.ToLower() == "yes")
            {
                userCoffeeChoice = true;
            }

            Console.WriteLine("What else would you like to drink?");
            var drinkChoice = Console.ReadLine();

            Console.WriteLine("What would you like for your entree?");
            var entreeChoice = Console.ReadLine();

            mealList.Add(new Breakfast("Breakfast", drinkChoice, entreeChoice, userCoffeeChoice));
        }

        static void Lunch(List<Meal> mealList)
        {
            Lunch lunch = new Lunch();
            Console.WriteLine("Will you be having soup or salad? Y or N?");
            string soSChoice = Console.ReadLine();

            if (soSChoice.ToLower() == "y" || soSChoice.ToLower() == "yes" || soSChoice.ToLower() == "salad" || soSChoice.ToLower() == "soup")
            {
                //make SaladOrSoup be what the user wants
                Console.WriteLine("Soup or salad?");
                lunch.SaladOrSoup = Console.ReadLine();
                lunch.SaladOrSoup = lunch.SoupOrSalad();
            }
            soSChoice = "";

            Console.WriteLine("What would you like to drink?");
            lunch.Drink = Console.ReadLine();

            Console.WriteLine("What would you like for your entree?");
            lunch.Entree = Console.ReadLine();

            mealList.Add(lunch);
        }

        static void Dinner(List<Meal> mealList)
        {
            Dinner dinner = new Dinner();
            dinner.AppetizerMethod();

            Console.WriteLine("What would you like to drink?");
            dinner.Drink = Console.ReadLine();

            Console.WriteLine("What would you like for your entree?");
            dinner.Entree = Console.ReadLine();

            Console.WriteLine("What would you like for your desert?");
            dinner.Desert = Console.ReadLine();

            mealList.Add(dinner);
        }

        static void Quit()
        {
            Console.WriteLine("Good bye!");
        }
    }
}