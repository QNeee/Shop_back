
using Shop_back.Core.Models.Product;

namespace Shop_back.Core.Abstractions.Product
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetAllProducts();
        Task<List<ProductModel>> GetProducts(string filter);
        Task<Guid> CreateProduct(ProductModel product);
        Task<ProductModel?> GetProductById(Guid id);
        Task<Guid> DeleteProduct(Guid id);
        Task<Guid> UpdateProductImages(Guid id, Dictionary<string, string[]> smartImages);
        Task<Guid> UpdateProductOptions(Guid id, Dictionary<string, string> options);
        Task<Guid> UpdateProductMainInfo(Guid id, string title, string desc);
        Task<Guid> UpdateProductVariants(Guid id, List<ProductModelVariant> variants);
    }
}
