using recipeBook.Classes;
using System;
using System.Collections.Generic;

namespace recipeBook
{
    class Program
    {
        static void Main()
        {
            var ingredientsClass = new IngredientsClass();
            var recipeClass = new RecipeClass();
            var recipes = new Dictionary<string, Recipe>();

            // Instantiate a new RecipeClass object
            recipeClass = new RecipeClass();

            

            while (true)
            {
                string recipeName = ingredientsClass.RecipeName();
                int numberOfIngredients = ingredientsClass.NumberOfIngredients();
                int numberOfSteps = ingredientsClass.NumberOfSteps();

                string[] ingredients = new string[numberOfIngredients];
                double[] quantitiesInGrams = new double[numberOfIngredients];
                string[] units = new string[numberOfIngredients];
                double[] convertedQuantities = new double[numberOfIngredients];
                double[] caloriesPerIngredient = new double[numberOfIngredients];
                string[] foodGroups = new string[numberOfIngredients];
                string[] stepDescription = new string[numberOfSteps];

                // Input ingredients
                for (int i = 0; i < numberOfIngredients; i++)
                {
                    ingredients[i] = ingredientsClass.IngredientName(i + 1);
                    foodGroups[i] = IngredientsClass.FoodGroup(ingredients[i]);
                    quantitiesInGrams[i] = IngredientsClass.QuantityInGrams(ingredients[i]);
                    units[i] = IngredientsClass.PreferredUnit(ingredients[i]);
                    convertedQuantities[i] = ingredientsClass.ConvertGramsToUnit(quantitiesInGrams[i], units[i]);
                    caloriesPerIngredient[i] = IngredientsClass.Calories(ingredients[i]);
                }

                // Input steps
                for (int i = 0; i < numberOfSteps; i++)
                {
                    stepDescription[i] = ingredientsClass.StepDescription(i + 1);
                }

                // Store original values
                recipeClass.StoreOriginalValues(recipeName, quantitiesInGrams, convertedQuantities, caloriesPerIngredient);

                // Calculate total calories
                double totalCalories = 0.0;
                recipeClass.CalorieCounter(ingredients, caloriesPerIngredient, out totalCalories);

                // Display the recipe
                RecipeClass.FullRecipe(recipeName, ingredients, quantitiesInGrams, units, numberOfSteps, stepDescription, convertedQuantities, foodGroups, caloriesPerIngredient, totalCalories);

                var recipe = new Recipe
                {
                    Name = recipeName,
                    Ingredients = ingredients,
                    QuantitiesInGrams = quantitiesInGrams,
                    Units = units,
                    ConvertedQuantities = convertedQuantities,
                    CaloriesPerIngredient = caloriesPerIngredient,
                    StepDescription = stepDescription,
                    TotalCalories = totalCalories
                };
                recipes.Add(recipeName, recipe);

                

                // Check if the user wants to scale the recipe
                if (recipeClass.ChooseToScaleRecipe())
                {
                    double scaleFactor = recipeClass.ScaleFactor();
                    recipeClass.AdjustQuantities(ref quantitiesInGrams, ref convertedQuantities, ref caloriesPerIngredient, scaleFactor, out totalCalories);

                    // Display the scaled recipe
                    Console.WriteLine("Here is your scaled recipe: ");
                    Console.WriteLine();
                    RecipeClass.FullRecipe(recipeName, ingredients, quantitiesInGrams, units, numberOfSteps, stepDescription, convertedQuantities, foodGroups, caloriesPerIngredient, totalCalories);

                    // Prompt the user to reset the recipe
                    Console.WriteLine("Would you like to reset the recipe to the original quantities? (yes/no): ");
                    string resetChoice = Console.ReadLine();
                    if (resetChoice.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        recipeClass.ResetRecipe(recipeName, ref quantitiesInGrams, ref convertedQuantities, units, ingredients, ref stepDescription, foodGroups, ref caloriesPerIngredient, ref totalCalories);

                        // Display the reset recipe
                        Console.WriteLine("Here is your reset recipe: ");
                        Console.WriteLine();
                        RecipeClass.FullRecipe(recipeName, ingredients, quantitiesInGrams, units, numberOfSteps, stepDescription, convertedQuantities, foodGroups, caloriesPerIngredient, totalCalories);
                    }
                }
                else
                {
                    Console.WriteLine("Here is your recipe: ");
                    Console.WriteLine();
                    RecipeClass.FullRecipe(recipeName, ingredients, quantitiesInGrams, units, numberOfSteps, stepDescription, convertedQuantities, foodGroups, caloriesPerIngredient, totalCalories);
                }

                // Display all recipes
                Console.WriteLine("All recipes: ");
                foreach (string name in recipes.Keys)
                {
                    Console.WriteLine(name);
                }

                // Search for a recipe
                Console.WriteLine();
                Console.WriteLine("Do you want to search for a recipe? (yes/no)");
                string searchChoice = Console.ReadLine();
                if (!string.IsNullOrEmpty(searchChoice) && searchChoice.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Enter the name of the recipe to search:");
                    string query = Console.ReadLine();
                    if (query != null)
                    {
                        List<string> matchingRecipes = recipeClass.SearchRecipes(recipes, query);
                        recipeClass.DisplaySearchResults(recipes, matchingRecipes);
                    }
                }

                // Enter a new recipe
                recipeClass.EnterNewRecipe(new List<string>(recipes.Keys));
            }
        }
    }
}
