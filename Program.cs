
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

namespace ST10343093
    {
        internal class Program
        {
            static void Main(string[] args)
            {
            Console.WriteLine("Welcome to your recipe App");

            Recipe recipe = null;
            bool exitApp = false;

            while (!exitApp)
            {
                Console.WriteLine("\nRecipe App Menu:");
                Console.WriteLine("1. Add a new recipe");
                Console.WriteLine("2. Display current recipe");
                Console.WriteLine("3. Scale the recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear the recipe");
                Console.WriteLine("6. Exit");

                Console.WriteLine("\nEnter your choice (1-6):");
                string choice = Console.ReadLine();

                switch (choice) //Switch case for the different options
                {
                    case "1":
                        recipe = AddRecipe(recipe);
                        break;
                    case "2":
                        if (recipe != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nCurrent Recipe:");
                            recipe.DisplayRecipe(1);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nNo recipe added yet. Please add a recipe first.");
                            Console.ResetColor();
                        }
                        break;
                    case "3":
                        if (recipe != null)
                        {
                            ScaleRecipe(recipe);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nNo recipe added yet. Please add a recipe first.");
                            Console.ResetColor();
                        }
                        break;
                    case "4":
                        if (recipe != null)
                        {
                            recipe.ResetQuantities();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nQuantities reset successfully.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nNo recipe added yet. Please add a recipe first.");
                            Console.ResetColor();
                        }
                        break;
                    case "5":
                        if (recipe != null)
                        {
                            recipe.ClearRecipe();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nNo recipe added yet. Please add a recipe first.");
                            Console.ResetColor();
                        }
                        break;
                    case "6":
                        exitApp = true;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nExiting Recipe App. Goodbye!");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 6.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        static Recipe AddRecipe(Recipe existingRecipe)
        {
            Recipe newRecipe = new Recipe();

            if (existingRecipe != null && existingRecipe.HasData())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is already a recipe added. Please clear it before adding a new one.");
                Console.ResetColor();
                return existingRecipe; // Return existing recipe without modification
            }

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
            Ingredient[] ingredients = new Ingredient[numIngredients];

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

                ingredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
            }

            newRecipe.AddIngredients(ingredients);

            Console.WriteLine("Enter the number of steps:");
            int numSteps;
            while (!int.TryParse(Console.ReadLine(), out numSteps) || numSteps <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive integer.");
            }
            Step[] steps = new Step[numSteps];

            // Input steps
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

                steps[i] = new Step { Description = description };
            }

            newRecipe.Steps = steps;

            Console.WriteLine("Recipe added successfully.");
            return newRecipe;
        }

        static void ScaleRecipe(Recipe recipe)
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

            recipe.DisplayRecipe(scale);
        }
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
