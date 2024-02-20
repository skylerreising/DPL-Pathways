using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meals
{
    public class Meal
    {
        //Properties
        public string MealType { get; set; }
        public string Drink { get; set; }
        public string Entree { get; set; }

        //Constructors
        public Meal()
        {
            MealType = "No Meal Specified";
            Drink = "None";
            Entree = "None";
        }

        public Meal(string mealType, string drink, string entree): this()
        {
            MealType = mealType;
            Drink = drink;
            Entree = entree;
        }

        //ToString()
        public override string ToString()
        {
            return $"\nMeal Type: {MealType}\nDrink: {Drink}\nEntree: {Entree}";
        }
    }
}
/*
*Parent - Meal
* A.String drink
* B.String entree
* C. ToString()
*/
