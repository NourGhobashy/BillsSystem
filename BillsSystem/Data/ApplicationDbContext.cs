using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BillsSystem.Models;

namespace BillsSystem.MVC.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // DbSet for your models
        public DbSet<Company> Companies { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Payment> Payments { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // لا تنسَ هذه

            modelBuilder.Entity<BillItem>()
                .Property(b => b.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.Property(b => b.Total).HasPrecision(18, 2);
                entity.Property(b => b.Discount).HasPrecision(18, 2);
                entity.Property(b => b.NetAmount).HasPrecision(18, 2);
                entity.Property(b => b.AmountPaid).HasPrecision(18, 2);
                entity.Property(b => b.RemainingAmount).HasPrecision(18, 2);
            });
        }
    }
}
