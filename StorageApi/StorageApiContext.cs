using Microsoft.EntityFrameworkCore;
using StorageApi.Models;

public class StorageApiContext : DbContext
{
    public StorageApiContext(DbContextOptions<StorageApiContext> options)
    : base(options)
    {
    }
    public DbSet<StorageApi.Models.Product> Products { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasData(
            new Product(1, "Hammer", 10, "Tools", "A1", 5, "Wooden handle."),
            new Product(2, "Screwdriver", 5, "Tools", "A2", 10, "The one with the flat head."),
            new Product(3, "Wrench", 15, "Tools", "A3", 7, "The one with the adjustable jaw."),
            new Product(4, "Saw", 5, "Tools", "A2", 10, "The one with the thoots."));
    }
}
