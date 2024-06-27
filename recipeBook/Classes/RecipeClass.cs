using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

/// <summary>
/// Name: Jacques du Plessis
/// Student: ST10329686
/// Module: PROG6221
/// </summary>
/// This class displays the recipe with ingredients, quantities, units, number of steps, and step descriptions.
/// it also allows the user to scale the recipe and reset it to the original quantities.
/// References:
/// https://www.c-sharpcorner.com/article/change-console-foreground-and-background-color-in-c-sharp/
/// https://www.w3schools.com/cs/cs_operators_logical.php
/// https://www.geeksforgeeks.org/ref-in-c-sharp/
/// https://www.c-sharpcorner.com/article/how-to-copy-an-array-in-c-sharp/
/// https://www.c-sharpcorner.com/UploadFile/c713c3/how-to-exit-in-C-Sharp/#

namespace recipeBook.Classes
{
    public class RecipeClass
    {
        private double totalCalories;
        private Dictionary<string, double[]> originalQuantities = new Dictionary<string, double[]>();
        private Dictionary<string, double[]> originalConvertedQuantities = new Dictionary<string, double[]>();
        private Dictionary<string, double[]> originalCaloriesPerIngredient = new Dictionary<string, double[]>();

        // Delegate to check calories
        public delegate void CalorieChecker(int calories);

        // Delegate instance
        public CalorieChecker CalorieCheckDelegate;


        // -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void CheckCalories(int calories)
        {
            // Delegate to check calories 
            if (calories < 200)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("This recipe is low in calories.");
            }
            else if (calories >= 200 && calories <= 300) // calories between 200 and 300
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("This recipe has an average amount of calories.");
            }
            else if (calories > 300 && calories <= 500) // calories between 300 and 500
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Warning: This recipe contains an above average amount of calories");
            }
            else // calories > 500 // calories above 500
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning: This recipe is very high in calories.");
            }
        }


        // -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public static void FullRecipe(string recipeName, string[] ingredients, double[] quantitiesInGrams, string[] units, int numberOfSteps, string[] stepDescription, double[] convertedQuantities, string[] foodGroups, double[] caloriesPerIngredient, double totalCalories)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Recipe Name: {recipeName}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;

            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ingredient: {ingredients[i]}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"  Food Group: {foodGroups[i]}");
                Console.WriteLine($"  Quantity in grams: {quantitiesInGrams[i]}");
                Console.WriteLine($"  Converted Quantity: {convertedQuantities[i]} {units[i]}");
                Console.WriteLine($"  Calories: {caloriesPerIngredient[i]}");
                Console.WriteLine("--------------------------------");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Total Calories:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(totalCalories);

            Console.WriteLine("--------------------------------");

            // check calories using delegate
            CalorieChecker calorieChecker = CheckCalories;

            Console.WriteLine("Number of steps:");
            Console.WriteLine(numberOfSteps);
            Console.WriteLine("--------------------------------");

            for (int i = 0; i < stepDescription.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Step {i + 1}:");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(stepDescription[i]);
                Console.WriteLine("--------------------------------");
            }

            Console.ResetColor();
        }

// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Method to get the recipe name
        public bool ChooseToScaleRecipe()
        {
            // Ask user if they want to scale the recipe
            Console.WriteLine("Would you like to scale the recipe? (yes/no): ");
            string scaleRecipe;

            // Validate user input
            while (true)
            {
                scaleRecipe = Console.ReadLine();
                if (scaleRecipe == "yes" || scaleRecipe == "no")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter yes or no: ");
                }
            }
            return scaleRecipe == "yes";
        }

// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        
        // Method to get the scale factor
        public double ScaleFactor()
        {
            Console.WriteLine("How much do you want to scale your recipe (2, 3, or 0.5): ");
            double scaleFactor;
            while (!double.TryParse(Console.ReadLine(), out scaleFactor) || (scaleFactor != 2 && scaleFactor != 3 && scaleFactor != 0.5))
            {
                Console.WriteLine("Please enter 2, 3, or 0.5: ");
            }
            return scaleFactor;
        }

// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Method to adjust the quantities
        public void AdjustQuantities(ref double[] quantities, ref double[] convertedQuantities, ref double[] caloriesPerIngredient, double scaleFactor, out double totalCalories)
        {
            double[] originalCaloriesPerIngredient = (double[])caloriesPerIngredient.Clone();

            
            // Adjust quantities with scale factor
            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] *= scaleFactor;
                convertedQuantities[i] *= scaleFactor;
                caloriesPerIngredient[i] *= scaleFactor;
            }

            totalCalories = 0.0;
            for (int i = 0; i < caloriesPerIngredient.Length; i++)
            {
                totalCalories += caloriesPerIngredient[i];
            }
        }


// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        
        // Method to store original values
        public void StoreOriginalValues(string recipeName, double[] quantitiesInGrams, double[] convertedQuantities, double[] caloriesPerIngredient)
        {
            originalQuantities[recipeName] = (double[])quantitiesInGrams.Clone();
            originalConvertedQuantities[recipeName] = (double[])convertedQuantities.Clone();
            originalCaloriesPerIngredient[recipeName] = (double[])caloriesPerIngredient.Clone();
        }

// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        

        // Method to reset the recipe
        public void ResetRecipe(string recipeName, ref double[] quantitiesInGrams, ref double[] convertedQuantities, string[] units, string[] ingredients, ref string[] stepDescriptions, string[] foodGroups, ref double[] caloriesPerIngredient, ref double totalCalories)
        {
            // Check if original values are stored
            if (!originalQuantities.ContainsKey(recipeName) || !originalConvertedQuantities.ContainsKey(recipeName) || !originalCaloriesPerIngredient.ContainsKey(recipeName))
            {
                Console.WriteLine("Original values for this recipe are not stored. Reset failed.");
                return;
            }

            // Reset the recipe
            Console.WriteLine("Resetting recipe to original quantities...");
            quantitiesInGrams = (double[])originalQuantities[recipeName].Clone();
            convertedQuantities = (double[])originalConvertedQuantities[recipeName].Clone();
            caloriesPerIngredient = (double[])originalCaloriesPerIngredient[recipeName].Clone();

            totalCalories = 0.0;
            CalorieCounter(ingredients, caloriesPerIngredient, out totalCalories);

            // Reset step descriptions
            FullRecipe(recipeName, ingredients, quantitiesInGrams, units, stepDescriptions.Length, stepDescriptions, convertedQuantities, foodGroups, caloriesPerIngredient, totalCalories);
        }

// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        
        // Method to count the calories
        public void CalorieCounter(string[] ingredients, double[] caloriesPerIngredient, out double totalCalories)
        {
            totalCalories = 0.0;
            for (int i = 0; i < ingredients.Length; i++)
            {
                totalCalories += caloriesPerIngredient[i];
            }
        }

// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
       
        // Method to get the step descriptions
        public void EnterNewRecipe(List<string> recipeNames)
        {
            Console.WriteLine("Would you like to enter a new recipe? (yes/no): ");
            string newRecipe;
            // Validate user input
            while (true)
            {
                newRecipe = Console.ReadLine();
                if (newRecipe == "yes")
                {
                    Console.WriteLine();
                    break;
                }
                else if (newRecipe == "no")
                {
                    Console.WriteLine("Goodbye!");
                    DisplayAllRecipes(recipeNames);
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please enter yes or no: ");
                }
            }
        }

// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        

        // Method to get the recipe name
        public void DisplayAllRecipes(List<string> recipeNames)
        {
            // Sort the recipe names
            recipeNames.Sort();
            Console.WriteLine("All recipes:");
            foreach (string recipe in recipeNames)
            {
                Console.WriteLine(recipe);
            }
        }

 // -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        

        // Method to get the recipe name
        public List<string> SearchRecipes(Dictionary<string, Recipe> recipes, string query)
        {
            // Search for recipes
            List<string> matchingRecipes = new List<string>();
            foreach (var recipe in recipes)
            {
                if (recipe.Key.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    matchingRecipes.Add(recipe.Key);
                }
            }
            return matchingRecipes;
        }
// -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        

        // Method to display the search results
        public void DisplaySearchResults(Dictionary<string, Recipe> recipes, List<string> matchingRecipes)
        {

            // Display search results
            if (matchingRecipes.Count == 0)
            {
                Console.WriteLine("No matching recipes found.");
                return;
            }

            // Display matching recipes
            foreach (var recipeName in matchingRecipes)
            {
                var recipe = recipes[recipeName];

                double totalCalories = 0;
                for (int i = 0; i < recipe.CaloriesPerIngredient.Length; i++)
                {
                    totalCalories += recipe.CaloriesPerIngredient[i];
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("--------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Recipe: {recipe.Name}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("--------------------------------");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ingredients:");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                for (int i = 0; i < recipe.Ingredients.Length; i++)
                {
                    Console.WriteLine($"{recipe.Ingredients[i]}: {recipe.ConvertedQuantities[i]} {recipe.Units[i]} (Calories: {recipe.CaloriesPerIngredient[i]})");
                }
                Console.WriteLine("--------------------------------");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Steps:");
                Console.ForegroundColor = ConsoleColor.Blue;
                for (int i = 0; i < recipe.StepDescription.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {recipe.StepDescription[i]}");
                }
                Console.WriteLine("--------------------------------");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Total Calories:");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(totalCalories);
                Console.WriteLine("--------------------------------");

                CalorieChecker calorieChecker = new CalorieChecker(CheckCalories);
                calorieChecker((int)totalCalories);

                Console.WriteLine();
            }

            Console.ResetColor();
        }
    }
}
// ---------------------------------------------------------------------END OF FILE--------------------------------------------------------------------------------------------------------------------------------------------