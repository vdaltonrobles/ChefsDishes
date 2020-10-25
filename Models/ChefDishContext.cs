using Microsoft.EntityFrameworkCore;

namespace ChefsDishes.Models
{
    public class ChefDishContext : DbContext
    {
        public ChefDishContext(DbContextOptions options) : base(options) { }
        public DbSet<Chef> Chefs {get;set;}
        public DbSet<Dish> Dishes {get;set;}
    }
}
