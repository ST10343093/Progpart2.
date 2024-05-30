using System;
using System.Collections.Generic;

namespace ST10343093
{
    public delegate void RecipeDelegate(string message);
    public class Recipe
    {
        public string Name { get; set; }
        private List<Ingredient> initialIngredients = new List<Ingredient>(); // Store initial quantities

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Step> Steps { get; set; } = new List<Step>();

        //New variables for part 2
        private string message; // used for unit testing

        private double totalCalories;
        // private double variable created to store the total number of calories in a recipe

        public void AddSteps(List<Step> steps)
        {
            Steps.AddRange(steps);
        }

        public bool HasData() // method to check if data exists
        {
            return Ingredients.Count > 0 || Steps.Count > 0;
        }

        public void DisplayRecipe(double scale)
        {
            Console.WriteLine($"Recipe: {Name}\n");

            if (Ingredients.Count > 0)
            {
                Console.WriteLine("Recipe Ingredients:");
                foreach (var ingredient in Ingredients)
                {
                    var scaledQuantity = ingredient.Quantity * scale;
                    var scaleCalories = ingredient.calories * scale;
                    Console.WriteLine($"{scaledQuantity} {ingredient.Unit} of {ingredient.Name}");
                    Console.WriteLine($" Calories : {scaleCalories}");
                    Console.WriteLine($" Food Group : {ingredient.FoodGroup}");
                }
            }
            else
            {
                Console.WriteLine("No ingredients added yet.");
            }

            if (Steps.Count > 0)
            {
                Console.WriteLine("\nRecipe Steps:");
                for (int i = 0; i < Steps.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Steps[i].Description}");
                }
            }
            else
            {
                Console.WriteLine("No steps added yet.");
            }
           double scaledTotalCalories = calculateTotalCalories() * scale; 
            displayCalories(scaledTotalCalories);
        }

        public double calculateTotalCalories()
        {
            totalCalories = 0; //create variable to hold total calories

            // runs a loop to access each ingredient object in ingredients list
            // allowing system to retrieve the number of calories for each ingredient and add them together
            
            foreach (var ingredient in Ingredients) {

                totalCalories = totalCalories + ingredient.calories;
            }

            return totalCalories;
        }// end calculate total calories method

        public void displayCalorieMessage(string message)
        { Console.WriteLine(message); }
        // delegate method created to dsplay a warning message to user once a recipe contains more than 300 calories
        // method also used to provide a message about the number of calories in the recipe to the uer

        public void displayCalories(double scaledTotalCalories)
        {
            RecipeDelegate recipeDelegate = new RecipeDelegate(displayCalorieMessage);
            // create instance of delegate

            recipeDelegate($"Total number of calories in recipe: {scaledTotalCalories}");
            // use of delegate to display the total number of calories in the recipe to the user

            if (scaledTotalCalories > 300)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                recipeDelegate("CALORIES EXCEED 300");
                // delegate used to warn user that recipe calories is over 300
                Console.ForegroundColor = ConsoleColor.White;
            }// end if

            if (scaledTotalCalories > 0 && scaledTotalCalories <= 200)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                recipeDelegate("This amount of calories is enough to satisfy you without interfering with appetite and is a good SNACK");
                // delegate used to display to user that recipe calories is a snack
                Console.ForegroundColor = ConsoleColor.White;
                message = "Snack";
            }// end if snack
            else if (scaledTotalCalories > 200 && scaledTotalCalories <= 400)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                recipeDelegate("This amount of calories serves as a LOW CALORIE MEAL, aiding in weight loss");
                // delegate used to display to user that recipe calories is a low calorie meal
                Console.ForegroundColor = ConsoleColor.White;
                message = "Low Calorie Meal";
            }// end low calorie meal
            else if (scaledTotalCalories > 400 && scaledTotalCalories <= 700)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                recipeDelegate("This amount of calories is suitable for an AVERAGE MEAL ");
                // delegate used to display to user that calories are average
                Console.ForegroundColor = ConsoleColor.White;
                message = "Average Calorie Meal";
            }
            else if (scaledTotalCalories > 700)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                recipeDelegate("This meal is considered a HIGH CALORIE MEAL, containing a large amount of calories, and should not be consumed frequently");
                // delegate used to display to user that calories are high 
                Console.ForegroundColor = ConsoleColor.White;
                message = "High Calorie Meal";
            }
        }

            public void AddIngredients(List<Ingredient> ingredients)
        {
            Ingredients = ingredients;
            initialIngredients.AddRange(ingredients); // Copy initial quantities
        }

        public void ResetQuantities()
        {
            if (initialIngredients.Count > 0)
            {
                for (int i = 0; i < Ingredients.Count; i++)
                {
                    Ingredients[i].Quantity = initialIngredients[i].Quantity; // Reset to initial quantities
                }
                Console.WriteLine("Recipe quantities reset to original.");
            }
            else
            {
                Console.WriteLine("No recipe added yet. Please add a recipe first.");
            }
        }

        public void ClearRecipe()
        {
            if (HasData())
            {
                Console.WriteLine("Are you sure you want to clear the recipe? (yes/no)");
                string confirmation = Console.ReadLine()?.Trim().ToLower();

                if (confirmation == "yes")
                {
                    Ingredients.Clear();
                    Steps.Clear();
                    initialIngredients.Clear(); // Clear initial ingredients list
                    Console.WriteLine("Recipe cleared successfully.");
                }
                else if (confirmation == "no")
                {
                    Console.WriteLine("Clear operation canceled.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                    // Do not call ClearRecipe() here to avoid recursion
                }
            }
            else
            {
                Console.WriteLine("No recipe added yet. Please add a recipe first.");
            }
        }

        // CREATED FOR USE IN UNIT TESTING
        public void setTotalCalories(double totalCalories)
        { this.totalCalories = totalCalories; }

        public void setIngredients(List<Ingredient> ingredients)
        { this.Ingredients = ingredients; }

        public string Message()
        { return message; }

    }
}
