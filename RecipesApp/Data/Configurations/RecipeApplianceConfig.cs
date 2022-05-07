using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipesApp.Models;

namespace RecipesApp.Data.Configurations
{
    public class RecipeApplianceConfig : IEntityTypeConfiguration<RecipeAppliance>
    {
        public void Configure(EntityTypeBuilder<RecipeAppliance> builder)
        {
            builder.HasKey(ra => new {ra.RecipeId, ra.ApplianceId});

            builder.Property(ra => ra.Necessary)
                .HasDefaultValue(true);
        }
    }
}
