using Data.Configuration;
using Domain.AccountAggregate.Entities;
using Domain.AddressAggregate.Entities;
using Domain.BeverageAggregate.Entities;
using Domain.MerchantAggregate.Entities;
using Domain.PhoneAggregate.Entities;
using Domain.TapAggregate.Entities;
using Domain.TransactionAggregate.Entities;
using Domain.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Account> Account { get; set; }

        public DbSet<AccountBeverage> AccountBeverage { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Beverage> Beverage { get; set; }

        public DbSet<BeveragePrice> BeveragePrice { get; set; }

        public DbSet<Consumption> Consumption { get; set; }

        public DbSet<Supply> Supply { get; set; }

        public DbSet<Merchant> Merchant { get; set; }

        public DbSet<Phone> Phone { get; set; }

        public DbSet<Tap> Tap { get; set; }

        public DbSet<Credit> Credit { get; set; }

        public DbSet<Transaction> Transaction { get; set; }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new AccountConfiguration())
                .ApplyConfiguration(new AccountBeverageConfiguration())
                .ApplyConfiguration(new AddressConfiguration())
                .ApplyConfiguration(new BeverageConfiguration())
                .ApplyConfiguration(new BeveragePriceConfiguration())
                .ApplyConfiguration(new ConsumptionConfiguration())
                .ApplyConfiguration(new SupplyConfiguration())
                .ApplyConfiguration(new MerchantConfiguration())
                .ApplyConfiguration(new PhoneConfiguration())
                .ApplyConfiguration(new TapConfiguration())
                .ApplyConfiguration(new CreditConfiguration())
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new TransactionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}