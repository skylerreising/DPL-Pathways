using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meals
{
    class Lunch: Meal
    {
        public string SaladOrSoup { get; set; }

        public Lunch()
        {
            MealType = "Lunch";
            SaladOrSoup = "None";
        }

        public Lunch(string mealType, string drink, string entree, string saladOrSoup): 
            base(mealType, drink, entree)
        {
            SaladOrSoup=saladOrSoup;
        }

        public string SoupOrSalad()
        {
            if(SaladOrSoup.ToLower() != "none")
            {
                if (SaladOrSoup.ToLower() == "salad")
                {
                    string salad;
                    Console.WriteLine("Garden or Caesar?");
                    salad = Console.ReadLine();
                    if (salad.ToLower() == "garden")
                    {
                        return "Garden salad";
                    }else if(salad.ToLower() == "caesar")
                    {
                        return "Caesar salad";
                    }
                    else
                    {
                        Console.WriteLine("Please choose Garden or Caesar.");
                        return SoupOrSalad();
                    }
                }
                else if(SaladOrSoup.ToLower() == "soup")
                {
                    return "The Soup du jour";
                }
                else
                {
                    Console.WriteLine("Please enter saladsoup.");
                    SaladOrSoup = Console.ReadLine();
                    return SoupOrSalad();
                }
            }
            else
            {
                return "None";
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"\nSoup or Salad: {SaladOrSoup}\n";
        }
    }
}
/* 2. Lunch
 *  A. Bool SaladOrSoup
 *      i. if true
 *          a. Salad
 *              1.Garden
 *              2.Caesar
 *          b. Soup du jour
 *  B. Overriding ToString()
 *      i. Default to no salad or soup or state the choice
 */