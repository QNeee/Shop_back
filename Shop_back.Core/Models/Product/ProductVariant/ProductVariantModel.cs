

namespace Shop_back.Core.Models.Product.ProductVariant
{
    public class ProductVariantModel
    {
        public Guid ProductVariantId { get; private set; }

        public int StorageGb { get; set; }

        public int MemoryGb { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public decimal? DiscountPercent { get; set; }

        public DateTime? DiscountExpiresAt { get; set; }
        public void SetId(Guid id) => ProductVariantId = id;
    }
}
