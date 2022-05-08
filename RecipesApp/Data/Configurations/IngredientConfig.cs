using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipesApp.Models;

namespace RecipesApp.Data.Configurations
{
    public class IngredientConfig : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(t => new {t.ProductId, t.RecipeId});

            builder.Property(i => i.Amount)
                .HasColumnType("float(10,2)")
                .HasDefaultValue(1);

            builder.Property(i => i.Necessary)
                .HasDefaultValue(true);
        }
    }
}
