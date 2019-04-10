using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Models
{
    public class DishsContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public DishsContext(DbContextOptions options) : base(options) { }
        public DbSet<Dish> Dishes { get; set; }
    }
}