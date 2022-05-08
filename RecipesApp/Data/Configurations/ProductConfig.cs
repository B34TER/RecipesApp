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
                .IsRequired();

            builder.HasOne(p => p.Unit)
                .WithMany(u => u.Products)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(p => p.FoodGroup)
                .WithMany(f => f.Products)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Property(p => p.Owned)
                .HasDefaultValue(false);

            builder.Property(p => p.Amount)
                .HasColumnType("float(10,2)");

            builder.Property(p => p.Protein)
                .HasColumnType("float(10,2)");

            builder.Property(p => p.Carbohydrates)
                .HasColumnType("float(10,2)");

            builder.Property(p => p.Fat)
                .HasColumnType("float(10,2)");
        }
    }
}
