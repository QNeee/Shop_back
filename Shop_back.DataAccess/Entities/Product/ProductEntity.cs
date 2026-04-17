
using Shop_back.DataAccess.Entities.Category;
using Shop_back.DataAccess.Entities.Product.ProductVariant;
using Shop_back.Core.Models.Product;
namespace Shop_back.DataAccess.Entities.Product
{
    public class ProductEntity : ProductEntityBase
    {
        public ICollection<ProductVariantEntity> Variants { get; set; } = new List<ProductVariantEntity>();
        public ICollection<ProductImageEntity> Images { get; set; } = new List<ProductImageEntity>();
        public CategoryEntity Category { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}
