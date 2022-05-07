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
                .IsRequired();

            builder.Property(u => u.Shortcut)
                .IsRequired();
        }
    }
}
