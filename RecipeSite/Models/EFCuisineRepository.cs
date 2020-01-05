using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSite.Models
{
    public class EFCuisineRepository : ICuisineRepository
    {
        private ApplicationDbContext context;

        public EFCuisineRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Cuisine> Cuisines => context.Cuisines;

        public void SaveCuisine(Cuisine cuisine)
        {
            if (cuisine.CuisineID == 0)
            {
                context.Cuisines.Add(cuisine);
            }
            else
            {
                Cuisine cuisineEntry = context.Cuisines
                    .FirstOrDefault(c => c.CuisineID == cuisine.CuisineID);
                if (cuisineEntry != null)
                {
                    cuisineEntry.CuisineType = cuisine.CuisineType;
                }
            }
            context.SaveChanges();
        }

        public Cuisine DeleteCuisine(int cuisineId)
        {
            Cuisine cuisineEntry = context.Cuisines
                .FirstOrDefault(c => c.CuisineID == cuisineId);
            if (cuisineEntry != null)
            {
                context.Cuisines.Remove(cuisineEntry);
                context.SaveChanges();
            }
            return cuisineEntry;
        }
    }
}
