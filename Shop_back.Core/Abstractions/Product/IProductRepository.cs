
using Shop_back.Core.Models.Product;

namespace Shop_back.Core.Abstractions.Product
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> Get();
        Task<Guid> Create(ProductModel product);
        Task<ProductModel?> GetById(Guid id);
        Task<Guid> Delete(Guid id);
        Task<Guid> UpdateSmartImages(Guid id, Dictionary<string, string[]> smartImages);
        Task<Guid> UpdateMainInfo(Guid id, string title, string desc);
        Task<Guid> UpdateVariants(Guid id, List<ProductModelVariant> variants);
    }
}
