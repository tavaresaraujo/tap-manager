using Domain.AccountAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Code).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UpdatedAt).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(128);

            builder.HasOne(p => p.Merchant).WithMany().HasForeignKey(p => p.MerchantId);
            builder.HasOne(p => p.Address).WithMany().HasForeignKey(p => p.AddressId);
            builder.HasOne(p => p.Phone).WithMany().HasForeignKey(p => p.PhoneId);
        }
    }
}
