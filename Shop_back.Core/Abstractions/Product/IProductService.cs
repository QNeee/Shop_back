
using Shop_back.Core.Models.Product;

namespace Shop_back.Core.Abstractions.Product
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetAllProducts();
        Task<Guid> CreateProduct(ProductModel product);
        Task<ProductModel?> GetProductById(Guid id);
        Task<Guid> DeleteProduct(Guid id);
        Task<Guid> UpdateSmartImages(Guid id, Dictionary<string, string[]> SmartImages);
        Task<Guid> UpdateSmartMainInfo(Guid id, string title, string desc);
        Task<Guid> UpdateSmartVariants(Guid id, List<ProductModelVariant> variants);
    }
}
