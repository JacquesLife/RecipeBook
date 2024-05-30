using Microsoft.VisualStudio.TestTools.UnitTesting;
using recipeBook.Classes;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The Test namespace contains unit tests for the recipeBook project.
/// However I struggle writing these and had to pass the methods to be tested as parameters to the TestConsole class.
/// it follows the same logic as the CalorieCheckerTests class.
/// https://www.youtube.com/watch?v=uvqAGchg8bc
///

namespace Test
{
    [TestClass]
    public class CalorieCheckerTests
    {
        private Recipe recipe;

        [TestInitialize]
        public void Setup()
        {
            recipe = new Recipe();
        }
// --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void CalorieChecker_ValidInput_ReturnsTotalCalories()
        {
            // Arrange
            recipe.Ingredients = new string[] { "Ingredient1", "Ingredient2" };
            recipe.CaloriesPerIngredient = new double[] { 100, 200 };
            double totalCalories = CalorieChecker(recipe);


            // Assert
            Assert.AreEqual(300, totalCalories, "Total calories calculated incorrectly.");
        }
// --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void CalorieChecker_InvalidInput_ReturnsZeroCalories()
        {
            // Arrange
            recipe.Ingredients = new string[] { "Ingredient1", "Ingredient2" };
            recipe.CaloriesPerIngredient = new double[] { -100, 200 };
            double totalCalories = CalorieChecker(recipe);


            // Assert
            Assert.AreEqual(0, totalCalories, "Total calories should be zero for negative calorie values.");
        }

// --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void CalorieChecker_NullInput_ReturnsZeroCalories()
        {
            // Arrange
            recipe.Ingredients = null;
            recipe.CaloriesPerIngredient = null;
            double totalCalories = CalorieChecker(recipe);

            // Act

            // Assert
            Assert.AreEqual(0, totalCalories, "Total calories should be zero for null inputs.");
        }

  // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void CalorieChecker_EmptyInput_ReturnsZeroCalories()
        {
            // Arrange
            recipe.Ingredients = new string[0];
            recipe.CaloriesPerIngredient = new double[0];
            double totalCalories = CalorieChecker(recipe);


            // Assert
            Assert.AreEqual(0, totalCalories, "Total calories should be zero for empty inputs.");
        }
// --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private double CalorieChecker(Recipe recipe)
        {
            double totalCalories = 0.0;

            if (recipe != null && recipe.Ingredients != null && recipe.CaloriesPerIngredient != null)
            {
                for (int i = 0; i < recipe.Ingredients.Length && i < recipe.CaloriesPerIngredient.Length; i++)
                {
                    totalCalories += recipe.CaloriesPerIngredient[i];
                }
            }

            return totalCalories;
        }
// --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void CheckCalories_CaloriesGreaterThanOrEqualTo300_PrintsWarning()
        {
            // Arrange
            int calories = 350;
            bool warningPrinted = false;
            Console.SetOut(new TestConsole(output => { warningPrinted = output.Contains("Warning"); }));

            // Act
            CheckCalories(calories);

            // Assert
            Assert.IsTrue(warningPrinted, "Warning message should be printed for calories >= 300.");
        }
// --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        [TestMethod]
        public void CheckCalories_CaloriesLessThan300_NoWarning()
        {
            // Arrange
            int calories = 250;
            bool warningPrinted = false;
            Console.SetOut(new TestConsole(output => { warningPrinted = output.Contains("Warning"); }));

            // Act
            CheckCalories(calories);

            // Assert
            Assert.IsFalse(warningPrinted, "No warning message should be printed for calories < 300.");
        }

// --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void CheckCalories(int calories)
        {
            if (calories >= 300)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning: This recipe contains 300 or more calories.");
            }
        }
// --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private class TestConsole : TextWriter
        {
            private readonly StringWriter _stringWriter;
            private readonly TextWriter _originalOutput;

            public TestConsole(Action<string> assertAction)
            {
                _stringWriter = new StringWriter();
                _originalOutput = Console.Out;
                Console.SetOut(_stringWriter);
                AssertAction = assertAction;
            }

            public Action<string> AssertAction { get; }

            public override Encoding Encoding => Encoding.UTF8;

            public override void WriteLine(string value)
            {
                AssertAction(value);
            }

            public override void WriteLine()
            {
                AssertAction(string.Empty);
            }

            protected override void Dispose(bool disposing)
            {
                Console.SetOut(_originalOutput);
                AssertAction(_stringWriter.ToString());
                _stringWriter.Dispose();
                base.Dispose(disposing);
            }
        }
    }
}
// ---------------------------------------------END OF FILE -----------------------------------------------------------------------------------------------------------------------------------
}