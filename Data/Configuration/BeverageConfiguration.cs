using Domain.BeverageAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class BeverageConfiguration : IEntityTypeConfiguration<Beverage>
    {
        public void Configure(EntityTypeBuilder<Beverage> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Code).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UpdatedAt).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(128);
            builder.Property(p => p.AchoolPercentage).IsRequired();
        }
    }
}
