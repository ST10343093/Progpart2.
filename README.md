Recipe App

Overview

The Recipe App allows users to add, display, scale, reset, and clear recipes. The app manages ingredients and steps for each recipe and provides functionality to adjust ingredient quantities based on a scaling factor.

Prerequisites 
1.	.NET SDK: Ensure you have the .NET SDK installed on your machine. You can download it from the official .NET website. C# IDE: Install a 
2.	C# Integrated Development Environment (IDE) such as Visual Studio or Visual Studio Code.
Installation
Clone the repository (or download the source code files):
git clone <repository_url>
cd <repository_name>

Compile the program: 
Open a command prompt or terminal. Navigate to the directory where the source code files (Program.cs, Recipe.cs, Ingredient.cs, Step.cs) are located.

Use the following command to compile the program:
dotnet build -o <output_directory>
Replace < output_directory > with the directory where you want the compiled program to be placed.

Running the Program 
Navigate to the output directory:
cd <output_directory>
Run the Program: 
dotnet ST10343093.dll
Usage
1.	Follow the on-screen instructions to interact with the Recipe App.
2.	Menu options include:
1.	Add a new recipe: Enter the recipe name, ingredients, and steps.
2.	Display the current recipe: View the recipe details.
3.	Scale the recipe: Adjust ingredient quantities by a factor (0.5, 2, or 3).
4.	Reset quantities: Reset ingredient quantities to their original values.
5.	Clear the recipe: Remove the current recipe from the app.
6.	Exit the application: Close the app.
Class Structure
Program
•	Main Method: Entry point of the application. Handles user interaction and menu selection.
Recipe: 
•	Properties:
1.	Name: The name of the recipe.
2.	Ingredients: List of ingredients.
3.	Steps: List of steps.
•	Methods:
1.	HasData(): Checks if the recipe has any data.
2.	DisplayRecipe(double scale): Displays the recipe details with scaled quantities.
3.	AddIngredients(List<Ingredient> ingredients): Adds ingredients to the recipe.
4.	ResetQuantities(): Resets ingredient quantities to their original values.
5.	ClearRecipe(): Clears the recipe data.
Ingredients: 
•	Properties:
1.	Name: The name of the ingredient.
2.	Quantity: The quantity of the ingredient.
3.	Unit: The unit of measurement for the ingredient.
Step: 
•	Properties:
1.	Description: The description of the step.

Key Methods
Recipe.DisplayRecipe(double scale)
Displays the recipe details with scaled quantities. This method multiplies each ingredient's quantity by the given scale factor.
Recipe.AddIngredients(List<Ingredient> ingredients)
Adds a list of ingredients to the recipe and stores the initial quantities for reset functionality.
Recipe.ResetQuantities()
Resets the ingredient quantities to their original values.
Recipe.ClearRecipe()
Clears the recipe data after user confirmation.
Error Handling
•	The program handles invalid inputs and prompts the user to enter valid data.
•	For example, if an invalid scaling factor is entered, the program will prompt the user to enter 0.5, 2, or 3.
