using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSite.Models
{
    public class Cuisine
    {
        [Key]
        public int CuisineID { get; set; }

        [Required(ErrorMessage = "Please Enter proper Type of Cuisine")]
        public string CuisineType { get; set; }
    }
}
