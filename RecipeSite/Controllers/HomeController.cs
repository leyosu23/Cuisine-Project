using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecipeSite.Models;
using RecipeSite.Models.ViewModels;

namespace RecipeSite.Controllers
{
    public class HomeController : Controller
    {
        private IRecipeRepository repository1;
        private ICuisineRepository cRepository;
        private Repository repository = new Repository();
        private ApplicationDbContext context;
        private RecipeAndCuisineViewModel RACV = new RecipeAndCuisineViewModel();

        public HomeController(IRecipeRepository repo, ApplicationDbContext ctx, ICuisineRepository repo1)
        {
            repository1 = repo;
            cRepository = repo1;
            context = ctx;
        }

        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }

        public ViewResult RecipeList()
        {
            List<Cuisine> cuisineList = new List<Cuisine>();
            cuisineList = context.Cuisines.ToList();

            RACV.AddRecipes = repository1.AddRecipes;
            RACV.Cuisines = cRepository.Cuisines;
            return View(RACV);
        }

        public IActionResult AddRecipe()
        {
            List<Cuisine> cuisineList = new List<Cuisine>();
            cuisineList = context.Cuisines.ToList();
            ViewBag.listofitems = cuisineList;

            return View();
        }

        [HttpPost]
        public ViewResult AddRecipe(AddRecipe addRecipe, Cuisine cuisine)
        {
            if(ModelState.IsValid)
            {
                repository1.SaveRecipe(addRecipe, cuisine);
                return View("Thanks", addRecipe);
            }
            else
            {
                return View();
            }
        }

        public IActionResult ViewRecipe(int id)
        {
            List<Cuisine> cuisineList = new List<Cuisine>();
            cuisineList = context.Cuisines.ToList();
            ViewBag.listofitems = cuisineList;

            return View(repository1.AddRecipes.FirstOrDefault(r => r.RecipeID == id));
        }

        public ViewResult ReviewRecipe(int id)
        {
            return View(repository.FindRecipe(id));
        }

        public ViewResult EditCuisine(int cuisineId) => View(cRepository.Cuisines.FirstOrDefault(c => c.CuisineID == cuisineId));

        [HttpPost]
        public IActionResult EditCuisine(Cuisine cuisine)
        {
            if (ModelState.IsValid)
            {
                cRepository.SaveCuisine(cuisine);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(cuisine);
            }
        }

        public ViewResult CreateCuisine() => View("EditCuisine", new Cuisine());
    }
}
