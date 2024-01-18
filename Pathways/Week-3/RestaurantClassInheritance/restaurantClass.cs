using System;

namespace restaurantAPP
{
  class Restaurant
    {
        public string RName //property
            { get; set;}
        public string RRating  // property
            { get; set; }
        

        // This is the default constructor when no values are being passed.
        public Restaurant ()
        {
            RName = null!;
            RRating = null!;
        }

        // This is the constructor when two values are passed.
        public Restaurant (string newRestaurant, string newRating)
        {
            RName = newRestaurant;
            RRating = newRating;
        }

        // This overrides ToString so an object can be printed out with the WriteLine.

        public override string ToString()
        {
            return "Restaurant: " + RName + "\nRating: " + RRating + " stars." + "\nNumber of Menu Items: " + MenuItems();
        }

        public virtual int MenuItems()
        {
            return 10;
        }

    }// class Restaurant
}// namespace restaurantAPP 