using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meals
{
    class Dinner: Meal
    {
        //Properties
        public string Appetizer { get; set; }
        public int NumOfAppetizers { get; set; }
        public string Desert { get; set; }

        public Dinner()
        {
            MealType = "Dinner";
            Appetizer = "None";
            NumOfAppetizers = 0;
            Desert = "None";
        }
        public Dinner(string mealType, string drink, string entree, string appetizer, int numOfAppetizers, string desert): base(mealType, drink, entree)
        {
            Appetizer = appetizer;
            NumOfAppetizers = numOfAppetizers;
            Desert = desert;
        }

        public void AppetizerMethod()
        {
            Console.WriteLine("Would you like an appetizer? Y or N");
            string answer = Console.ReadLine();

            if(answer.ToLower() == "y" || answer.ToLower() == "yes")
            {
                Console.WriteLine("What would you like for your appetizer?");
                Appetizer = Console.ReadLine();

                Console.WriteLine("How many would you like?");
                NumOfAppetizers = Convert.ToInt32(Console.ReadLine());
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"\nAppetizer: {NumOfAppetizers} {Appetizer}\nDesert: {Desert}\n";
        }
    }
}
/*
*5.Dinner
* i.Appetizer ?
*a. int amount?
* B.Meal questions
* i. Drink?
* ii. Entree?
* iiiC. Desert?
*/