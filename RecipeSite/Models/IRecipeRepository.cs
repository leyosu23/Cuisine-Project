using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSite.Models
{
    public interface IRecipeRepository
    {
        IQueryable<AddRecipe> AddRecipes { get; }

        IQueryable<Cuisine> Cuisines { get; }

        void SaveRecipe(AddRecipe addRecipe, Cuisine cuisine);

        AddRecipe DeleteRecipe(int recipeId);
    }
}
