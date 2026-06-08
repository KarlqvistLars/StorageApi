using Microsoft.EntityFrameworkCore;
using StorageApi.Models;

namespace StorageApi.DbContext
{
    public class ProductContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Product>()
                .HasData(
                new Product(1, "Hammer", 10, "Tools", "A1", 5, "Wooden handle."),
                new Product(2, "Screwdriver", 5, "Tools", "A2", 10, "The one with the flat head."),
                new Product(3, "Wrench", 15, "Tools", "A3", 7, "The one with the adjustable jaw."));
        }
    }
}
