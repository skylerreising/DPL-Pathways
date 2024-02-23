using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meals
{
    public class MealService: IPayForMeal
    {
        private readonly IPayForMeal _mealPrice;

        public MealService(IPayForMeal mealPrice)
        {
            _mealPrice = mealPrice;
        }

        public int PayForMeal(int items)
        {
            return _mealPrice.PayForMeal(items);
        }
    }
}
