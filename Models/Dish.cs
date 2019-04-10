using System.ComponentModel.DataAnnotations;
using System;

namespace CRUDelicious.Models
{
  
        public class Dish
        {
            // auto-implemented properties need to match the columns in your table
            // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
            [Key]
            public int DishId { get; set; }
        // MySQL VARCHAR and TEXT types can be represeted by a string
            [Required(ErrorMessage = "ChefName is required")]
            [MinLength(4)]
            [Display(Name = "Chef's Name:")]
            public string ChefName { get; set; }
            [Required(ErrorMessage = "Dish Name is required")]
            // [MinLength(4)]
            [Display(Name = "Name of Dish:")]
            public string DishName { get; set; }
            [Display(Name = "Description:")]  
            public string Description { get; set; }
            [Required(ErrorMessage = "Calories is required")]
            [Display(Name = "Calories:")]
            [Range(1,5000)]
            public int Calories { get; set; }
            [Required(ErrorMessage = "Tastiness is required")]
            [Display(Name = "Tastiness:")]
            [Range(1, 5)]
            public int Tasiness { get; set; }
            // The MySQL DATETIME type can be represented by a DateTime

            public DateTime CreatedAt { get; set; } = DateTime.Now;
            public DateTime UpdatedAt { get; set; } = DateTime.Now;
        }
    
}