using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10343093
{
    internal class Recipe
    {
        public string Name { get; set; }
        private Ingredient[] initialIngredients; // Store initial quantities

        public Ingredient[] Ingredients { get; set; }
        public Step[] Steps { get; set; }

        public bool HasData() // method to hash data
        {
            return Ingredients != null || Steps != null;
        }// to ensure values are not null

        public void DisplayRecipe(double scale)
        {
            Console.WriteLine($"Recipe: {Name}\n");

            if (Ingredients != null)// for null
            {
                Console.WriteLine("Recipe Ingredients:");
                foreach (var ingredient in Ingredients)
                {
                    var scaledQuantity = ingredient.Quantity * scale;
                    Console.WriteLine($"{scaledQuantity} {ingredient.Unit} of {ingredient.Name}");
                }
            }
            else
            {
                Console.WriteLine("No ingredients added yet.");
            }

            if (Steps != null)
            {
                Console.WriteLine("\nRecipe Steps:");
                for (int i = 0; i < Steps.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Steps[i].Description}");
                }
            }
            else
            {
                Console.WriteLine("No steps added yet.");//
            }
        }

        public void AddIngredients(Ingredient[] ingredients)// Add ingrenidtents method
        {
            Ingredients = ingredients;
            initialIngredients = new Ingredient[ingredients.Length];
            Array.Copy(ingredients, initialIngredients, ingredients.Length); // Copy initial quantities
        }

        public void ResetQuantities() //reset quantities methods
        {
            if (initialIngredients != null)
            {
                for (int i = 0; i < Ingredients.Length; i++)
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



        public void ClearRecipe()// clear recipe methods
        {
            if (HasData())
            {
                Console.WriteLine("Are you sure you want to clear the recipe? (yes/no)");
                string confirmation = Console.ReadLine()?.Trim().ToLower(); // Ensure not null

                if (confirmation == "yes")
                {
                    Ingredients = null;
                    Steps = null;
                    initialIngredients = new Ingredient[0]; // Initialize with an empty array
                    Console.WriteLine("Recipe added successfully.");// confirmation message if added sucessfully

                }
                else if (confirmation == "no")
                {
                    Console.WriteLine("Clear operation canceled.");

                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                    ClearRecipe(); // Prompt again until valid input is provided
                }
            }
            else
            {
                Console.WriteLine("No recipe added yet. Please add a recipe first.");
            }
        }








    }
}
