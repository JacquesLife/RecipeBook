/// <summary>
/// This is the backend for the program. It contains the Recipe class which is used to store the recipe information.
/// it is essentially getters and setters for the recipe information.
/// as well as the IngredientsClass which is used to get the information about the ingredients.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipeBook.Classes
{
    public class Recipe
    {
        public string Name { get; set; }
        public string[] Ingredients { get; set; }
        public double[] QuantitiesInGrams { get; set; }
        public string[] Units { get; set; }
        public double[] ConvertedQuantities { get; set; }
        public double[] CaloriesPerIngredient { get; set; }
        public string[] FoodGroups { get; set; }
        public string[] StepDescription { get; set; }
        public double TotalCalories { get; set; }


        public Recipe()
        {
            Name = "";
            Ingredients = new string[0];
            QuantitiesInGrams = new double[0];
            Units = new string[0];
            ConvertedQuantities = new double[0];
            CaloriesPerIngredient = new double[0];
            FoodGroups = new string[0];
            StepDescription = new string[0];
            TotalCalories = 0;
        }
    }
}

// ----------------------------------------------------END OF FILE----------------------------------------------------------------------------------------------------------------------------