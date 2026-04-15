
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

        public async Task<List<ProductModel>> GetProducts(string filter)
        {
            return await _productRepository.GetByFilter(filter);
        }


        public async Task<Guid> UpdateProductImages(Guid id, Dictionary<string, string[]> SmartImages)
        {
            return  await _productRepository.UpdateProductImages(id, SmartImages);
        }

        public async Task<Guid> UpdateProductMainInfo(Guid id, string title, string desc)
        {
            return await _productRepository.UpdateProductMainInfo(id, title, desc);
        }

        public async Task<Guid> UpdateProductOptions(Guid id, Dictionary<string, string> options)
        {
            return await _productRepository.UpdateProductOptions(id, options);
        }

        public async Task<Guid> UpdateProductVariants(Guid id, List<ProductModelVariant> variants)
        {
            return await _productRepository.UpdateProductVariants(id, variants);
        }
    }
}
