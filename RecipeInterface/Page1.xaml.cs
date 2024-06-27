using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using recipeBook.Classes;

namespace RecipeInterface
{
    public partial class Page1 : Page
    {
        public Recipe CurrentRecipe { get; set; }
        private ObservableCollection<string> stepsList; // Collection to store steps
        private ObservableCollection<string> ingredientsList; // Collection to store ingredients

        public Page1(string recipeName, int numberOfIngredients, int numberOfSteps)
        {
            InitializeComponent();

            // Initialize all properties of the CurrentRecipe instance
            CurrentRecipe = new Recipe
            {
                Name = recipeName,
                Ingredients = new string[numberOfIngredients],
                QuantitiesInGrams = new double[numberOfIngredients],
                Units = new string[numberOfIngredients],
                ConvertedQuantities = new double[numberOfIngredients],
                CaloriesPerIngredient = new double[numberOfIngredients],
                FoodGroups = new string[numberOfIngredients],
                StepDescription = new string[numberOfSteps],
                Steps = new ObservableCollection<Recipe.Step>()
            };

            // Initialize steps and ingredients collections
            stepsList = new ObservableCollection<string>();
            ingredientsList = new ObservableCollection<string>();
            StepsListBox.ItemsSource = stepsList;
            IngredientsListBox.ItemsSource = ingredientsList;

            // Set DataContext to the current page instance (optional, but good practice)
            DataContext = this;
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            // Validate ingredient input
            if (!string.IsNullOrWhiteSpace(IngredientNameTextBox.Text))
            {
                // Add ingredient to the collection
                string ingredient = $"Ingredient {ingredientsList.Count + 1}: {IngredientNameTextBox.Text}";
                // Add Food Group to the collection
                string foodGroup = $"Food Group: {FoodGroupTextBox.Text}";
                // Add Calories to the collection
                string calories = $"Calories: {CaloriesTextBox.Text}";
                // Add Quantity to the collection

                
                ingredientsList.Add(ingredient);
                IngredientNameTextBox.Text = ""; 
            }
            else
            {
                MessageBox.Show("Please enter an ingredient name.");
            }
        }

        private int stepCount = 1; // Initialize a step counter

        private void EnterNewStep_Click(object sender, RoutedEventArgs e)
        {
            // Validate step description
            if (!string.IsNullOrWhiteSpace(StepDescriptionTextBox.Text))
            {
                // Add step description with step number to collection
                string stepDescription = $"Step {stepCount}: {StepDescriptionTextBox.Text}";
                stepsList.Add(stepDescription);
                StepDescriptionTextBox.Text = ""; // Clear text box for next step
                stepCount++; // Increment step counter for the next step
            }
            else
            {
                MessageBox.Show("Please enter a step description.");
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }

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
        public ObservableCollection<Step> Steps { get; set; }

        public class Step
        {
            public int StepNumber { get; set; }
            public string Description { get; set; }
        }
    }
}

// ---------------------------------------------------End of File------------------------------------------------------
