using System;

namespace restaurantAPP
{
  class FineDining : Restaurant
    {
        //FineDining Properties
        public double Tip { get; set; }
        public string DressCode { get; set; }
        public int MichelinStars { get; set; }

        // This is the default constructor when no values are being passed.
        public FineDining () : base()
        {
            Tip = 0.25;
            DressCode = "Formal";
            MichelinStars = -1;
        }

        // This is the constructor when two values are passed.
        public FineDining (string newRestaurant, string newRating, double tip, string dressCode, int michelinStars): base(newRestaurant,newRating)
        {
            Tip = tip;
            DressCode = dressCode;
            MichelinStars = michelinStars;
        }

        // This overrides ToString so an object can be printed out with the WriteLine.
        public override string ToString()
        {
            return base.ToString() + $"\nDefault Tip: {Tip}\nDress Code: {DressCode}\nMichelin Stars: {MichelinStars} ";
            //return $"Restaurant: {RName}\nRating: {RRating} stars\nDefault Tip: {Tip}\nDress Code: {DressCode}\nMichelin Stars: {MichelinStars}";
        }

    }// class Restaurant
}// namespace restaurantAPP 