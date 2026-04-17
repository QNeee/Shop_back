using Shop_back.Core.Models.Product.ProductVariant;

namespace Shop_back.Core.Models.Product
{
    public class ProductModel
    {
        public Guid ProductId { get; set; }

        public int CategoryId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public List<ProductVariantModel> Variants { get; set; } = new();
        public ProductOptions Options { get; set; } = new();
        public Dictionary<string, string[]> Images { get; set; } = new();

        private readonly DateTime CreatedAt  = DateTime.UtcNow;

        private DateTime UpdatedAt { get; set; }  = DateTime.UtcNow;

    }

}
