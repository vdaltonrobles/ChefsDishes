    using System;
    using System.ComponentModel.DataAnnotations;
    

    namespace ChefsDishes.Models
    {
        public class Dish
        {
            [Key]
            public int DishId { get; set; }
            
            [Required(ErrorMessage="Name of Dish is required.")]
            public string Name { get; set; }
            
            [Required(ErrorMessage="# of Calories is required.")]
            [Range(1,5000, ErrorMessage="Calories must be more than 0.")]
            public int? Calories { get; set; }
            
            [Required(ErrorMessage="Description is required.")]
            public string Description { get; set; }
            
            
            [Required(ErrorMessage="Tastiness is required.")]
            [Range(1,5, ErrorMessage="Tastiness must be between 1 and 5.")]
            public int? Tastiness { get; set; }
            
            public int ChefId { get; set; }
            public Chef Creator { get; set; }
            
            public DateTime CreatedAt {get;set;} = DateTime.Now;
            public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}
