using Domain.AddressAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Code).IsRequired().HasMaxLength(36);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(128);
            builder.Property(p => p.Number).IsRequired().HasMaxLength(16);
            builder.Property(p => p.State).IsRequired().HasMaxLength(2);
            builder.Property(p => p.Street).IsRequired().HasMaxLength(64);
            builder.Property(p => p.City).IsRequired().HasMaxLength(64);
            builder.Property(p => p.Zip).IsRequired().HasMaxLength(64);
            builder.Property(p => p.Neighborhood).IsRequired().HasMaxLength(64);
            builder.Property(p => p.Complement).HasMaxLength(64);
            builder.Property(p => p.Country).IsRequired().HasMaxLength(2);
            builder.Property(p => p.UpdatedAt).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.Zip).IsRequired().HasMaxLength(16);

            //HasRequired(p => p.Customer).WithMany().HasForeignKey(p => p.CustomerId);
        }
    }
}