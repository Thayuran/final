using Entities.Identity;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User, UserRole, string>
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleAssignmentConfiguration());


            
            modelBuilder.Entity<Device>()
           .HasOne(d => d.Category)
           .WithMany(c => c.Devices)
           .HasForeignKey(d => d.CategoryId);

            modelBuilder.Entity<Device>()
                .HasOne(d => d.Brand)
                .WithMany(b => b.Devices)
                .HasForeignKey(d => d.BrandId);

            modelBuilder.Entity<Device>()
                .HasOne(d => d.Supplier)
                .WithMany(s => s.Devices)
                .HasForeignKey(d => d.SupplierId);

            modelBuilder.Entity<Device>()
               .HasOne<Cartitem>()
               .WithOne(s => s.Product);

            modelBuilder.Entity<Sales>()
        .ToTable("Sales");

            modelBuilder.Entity<Cartitem>()
        .ToTable("CartItems");

        }


        public DbSet<Device> Devices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Report> Reports { get; set; }

        public DbSet<Cartitem> CartItems { get; set; }
    }
}
