/*
 * Really struggled with the interface. I think my existing recipeBook code was to complex for the interface.
 * This casaused major issues with the interface. Did all I could to get as much functionality as possible.
 * 
 */


using System.Windows;
using System.Windows.Controls;

namespace RecipeInterface
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            if (tabControl == null) return;

            switch (tabControl.SelectedIndex)
            {
                case 0: // Recipe Name tab
                    // Navigate to Page3 (Recipe Name page)
                    RecipeFrame.Navigate(new Page3());
                    break;
                case 1: // Ingredients tab
                    // Navigate to Page1 (Ingredients page) 
                    IngredientsFrame.Navigate(new Page1("Default Recipe Name", 3, 3));
                    break;
                case 2: // Scale tab
                    // Navigate to Page2 (Scale page) 
                    ScaleFrame.Navigate(new Page2());
                    break;
                default:
                    break;
            }
        }
    }

    // ---------------------------------------------------End of File------------------------------------------------------
}   
