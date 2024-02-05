using System;

namespace recipeApp
{

    class Recipe
    {
        //Properties with get/set methods
        public string Materials { get; set; }
        public string Ingredients { get; set; }
        public string Directions { get; set; }

        //Default constructor
        public Recipe ()
        {
            Materials = null;
            Ingredients = null;
            Directions = null;
        }

        //Constructor when ingredients and directions are passed in
        public Recipe (string materials, string ingredients, string directions)
        {
            Materials = materials;
            Ingredients = ingredients;
            Directions = directions;
        }

        //ToString method for this class
        public override string ToString()
        {
            return $"This recipe calls for\n MATERIALS:\n{Materials}\n\nINGREDIENTS:\n{Ingredients} \nHere is how you make this recipe:\nDIRECTIONS:\n{Directions}";
        }
    }//end of class
}//end of namespace