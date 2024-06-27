using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using recipeBook.Classes;

namespace RecipeInterface
{
    public partial class Page2 : Page, INotifyPropertyChanged
    {
        private ObservableCollection<Recipe> recipes;

        public Page2()
        {
            InitializeComponent();

            // Initialize recipes collection
            recipes = new ObservableCollection<Recipe>();
            RecipesListBox.ItemsSource = recipes; // Bind ListBox to recipes collection

            // Sort recipes by name initially
            SortRecipesByName();
        }

        public ObservableCollection<Recipe> Recipes
        {
            get { return recipes; }
            set
            {
                recipes = value;
                OnPropertyChanged(nameof(Recipes));
            }
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Method to sort recipes by name
        private void SortRecipesByName()
        {
            Recipes = new ObservableCollection<Recipe>(recipes.OrderBy(r => r.Name));
        }

        // Add Recipe Button Click Handler
        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Validate recipe name input
            if (!string.IsNullOrWhiteSpace(RecipeNameTextBox.Text))
            {
                // Create a new Recipe instance
                Recipe newRecipe = new Recipe
                {
                    Name = RecipeNameTextBox.Text.Trim(),
                    // Initialize other properties as needed
                };

                // Add the new recipe to the collection
                recipes.Add(newRecipe);
                RecipeNameTextBox.Text = ""; // Clear text box after adding

                // Sort recipes by name again after adding new recipe
                SortRecipesByName();

                // Refresh ListBox to reflect the updated collection
                RecipesListBox.ItemsSource = null;
                RecipesListBox.ItemsSource = recipes;
            }
            else
            {
                MessageBox.Show("Please enter a recipe name.");
            }
        }
    }
}

// ---------------------------------------------------End of File------------------------------------------------------