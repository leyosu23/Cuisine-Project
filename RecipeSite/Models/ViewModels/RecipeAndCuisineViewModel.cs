using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSite.Models.ViewModels
{
    public class RecipeAndCuisineViewModel
    {
        public IEnumerable<AddRecipe> AddRecipes { get; set; }
        public IEnumerable<Cuisine> Cuisines { get; set; }

        public Cuisine Cuisine { get; set; }
        public AddRecipe AddRecipe { get; set; }
    }
}
