

namespace Shop_back.Core.Models.Product.ProductShares
{
    public class ProductSharesModel
    {
        public Guid ProductId { get; set; }
        public Guid ProductVariantId { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Dictionary<string, string[]> Images { get; set; } = new();
        public int CategoryId { get; set; } 
        public DateTime ? DiscountExpiresIn { get; set; }
        public decimal ? DiscountPercentage { get; set; }
        public int Stock { get; set; }

    }
}
