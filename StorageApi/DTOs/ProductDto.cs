using System.ComponentModel.DataAnnotations;

namespace StorageApi.DTOs
{
    public class ProductDto
    {
        public ProductDto()
        {
        }

        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
        public decimal Price { get; set; } = 0;
        [Required]
        public required string Category { get; set; }
        public required string Shelf { get; set; }
        public int Count { get; set; }
        [MaxLength(250)]
        public required string Description { get; set; }
        public decimal InventoryValue => Price * Count;

    }
}
