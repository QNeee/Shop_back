
using Shop_back.Core.Models.Product;
using Shop_back.Core.Models.Product.ProductCatalog;
using Shop_back.Core.Models.Product.ProductShares;
using Shop_back.Core.Models.Product.ProductVariant;

namespace Shop_back.Core.Abstractions.Product
{
    public interface IProductService
    {
        Task<List<ProductCatalogModel>> GetAllCatalogProducts(int? categoryId);
        Task<List<ProductCatalogModel>> GetAllBasketProducts(List<Guid> ids);
        Task<List<ProductSharesModel>> GetAllSharesProducts(int? categoryId);
        Task<Guid> CreateProduct(ProductModel product);
        Task<Guid> DeleteProduct(Guid id);
        Task<Guid> UpdateProductImages(Guid id, Dictionary<string, string[]> smartImages);
        Task<Guid> UpdateProductOptions(Guid id, ProductOptions options);
        Task<Guid> UpdateProductMainInfo(Guid id, string productName, int categoryId);
        Task<Guid> UpdateProductVariants(Guid id, List<ProductVariantModel> variants);
        Task<Guid> UpdateProductVariant(Guid id, ProductVariantModel variant, Guid variantId);
        Task<bool> GetProductVariantExists(Guid productId,Guid variantId);
        Task<bool> GetCategoryExists(int categoryId);
    }
}
