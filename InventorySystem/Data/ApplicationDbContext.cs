using Microsoft.EntityFrameworkCore;
using InventorySystem.Models.Entities;

namespace InventorySystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SupplierProduct> SupplierProducts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SupplierProduct>()
                .HasKey(sp => new { sp.SupplierID, sp.ProductID });

            modelBuilder.Entity<SupplierProduct>()
                .HasOne(sp => sp.Supplier)
                .WithMany(s => s.ProductLinks)
                .HasForeignKey(sp => sp.SupplierID);

            modelBuilder.Entity<SupplierProduct>()
                .HasOne(sp => sp.Product)
                .WithMany(p => p.SupplierLinks)
                .HasForeignKey(sp => sp.ProductID);
        }
    }
}