namespace StorageApi.DTOs
{
    public class ProductStatsDto
    {
        public ProductStatsDto()
        {
        }
        public int TotalProducts { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal TotalValue { get; set; }

        public Dictionary<string, int>? CategoryCounts { get; set; }
    }
}
