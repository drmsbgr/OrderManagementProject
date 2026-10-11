using Microsoft.EntityFrameworkCore;
using OrderManagement.Core.Models;

namespace OrderManagement.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(c =>
        {
            c.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Order>(o =>
        {
            o.HasKey(e => e.Id);

            o.HasOne(e => e.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(e => e.CustomerId);

            o.HasMany(e => e.Products)
                .WithMany(p => p.Orders);
        });

        modelBuilder.Entity<Product>(b =>
        {
            b.HasKey(p => p.Id);
        });
    }
}
