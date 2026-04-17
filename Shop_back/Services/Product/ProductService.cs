
using Shop_back.Core.Abstractions.Product;
using Shop_back.Core.Models.Product;
using Shop_back.Core.Models.Product.ProductShares;
using Shop_back.Core.Models.Product.ProductVariant;

namespace Shop_back.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> GetCategoryExists(int categoryId)
        {
           return await  _productRepository.GetCategoryExists(categoryId);
        }

        public async Task<Guid> CreateProduct(ProductModel product)
        {
            return await _productRepository.Create(product);
        }

        public async Task<Guid> DeleteProduct(Guid id)
        {
            return await _productRepository.Delete(id);
        }

        public async Task<List<ProductModel>> GetAllProducts(int? categoryId)
        {
            return await _productRepository.GetAll(categoryId);
        }



        public async Task<Guid> UpdateProductImages(Guid id, Dictionary<string, string[]> images)
        {
            return await _productRepository.UpdateProductImages(id, images);
        }

        public async Task<Guid> UpdateProductMainInfo(Guid id, string productName, int categoryId)
        {
            return await _productRepository.UpdateProductMainInfo(id, productName, categoryId);
        }

        public async Task<Guid> UpdateProductOptions(Guid id, ProductOptions options)
        {
            return await _productRepository.UpdateProductOptions(id, options);
        }

        public async Task<Guid> UpdateProductVariants(Guid id, List<ProductVariantModel> variants)
        {
            return await _productRepository.UpdateProductVariants(id, variants);
        }

        public async Task<Guid> UpdateProductVariant(Guid productId, ProductVariantModel variant,Guid variantId)
        {
            return await _productRepository.UpdateProductVariant(productId, variant, variantId);
        }

        public async Task<bool> GetProductVariantExists(Guid productId,Guid variantId)
        {
            return await _productRepository.GetProductVariantExists(productId, variantId);
        }

        public async Task<List<ProductSharesModel>> GetAllSharesProducts(int? categoryId)
        {
            return await _productRepository.GetAllSharesProducts(categoryId);
        }
    }
}
