
using Shop_back.Core.Models.Product;
using Shop_back.Core.Models.Product.ProductShares;
using Shop_back.Core.Models.Product.ProductVariant;

namespace Shop_back.Core.Abstractions.Product
{
    public interface IProductRepository
    {
        Task<List<ProductSharesModel>> GetAllSharesProducts(int? categoryId);
        Task<List<ProductModel>> GetAll(int? categoryId);
        Task<Guid> Create(ProductModel product);
        Task<Guid> Delete(Guid id);
        Task<Guid> UpdateProductImages(Guid id, Dictionary<string, string[]> smartImages);
        Task<Guid> UpdateProductMainInfo(Guid id, string productName, int categoryId);
        Task<Guid> UpdateProductVariants(Guid id, List<ProductVariantModel> variants);
        Task<Guid> UpdateProductVariant(Guid id, ProductVariantModel variant, Guid variantId);
        Task<Guid> UpdateProductOptions(Guid id, ProductOptions options);
        Task<bool> GetCategoryExists(int categoryId);
        Task<bool> GetProductVariantExists(Guid productId, Guid variantId);
    }
}
