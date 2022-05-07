using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipesApp.Models;

namespace RecipesApp.Data.Configurations
{
    public class FoodGroupConfig : IEntityTypeConfiguration<FoodGroup>
    {
        public void Configure(EntityTypeBuilder<FoodGroup> builder)
        {
            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(f => f.PlantBased)
                .HasDefaultValue(false);
        }
    }
}
