using Domain.TapAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class TapConfiguration : IEntityTypeConfiguration<Tap>
    {
        public void Configure(EntityTypeBuilder<Tap> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Code).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UpdatedAt).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(128);
            builder.Property(p => p.TargetUrl).IsRequired();

            builder.HasOne(p => p.BeveragePrice).WithMany().HasForeignKey(p => p.BeveragePriceId);
        }
    }
}
