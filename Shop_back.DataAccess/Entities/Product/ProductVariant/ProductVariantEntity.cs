
namespace Shop_back.DataAccess.Entities.Product.ProductVariant
{
    public class ProductVariantEntity
    {
        public Guid ProductVariantId { get; set; }

        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; } = null!;

        public int StorageGb { get; set; }
        public int MemoryGb { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }
        public decimal? DiscountPercent { get; set; }

        public DateTime? DiscountExpiresAt { get; set; }
    }
}
