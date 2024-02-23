using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meals
{
    class Breakfast: Meal
    {
        public bool Coffee { get; set; }

        public Breakfast()
        {
            MealType = "Breakfast";
            Coffee = false;
        }

        public Breakfast(string mealType, string drink, string entree, bool coffee): 
            base(mealType, drink, entree)
        {
            Coffee = coffee;
        }

        public string CoffeeMethod()
        {
            return Coffee ? "Yes" : "No";
        }

        public override string ToString()
        {
            return base.ToString() + $"\nCoffee: {CoffeeMethod()}\n";
        }
    }
}
/*
*1.Breakfast
* A.Bool coffee
* B.Overriding ToString()
*/