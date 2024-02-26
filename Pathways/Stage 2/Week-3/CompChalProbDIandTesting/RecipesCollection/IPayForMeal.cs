using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meals
{
    public interface IPayForMeal
    {
        double PayForMeal(double items);
    }
}
