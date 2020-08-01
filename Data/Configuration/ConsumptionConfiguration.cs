using Domain.BeverageAggregate.Entities;
using Domain.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class ConsumptionConfiguration : IEntityTypeConfiguration<Consumption>
    {
        public void Configure(EntityTypeBuilder<Consumption> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Code).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UpdatedAt).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.Volume).IsRequired();

            builder.HasOne(ci => ci.BeveragePrice).WithMany().HasForeignKey(ci => ci.BeveragePriceId);
            builder.HasOne(ci => ci.User).WithMany().HasForeignKey(ci => ci.UserId);
        }
    }
}
