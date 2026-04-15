
using Shop_back.Core.Models.Product;

namespace Shop_back.Core.Abstractions.Product
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> Get();
        Task<List<ProductModel>> GetByFilter(string filter);
        Task<Guid> Create(ProductModel product);

        Task<ProductModel?> GetById(Guid id);
        Task<Guid> Delete(Guid id);
        Task<Guid> UpdateProductImages(Guid id, Dictionary<string, string[]> smartImages);
        Task<Guid> UpdateProductMainInfo(Guid id, string title, string desc);
        Task<Guid> UpdateProductVariants(Guid id, List<ProductModelVariant> variants);
        Task<Guid> UpdateProductOptions(Guid id, Dictionary<string, string> Options);
    }
}
