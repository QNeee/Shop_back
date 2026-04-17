
using Shop_back.Core.Models.Product;
using Shop_back.Core.Models.Product.ProductVariant;
using Shop_back.DataAccess.Entities.Product;
using Shop_back.DataAccess.Entities.Product.ProductVariant;

namespace Shop_back.DataAccess.Repositories.Product
{
    public class ProductReposityoryHelper
    {
        private static ProductVariantModel MakeProductVariantModel(ProductVariantEntity pVe)
        {
            var productVariantModel = new ProductVariantModel
            {
                StorageGb = pVe.StorageGb,
                MemoryGb = pVe.MemoryGb,
                Price = pVe.Price,
                Stock = pVe.Stock,
                DiscountPercent = pVe.DiscountPercent,
                DiscountExpiresAt = pVe.DiscountExpiresAt
            };
            productVariantModel.SetId(pVe.ProductVariantId);
            return productVariantModel;
        }
        public static void UpdateVariant(ProductVariantEntity entity, ProductVariantModel model)
        {
            entity.StorageGb = model.StorageGb;
            entity.MemoryGb = model.MemoryGb;
            entity.Stock = model.Stock;
            entity.Price = model.Price;
            entity.DiscountPercent = model.DiscountPercent;
            entity.DiscountExpiresAt = model.DiscountExpiresAt;
        }
        public static ProductVariantEntity MakeProductVariantEntity (ProductVariantModel pVm)
        {
            return new ProductVariantEntity
            {
                ProductVariantId = pVm.ProductVariantId,
                StorageGb = pVm.StorageGb,
                MemoryGb = pVm.MemoryGb,
                Price = pVm.Price,
                Stock = pVm.Stock,
                DiscountPercent = pVm.DiscountPercent,
                DiscountExpiresAt = pVm.DiscountExpiresAt
            };
        }
        public static ProductModel MakeProductModel(Guid productId, int categoryId, string productName, ProductOptions options, ICollection<ProductVariantEntity> pVe, ICollection<ProductImageEntity> pIe)
        {
            return new ProductModel
            {
                ProductId = productId,
                CategoryId = categoryId,
                ProductName = productName,
                Options = options,
                Variants = pVe.Select(v => MakeProductVariantModel(v)).ToList(),
                Images = pIe.ToDictionary(im => im.Color, im => im.Urls)
            };
        }
    }
}
