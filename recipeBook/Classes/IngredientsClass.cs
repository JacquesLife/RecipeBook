using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Name: Jacques du Plessis
/// Student: ST10329686
/// Module: PROG6221
/// </summary>
/// This class is responsible for getting the number of ingredients, 
/// the name of each ingredient, the quantity of each ingredient, the unit of each ingredient, 
/// the number of steps, and the description of each step from the user.
/// References:
/// https://learn.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=net-8.0
/// https://www.tutorialsteacher.com/csharp/csharp-ternary-operator
/// https://www.youtube.com/watch?v=5VvAcoBJGJs
/// https://www.geeksforgeeks.org/c-sharp-arrays/
/// https://stackoverflow.com/questions/169217/c-sharp-equivalent-of-the-isnull-function-in-sql-server
/// 

using System;
using System.Net;
using System.IO;
using System.Data.Common;

namespace recipeBook.Classes
{
    internal class IngredientsClass
    {
        private readonly List<string> recipeNames = new List<string>();

        public string RecipeName()
        {
            string recipeName;
            do
            {
                Console.WriteLine("Enter the name of your recipe: ");
                recipeName = (Console.ReadLine() ?? string.Empty).Trim();
                if (recipeNames.Contains(recipeName))
                {
                    Console.WriteLine("Recipe name already exists. Please enter a different name.");
                }
            } while (recipeNames.Contains(recipeName));
            recipeNames.Add(recipeName);
            return recipeName;
        }

        // ------------------------------------------------------------------------------------------------------------------------------
        private readonly Dictionary<string, double> gramsToUnit = new Dictionary<string, double>
        {
            { "tablespoons", 1.0 / 14.3 },  // 1 gram = 1/14.3 tablespoons
            { "cups", 1.0 / 240 },          // 1 gram = 1/240 cups
            { "teaspoons", 1.0 / 4.2 }      // 1 gram = 1/4.2 teaspoons
        };
        //---------------------------------------------------------------------------------------------------------------------------------
        public int NumberOfIngredients()
        /// <summary>
        ///https://learn.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=net-8.0
        /// This method asks the user for the number of ingredients in the recipe.
        /// It checks if the input is a number.
        /// </summary>
        {
            // ask user for number of ingredients
            Console.WriteLine("How many ingredients are in your recipe?: ");

            int numberOfIngredients;

            // check if input is a number
            while (!int.TryParse(Console.ReadLine(), out numberOfIngredients))
            {
                Console.WriteLine("Please enter a number: ");
            }
            Console.WriteLine("You have " + numberOfIngredients + " ingredients in your recipe.");
            Console.WriteLine();
            return numberOfIngredients;
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        public string IngredientName(int index)
        /// <summary>
        /// https://www.tutorialsteacher.com/csharp/csharp-ternary-operator
        /// This method asks the user for the name of each ingredient in the recipe.
        /// </summary>
        {
            // ask user for ingredient name
            Console.WriteLine("Enter the name of ingredient " + index + ": ");

            // check if input is null
            string ingredient = Console.ReadLine();
            return ingredient ?? string.Empty;
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        public static double QuantityInGrams(string ingredient)
        {
            while (true)
            {
                Console.WriteLine($"Enter the quantity of {ingredient} in grams: ");
                string quantity = (Console.ReadLine() ?? string.Empty).Trim();
                if (double.TryParse(quantity, out double result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid quantity format. Please enter a valid number: ");
                }
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// https://www.youtube.com/watch?v=5VvAcoBJGJs
        /// This method creates a dictionary to store the units of measurement for the ingredients.
        /// </summary>
        public static string PreferredUnit(string ingredient)
        {
            string unit;
            do
            {
                Console.WriteLine($"Enter the preferred unit to convert {ingredient} to (cups, tablespoons, or teaspoons): ");
                unit = (Console.ReadLine() ?? string.Empty).Trim().ToLower();
                if (unit == "cups" || unit == "tablespoons" || unit == "teaspoons")
                {
                    return unit;
                }
                else
                {
                    Console.WriteLine("Please enter a valid unit of measurement: ");
                }
            } while (true);
        }

        //---------------------------------------------------------------------------------------------------------------------------------

        public double ConvertGramsToUnit(double grams, string unit)
        {
            if (gramsToUnit.TryGetValue(unit, out double conversionFactor))
            {
                return grams * conversionFactor;
            }
            else
            {
                return grams;
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------
        public int NumberOfSteps()
        {
            // ask user for number of steps
            Console.WriteLine("How many steps are in your recipe?: ");
            int numberOfSteps;

            // check if input is a number greater than 0
            while (!int.TryParse(Console.ReadLine(), out numberOfSteps) || numberOfSteps <= 0)
            {
                Console.WriteLine("Please enter a number greater than 0: ");
            }
            return numberOfSteps;
        }
        //---------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// https://www.geeksforgeeks.org/c-sharp-arrays/
        /// This method asks the user for the description of each step in the recipe.
        /// It stores the steps in an array.
        /// </summary>
        public string StepDescription(int stepNumber)
        {
            // Ask the user for the description of the specified step
            Console.WriteLine($"Enter a description for step {stepNumber}: ");
            return Console.ReadLine() ?? string.Empty;
        }
        //---------------------------------------------------------------------------------------------------------------------------------

        public string ValidateDescription(string description)
        /// <summary>
        /// https://stackoverflow.com/questions/169217/c-sharp-equivalent-of-the-isnull-function-in-sql-server
        /// This method checks if the description is empty and asks the user to enter a description if it is empty.
        /// </summary>
        {
            // check if description is empty
            while (string.IsNullOrEmpty(description))
            {
                Console.WriteLine("Description cannot be empty. Please enter a description: ");
                description = Console.ReadLine() ?? string.Empty;
            }
            return description;
        }
        //---------------------------------------------------------------------------------------------------------------------------------

        public static double Calories(string ingredient)
        {
            while (true)
            {
                Console.WriteLine("Enter the calories of " + ingredient + ": ");
                string input = Console.ReadLine() ?? string.Empty;

                // Check if input is a valid double
                if (double.TryParse(input, out double calories))
                {
                    // Check if calories are within an acceptable range
                    if (calories >= 0) 
                    {
                        return calories;
                    }
                    else
                    {
                        Console.WriteLine("Calories cannot be negative. Please enter a non-negative number.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------

        public static string FoodGroup(string ingredient)
        {
            Console.WriteLine($"Enter the food group for {ingredient}: ");
            Console.WriteLine("Options: Fruit and Vegetables, Carbohydrates, Proteins, Dairy, Fats and Oils");
            string foodGroup = (Console.ReadLine() ?? string.Empty).Trim();

            switch (foodGroup.ToLower())
            {
                case "fruit and vegetables":
                case "carbohydrates":
                case "proteins":
                case "dairy":
                case "fats and oils":
                    return foodGroup;
                default:
                    Console.WriteLine("Please enter a valid food group.");
                    return FoodGroup(ingredient);
            }
        }
        //------------------------------------------------------end of file------------------------------------------------------------------
    }
}
