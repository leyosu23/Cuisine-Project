using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSite.Models
{
    public class Repository
    {
        private static List<AddRecipe> recipes = new List<AddRecipe>();

        public static IEnumerable<AddRecipe> Recipes
        {
            get
            {
                return recipes;
            }
        }
        public AddRecipe FindRecipe(int id)
        {

            return recipes.Find(recipe => recipe.RecipeID == id);
        }
       
        public void AddRecipes(AddRecipe addRecipe)
        {
            recipes.Add(addRecipe);
        }

        //public AddRecipe Update(AddRecipe updateRecipe)
        //{
        //    int index = recipes.FindIndex(recipe => recipe.RecipeID == updateRecipe.RecipeID);
        //    recipes[index] = updateRecipe;
        //    return recipes[index];
        //}
    }
}
