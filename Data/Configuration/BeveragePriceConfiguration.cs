using Domain.BeverageAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class BeveragePriceConfiguration : IEntityTypeConfiguration<BeveragePrice>
    {
        public void Configure(EntityTypeBuilder<BeveragePrice> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Code).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UpdatedAt).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.Amount).IsRequired();

            builder.HasOne(p => p.Beverage).WithMany().HasForeignKey(p => p.BeverageId);
        }
    }
}