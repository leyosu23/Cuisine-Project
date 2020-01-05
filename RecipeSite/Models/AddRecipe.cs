using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeSite.Models
{
    public class AddRecipe
    {
        [Key]
        public int RecipeID { get; set; }        

        [Required(ErrorMessage = "Please Enter the name of Recipe.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Define Level of Difficulty")]
        public string DifficultyLevel { get; set; }

        [Required(ErrorMessage = "Please Enter the Cooking Time in Minute")]
        public int CookingTimeInMin { get; set; }

        [Required(ErrorMessage = "Please Enter the Ingredient List")]
        public string IngredientList { get; set; }

        [Required(ErrorMessage = "Please Enter the Description")]
        public string Description { get; set; }

        public Cuisine Cuisine { get; set; }
    }
}
