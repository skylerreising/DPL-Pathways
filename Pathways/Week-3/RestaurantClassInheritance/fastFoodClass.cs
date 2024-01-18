using System;

namespace restaurantAPP
{
  class FastFood : Restaurant
    {
        //FineDining Properties
        public bool DriveThru { get; set; }
        public string HoursOfOperation { get; set; }

        // This is the default constructor when no values are being passed.
        public FastFood () : base()
        {
            DriveThru = false;
            HoursOfOperation = "24 Hours";
        }

        // This is the constructor when two values are passed.
        public FastFood (string newRestaurant, string newRating, bool driveThru, string hoursOfOperation) : base(newRestaurant,newRating)
        {
            DriveThru = driveThru;
            HoursOfOperation = hoursOfOperation;
        }

        //methods
        private string DriveOnThru()
        {
            return (DriveThru == false) ? "No" : "Yes";
        }

        // This overrides ToString so an object can be printed out with the WriteLine.

        public override string ToString()
        {
            return base.ToString() + $"\nDrive Thru Available?: {DriveOnThru()}\nHours of Operation: {HoursOfOperation}";
        }

        public override int MenuItems()
        {
            return 50;
        }

    }// class Restaurant
}// namespace restaurantAPP 