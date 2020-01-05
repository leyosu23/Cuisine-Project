using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSite.Models
{
    public class FakeRecipeRepository /*: IRecipeRepository */
    {
        public IQueryable<AddRecipe> AddRecipes => new List<AddRecipe>
        {
            //new AddRecipe
            //{ Name= "Test1" ,
            //TypeOfCuisine= "Test1",
            //DifficultyLevel = "Hard",
            //CookingTimeInMin = 30,
            //IngredientList = "Test1",
            //Description = "Test1"},
            //new AddRecipe
            //{ Name= "Test2" ,
            //TypeOfCuisine= "Test2",
            //DifficultyLevel = "Easy",
            //CookingTimeInMin = 15,
            //IngredientList = "Test2",
            //Description = "Test2"},
            //new AddRecipe
            //{ Name= "Test3" ,
            //TypeOfCuisine= "Test3",
            //DifficultyLevel = "Hard",
            //CookingTimeInMin = 30,
            //IngredientList = "Test3",
            //Description = "Test3"}
        }.AsQueryable<AddRecipe>();
    }
}
