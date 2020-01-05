using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace RecipeSite.Models
{
    public static class SeedData
    {
        private static Cuisine American;
        private static Cuisine Italian;
        private static Cuisine French;
        private static Cuisine Chinese;
        private static Cuisine Korean;
        
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
        
            context.Database.Migrate();
        
            context.Cuisines.AddRange(
                American = new Cuisine
                {
                    CuisineType = "American"
                },
                Italian = new Cuisine
                {
                    CuisineType = "Italian"
                },
                French = new Cuisine
                {
                    CuisineType = "French"
                },
                Chinese = new Cuisine
                {
                    CuisineType = "Chinese"
                },
                Korean = new Cuisine
                {
                    CuisineType = "Korean"
                }
            );
            
            if (!context.AddRecipes.Any())
            {
                context.AddRecipes.AddRange(
                    new AddRecipe
                    {
                        Name = "Test1",
                        DifficultyLevel = "Hard",
                        CookingTimeInMin = 30,
                        IngredientList = "Test1",
                        Description = "Test1",
                        Cuisine = Korean
                    },
                    new AddRecipe
                    {
                        Name = "Test2",
                        DifficultyLevel = "Easy",
                        CookingTimeInMin = 15,
                        IngredientList = "Test2",
                        Description = "Test2",
                        Cuisine = Italian
                    },
                    new AddRecipe
                    {
                        Name = "Test3",
                        DifficultyLevel = "Hard",
                        CookingTimeInMin = 30,
                        IngredientList = "Test3",
                        Description = "Test3",
                        Cuisine = French
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
