using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ChefsDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }
        
        [Required(ErrorMessage="First Name is required!")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage="Last Name is required!")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage="Date of Birth is required!")]
        [DateOfBirth(MinAge = 18, MaxAge = 150, ErrorMessage="Chef must be 18 years old or older.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public int Age {get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }    
        }
        public List<Dish> CreatedDishes { get; set; }

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

    }
    public class DateOfBirthAttribute : ValidationAttribute
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            var val = (DateTime)value;

            if (val.AddYears(MinAge) > DateTime.Now)
                return false;
            return (val.AddYears(MaxAge) > DateTime.Now);
        }
    }
}
