using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipesApp.Models;

namespace RecipesApp.Data.Configurations
{
    public class UnitConfig : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.Property(u => u.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(u => u.Shortcut)
                .HasMaxLength(5)
                .IsRequired();
        }
    }
}
