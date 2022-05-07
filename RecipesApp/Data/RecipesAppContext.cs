using Microsoft.EntityFrameworkCore;
using RecipesApp.Models;

namespace RecipesApp.Data
{
    public class RecipesAppContext : DbContext
    {
        public RecipesAppContext(DbContextOptions<RecipesAppContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipesAppContext).Assembly);
        }

        public DbSet<Appliance> Appliances { get; set; }
        public DbSet<FoodGroup> FoodGroups { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeAppliance> RecipeAppliance { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}
