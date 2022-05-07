using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipesApp.Models;

namespace RecipesApp.Data.Configurations
{
    public class RecipeConfig : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(r => r.Instruction)
                .IsRequired();

            builder.Property(r => r.Portions)
                .HasDefaultValue(1);
        }
    }
}
