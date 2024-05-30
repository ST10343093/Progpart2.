using System;
using System.Collections.Generic;
using System.Linq; // Required for sorting

namespace ST10343093
{

    internal class Program
    {
        public FoodGroup FoodGroup { get; set; } 
        private static List<Recipe> recipes = new List<Recipe>(); // Static list to store recipes

        static void Main(string[] args)
        {
            Console.Title = "Recipe App";

         
            Console.Clear();


            Console.WriteLine("Welcome to your recipe App");

            bool exitApp = false;

            while (!exitApp)
            {
                Console.WriteLine("\nRecipe App Menu:");
                Console.WriteLine("1. Add a new recipe");
                Console.WriteLine("2. Display current recipe");
                Console.WriteLine("3. Scale the recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear the recipe");
                Console.WriteLine("6. Display all recipes");
                Console.WriteLine("7. Display all recipes in alphabetical order");
                Console.WriteLine("8. Display a specific recipe from list");
                Console.WriteLine("9. Exit");

                Console.WriteLine("\nEnter your choice (1-9):");
                string choice = Console.ReadLine();

                switch (choice) //Switch case for the different options
                {
                    case "1":
                        AddRecipe();
                        break;
                    case "2":
                        DisplayCurrentRecipe();
                        break;
                    case "3":
                        ScaleRecipe();
                        break;
                    case "4":
                        ResetQuantities();
                        break;
                    case "5":
                        //ClearRecipe();
                        ClearSpecificRecipe();
                        break;
                    case "6":
                        DisplayAllRecipes();
                        break;
                    case "7":
                        DisplayAllRecipesInOrder();
                        break;
                    case "8":
                        DisplaySpecificRecipe();
                        break;
                    case "9":
                        exitApp = true;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nExiting Recipe App. Goodbye!");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 9.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        static void AddRecipe()
        {
            Recipe newRecipe = new Recipe();

            while (true)
            {
                Console.WriteLine("Enter the name of the recipe:");
                newRecipe.Name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(newRecipe.Name))
                {
                    break; // Exit the loop if the name is not empty
                }
                else
                {
                    Console.WriteLine("Recipe name cannot be empty. Please enter a valid name.");
                }
            }

            Console.WriteLine("Enter the number of ingredients:");
            int numIngredients;
            while (!int.TryParse(Console.ReadLine(), out numIngredients) || numIngredients <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive integer.");
            }

            List<Ingredient> ingredients = new List<Ingredient>(); // Switched to List<Ingredient> from Ingredient[]

            // Input ingredients
            for (int i = 0; i < numIngredients; i++)
            {
                string name;
                while (true)
                {
                    Console.WriteLine($"Enter ingredient {i + 1} name:");
                    name = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        break; // Exit the loop if the name is not empty
                    }
                    else
                    {
                        Console.WriteLine("Ingredient name cannot be empty. Please enter a valid name.");
                    }
                }

                double quantity;
                while (true)
                {
                    Console.WriteLine($"Enter quantity for {name}:");
                    if (double.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity. Please enter a valid positive number.");
                    }
                }

                string unit;
                while (true)
                {
                    Console.WriteLine($"Enter unit of measurement for {name} (you can enter any unit):");
                    unit = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(unit))
                    {
                        break; // Exit the loop if the unit is not empty
                    }
                    else
                    {
                        Console.WriteLine("Unit of measurement cannot be empty. Please enter a valid unit.");
                    }



                }

                double calories;//variable to hold quantity of ingredients
                                //do while loop to continue prompting user if they enter invalid integer ( zero or less)
                do
                {//do begin
                    Console.Write($"Please enter the calories for {name}:");
                    calories = GetDoubleInput();
                    if (calories <= 0)
                    {//if begin
                        Console.WriteLine("Please enter a valid number (greater than zero).");
                    }//if end
                }//do end
                while (calories <= 0); //while condition

                //  GET FOOD GROUP FROM USER
                Console.WriteLine("A Food Group is a collection of foods that share similar nutritional properties\nPlease enter the food group that this ingredient belongs to\nEnter the name of the Food Group. Choose from:\n1.Carbohydrate\n2.Protein\n3.Fat\n4.Fruit\n5.Vegetable\n6.Dairy");
                FoodGroup foodGroup = GetFoodGroup($"Please enter the food group for {name}: ");

                ingredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit, calories = calories, FoodGroup = foodGroup });
            }

            newRecipe.AddIngredients(ingredients);



            Console.WriteLine("Enter the number of steps:");
            int numSteps;
            while (!int.TryParse(Console.ReadLine(), out numSteps) || numSteps <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive integer.");
            }
            List<Step> steps = new List<Step>();
            for (int i = 0; i < numSteps; i++)
            {
                string description;
                while (true)
                {
                    Console.WriteLine($"Enter step {i + 1} description:");
                    description = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(description))
                    {
                        break; // Exit the loop if the description is not empty
                    }
                    else
                    {
                        Console.WriteLine("Step description cannot be empty. Please enter a valid description.");
                    }
                }

                steps.Add(new Step { Description = description });
            }

            newRecipe.AddSteps(steps);

            recipes.Add(newRecipe); // Add the new recipe to the static list

            Console.WriteLine("Recipe added successfully.");
        }


        static void DisplayCurrentRecipe()
        {
            if (recipes.Count == 0 || recipes[^1] == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo recipe added yet. Please add a recipe first.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nCurrent Recipe:");
                recipes[^1].DisplayRecipe(1);
                Console.ResetColor();
            }
        }

        static void DisplayAllRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo recipes added yet. Please add a recipe first.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("\nAll Recipes:");
                foreach (var recipe in recipes)
                {
                    recipe.DisplayRecipe(1); // Assuming you want to display each recipe unscaled
                }
            }
        }


        static void DisplayAllRecipesInOrder()
        {
            if (recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo recipes added yet. Please add a recipe first.");
                Console.ResetColor();
            }
            else
            {
                // Sort recipes by name
                List<Recipe> sortedRecipes = recipes.OrderBy(r => r.Name).ToList();

                Console.WriteLine("\nAll Recipes (Alphabetical Order by Name):");
                foreach (var recipe in sortedRecipes)
                {
                    recipe.DisplayRecipe(1);
                }
            }
        }


        static void DisplaySpecificRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo recipes added yet. Please add a recipe first.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("\nSelect a recipe to display:");
                for (int i = 0; i < recipes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {recipes[i].Name}");
                }

                Console.WriteLine("\nEnter the number of the recipe:");
                if (int.TryParse(Console.ReadLine(), out int recipeNumber) && recipeNumber > 0 && recipeNumber <= recipes.Count)
                {
                    Console.WriteLine("\nSelected Recipe:");
                    recipes[recipeNumber - 1].DisplayRecipe(1);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid input. Please enter a valid recipe number.");
                    Console.ResetColor();
                }
            }
        }


        //Clear recipe method to remove the recipe from the list
        public static void DeleteRecipe(List<Recipe> recipes, Recipe recipeToDelete)

        {

            if (recipes.Contains(recipeToDelete))

            {

                recipes.Remove(recipeToDelete);

                Console.WriteLine($"Recipe '{recipeToDelete.Name}' has been deleted.\n");

            }

            else

            {

                Console.WriteLine($"Recipe '{recipeToDelete.Name}' not found.\n");

            }

        }


        public static void ClearSpecificRecipe()

        {

            if (recipes.Count == 0)

            {

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("\nNo recipes added yet. Please add a recipe first.");

                Console.ResetColor();

            }

            else

            {

                Console.WriteLine("\nSelect a recipe to clear:");

                for (int i = 0; i < recipes.Count; i++)

                {

                    Console.WriteLine($"{i + 1}. {recipes[i].Name}");

                }



                Console.WriteLine("\nEnter the number of the recipe:");

                if (int.TryParse(Console.ReadLine(), out int recipeNumber) && recipeNumber > 0 && recipeNumber <= recipes.Count)

                {

                    Recipe recipeToDelete = recipes[recipeNumber - 1];

                    DeleteRecipe(recipes, recipeToDelete);

                }

                else

                {

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("\nInvalid input. Please enter a valid recipe number.");

                    Console.ResetColor();

                }

            }

        }




        static void ScaleRecipe()
        {
            if (recipes.Count == 0 || recipes[^1] == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo recipe added yet. Please add a recipe first.");
                Console.ResetColor();
            }
            else
            {
                double scale;
                while (true)
                {
                    Console.WriteLine("Enter scaling factor (0.5, 2, or 3):");
                    if (double.TryParse(Console.ReadLine(), out scale) && (scale == 0.5 || scale == 2 || scale == 3))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid scaling factor. Please enter 0.5, 2, or 3.");
                    }
                }

                recipes[^1].DisplayRecipe(scale);
            }
        }

        static void ResetQuantities()
        {
            if (recipes.Count == 0 || recipes[^1] == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo recipe added yet. Please add a recipe first.");
                Console.ResetColor();
            }
            else
            {
                recipes[^1].ResetQuantities();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nQuantities reset successfully.");
                Console.ResetColor();
            }
        }

        static void ClearRecipe()
        {
            recipes.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAll recipes cleared successfully.");
            Console.ResetColor();
        }


        private static FoodGroup GetFoodGroup(string prompt)
        {
            // Dictionary to map numbers to food groups
            Dictionary<int, FoodGroup> foodGroupMap = new Dictionary<int, FoodGroup>
    {
        { 1, FoodGroup.CARBOHYDRATE },
        { 2, FoodGroup.PROTEIN },
        { 3, FoodGroup.FAT },
        { 4, FoodGroup.FRUIT },
        { 5, FoodGroup.VEGETABLE },
        { 6, FoodGroup.DAIRY }
    };

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Trim();

                // Check if input is a number and within valid range
                if (int.TryParse(input, out int number) && foodGroupMap.ContainsKey(number))
                {
                    return foodGroupMap[number];
                }
                // Check if input matches an enum name
                else if (Enum.TryParse<FoodGroup>(input, true, out FoodGroup foodGroup) &&
                         Enum.IsDefined(typeof(FoodGroup), foodGroup))
                {
                    return foodGroup;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Food Group. Valid options are:");
                    Console.ResetColor();

                    // Display the options
                    foreach (var kvp in foodGroupMap)
                    {
                        Console.WriteLine($"{kvp.Key}. {kvp.Value}");
                    }
                }
            }
        }


            //method to validate double user input
            public static double GetDoubleInput()
        {//GetDoubleInput begin
            while (true)
            {//while loop begin
             //try-catch for validation
                try
                {//try begin
                    return double.Parse(Console.ReadLine());
                }//try end
                catch (FormatException)
                {//catch begin
                 //Display error message and reprompt user
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.ResetColor();
                }//catch end
            }//while loop end
        }//GetDoubleInput en




    }

}

/*  Code attribution
 *  The follwing code was taken from StackOverFlow:
 *  Link : https://stackoverflow.com/questions/2552501/switch-statement-in-c-sharp
 *  switch (x)
{
   case 1:
     //do something
     break;
   case 2..8:
     //do something else
     break;
   default:
     break;
}


    The follwing code was taken from StackOverFlow:
 *  Link : https://stackoverflow.com/questions/14973642/how-using-try-catch-for-exception-handling-is-best-practice
 *  try
{
    //do something
}
    catch
{
    //Do nothing
} 
 *  
 *  The follwing code was taken from StackOverFlow:
 *  Link : The follwing code was taken from StackOverFlow: 
 *  https://stackoverflow.com/questions/14973642/how-using-try-catch-for-exception-handling-is-best-practice
 * 
 *   for (i=0 ; i<=10; i++)
{
    ..
    ..
}

    i=0;
    while(i<=10)
    {
        ..
        ..
        i++;
    }
    END
 */ 