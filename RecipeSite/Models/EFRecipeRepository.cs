using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSite.Models
{
    public class EFRecipeRepository : IRecipeRepository
    {
        private ApplicationDbContext context;

        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<AddRecipe> AddRecipes => context.AddRecipes;

        public IQueryable<Cuisine> Cuisines => context.Cuisines;

        public void SaveRecipe(AddRecipe addRecipe, Cuisine cuisine)
        {
            List<Cuisine> cuisineList = new List<Cuisine>();
            cuisineList = context.Cuisines.ToList();

            foreach (var item in cuisineList)
            {
                if (cuisine.CuisineType.Equals(item.CuisineType))
                {
                    addRecipe.Cuisine = cuisineList.Find(c => c.CuisineType == item.CuisineType);
                }
            }

            if (addRecipe.RecipeID == 0)
            {
                context.AddRecipes.Add(addRecipe);
            }
            else
            {
                AddRecipe recipeEntry = context.AddRecipes
                    .FirstOrDefault(r => r.RecipeID == addRecipe.RecipeID);

                Cuisine cuisineEntry = context.Cuisines
                    .FirstOrDefault(c => c.CuisineID == cuisine.CuisineID);

                if (recipeEntry != null)
                {
                    recipeEntry.Name = addRecipe.Name;
                    recipeEntry.Cuisine = addRecipe.Cuisine;
                    recipeEntry.DifficultyLevel = addRecipe.DifficultyLevel;
                    recipeEntry.CookingTimeInMin = addRecipe.CookingTimeInMin;
                    recipeEntry.IngredientList = addRecipe.IngredientList;
                    recipeEntry.Description = addRecipe.Description;
                }
                if(cuisineEntry != null)
                {
                    cuisineEntry.CuisineType = cuisine.CuisineType;
                }
            }
            context.SaveChanges();
        }

        public AddRecipe DeleteRecipe(int recipeId)
        {
            AddRecipe recipeEntry = context.AddRecipes
                .FirstOrDefault(r => r.RecipeID == recipeId);

            if (recipeEntry != null)
            {
                context.AddRecipes.Remove(recipeEntry);
                context.SaveChanges();
            }

            return recipeEntry;
        }
    }
}
