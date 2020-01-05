using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeSite.Models;
using RecipeSite.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSite.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IRecipeRepository repository;
        private ICuisineRepository cRepository;
        private ApplicationDbContext context;

        public AdminController(IRecipeRepository repo, ICuisineRepository cRepo, ApplicationDbContext ctx)
        {
            repository = repo;
            cRepository = cRepo;
            context = ctx;
        }

        public ViewResult Index()
        {
            List<Cuisine> cuisineList = new List<Cuisine>();
            cuisineList = context.Cuisines.ToList();

            RecipeAndCuisineViewModel RACV = new RecipeAndCuisineViewModel();
            RACV.AddRecipes = repository.AddRecipes;
            RACV.Cuisines = cRepository.Cuisines;
            return View(RACV);
        }
        public ViewResult Edit(int recipeId)
        {
            List<Cuisine> cuisineList = new List<Cuisine>();
            cuisineList = context.Cuisines.ToList();
            ViewBag.listofitems = cuisineList;

            return View(repository.AddRecipes.FirstOrDefault(r => r.RecipeID == recipeId));
        }

        [HttpPost]
        public IActionResult Edit(AddRecipe addRecipe, Cuisine cuisine)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRecipe(addRecipe, cuisine);
                TempData["message"] = $"{addRecipe.Name} Recipe has been saved!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(addRecipe);
            }
        }

        public ViewResult Create()
        {
            List<Cuisine> cuisineList = new List<Cuisine>();
            cuisineList = context.Cuisines.ToList();
            ViewBag.listofitems = cuisineList;

            return View("Edit", new AddRecipe());
        }

        [HttpPost]
        public IActionResult Delete(int recipeId)
        {
            AddRecipe deletedRecipe = repository.DeleteRecipe(recipeId);

            if(deletedRecipe != null)
            {
                TempData["message"] = $"{deletedRecipe.Name} was deleted!";
            }
            return RedirectToAction(nameof(Index));
        }

        public ViewResult EditCuisine(int cuisineId) => View(cRepository.Cuisines.FirstOrDefault(c => c.CuisineID == cuisineId));

        [HttpPost]
        public IActionResult EditCuisine(Cuisine cuisine)
        {
            if (ModelState.IsValid)
            {
                cRepository.SaveCuisine(cuisine);
                TempData["message"] = $"{cuisine.CuisineType} Cuisine has been saved!";
                return RedirectToAction(nameof(CuisineIndex));
            }
            else
            {
                return View(cuisine);
            }
        }

        public IActionResult DeleteCuisine(int cuisineId)
        {
            Cuisine deletedCuisine = cRepository.DeleteCuisine(cuisineId);

            if (deletedCuisine != null)
            {
                TempData["message"] = $"{deletedCuisine.CuisineType} was deleted!";
            }
            return RedirectToAction(nameof(CuisineIndex));
        }
        public ViewResult CreateCuisine() => View("EditCuisine", new Cuisine());

        public ViewResult CuisineIndex() => View(cRepository.Cuisines);
    }
}
