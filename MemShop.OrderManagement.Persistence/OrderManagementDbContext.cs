using MemShop.OrderManagement.Domain;
using MemShop.OrderManagement.Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;

namespace MemShop.OrderManagement.Persistence
{
    public class OrderManagementDbContext : DbContext
    {
        public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderManagementDbContext).Assembly);

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                FirstName = "John",
                LastName = "LEGRAND",
                Email = "john.legrand@gmail.com",
                Adresse = "46 Rue de la paie",
                ZipCode = 75116,
                CustomerType = CustomerType.Basic
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                FirstName = "Emmanuel",
                LastName = "LEPETIT",
                Email = "emmanuel.lepetit@gmail.com",
                Adresse = "1 Rue de la liberté",
                ZipCode = 75115,
                CustomerType = CustomerType.Silver
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
                FirstName = "Marc",
                LastName = "THAUVIN",
                Email = "marc.thauvin@gmail.com",
                Adresse = "2 Rue de l'indépendance",
                ZipCode = 75114,
                CustomerType = CustomerType.Premium
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                FirstName = "Thomas",
                LastName = "DUPONT",
                Email = "thomas.dupont@gmail.com",
                Adresse = "14 Rue de l'armée",
                ZipCode = 75110,
                CustomerType = CustomerType.Premium
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = Guid.Parse("{1BABD057-E980-4CB3-9CD2-7FDD9E525668}"),
                FirstName = "François",
                LastName = "LE MAIRE",
                Email = "françois.lemaire@gmail.com",
                Adresse = "3 Rue de la république",
                ZipCode = 75109,
                CustomerType = CustomerType.Basic
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = Guid.Parse("{ADC42C09-08C1-4D2C-9F96-2D15BB1AF299}"),
                FirstName = "Gaetan",
                LastName = "BOILET",
                Email = "gaetan.fort@gmail.com",
                Adresse = "1 Rue Colbert",
                ZipCode = 75108,
                CustomerType = CustomerType.Silver
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}