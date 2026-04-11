
using Shop_back.Core.Abstractions.Product;
using Shop_back.Core.Models.Product;

namespace Shop_back.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Guid> CreateProduct(ProductModel product)
        {
            return _productRepository.Create(product);
        }

        public async Task<Guid> DeleteProduct(Guid id)
        {
            return await _productRepository.Delete(id);
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            return await _productRepository.Get();
        }

        public async Task<ProductModel?> GetProductById(Guid id)
        {
            return await _productRepository.GetById(id);
        }


        public async Task<Guid> UpdateSmartImages(Guid id, Dictionary<string, string[]> SmartImages)
        {
            return  await _productRepository.UpdateSmartImages(id, SmartImages);
        }

        public async Task<Guid> UpdateSmartMainInfo(Guid id, string title, string desc)
        {
            return await _productRepository.UpdateMainInfo(id, title, desc);
        }

        public async Task<Guid> UpdateSmartVariants(Guid id, List<ProductModelVariant> variants)
        {
            return await _productRepository.UpdateVariants(id, variants);
        }
    }
}
