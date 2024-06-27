using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using recipeBook.Classes;
using System.Windows.Navigation;

namespace RecipeInterface
{
    public partial class Page3 : Page
    {
        // Static list to store recipe names
        private static List<string> recipeNames = new List<string>();

        public Page3()
        {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Get recipe details from the text boxes
            string recipeName = RecipeNameTextBox.Text.Trim();
            int numberOfIngredients = int.Parse(NumberOfIngredientsTextBox.Text.Trim());
            int numberOfSteps = int.Parse(NumberOfStepsTextBox.Text.Trim());

            // Store rthe recipe name in the list
            recipeNames.Add(recipeName);
            

            // Create a new instance of Recipe with entered details
            Recipe recipe = new Recipe
            {
                Name = recipeName,
                Ingredients = new string[numberOfIngredients],
                StepDescription = new string[numberOfSteps]
            };

            // Store the recipe instance in App
            if (App.Current is App app)
            {
                app.CurrentRecipe = recipe;
            }

            // Navigate to Page2
            NavigationService.Navigate(new Page2());
        }

        // Method to retrieve the list of recipe names
        public static List<string> GetRecipeNames()
        {
            return recipeNames;
        }
    }
}

//---------------------------------------------------End of File------------------------------------------------------