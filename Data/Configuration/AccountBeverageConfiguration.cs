using Domain.AccountAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class AccountBeverageConfiguration : IEntityTypeConfiguration<AccountBeverage>
    {
        public void Configure(EntityTypeBuilder<AccountBeverage> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Code).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UpdatedAt).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();

            builder.HasOne(p => p.BeveragePrice).WithMany().HasForeignKey(p => p.BeveragePriceId);
        }
    }
}  