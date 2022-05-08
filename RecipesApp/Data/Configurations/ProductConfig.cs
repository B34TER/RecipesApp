using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipesApp.Models;

namespace RecipesApp.Data.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(p => p.Unit)
                .WithMany(u => u.Products)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(p => p.FoodGroup)
                .WithMany(f => f.Products)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Property(p => p.Owned)
                .HasDefaultValue(false);
        }
    }
}
