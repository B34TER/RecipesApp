using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipesApp.Models;

namespace RecipesApp.Data.Configurations
{
    public class ApplianceConfig : IEntityTypeConfiguration<Appliance>
    {
        public void Configure(EntityTypeBuilder<Appliance> builder)
        {
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Owned)
                .HasDefaultValue(false);
        }
    }
}
