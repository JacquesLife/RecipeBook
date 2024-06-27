# User Manuel for POE project

## Overview

This is a user manuel for the POE project. The project is written in the .net framework in the 4.8 sdk. The project is a recipe managment system which takes in user input to create recipes. The project is divied into 3 parts Test, Interface and recipeBook. The test project is used to test the recipeBook project. The interface project is used to create a user interface for the recipeBook project. The recipeBook project is used to create the recipe managment system. When running this application I recommend running the recipeBook project first and choosing between 1 and 3 steps and ingredients. otherwise you will need to enter a lot of data which can be time consuming. the application can handle a lot so if you choose to enter 100 ingredients and steps you will be prompted to enter 100 ingredients and steps.

## Recipe Book

### How to run Recipe Book in visual studio
Once you have downloaded the project from github, open the project in visual studio. Once the project is open, right click on the recipeBook project and click on set as startup project. Once the project is set as the startup project, click on the start button to run the project.

### Step 1: Enter Recipe Name
Once the project is running, you will be prompted to enter a recipe name. Enter the name of the recipe you would like to create and press enter.

### Step 2: Enter the number of ingredients
Once you have entered the recipe name, you will be prompted to enter the number of ingredients in the recipe. Enter the number of ingredients and press enter (Must be a number).

### Step 3: Enter the number of steps
Once you have entered the number of ingredients, you will be prompted to enter the number of steps in the recipe. Enter the number of steps and press enter (Must be a number).

### Step 4: Enter the ingredients name 
Once you have entered the number of steps, you will be prompted to enter the name of the ingredients. Enter the name of the ingredients and press enter. Note that the number of ingredients you entered in step 2 will determine how many times you will be prompted to enter the name of the ingredients.

### Step 5: Enter the food group
Once you have entered the name of the ingredients, you will be prompted to enter the food group (Dairy, Fruit and Vegtables, Proteins, Carbohydrates, Fats and Oils.) of the ingredients. Enter the food group of the ingredients and press enter. Note that the number of ingredients you entered in step 2 will determine how many times you will be prompted to enter the food group of the ingredients.

### Step 6: Enter the quantity
Once you have entered the food group, you will be prompted to enter the quantity of the ingredients in grams. Enter the quantity of the ingredients and press enter. Note that the number of ingredients you entered in step 2 will determine how many times you will be prompted to enter the quantity of the ingredients.

### Step 7: Enter your preffered unit of measurement
Once you have entered the quantity of the ingredients, you will be prompted to enter your preffered unit of measurement (Cups, Tablespoons, Teaspoons) of the ingredients. Enter your preffered unit of measurement and press enter. Note that the number of ingredients you entered in step 2 will determine how many times you will be prompted to enter your preffered unit of measurement of the ingredients.

### Step 8: Enter the number of calories for the ingredients
Once you have entered your preffered unit of measurement, you will be prompted to enter the number of calories for the ingredients. Enter the number of calories for the ingredients and press enter. Note that the number of ingredients you entered in step 2 will determine how many times you will be prompted to enter the number of calories for the ingredients.

### Step 9: Step descriptions
Once you have entered the number of calories for the ingredients, you will be prompted to enter the step descriptions. Enter the step descriptions and press enter. Note that the number of steps you entered in step 3 will determine how many times you will be prompted to enter the step descriptions.

### Step 10: The recipe is displayed
Once you have entered the step descriptions, the recipe will be displayed. The recipe will display the recipe name, ingredients, steps and the total number of calories in the recipe all displayed in a red and blue color.

### Step 11: Scale the recipe
Choose either to scale the recipe by writing either "yes" or "no". If you choose "yes" you will be prompted to enter the number of servings you would like to scale the recipe by. If you choose "no" the recipe wont be scaled and you will be prompted to search for a recipe in step 15.

### Step 12: Enter scale factor
Once you have entered "yes" in step 11, you will be prompted to enter the number of servings you would like to scale the recipe by (0.5, 2, 3). Enter the number of servings you would like to scale the recipe by and press enter.

### Step 13: The scaled recipe is displayed
Once you have entered the number of servings you would like to scale the recipe by, the scaled recipe will be displayed. The scaled recipe will display the recipe name, ingredients, steps and the total number of calories in the recipe all displayed in a red and blue color.

### Step 14: Reset the scaled recipe
Once you have viewed the scaled recipe, you will be prompted to reset the scaled recipe. Enter "yes" to reset the scaled recipe or "no" to keep the scaled recipe. The list of all your recipes will be displayed in alphabetical order at the bottom of the display in white.

### Step 15: Search for a recipe
You will be prompted to search for a recipe you can choose "yes" to search for a recipe or "no" where you will be prompted to enter a new recipe in step 18.

### Step 16: Enter the recipe name
Once you have entered "yes" in step 15, you will be prompted to enter the recipe name you would like to search for. Enter the recipe name and press enter. if the recipe is found it will be displayed if not the system will display a message saying the recipe was not found and you will be prompted to enter a new recipe in step 18.

### Step 17: Search recipe is displayed
Once you have entered the recipe name you would like to search for, the recipe will be displayed. The recipe will display the recipe name, ingredients, steps and the total number of calories in the recipe all displayed in a red and blue color.

### Step 18: Enter a new recipe
Once you have viewed the search recipe, you will be prompted to enter a new recipe. Enter "yes" to enter a new recipe or "no" to exit the application. If you choose "yes" the process will start again from step 1. If you choose "no" the application will exit.

## Test

### How to run Test in visual studio
Navigate to test in the solution explorer and right click on the test project and run the test. The test file will run and display the results of the unit tests.

### Test 1: Calculate Calories
The test will calculate the calories of the recipe and compare it to the expected calories. If the calories are correct the test will pass.

### Test 2: Valid input for calories
The test will check if the calories are valid. If the calories are valid the test will pass.

### Test 3: Catch null input for calories
The test will check if the calories are null. If the calories are null the test will pass.

### Test 4: Catch Empty input for calories
The test will check if the calories are empty. If the calories are empty the test will pass.

### Test 5: Test Delagate calorie warning
The test will check if the calories are above 300. If the calories are above 300 the test will pass if the warning is displayed.

### Test 6: Test Delagate calorie warning
The test will check if the calories are below 300. If the calories are below 300 the test will fail if the warning is displayed.

## Interface

### How to run Interface in visual studio
By the play button in visual studio, you can run the interface project. The interface project will apear by the dropdown menu next to the green play icon in visual studio. Select the interface project and click the play button to run the interface project.

### Step 1: Recipe Name Page (Default Page)
Once the interface project is running, you will see a page with a Recipe Name instruction and a text box to enter the recipe name. Enter your recipe name. Below the box you can see a number of ingridients instruction with a text box to enter the number of ingridients. Below the number of ingridients you can see a number of steps instruction with a text box to enter the number of steps. Once you have entered the recipe name, number of ingridients and number of steps, click the next button to go to the next page (Ingridients Page).

### Step 2: Ingridients Page
Once you have clicked the next button, you will be taken to the Ingridients Page. On this page you will see a Ingridient Name, Food Group, Preffered Unit of Measurement, Quantity and Calories instruction. You will also see a text box to enter the Ingridient Name, Food Group, Preffered Unit of Measurement, Quantity and Calories. Once you have entered the Ingridient Name, Food Group, Preffered Unit of Measurement, Quantity and Calories click the add ingridient button to add the ingridient to the list of ingridients. This will display the name of the ingridient you entered in a list below the add ingridient button. Once you have entered all the ingridients, click the next button to go to the next page (Scale Page).

### Step 3: Scale Page
This page will take your Recipe Names and display them in a list in alphabetical order. You can add as many Recipe Names as you like. When you are done you can click the "X" in the top right corner to close the Interface project.

## Changes made according to feedback
Improved the Delegate to give users more infomation about calories now not only giving the user a warning when calories greater than 300 but also giving them calories infomation such as when calories are between 250 and 500 print above average calories. When calories over 500 print high calories. When calories below 250 print low calories. Hopefuly this will give the user more infomation about the calories in the recipe. 

## Github link

Link: https://github.com/JacquesLife/RecipeBook/tree/Final-POE3

